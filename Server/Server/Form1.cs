using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using ScreenshotCaptureWithMouse.ScreenCapture;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace Server
{
    public partial class Form1 : Form
    {      
        List <string> AddressList = new List<string>();
        public delegate void SendImageD(MemoryStream ms, string ip, int prt);
        SendImageD Handler = SendImage;
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            setIp.Enabled = true;
            TrStop.Enabled = false;
            this.Motion.Checked = false;
            this.panel1.BackColor = Color.Transparent;
        }
        public void SaveAddressList()
        {
            File.Delete("Addresslist.txt");
            if (!File.Exists("Addresslist.txt"))
            {
                StreamWriter Writer = new StreamWriter("Addresslist.txt");
                for (int i = 0; i < AddressList.Count; i++)
                {
                    Writer.WriteLine(AddressList[i].ToString());
                }
                Writer.Close();
                Writer.Dispose();
            }
        }
        public void ReadIP()
        {
            if (File.Exists("Addresslist.txt"))
            {
                StreamReader Reader = new StreamReader("Addresslist.txt");
                string temp = Reader.ReadLine();
                while (temp != null)
                {
                    AddressList.Add(temp);
                    temp = Reader.ReadLine();
                }
                Reader.Close();
                Reader.Dispose();
            }
        }
        public bool ImgReview(Bitmap im1, Bitmap im2)
        {
            byte[] rawDataPic1 = new byte[im1.Width * im1.Height];
            byte[] rawDataPic2 = new byte[im2.Width * im2.Height];
            BitmapData bData1 = im1.LockBits(new Rectangle(0, 0, im1.Width, im1.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
            Marshal.Copy(bData1.Scan0, rawDataPic1, 0, im1.Width * im1.Height);
            im1.UnlockBits(bData1);
            BitmapData bData2 = im2.LockBits(new Rectangle(0, 0, im2.Width, im2.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
            Marshal.Copy(bData2.Scan0, rawDataPic2, 0, im2.Width * im2.Height);
            im2.UnlockBits(bData2);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash1 = md5.ComputeHash(rawDataPic1);
            byte[] hash2 = md5.ComputeHash(rawDataPic2);
            if (hash1.Length != hash2.Length)
            { return false; }
            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i])
                { return false; }
            }
            return true;
        }
        public static void SendImage(MemoryStream ms, string ip, int prt)
        {
            try
            {
                TcpClient client = new TcpClient(ip, prt);
                NetworkStream outputStream = client.GetStream();
                long length = ms.Length;
                byte[] buffer = ms.GetBuffer();
                outputStream.Write(buffer, 0, buffer.Length);
                client.Close();
                Thread.Sleep(125);
            }
            catch (SocketException)
            { Thread.Sleep(125); return; }  
        }
        public static void SendImage(MemoryStream ms,string ip)
        {
            try
            {
                TcpClient client = new TcpClient(ip, 20000); //создаем объект TcpClient и связываем его с помощью конструктора с адресом и портом клиента
                NetworkStream outputStream = client.GetStream(); //создаем сетевой поток данных для передачи содержимого экрана
                long lenght = ms.Length;
                byte[] buffer = ms.GetBuffer(); //организуем поток данных в виде массива байт
                outputStream.Write(buffer, 0, buffer.Length); //пишем данные в поток и отправляем их по сети клиенту
                ms.Close(); //закрываем поток данных
                Thread.Sleep(125);
                client.Close(); //приостанавливаем работу 
            }
            catch (SocketException)
            {
                Thread.Sleep(125);
                return;
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
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
        static Image ScaleImage(Image source, int width, int height)
        {
            Image dest = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.FillRectangle(Brushes.Transparent, 0, 0, width, height);  // Очищаем экран
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
        private void TrSettings_Click(object sender, EventArgs e)
        {
            Process.Start("C:/Windows/System32/notepad.exe", "Addresslist.txt");
        }
        public static bool PingTarget(string ip)
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(ip);

                if (pingReply.Status != IPStatus.Success)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        private void TrStop_Click(object sender, EventArgs e)
        {
            MenuStrip.Items[MenuStrip.Items.Count - 3].Enabled = true; ;
            if (File.Exists("server_off.ico"))
            {
                Traybox.Icon = new System.Drawing.Icon("server_off.ico");
                this.Icon = new System.Drawing.Icon("server_off.ico");
            }
            logBox.Items.Add("Вещание приостановлено ");
            logBox.Items.Add(DateTime.Now);
            this.Traybox.ShowBalloonTip(12500, "Информация", "Клиент-серверная система трансляции \r содержимого экрана" + "\r Вещание приостановлено в " + DateTime.Now.ToString(), ToolTipIcon.Info);
            setIp.Enabled = true;
            TrBegin.Enabled = true;
            TrStop.Enabled = false;
            Motion.Enabled = true;
            if (BackWorker.IsBusy)
            {
                BackWorker.CancelAsync();
            }
            if (BackWorkerWithDiff.IsBusy)
            {
                BackWorkerWithDiff.CancelAsync();
            }  
        }
        private void TrBegin_Click(object sender, EventArgs e)
        {
            if (File.Exists("server_on.ico"))
            {
                this.Icon = new System.Drawing.Icon("server_on.ico");
                Traybox.Icon = new System.Drawing.Icon("server_on.ico");
            }
            this.MenuStrip.Items[this.MenuStrip.Items.Count - 8].Enabled = false;
            this.MenuStrip.Items[this.MenuStrip.Items.Count - 7].Enabled = true;
            MenuStrip.Items[MenuStrip.Items.Count-3].Enabled = false;
            logBox.Items.Add("Вещание начато ");
            logBox.Items.Add(DateTime.Now);
            this.Traybox.ShowBalloonTip(12500, "Информация", "Клиент-серверная система трансляции \r содержимого экрана" + "\r Вещание начато в " + DateTime.Now.ToString(), ToolTipIcon.Info);
            Motion.Enabled = false;
            TrBegin.Enabled = false;
            TrStop.Enabled = true;
            setIp.Enabled = false;
            if (Motion.Checked)
            {
                try
                { 
                    if(Motion.Checked)        
                    BackWorkerWithDiff.RunWorkerAsync();
                    ipWorker.RunWorkerAsync();
                }
                catch (InvalidOperationException)
                { }
            }
            else
            {
                try
                {
                    BackWorker.RunWorkerAsync();
                    ipWorker.RunWorkerAsync();
                }
                catch (InvalidOperationException) { }
            }
        }
        public Bitmap Get_Resized_Image(int w, int h, Bitmap Img)
        {
            Bitmap Result = Img;
            try
            {
                Size sizing = new Size(w, h);
                Result = new System.Drawing.Bitmap(Img, sizing);
            }
            catch (Exception) { }
            return Result;
        }
        public float difference(Bitmap OrginalImage, Bitmap SecoundImage)
        {
            float percent = 0;
            try
            {
                float counter = 0;
                int size_H = OrginalImage.Size.Height;
                int size_W = OrginalImage.Size.Width;
                float total = size_H * size_W;
                Color pixel_image1;
                Color pixel_image2;
                for (int x = 0; x != size_W; x++)
                {
                    for (int y = 0; y != size_H; y++)
                    {
                        pixel_image1 = OrginalImage.GetPixel(x, y);
                        pixel_image2 = SecoundImage.GetPixel(x, y);
                        if (pixel_image1 != pixel_image2)
                        {
                            counter++;
                        }
                    }
                }
                percent = (counter / total) * 100;
            }
            catch (Exception) { percent = 0; }
            return percent;
        }
        private void BackWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ReadIP();
    
            int Prt = 20000;
              while (true)
              {
                  BackgroundWorker worker = (BackgroundWorker)sender;
                  Bitmap Scr = CaptureScreen.CaptureDesktopWithCursor();
                  MemoryStream ms = new MemoryStream();
                  ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                  System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                  EncoderParameters myEncoderParameters = new EncoderParameters(1);
                  EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                  myEncoderParameters.Param[0] = myEncoderParameter;
                  Scr.Save(ms, jpgEncoder, myEncoderParameters);
                  Graphics gr = panel1.CreateGraphics();
                  Image toPanel = ScaleImage(Scr, panel1.Width, panel1.Height);
                  for (int i = 0; i < AddressList.Count; i++)
                  {
                      Handler.BeginInvoke(ms, AddressList[i], Prt, null, null);
                  }
                  worker.ReportProgress(0, toPanel);
                  if (worker.CancellationPending)
                  {   
                      return;
                  }
              }
          }
        private void BackWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Image Img = (Image)e.UserState;
            Graphics gr = panel1.CreateGraphics();
            gr.DrawImage(Img, new Point(0, 0));
            this.Text = "Cервер | подключено |";
            if (BackWorker.CancellationPending)
            {
                this.Text = "Cервер | отключено |";
                this.panel1.Refresh();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MenuStrip.Items[this.MenuStrip.Items.Count - 7].Enabled = false;
            this.MenuStrip.Items[this.MenuStrip.Items.Count - 5].Enabled = false;
            this.Text = "Cервер | отключено |";
            this.TrStop.Enabled = false;
        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            BackWorker.WorkerSupportsCancellation = true;
            try
            {
                BackWorker.RunWorkerAsync();
            }
            catch (System.InvalidOperationException)
            { }
            TrBegin.Enabled = false;
        }
        private void BackWorkerWithDiff_DoWork(object sender, DoWorkEventArgs e)
        {
            ReadIP();
            int Prt = 20000;
            Bitmap oldImage = CaptureScreen.CaptureDesktopWithCursor();
            oldImage = Get_Resized_Image(100, 100, oldImage);
            while (true)
            {
                Bitmap newImage = CaptureScreen.CaptureDesktopWithCursor();
                newImage = Get_Resized_Image(100, 100, newImage);
                float diff = difference(oldImage, newImage);
                BackgroundWorker worker_diff = (BackgroundWorker)sender;
                BackgroundWorker worker = (BackgroundWorker)sender;
                string to_form = diff.ToString() + "%";
                if (diff >= 1)
                {
                    worker_diff.ReportProgress(0, to_form);
                    Bitmap Scr = CaptureScreen.CaptureDesktopWithCursor();
                    MemoryStream ms = new MemoryStream();
                    ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    Scr.Save(ms, jgpEncoder, myEncoderParameters);
                    Graphics gr = panel1.CreateGraphics();
                    Image toPanel = ScaleImage(Scr, panel1.Width, panel1.Height);
                    for (int i = 0; i < AddressList.Count; i++)
                    {
                        Handler.BeginInvoke(ms, AddressList[i], Prt, null, null);
                    }
                    worker.ReportProgress(0, toPanel);
                    oldImage = newImage;
                }
                else
                {
                    to_form = "Пауза";
                    worker_diff.ReportProgress(0, to_form);
                }
                if (worker.CancellationPending || worker_diff.CancellationPending)
                {
                    this.Text = "Cервер | отключено |";
                    return; 
                }
            }
        }
        private void BackWorkerWithDiff_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                Image Img = (Image)e.UserState;
                Graphics gr = panel1.CreateGraphics();
                gr.DrawImage(Img, new Point(0, 0));
            }
            catch(Exception)
            {
                string percentage = (String)e.UserState;
                this.Text = "Cервер | подключено | " + percentage;
            }
            if (BackWorkerWithDiff.CancellationPending)
            {
                this.Text = "Cервер | отключено |";
                this.panel1.Refresh();
            }
        }
        private void setIp_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.StartPosition = FormStartPosition.CenterScreen;
            s.Show();     
        }
        private void add_ip(string ip)
        {
            bool f = false;
            for (int i = 0; i < AddressList.Count; i++)
            {
                if (AddressList[i] == ip)
                {
                    f = true;
                }
            }
            if (!f)
            {
                AddressList.Add(ip);
            }
        }
        private void rem_ip(string ip)
        {
            if (AddressList.Count != 0)
            {
                for (int i = 0; i < AddressList.Count; i++)
                {
                    if (AddressList[i] == ip)
                    {
                        AddressList.RemoveAt(i);
                    }
                }
            }
           
        }
        private void ipWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker ip_Worker = (BackgroundWorker)sender;
            TcpListener listen = new TcpListener(IPAddress.Any, 11000);
            listen.Start();
            
          
            while(true)
            {
                TcpClient ipClient = listen.AcceptTcpClient();
            if(ipClient.Connected)
            {
               
               // List<string> d = new List<string>();
                string[] mas = ipClient.Client.RemoteEndPoint.ToString().Split(':');
                string ip_addr = mas[0]; 
                NetworkStream inputStream = ipClient.GetStream();
                MemoryStream outputStream = new MemoryStream();
                int readBytes = 0;
                byte[] buffer = new byte[1];
                readBytes = inputStream.Read(buffer, 0, buffer.Length);
                outputStream.Write(buffer, 0, readBytes);
                string info = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
               
                if (info == "0")
                {
                    rem_ip(ip_addr);
                    ipWorker.ReportProgress(0, Dns.GetHostEntry(ip_addr).HostName +" ("+ip_addr+ ") отключился");
                }
                if (info == "1")
                {
                    add_ip(ip_addr);
                    ipWorker.ReportProgress(0,  Dns.GetHostEntry(ip_addr).HostName +" ("+ip_addr + ") подключился");
                }
            
            }
            if (ipWorker.CancellationPending)
            {
                return;
            }
        }
        }
        private void начатьТрансляциюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MenuStrip.Items[this.MenuStrip.Items.Count - 8].Enabled = false;
            this.MenuStrip.Items[this.MenuStrip.Items.Count - 7].Enabled = true;
            TrBegin_Click(sender,e);
        }
        private void MinimizeToTray_Click(object sender, EventArgs e)
        {
            this.MenuStrip.Items[MenuStrip.Items.Count - 5].Enabled = true;
            this.MenuStrip.Items[MenuStrip.Items.Count - 4].Enabled = false;
            this.Hide();
        }
        private void показатьГлавноеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MenuStrip.Items[MenuStrip.Items.Count - 5].Enabled = false;
            this.MenuStrip.Items[MenuStrip.Items.Count - 4].Enabled = true;
            this.Show();
        }
        private void закончитьТрансляциюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MenuStrip.Items[this.MenuStrip.Items.Count - 8].Enabled = true;
            this.MenuStrip.Items[this.MenuStrip.Items.Count - 7].Enabled = false;
            TrStop_Click(sender, e);
        }
        private void настроитьРассылкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setIp_Click(sender, e);
        }
        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Внимание! При завершении работы с программой все активные соединения будут разорваны. Вы действительно хотите завершить работу с программой?", "Завершение работы", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SaveAddressList();
                Application.Exit();
            } 
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Внимание! При завершении работы с программой все активные соединения будут разорваны. Вы действительно хотите завершить работу с программой?", "Завершение работы", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SaveAddressList();
                Application.Exit();
            } 
        }
        private void cdtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MenuStrip.Items[MenuStrip.Items.Count - 5].Enabled = true;
            this.MenuStrip.Items[MenuStrip.Items.Count - 4].Enabled = false;
            this.Hide();
        }
        private void Traybox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible == false)
            {
                this.MenuStrip.Items[MenuStrip.Items.Count - 4].Enabled = true;
                this.Show();
            }
           else
            {
                this.MenuStrip.Items[MenuStrip.Items.Count - 4].Enabled = false;
                this.Hide(); 
            }
        }
        private void UseDifference_Click(object sender, EventArgs e)
        {
            if (Motion.Checked)
            { this.Motion.Checked = false; }
            else
            { this.Motion.Checked = true; }
        }

        private void ipWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.logBox.Items.Add(e.UserState.ToString());
            logBox.Items.Add(DateTime.Now);
          
        }

       
    }
}
