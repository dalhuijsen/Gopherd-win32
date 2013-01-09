using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gopherc
{
    public class GopherURL
    {
        //CHAR+LABEL{TEXT}\\tSELECTOR{URI}\\tSERVER\\tPORT\\t
        public const int DefaultPort = 70;
        public const string DefaultFileType = "1";
        public const string DefaultURI = "/";

        public string Protocol { get; set; }
        public string FileType { get; set; }
        public string Text { get; set; }
        public string URI { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public string Extra { get; set; }

        public static GopherURL FromString(string gopherurl)
        {
            //gopherurl = "gopher://127.0.0.1:70/1/dus";
            string[] urlparts = gopherurl.Split('/');
            if (urlparts.Length < 3)
            {
                throw new ArgumentOutOfRangeException("gopherurl less than 3");
            }
            string proto = urlparts[0].Substring(0,(urlparts[0].Length-1));
            string srv = urlparts[2];
            int prt = DefaultPort;
            string ft = DefaultFileType;
            string uri = DefaultURI;

            if (srv.Contains(':')) {
                string[] subparts = srv.Split(':');
                srv = subparts[0];
                prt = Convert.ToInt16(subparts[1]); 
            }

            if ( urlparts.Length >= 4 && !String.IsNullOrEmpty(urlparts[3])) {
                ft = urlparts[3];
            }

            if (urlparts.Length >= 5 && !String.IsNullOrEmpty(urlparts[4]))
            {
                uri = urlparts[4];
            }

            return new GopherURL()
            {
                Protocol = proto,
                Server = srv,
                Port = prt,
                FileType = ft,
                URI = uri,
                Text = gopherurl
            }; 

        }

        internal string AsRequestString()
        {
            return "";
            //throw new NotImplementedException();
        }
        internal string AsGopherMap()
        {
            return String.Format("{0}{1}\t{2}\t{3}\t{4}\t{5}",FileType,Text,URI,Server,Port,Extra);
        }
        internal static object FromGopherMapString(string line)
        {
            // line = "1kak   /   127.0.0.1   70 "

            string ft = line.Substring(0, 1);
            line = line.Substring(1);
            string[] parts = line.Split('\t');
            string gopherurl = parts[0];
            string uri = parts[1];
            string srv = parts[2];
            string prt = parts[3];
            string proto = "gopher"; //default
            switch (ft)
            {
                case "8":
                    proto = "telnet";
                    uri = "";
                    break;
            }


            return new GopherURL()
            {
                Protocol = proto,
                Server = srv,
                Port = Convert.ToInt16(prt),
                FileType = ft,
                URI = uri,
                Text = gopherurl
            }; 

            //return new GopherURL() { Protocol = "gopher", Server = "127.0.0.1", Port = 70, FileType = "1", URI = "/", Text = "kak", Raw = "1kak   /   127.0.0.1   70" };
            //throw new NotImplementedException();
        }

        public string Raw { get; set; }
    }
}
