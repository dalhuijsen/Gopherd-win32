using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Configuration;
using Microsoft.Win32; //needed for mimeinfo, maybe im better off using /etc/mime.types?

namespace Gopherd
{
    public class Server
    {
        /* Settings */
        public string ServerRoot { get; set; }
        public string ServerName { get; set; }
        public string ServerPort { get; set; }

        public string DirectoryIndex { get; set; }
        public int ClientTimeout { get; set; } //FIXME: have background thread kill the connection if request > timeout
        public bool Debugging { get; set; }
        public bool Indexes { get; set; }
        public bool FancyIndexes { get; set; }
        public bool Logging { get; set; }
        private bool Listen { get; set; }
        /* Globals */
        private TcpListener tcpListener;
        private Thread listenThread;
        private string ClientRequest { get; set; }
        //private NotifyIcon SysTrayIcon { get; set; }
        private NetworkStream clientStream { get; set; }
        private ASCIIEncoding encoder { get; set; }
        private TcpClient client {get; set; }
        private Thread clientThread {get; set;}

        public Server()
        {
            //System.IO.Path.GetFullPath
            dbg("Server()");
            /* grab settings from config */
            ServerRoot = Properties.Settings.Default.DocumentRoot;
            ServerName = Properties.Settings.Default.ServerName;
            ServerPort = Properties.Settings.Default.Port;
            FancyIndexes = Properties.Settings.Default.FancyIndexes;
            DirectoryIndex = Properties.Settings.Default.DirectoryIndex;

            if (SanityTest())
            {
                StartServer();
            }
            else
            {
                dbg("SERVER MALCONFIGURED, EXITING");
            }
        }

