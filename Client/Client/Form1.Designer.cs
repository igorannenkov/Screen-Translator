namespace Client
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Connect = new System.Windows.Forms.ToolStripMenuItem();
            this.Disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.свернутьВТрейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьГлавноеОкноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.FullScr = new System.Windows.Forms.ToolStripMenuItem();
            this.WindScr = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.серверToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.bWorker = new System.ComponentModel.BackgroundWorker();
            this.Traybox = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 389);
            this.panel1.TabIndex = 0;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Connect,
            this.Disconnect,
            this.toolStripSeparator2,
            this.свернутьВТрейToolStripMenuItem,
            this.показатьГлавноеОкноToolStripMenuItem,
            this.toolStripSeparator3,
            this.FullScr,
            this.WindScr,
            this.toolStripSeparator1,
            this.серверToolStripMenuItem,
            this.Exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(217, 198);
            // 
            // Connect
            // 
            this.Connect.Image = ((System.Drawing.Image)(resources.GetObject("Connect.Image")));
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(216, 22);
            this.Connect.Text = "Подключиться";
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Disconnect
            // 
            this.Disconnect.Image = ((System.Drawing.Image)(resources.GetObject("Disconnect.Image")));
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(216, 22);
            this.Disconnect.Text = "Отключиться";
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // свернутьВТрейToolStripMenuItem
            // 
            this.свернутьВТрейToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("свернутьВТрейToolStripMenuItem.Image")));
            this.свернутьВТрейToolStripMenuItem.Name = "свернутьВТрейToolStripMenuItem";
            this.свернутьВТрейToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.свернутьВТрейToolStripMenuItem.Text = "Свернуть в трей...";
            this.свернутьВТрейToolStripMenuItem.Click += new System.EventHandler(this.свернутьВТрейToolStripMenuItem_Click);
            // 
            // показатьГлавноеОкноToolStripMenuItem
            // 
            this.показатьГлавноеОкноToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("показатьГлавноеОкноToolStripMenuItem.Image")));
            this.показатьГлавноеОкноToolStripMenuItem.Name = "показатьГлавноеОкноToolStripMenuItem";
            this.показатьГлавноеОкноToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.показатьГлавноеОкноToolStripMenuItem.Text = "Показать главное окно";
            this.показатьГлавноеОкноToolStripMenuItem.Click += new System.EventHandler(this.показатьГлавноеОкноToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(213, 6);
            // 
            // FullScr
            // 
            this.FullScr.Image = ((System.Drawing.Image)(resources.GetObject("FullScr.Image")));
            this.FullScr.Name = "FullScr";
            this.FullScr.Size = new System.Drawing.Size(216, 22);
            this.FullScr.Text = "На весь экран";
            this.FullScr.Click += new System.EventHandler(this.FullScr_Click);
            // 
            // WindScr
            // 
            this.WindScr.Image = ((System.Drawing.Image)(resources.GetObject("WindScr.Image")));
            this.WindScr.Name = "WindScr";
            this.WindScr.Size = new System.Drawing.Size(216, 22);
            this.WindScr.Text = "Оконный режим";
            this.WindScr.Click += new System.EventHandler(this.WindScr_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // серверToolStripMenuItem
            // 
            this.серверToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("серверToolStripMenuItem.Image")));
            this.серверToolStripMenuItem.Name = "серверToolStripMenuItem";
            this.серверToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.серверToolStripMenuItem.Text = "Источник подключения...";
            this.серверToolStripMenuItem.Click += new System.EventHandler(this.серверToolStripMenuItem_Click);
            // 
            // Exit
            // 
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(216, 22);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // bWorker
            // 
            this.bWorker.WorkerReportsProgress = true;
            this.bWorker.WorkerSupportsCancellation = true;
            this.bWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWorker_DoWork);
            this.bWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bWorker_ProgressChanged);
            // 
            // Traybox
            // 
            this.Traybox.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Traybox.ContextMenuStrip = this.contextMenuStrip1;
            this.Traybox.Icon = ((System.Drawing.Icon)(resources.GetObject("Traybox.Icon")));
            this.Traybox.Text = "Клиент-серверная система\r\nтрансляции содержимого экрана";
            this.Traybox.Visible = true;
            this.Traybox.DoubleClick += new System.EventHandler(this.Traybox_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 389);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удаленный клиент";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FullScr;
        private System.Windows.Forms.ToolStripMenuItem WindScr;
        private System.ComponentModel.BackgroundWorker bWorker;
        private System.Windows.Forms.ToolStripMenuItem Connect;
        private System.Windows.Forms.ToolStripMenuItem Disconnect;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem серверToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon Traybox;
        private System.Windows.Forms.ToolStripMenuItem свернутьВТрейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьГлавноеОкноToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

