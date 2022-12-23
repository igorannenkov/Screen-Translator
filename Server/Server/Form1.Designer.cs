namespace Server
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TrBegin = new System.Windows.Forms.Button();
            this.TrStop = new System.Windows.Forms.Button();
            this.BackWorker = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.setIp = new System.Windows.Forms.Button();
            this.MinimizeToTray = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Motion = new System.Windows.Forms.CheckBox();
            this.BackWorkerWithDiff = new System.ComponentModel.BackgroundWorker();
            this.ipWorker = new System.ComponentModel.BackgroundWorker();
            this.logBox = new System.Windows.Forms.ListBox();
            this.Traybox = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StartView = new System.Windows.Forms.ToolStripMenuItem();
            this.StopView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowWind = new System.Windows.Forms.ToolStripMenuItem();
            this.HideWind = new System.Windows.Forms.ToolStripMenuItem();
            this.UseDifference = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.настроитьРассылкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 151);
            this.panel1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.panel1, "Предварительный просмотр содержимого экрана,\r\nкоторое отпавляется другим пользова" +
                    "телям");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 170);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Предварительный просмотр";
            // 
            // TrBegin
            // 
            this.TrBegin.BackColor = System.Drawing.Color.Transparent;
            this.TrBegin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TrBegin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TrBegin.Image = ((System.Drawing.Image)(resources.GetObject("TrBegin.Image")));
            this.TrBegin.Location = new System.Drawing.Point(3, 452);
            this.TrBegin.Name = "TrBegin";
            this.TrBegin.Size = new System.Drawing.Size(40, 40);
            this.TrBegin.TabIndex = 6;
            this.toolTip1.SetToolTip(this.TrBegin, "Начать трансляцию");
            this.TrBegin.UseVisualStyleBackColor = false;
            this.TrBegin.Click += new System.EventHandler(this.TrBegin_Click);
            // 
            // TrStop
            // 
            this.TrStop.BackColor = System.Drawing.Color.Transparent;
            this.TrStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TrStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TrStop.Image = ((System.Drawing.Image)(resources.GetObject("TrStop.Image")));
            this.TrStop.Location = new System.Drawing.Point(44, 452);
            this.TrStop.Name = "TrStop";
            this.TrStop.Size = new System.Drawing.Size(40, 40);
            this.TrStop.TabIndex = 7;
            this.toolTip1.SetToolTip(this.TrStop, "Приостановить трансляцию");
            this.TrStop.UseVisualStyleBackColor = false;
            this.TrStop.Click += new System.EventHandler(this.TrStop_Click);
            // 
            // BackWorker
            // 
            this.BackWorker.WorkerReportsProgress = true;
            this.BackWorker.WorkerSupportsCancellation = true;
            this.BackWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackWorker_DoWork);
            this.BackWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackWorker_ProgressChanged);
            // 
            // setIp
            // 
            this.setIp.BackColor = System.Drawing.Color.Transparent;
            this.setIp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.setIp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setIp.Image = ((System.Drawing.Image)(resources.GetObject("setIp.Image")));
            this.setIp.Location = new System.Drawing.Point(85, 452);
            this.setIp.Name = "setIp";
            this.setIp.Size = new System.Drawing.Size(40, 40);
            this.setIp.TabIndex = 15;
            this.toolTip1.SetToolTip(this.setIp, "Настройка адресов");
            this.setIp.UseVisualStyleBackColor = false;
            this.setIp.Click += new System.EventHandler(this.setIp_Click);
            // 
            // MinimizeToTray
            // 
            this.MinimizeToTray.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeToTray.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MinimizeToTray.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimizeToTray.Image = ((System.Drawing.Image)(resources.GetObject("MinimizeToTray.Image")));
            this.MinimizeToTray.Location = new System.Drawing.Point(126, 452);
            this.MinimizeToTray.Name = "MinimizeToTray";
            this.MinimizeToTray.Size = new System.Drawing.Size(40, 40);
            this.MinimizeToTray.TabIndex = 17;
            this.toolTip1.SetToolTip(this.MinimizeToTray, "Свернуть в трей");
            this.MinimizeToTray.UseVisualStyleBackColor = false;
            this.MinimizeToTray.Click += new System.EventHandler(this.MinimizeToTray_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.Location = new System.Drawing.Point(167, 452);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(40, 40);
            this.Exit.TabIndex = 18;
            this.toolTip1.SetToolTip(this.Exit, "Выход");
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Motion
            // 
            this.Motion.AutoSize = true;
            this.Motion.BackColor = System.Drawing.Color.Transparent;
            this.Motion.Location = new System.Drawing.Point(6, 432);
            this.Motion.Name = "Motion";
            this.Motion.Size = new System.Drawing.Size(194, 17);
            this.Motion.TabIndex = 14;
            this.Motion.Text = "Учитывать изменения на экране";
            this.Motion.UseVisualStyleBackColor = false;
            // 
            // BackWorkerWithDiff
            // 
            this.BackWorkerWithDiff.WorkerReportsProgress = true;
            this.BackWorkerWithDiff.WorkerSupportsCancellation = true;
            this.BackWorkerWithDiff.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackWorkerWithDiff_DoWork);
            this.BackWorkerWithDiff.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackWorkerWithDiff_ProgressChanged);
            // 
            // ipWorker
            // 
            this.ipWorker.WorkerReportsProgress = true;
            this.ipWorker.WorkerSupportsCancellation = true;
            this.ipWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ipWorker_DoWork);
            this.ipWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ipWorker_ProgressChanged);
            // 
            // logBox
            // 
            this.logBox.FormattingEnabled = true;
            this.logBox.Location = new System.Drawing.Point(4, 188);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(203, 238);
            this.logBox.TabIndex = 16;
            // 
            // Traybox
            // 
            this.Traybox.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Traybox.BalloonTipText = "Приложение готово к работе";
            this.Traybox.BalloonTipTitle = "Информация";
            this.Traybox.ContextMenuStrip = this.MenuStrip;
            this.Traybox.Icon = ((System.Drawing.Icon)(resources.GetObject("Traybox.Icon")));
            this.Traybox.Text = "Клиент-серверная система \r\nтрансляции содержимого экрана";
            this.Traybox.Visible = true;
            this.Traybox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Traybox_MouseDoubleClick);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartView,
            this.StopView,
            this.toolStripSeparator2,
            this.ShowWind,
            this.HideWind,
            this.UseDifference,
            this.toolStripSeparator1,
            this.Quit});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(232, 148);
            // 
            // StartView
            // 
            this.StartView.Image = ((System.Drawing.Image)(resources.GetObject("StartView.Image")));
            this.StartView.Name = "StartView";
            this.StartView.Size = new System.Drawing.Size(231, 22);
            this.StartView.Text = "Начать трансляцию";
            this.StartView.Click += new System.EventHandler(this.начатьТрансляциюToolStripMenuItem_Click);
            // 
            // StopView
            // 
            this.StopView.Image = ((System.Drawing.Image)(resources.GetObject("StopView.Image")));
            this.StopView.Name = "StopView";
            this.StopView.Size = new System.Drawing.Size(231, 22);
            this.StopView.Text = "Закончить трансляцию";
            this.StopView.Click += new System.EventHandler(this.закончитьТрансляциюToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(228, 6);
            // 
            // ShowWind
            // 
            this.ShowWind.Image = ((System.Drawing.Image)(resources.GetObject("ShowWind.Image")));
            this.ShowWind.Name = "ShowWind";
            this.ShowWind.Size = new System.Drawing.Size(231, 22);
            this.ShowWind.Text = "Показать главное окно";
            this.ShowWind.Click += new System.EventHandler(this.показатьГлавноеОкноToolStripMenuItem_Click);
            // 
            // HideWind
            // 
            this.HideWind.Image = ((System.Drawing.Image)(resources.GetObject("HideWind.Image")));
            this.HideWind.Name = "HideWind";
            this.HideWind.Size = new System.Drawing.Size(231, 22);
            this.HideWind.Text = "Свернуть в трей";
            this.HideWind.Click += new System.EventHandler(this.cdtToolStripMenuItem_Click);
            // 
            // UseDifference
            // 
            this.UseDifference.CheckOnClick = true;
            this.UseDifference.Image = ((System.Drawing.Image)(resources.GetObject("UseDifference.Image")));
            this.UseDifference.Name = "UseDifference";
            this.UseDifference.Size = new System.Drawing.Size(231, 22);
            this.UseDifference.Text = "Учесть изменения на экране";
            this.UseDifference.Click += new System.EventHandler(this.UseDifference_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(228, 6);
            // 
            // Quit
            // 
            this.Quit.Image = ((System.Drawing.Image)(resources.GetObject("Quit.Image")));
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(231, 22);
            this.Quit.Text = "Выход";
            this.Quit.Click += new System.EventHandler(this.выходToolStripMenuItem_Click_1);
            // 
            // настроитьРассылкуToolStripMenuItem
            // 
            this.настроитьРассылкуToolStripMenuItem.Name = "настроитьРассылкуToolStripMenuItem";
            this.настроитьРассылкуToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.настроитьРассылкуToolStripMenuItem.Text = "Настроить рассылку";
            this.настроитьРассылкуToolStripMenuItem.Click += new System.EventHandler(this.настроитьРассылкуToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 499);
            this.ContextMenuStrip = this.MenuStrip;
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.setIp);
            this.Controls.Add(this.MinimizeToTray);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Motion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TrBegin);
            this.Controls.Add(this.TrStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Cервер";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button TrBegin;
        private System.Windows.Forms.Button TrStop;
        private System.ComponentModel.BackgroundWorker BackWorker;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox Motion;
        private System.ComponentModel.BackgroundWorker BackWorkerWithDiff;
        private System.Windows.Forms.Button setIp;
        private System.ComponentModel.BackgroundWorker ipWorker;
        private System.Windows.Forms.ListBox logBox;
        private System.Windows.Forms.NotifyIcon Traybox;
        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem StartView;
        private System.Windows.Forms.ToolStripMenuItem StopView;
        private System.Windows.Forms.ToolStripMenuItem ShowWind;
        private System.Windows.Forms.ToolStripMenuItem Quit;
        private System.Windows.Forms.Button MinimizeToTray;
        private System.Windows.Forms.ToolStripMenuItem UseDifference;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.ToolStripMenuItem HideWind;
        private System.Windows.Forms.ToolStripMenuItem настроитьРассылкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

