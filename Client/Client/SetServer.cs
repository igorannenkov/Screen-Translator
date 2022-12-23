using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Client
{
    public partial class SetServer : Form
    {
        public SetServer()
        {
            InitializeComponent();
        }
        string settings = "";
        public string GetIP()
        {
            StreamReader Reader = new StreamReader("Settings.txt");
            settings = Reader.ReadLine();
            Reader.Close();
            Reader.Dispose();
            return settings;
        }
        public void SetIP(string ip)
        {
            if(File.Exists("Settings.txt"))
            {
                File.Delete("Settings.txt");
            }
            StreamWriter Writer = new StreamWriter("Settings.txt");
            Writer.WriteLine(ip);
            Writer.Close();
            Writer.Dispose();
        }

        private void SaveIP_Click(object sender, EventArgs e)
        {
            SetIP(IP_Container.Text);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
