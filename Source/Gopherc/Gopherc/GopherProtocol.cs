using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Gopherc
{
    class GopherProtocol
    {
        private GopherURL gopherURL;

        public GopherProtocol(GopherURL gopherURL)
        {
            // TODO: Complete member initialization
            this.gopherURL = gopherURL;
        }

        internal static string GetData(GopherURL gopherURL)
        {
            return "";
        }
        public string GetData()
        {
            return GetFromServer(gopherURL);

        }
        
   
        internal string GetFromServer(GopherURL gopherURL)
        {
            IPAddress destination = DnsLookup(gopherURL);
            IPEndPoint ipEndPoint = new IPEndPoint( destination, Convert.ToInt16(gopherURL.Port));
            using (Socket socket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    socket.Connect(ipEndPoint);
                }
                catch (SocketException e)
                {
                    return e.Message;
                }

                if (socket.Connected)
                {
                    Byte[] Sent = Encoding.ASCII.GetBytes(gopherURL.AsRequestString());
                    Byte[] Received = new Byte[256];
                    if (socket == null) throw new ArgumentOutOfRangeException();
                    socket.Send(Sent, Sent.Length, 0);
                    int bytes = 0;
                    string page = "";
                    do
                    {
                        bytes = socket.Receive(Received, Received.Length, 0);
                        page += Encoding.ASCII.GetString(Received, 0, bytes);
                    } while (bytes > 0); //run at least once
                    return page;
                }
                else
                {
                    return null;
                }
            }
        }

        private static IPAddress DnsLookup(GopherURL gopherURL)
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(gopherURL.Server);
            foreach (IPAddress testip in hostEntry.AddressList)
            {
                //loop through the addresses until we find one we can connect a socket to
                //only return ipv4 for now... :( FIXME
                if (testip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return testip;
                }
            }
            return null;
        }
    }
}
