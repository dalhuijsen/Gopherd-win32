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


namespace Gopherd
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

   
}



//try
//{
//    //blocks until client sends something
//    ;
//}
//catch
//{
//    //socket error!!
//    break;
//}
//if (bytesRead == 0)
//{
//    //client disconnect
//    break;
//}
//else
//{

//    //string gophermap = System.Configuration.ConfigurationSettings.AppSettings.Get("GopherMap");
//    string gophermap = ConfigurationManager.AppSettings.Get("GopherMap");
//    int buffersize = 20;
//    byte[] outbuffer = new byte[buffersize];

//    if (File.Exists(gophermap))
//    {
//        dbg("gopher exists");
//        //StreamReader streamReader = new StreamReader(filePath);
//        using (StreamReader mapContents = new StreamReader(gophermap))
//        {
//            byte[] largemem = encoder.GetBytes(mapContents.ReadToEnd());
//            clientStream.Write(largemem, 0, largemem.Length);
//            clientStream.Flush();

//        }
//        //mapContents.CopyTo(clientStream);
//        //clientStream.Flush();
//        ////while ((outline = mapContents.ReadLine()) != null)
//        ////{
//        ////    clientStream.Write(outline.ToCharArray(),0,outline.
//        ////}
//        break;
//    }
//    else
//    {
//        // write some outputs
//        byte[] hcbuffer = encoder.GetBytes(".NET Gopherd v1.0.0a");
//        clientStream.Write(hcbuffer, 0, hcbuffer.Length);
//        clientStream.Flush();
//        break;
//    }
//}
