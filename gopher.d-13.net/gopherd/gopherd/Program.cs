using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gopherd
{

    public static class Program
    {

        public static int listenPort { get; set; } // port to listen on 
        public static string listenAddress { get; set; }  // optional hostname

        [Serializable]
        static class _settings
        {
            public static bool ipv6 = true;
            private const string progname = "gopherd";
            private const string version = "1.0.18";
        }

        public static event ServerNotifyHandler OnConnectionStarted;

        static void Main(string[] args)
        {
            //grab the port and address from the command line or set it to default
            listenPort = args.Count() >= 1 ? int.Parse(args[0]) : 70;
            listenAddress = args.Count() >= 2 ? args[2].Trim() : Dns.GetHostName();
            List<Thread> threadPool = new List<Thread>();
            foreach (IPAddress ip in Dns.GetHostEntry(listenAddress).AddressList.Where( (IPAddress p) => ipMatchesSettings(p) ) )
            {

                Server server = new Server(new IPEndPoint(ip,listenPort));
                ServerDecorator(ref server);
                var bgt = new Thread(server.Start);
                bgt.Start();
                //server.Start();
            }

            Console.ReadLine();
         
            //ThreadedServer ts = new ThreadedServer(listen); ts.Start(); Console.ReadLine();


        }

        private static void ServerDecorator(ref Server server)
        {
            server.OnServerNotify += server_OnServerNotify;
            server.OnProtocolNotify += (object sender, ConnectionEventArgs e) => Console.WriteLine(sender.ToString() + e.Message);
            server.OnServerNotify += (object sender, ConnectionEventArgs e) => Console.WriteLine(sender.ToString() + e.Message);
        }

        static void server_OnServerNotify(object sender, ConnectionEventArgs e)
        {
           // throw new NotImplementedException();
        }

        private static bool ipMatchesSettings(IPAddress p)
        {
            return true;
            return (_settings.ipv6 && p.AddressFamily == AddressFamily.InterNetworkV6);
        }

    }


     class ProtocolInstance
    {
        public Socket Socket;
        public Thread Thread;
    }





    class Server
    {
        public event ServerNotifyHandler OnServerNotify;
        public event ProtocolNotifyHandler OnProtocolNotify;
     

        private Socket _serverSocket;
        [Flags]
        public enum ServerState : byte
        {
            INIT = 0x00,
            STARTING = 0x01,
            STARTED = 0x02,
            STOPPING = 0x04,
            STOPPED = 0x08,
            HALTED = 0x10,
        };
        private IPEndPoint _listen;

        public Server(IPEndPoint listen)
        {
            _listen = listen;
        }

        private Thread _acceptThread;
        private List<ProtocolInstance> _connections = new List<ProtocolInstance>();
        public void Start()
        {
            SetupServerSocket();
            _acceptThread = new Thread(AcceptConnections);
            _acceptThread.IsBackground = true;
            _acceptThread.Start();
        }
        private void SetupServerSocket()
        { // Resolving local machine information 
            Console.WriteLine(@"Listening on: " + _listen.ToString());
            //IPEndPoint myEndpoint = new IPEndPoint(localMachineInfo.AddressList[0], _port);
            // Create the socket, bind it, and start listening 
            _serverSocket = new Socket(_listen.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(_listen);
            _serverSocket.Listen((int)SocketOptionName.MaxConnections);
        }
        private void AcceptConnections()
        {
            while (true)
            {
                OnServerNotify(this, new ConnectionEventArgs() { Message = "accept" });
                // Accept a connection 
                Socket socket = _serverSocket.Accept();
                ProtocolInstance connection = new ProtocolInstance();
                connection.Socket = socket;
                // Create the thread for the receives. 
                connection.Thread = new Thread(ProcessConnection);
                connection.Thread.IsBackground = true;
                connection.Thread.Start(connection); // Store the socket 
                lock (_connections)
                    _connections.Add(connection);
            }
        }
        private void ProcessConnection(object state)
        {
            ProtocolInstance connection = (ProtocolInstance)state;
            byte[] buffer = new byte[255];
            try
            {
                while (true)
                {
                    int bytesRead = connection.Socket.Receive(buffer);
                    if (bytesRead > 0)
                    {
                        lock (_connections)
                        {
                            foreach (ProtocolInstance conn in _connections)
                            {
                                if (conn != connection)
                                {
                                    conn.Socket.Send(buffer, bytesRead, SocketFlags.None);
                                }
                            }
                        }
                    }
                    else if (bytesRead == 0)
                        return;
                }
            }
            catch (SocketException exc)
            {
                Console.WriteLine("Socket exception: " + exc.SocketErrorCode);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc);
            }
            finally
            {
                connection.Socket.Close();
                lock (_connections)
                    _connections.Remove(connection);
            }
        }
    }


    public delegate void ServerNotifyHandler(object sender, ConnectionEventArgs e);
    public delegate void ProtocolNotifyHandler(object sender, ConnectionEventArgs e);



    public class ConnectionEventArgs : EventArgs
    {
        public object Message { get; set; }
    }


}
