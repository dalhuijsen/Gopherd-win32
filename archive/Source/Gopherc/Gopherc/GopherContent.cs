using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Gopherc
{
    class GopherContent
    {
        public string Text { get; set; }
        public static GopherURL GopherURI { get; set; }
        public override string ToString()
        {
            return Text;
            //return base.ToString();
        }
        internal static GopherContent GetURI(GopherURL gurl)
        {
            GopherProtocol gopherProtocol = new GopherProtocol(GopherURI = gurl);
            return new GopherContent() { Text = gopherProtocol.GetData() };
            
        }


        internal string AsHTML()
        {
            if (Text == null) { return ""; }
            string header = "<!DOCTYPE html><html><head><title>" + 
                    WebUtility.HtmlEncode(GopherURI.Server) + 
                "</title></head><body style=\"font-family:fixed;font-size:13px;white-space:pre;\"><tt>";
            StringBuilder rv = new StringBuilder(header);
            using (StringReader stringReader = new StringReader(Text))
            {
                string line;
                while ((line = stringReader.ReadLine()) != null)
                {
                    if (isGopherLine(line))
                    {
                        rv.AppendFormat("{0}\n", GopherURLToHTML(line));
                    }
                    else
                    {
                        rv.AppendFormat("{0}\n", WebUtility.HtmlEncode(line));
                    }
                    }
                return rv.ToString();
            }
        }

        private string GopherURLToHTML(string line)
        {
            switch (line.Substring(0, 1))
                {
                    case "3":
                        return "ERROR: " + line.Substring(1);
                    case "i":
                        return "" + line.Substring(1);
                    default:
                        return GopherMapToHref(GopherURL.FromGopherMapString(line));
                }
        }

        private string GopherMapToHref(object p)
        {
            GopherURL gopherURL = (GopherURL) p;
            
            return String.Format("<li class=\"{2}\"><a href=\"{0}\" title=\"{1}\" class=\"{2}\">{3}</a></li>",
                gopherURL.Protocol + "://" + gopherURL.Server + ":" + gopherURL.Port.ToString() + 
                    ( String.IsNullOrEmpty(gopherURL.URI) ? "" :  "/" + gopherURL.FileType + "" + gopherURL.URI ),
                WebUtility.HtmlEncode(gopherURL.Raw),
                gopherURL.Protocol,
                WebUtility.HtmlEncode(gopherURL.Text));
        }




        private bool isGopherLine(string line)
        {
            return (!String.IsNullOrEmpty(line) &&
                 (line.Substring(0, 1).Equals("i") ||
                     Regex.Match(line, "^([^\t])([^\t]+)\t([^\t]+)\t([^\t]+)(\t([^\t]+))?").Success)
                 );
        }
    }
}