        public void StartServer()
        {
            Listen = true;
            encoder = new ASCIIEncoding();
            tcpListener = new TcpListener(IPAddress.Any, Convert.ToInt16(ServerPort));
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        public void StopServer()
        {
            Listen = false;
            if (clientThread != null) clientThread.Abort();
            //listenThread.Abort();
            tcpListener.Stop();
        }

        public static Server newServer()
        {
            return new Server();
        }
 

        private bool SanityTest()
        {
            /* Check if all settings are valid for this computer or vomit errors when something is amis */
            return true;
        }
        private void ListenForClients()
        {
            dbg("ListenForClients()");
            tcpListener.Start();
            while (Listen)
            {
                //blocks until client is connected
                try
                {
                    client = this.tcpListener.AcceptTcpClient();
                    clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                }
                catch
                {
                    //stopping serv?
                }

            }
        }
        private void HandleClientComm(object client)
        {
            dbg("HandleClientComm");
            TcpClient tcpClient = (TcpClient)client;
            clientStream = tcpClient.GetStream();
            StringBuilder request = new StringBuilder();
            byte[] message = new byte[2048];
            int bytesRead;
            
            while ((bytesRead = clientStream.Read(message, 0, 2048)) != 0)
            {
                string input = encoder.GetString(message, 0, bytesRead);
                request.Append(input);
                Match match = Regex.Match(input, @"(\n|\r)");
                if (match.Success)
                {
                    dbg("NEWLINE!: " + request.ToString());
                    ClientRequest = request.ToString();
                    break;
                }
                log(tcpClient.Client.RemoteEndPoint.ToString() + " " + ClientRequest + Environment.NewLine);
                dbg("Client sent:" + encoder.GetString(message, 0, bytesRead) + ".");


            }
            ClientRequest = ClientRequest.Replace("\n", "");
            ClientRequest = ClientRequest.Replace("\r", "");
            if (String.IsNullOrEmpty(ClientRequest))
            {
                ClientRequest = @"";
            }
            ClientRequest = ClientRequest.Replace("/", "\\");
            if (isValidQuery(ClientRequest))
            {
                string fullpath = ServerRoot + ClientRequest;
                if (Directory.Exists(fullpath))
                {
                    dbg("Request is a directory: " + ClientRequest);
                    ListDirectoryToClient(fullpath);
                }
                else if (File.Exists((fullpath)))
                {
                    dbg("Request is a file: " + ClientRequest); WriteFileToClient(fullpath);
                }
                else
                {
                    dbg("Request was not found: " + ClientRequest);
                    ShowErrorMessage("404 File Not found: " + ClientRequest.Replace("\\", "/") + " ");
                }
            }
            else
            {
                ShowErrorMessage("Bad Programmer, No cookie");

            }

            tcpClient.Close();
        }

        private void ListDirectoryToClient(string fullpath)
        {
            StringBuilder dirlisting = new StringBuilder("");
            string reldir = fullpath.Substring(ServerRoot.Length);
            string shortpath = "";
            string typedef = "1";
            //FIXME: refactor this maybe, starts to get long
            if (FancyIndexes)
                dirlisting.Append("iContents of " + reldir.Replace("\\", "/") + Environment.NewLine);

            if (!String.IsNullOrEmpty(DirectoryIndex) && File.Exists(fullpath + @"\" + DirectoryIndex))
            {
                WriteFileToClient(fullpath + @"\" + DirectoryIndex);
                return;
            }
            try
            {
                foreach (string dirname in Directory.GetDirectories(fullpath))
                {
                    shortpath = System.IO.Path.GetFileName(dirname); //FIXME: add relative path to uri
                    dirlisting.Append(String.Format("{0}{1}\t{2}/{1}\t{3}\t{4}{5}", typedef, shortpath, reldir.Replace(@"\", "/"), ServerName, ServerPort, Environment.NewLine));
                }

                foreach (string filename in Directory.GetFiles(fullpath))
                {
                    typedef = GopherTypeFromPath(filename);
                    shortpath = System.IO.Path.GetFileName(filename); //FIXME: add relative path to uri
                    dirlisting.Append(String.Format("{0}{1}\t{2}/{1}\t{3}\t{4}{5}", typedef, shortpath, reldir.Replace(@"\", "/"), ServerName, ServerPort, Environment.NewLine));
                }
            }
            catch (Exception e)
            {
                ShowErrorMessage("FILE ACCESS DENIED ON CHILD, EXITING");
            }
            WriteStringToClient(dirlisting.ToString());
        }


        /* since .net 4.0 still hasn't really understood mimetypes: */
        private string GopherTypeFromPath(string fullpath)
        {
            if (System.IO.Path.GetFileName(fullpath).ToLowerInvariant() == "gophermap") return "1";
            string ext = System.IO.Path.GetExtension(fullpath).ToLowerInvariant();
            switch (ext)
            {
                /* custom */
                case ".gophermap":
                    return "1";
                /* image/* */
                case ".ico":
                case ".jpg":
                case ".bmp":
                case ".jpeg":
                case ".gif":
                case ".swf":
                case ".ppt":
                case ".png":
                    return "I";
                /* text/* */
                case ".txt":
                case ".html":
                case ".log":
                case ".xml":
                case ".htm":
                case ".ini":
                case ".inf":
                    return "0";
                /* application/octet-stream */
                default:
                    return "9";
            }
            //FIXME: Framework 4.5 has MimeMapping which supposedly will be faster
            //until then, above fakeness will have to do :(
            //string mimetype = "application/octet-stream"; //default

        }



        /* prettify an error message: */
        private void ShowErrorMessage(string msg)
        {
            WriteStringToClient("3 /* *********************************************************************** " + Environment.NewLine);
            WriteStringToClient("3  * ERROR: " + msg + Environment.NewLine);
            WriteStringToClient("3  * ***********************************************************************/ " + Environment.NewLine);
        }

        /* stuff that writes to the client */
        private void WriteStringToClient(string msg)
        {
            dbg("Writing string to client:" + Environment.NewLine + msg + Environment.NewLine);
            byte[] hcbuffer = encoder.GetBytes(msg);
            clientStream.Write(hcbuffer, 0, hcbuffer.Length);
            clientStream.Flush();
        }
        private void WriteFileToClient(string filepath)
        {
            //StreamReader streamReader = new StreamReader(filePath);
            try
            {
                using (StreamReader RequestFile = new StreamReader(filepath))
                {
                    byte[] largemem = encoder.GetBytes(RequestFile.ReadToEnd()); //FIXME: dont readtoend you git ;-)

                    clientStream.Write(largemem, 0, largemem.Length);
                    clientStream.Flush();

                }
            }
            catch (IOException)
            {
                ShowErrorMessage("ACCESS DENIED");
            }

        }



        #region validation
        /* checks for ../ path vulns: */
        private bool isValidQuery(string ClientRequest)
        {
            string fullpath = ServerRoot + ClientRequest;
            if (File.Exists(fullpath) || Directory.Exists(fullpath))
            {
                string requestpath = System.IO.Path.GetFullPath(fullpath);
                if (
                    requestpath.Length < ServerRoot.Length || // <- path is shorter than root, can't be right
                    !requestpath.Substring(0, ServerRoot.Length).Equals(ServerRoot)) // realpath is not in or under serverroot
                {
                    return false;
                }
            }
            return true;
        }

        #endregion



        //private void showSysTray()
        //{
        //    string iconpath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)+@"\favicon.ico";
        //    if (File.Exists(iconpath))
        //    {
        //        SysTrayIcon.Icon = new System.Drawing.Icon(iconpath);

        //        SysTrayIcon.Visible = true;
        //        SysTrayIcon.Text = "Gopherd";
        //    }/* this currently doesn't work, because windows can't communicate with gopherd (not a winform app)
        //      * the notify icon dissapears on first mouseover */

        //}


        private void dbg(string line)
        {
            if (this.Debugging)
            {
                Console.WriteLine(line);
            }
        }
        private void log(string line)
        {
            if (this.Logging)
            {
                MessageBox.Show(line);
            }
        }
    }
}
