namespace Player
{
    partial class frmPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayer));
            this.notifyPlayer = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuSuspenderAtalhos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlayPause = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAnterior = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProxima = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVolumeDown = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVolumeUP = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.TimerKeys = new System.Windows.Forms.Timer(this.components);
            this.MenuPlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyPlayer
            // 
            this.notifyPlayer.ContextMenuStrip = this.MenuPlayer;
            this.notifyPlayer.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyPlayer.Icon")));
            this.notifyPlayer.Text = "Player";
            this.notifyPlayer.Visible = true;
            // 
            // MenuPlayer
            // 
            this.MenuPlayer.AutoSize = false;
            this.MenuPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSuspenderAtalhos,
            this.MenuPlayPause,
            this.MenuAnterior,
            this.MenuProxima,
            this.MenuVolumeDown,
            this.MenuVolumeUP,
            this.MenuConfig,
            this.MenuHelp,
            this.toolStripSeparator1,
            this.MenuSair});
            this.MenuPlayer.Name = "MenuPlayer";
            this.MenuPlayer.Size = new System.Drawing.Size(30, 226);
            // 
            // MenuSuspenderAtalhos
            // 
            this.MenuSuspenderAtalhos.AutoSize = false;
            this.MenuSuspenderAtalhos.Image = global::Player.Properties.Resources.Aberto;
            this.MenuSuspenderAtalhos.Name = "MenuSuspenderAtalhos";
            this.MenuSuspenderAtalhos.Size = new System.Drawing.Size(30, 22);
            this.MenuSuspenderAtalhos.Text = " ";
            this.MenuSuspenderAtalhos.Click += new System.EventHandler(this.MenuSuspenderAtalhos_Click);
            // 
            // MenuPlayPause
            // 
            this.MenuPlayPause.AutoSize = false;
            this.MenuPlayPause.Image = ((System.Drawing.Image)(resources.GetObject("MenuPlayPause.Image")));
            this.MenuPlayPause.Name = "MenuPlayPause";
            this.MenuPlayPause.Size = new System.Drawing.Size(30, 22);
            this.MenuPlayPause.Text = " ";
            this.MenuPlayPause.Click += new System.EventHandler(this.MenuPlayPause_Click);
            // 
            // MenuAnterior
            // 
            this.MenuAnterior.AutoSize = false;
            this.MenuAnterior.Image = global::Player.Properties.Resources.Anterior;
            this.MenuAnterior.Name = "MenuAnterior";
            this.MenuAnterior.Size = new System.Drawing.Size(30, 22);
            this.MenuAnterior.Text = " ";
            this.MenuAnterior.Click += new System.EventHandler(this.MenuAnterior_Click);
            // 
            // MenuProxima
            // 
            this.MenuProxima.AutoSize = false;
            this.MenuProxima.Image = global::Player.Properties.Resources.Proxima;
            this.MenuProxima.Name = "MenuProxima";
            this.MenuProxima.Size = new System.Drawing.Size(30, 22);
            this.MenuProxima.Text = " ";
            this.MenuProxima.Click += new System.EventHandler(this.MenuProxima_Click);
            // 
            // MenuVolumeDown
            // 
            this.MenuVolumeDown.AutoSize = false;
            this.MenuVolumeDown.Image = global::Player.Properties.Resources.VolupeDown;
            this.MenuVolumeDown.Name = "MenuVolumeDown";
            this.MenuVolumeDown.Size = new System.Drawing.Size(30, 22);
            this.MenuVolumeDown.Text = " ";
            this.MenuVolumeDown.Click += new System.EventHandler(this.MenuVolumeDown_Click);
            // 
            // MenuVolumeUP
            // 
            this.MenuVolumeUP.AutoSize = false;
            this.MenuVolumeUP.Image = global::Player.Properties.Resources.VolupeUp;
            this.MenuVolumeUP.Name = "MenuVolumeUP";
            this.MenuVolumeUP.Size = new System.Drawing.Size(30, 22);
            this.MenuVolumeUP.Text = " ";
            this.MenuVolumeUP.Click += new System.EventHandler(this.MenuVolumeUP_Click);
            // 
            // MenuConfig
            // 
            this.MenuConfig.AutoSize = false;
            this.MenuConfig.Image = global::Player.Properties.Resources.Config;
            this.MenuConfig.Name = "MenuConfig";
            this.MenuConfig.Size = new System.Drawing.Size(30, 22);
            this.MenuConfig.Text = " ";
            this.MenuConfig.Click += new System.EventHandler(this.MenuConfig_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.AutoSize = false;
            this.MenuHelp.Image = global::Player.Properties.Resources.Help;
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(30, 22);
            this.MenuHelp.Text = " ";
            this.MenuHelp.Click += new System.EventHandler(this.MenuHelp_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(26, 6);
            // 
            // MenuSair
            // 
            this.MenuSair.AutoSize = false;
            this.MenuSair.Image = global::Player.Properties.Resources.Sair;
            this.MenuSair.Name = "MenuSair";
            this.MenuSair.Size = new System.Drawing.Size(30, 22);
            this.MenuSair.Text = " ";
            this.MenuSair.Click += new System.EventHandler(this.MenuSair_Click);
            // 
            // TimerKeys
            // 
            this.TimerKeys.Interval = 1000;
            this.TimerKeys.Tick += new System.EventHandler(this.TimerKeys_Tick);
            // 
            // frmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 78);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPlayer";
            this.Text = "Player";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlayer_FormClosing);
            this.Load += new System.EventHandler(this.frmPlayer_Load);
            this.MenuPlayer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyPlayer;
        private System.Windows.Forms.ContextMenuStrip MenuPlayer;
        private System.Windows.Forms.ToolStripMenuItem MenuSuspenderAtalhos;
        private System.Windows.Forms.ToolStripMenuItem MenuPlayPause;
        private System.Windows.Forms.ToolStripMenuItem MenuAnterior;
        private System.Windows.Forms.ToolStripMenuItem MenuProxima;
        private System.Windows.Forms.ToolStripMenuItem MenuVolumeDown;
        private System.Windows.Forms.ToolStripMenuItem MenuVolumeUP;
        private System.Windows.Forms.ToolStripMenuItem MenuSair;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuConfig;
        private System.Windows.Forms.Timer TimerKeys;
    }
}

