using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Server
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        public void save_file()
        {
            File.Delete("IPList.txt");
            if (!File.Exists("IPList.txt"))
            {
                StreamWriter Writer = new StreamWriter("IPList.txt");
                for (int i = 0; i < ipContainer.Items.Count; i++)
                {
                    Writer.WriteLine(ipContainer.Items[i].ToString());
                }
                Writer.Close();
                Writer.Dispose();
            }
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            if (File.Exists("IPList.txt"))
            {
                StreamReader Reader = new StreamReader("IPList.txt");
                string temp = Reader.ReadLine();
                while (temp != null)
                {
                    ipContainer.Items.Add(temp);
                    temp = Reader.ReadLine();
                }
                Reader.Close();
                Reader.Dispose();
            } 
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (newAddressBox.Text != "")
            {
                ipContainer.Items.Add(newAddressBox.Text);
                newAddressBox.Text = "";
            }
            save_file();
        }
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ipContainer.SelectedIndex != -1)
            {
                ipContainer.Items.RemoveAt(ipContainer.SelectedIndex);
            }
            save_file();
        }
        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_file();
            this.Close();
        }
        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ipContainer.SelectedIndex != -1)
            {
                newAddressBox.Text = ipContainer.Items[ipContainer.SelectedIndex].ToString();
                ipContainer.Items.RemoveAt(ipContainer.SelectedIndex);
            }
        }
        private void newAddressBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                добавитьToolStripMenuItem_Click(sender, e);
            }
        }

       

      
    }
}
