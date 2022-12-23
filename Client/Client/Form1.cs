using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 10].Enabled = false;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 7].Enabled = false;
        }
        bool mode = false;
        bool isConnected = false;
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        private string get_ip()
        {
            StreamReader reader = new StreamReader("Settings.txt");
            string IP = reader.ReadLine();
            reader.Dispose(); reader.Close();
            return IP;
        }
        private void FullScr_Click(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 5].Enabled = false;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 4].Enabled = true;
        }
        static Image ScaleImage(Image source, int width, int height)
        {
            Image dest = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.FillRectangle(Brushes.Black, 0, 0, width, height);  // Очищаем экран
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                float srcwidth = source.Width;
                float srcheight = source.Height;
                float dstwidth = width;
                float dstheight = height;
                if (srcwidth <= dstwidth && srcheight <= dstheight)  // Исходное изображение меньше целевого
                {
                    int left = (width - source.Width) / 2;
                    int top = (height - source.Height) / 2;
                    gr.DrawImage(source, left, top, source.Width, source.Height);
                }
                else if (srcwidth / srcheight > dstwidth / dstheight)  // Пропорции исходного изображения более широкие
                {
                    float cy = srcheight / srcwidth * dstwidth;
                    float top = ((float)dstheight - cy) / 2.0f;
                    if (top < 1.0f) top = 0;
                    gr.DrawImage(source, 0, top, dstwidth, cy);
                }
                else  // Пропорции исходного изображения более узкие
                {
                    float cx = srcwidth / srcheight * dstheight;
                    float left = ((float)dstwidth - cx) / 2.0f;
                    if (left < 1.0f) left = 0;
                    gr.DrawImage(source, left, 0, cx, dstheight);
                }
                return dest;
            }
        }
        private void WindScr_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 5].Enabled = true;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 4].Enabled = false;
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
        }
        private void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
            {
                this.panel1.Refresh();
            }
            Bitmap image = (Bitmap)e.UserState;
            Graphics gr = panel1.CreateGraphics();
            try
            {
                Image imgToPanel = ScaleImage(image, panel1.Width, panel1.Height);
                gr.DrawImage(imgToPanel, new Point(0, 0));
            }
            catch (ArgumentException)
            { }
            catch (NullReferenceException)
            { }
        }
        private void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {     
            BackgroundWorker worker = (BackgroundWorker)sender;
            TcpListener listener = new TcpListener(IPAddress.Any, 20000);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream inputStream = client.GetStream();
                long totalBytes = 0;
                int readBytes = 0;
                byte[] buffer = new byte[2048];
                MemoryStream outputStream = new MemoryStream();
                do
                {
                    readBytes = inputStream.Read(buffer, 0, buffer.Length);
                    outputStream.Write(buffer, 0, readBytes);
                    totalBytes += readBytes;
                } while (client.Connected && readBytes > 0);
                Bitmap ScreenShot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                ScreenShot = new Bitmap(outputStream);
                worker.ReportProgress(0, ScreenShot);
                //if (bWorker.CancellationPending)
                //{
                //    listener.Stop();
                //    worker.ReportProgress(100);
                //    return;
                //}
            }
        }
        public static void SendInfo(string inf,string ip, int prt)
        {
            try
            {
                TcpClient client = new TcpClient(ip, prt);
                NetworkStream outputStream = client.GetStream();
                MemoryStream memoryStr = new MemoryStream(ASCIIEncoding.ASCII.GetBytes(inf), 0,
                    ASCIIEncoding.ASCII.GetBytes(inf).Length, true, true);
               
                outputStream.Write(memoryStr.GetBuffer(), 0, memoryStr.GetBuffer().Length);
               
                memoryStr.Close();
            }
            catch (SocketException)
            { return; }
        }
        private void Connect_Click(object sender, EventArgs e)
        {
            string info = "1";
            SendInfo(info, get_ip(), 11000);
            if (File.Exists("client_on.ico"))
            {
                Traybox.Icon = new System.Drawing.Icon("client_on.ico");
            }
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 11].Enabled = false;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 10].Enabled = true;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 2].Enabled = false;
            this.Text = "Удаленный клиент  |  Подключено";
            isConnected = true;
            Traybox.ShowBalloonTip(12500, "Информация", "Клиент - серверная система трансляции содержимого экрана (подключено к серверу)", ToolTipIcon.Info);
            if (!bWorker.IsBusy)
            {
                bWorker.RunWorkerAsync();
            }
        }
        private void Disconnect_Click(object sender, EventArgs e)
        {
            string info = "0";
            SendInfo(info, get_ip(), 11000);
            if (File.Exists("client_off.ico"))
            {
                Traybox.Icon = new System.Drawing.Icon("client_off.ico");
            }
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 11].Enabled = true;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 10].Enabled = false;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 2].Enabled = true;
            bWorker.CancelAsync();
            this.Text = "Удаленный клиент  |  Отключено";
            isConnected = false;
            Traybox.ShowBalloonTip(12500, "Информация", "Клиент - серверная система трансляции содержимого экрана (отключено от сервера)", ToolTipIcon.Info);
            if (bWorker.IsBusy)
            {
                bWorker.CancelAsync();
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void серверToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetServer setserv = new SetServer(); 
            setserv.Show();
        }
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (mode == false)
            {
                FullScr_Click(sender, e);
                mode = true;
            }
            else
            {
                WindScr_Click(sender,e);
                mode = false;
            }
        }
        private void свернутьВТрейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 7].Enabled = true;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 8].Enabled = false;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 5].Enabled = false;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 4].Enabled = false;
            this.Hide();
        }

        private void показатьГлавноеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 7].Enabled = false;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 8].Enabled = true;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 5].Enabled = true;
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 4].Enabled = true;
            this.Show();
        }
        private void Traybox_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                свернутьВТрейToolStripMenuItem_Click(sender, e);
            }
            else
            {
                показатьГлавноеОкноToolStripMenuItem_Click(sender, e);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = DialogResult.Yes;
           result =  MessageBox.Show("Вы действительно хотите завершить работу с программой?", "Завершение работы", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           if (result == DialogResult.No)
           {
               e.Cancel = true;
           }
           else 
           {
               if (isConnected)
               {
                   Disconnect_Click(sender, e);
               }
           }
        }



       

    }
}
