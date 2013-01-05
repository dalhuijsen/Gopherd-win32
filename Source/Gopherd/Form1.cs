using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
//using System.Runtime.InteropServices;


namespace Gopherd
{

    public partial class Form1 : Form
    {
        #region workhorses

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    AllocConsole();
        //}

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();

        public Server MyServer { get; set; }
        private void StartBackgroundServer()
        {
            Thread ServerThread = new Thread(StartServer);
            ServerThread.Start();
            isRunning = true;
        }

        public void StartServer()
        {
             MyServer = new Server();

        }

        #endregion

        #region props

        public bool isRunning { get; set; }

        #endregion
        

















        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                MessageBox.Show("Server Thread already started.");
            }
            else
            {
                isRunning = true;
                StartServer();
                SetRunning(true);
            }
        }

        private void SetRunning(bool toggle)
        {
            isRunning = toggle;
            switch (toggle)
            {
                case true:
                    RunningIndicator.Visible = true;
                    RunningIndicator.Text = "running";
                    RunningIndicator.ForeColor = Color.Green;
                    break;
                case false:
                    RunningIndicator.Visible = true;
                    RunningIndicator.Text = "stopped";
                    RunningIndicator.ForeColor = Color.Red;
                    break;
            }
        }
        private void RunningIndicator_Click(object sender, EventArgs e)
        {

        }

        private void RunningIndicator_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
           Properties.Settings.Default.Save();
        }

        private void RunningIndicator_Click_1(object sender, EventArgs e)
        {

        }

        private void Stop_Click(object sender, EventArgs e)
        {
            MyServer.StopServer();
            SetRunning(false);
        }

        private void TSR_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
