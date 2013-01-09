using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gopherc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Bar_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Bar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
                HandleBarText();
//                MessageBox.Show(Bar.Text);
            }
        }

        private void HandleBarText()
        {
            /* sanity, make sure its a gopherurl */
            if (Bar.Text.Length <= 9 || !Bar.Text.Substring(0, 9).ToLower().Equals("gopher://"))
            {
                Bar.Text = "gopher://" + Bar.Text;
                HandleBarText(); 
                return;
            }

            GopherURL gurl = GopherURL.FromString(Bar.Text);
            GopherContent content = GopherContent.GetURI(gurl);
            Canvas.DocumentText = content.AsHTML();
            
        }
    }
   
}
