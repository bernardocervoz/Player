using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
namespace Player
{
    public partial class frmPlayer : Form
    {
        #region Private properts
        private bool Suspend { get; set; }
        private bool SendText { get; set; }
        private int Seconds { get; set; }
        private Hotkeys _hotkeys;

        public Hotkeys hotkeys
        {
            get
            {
                var arquivo = @"C:\Player\PlayerConfig.xml";
                if (File.Exists(arquivo) && _hotkeys == null)
                {
                    _hotkeys =  Util.LerXML(arquivo);
                }
                return _hotkeys;
            }
        }
        
        private GlobalHotkey p;
        private GlobalHotkey v;
        private GlobalHotkey s;
        private GlobalHotkey b;
        private GlobalHotkey n;
        private GlobalHotkey o;
        private GlobalHotkey c;
        private GlobalHotkey f;
        private GlobalHotkey w;
        private GlobalHotkey g;
        private GlobalHotkey i;
        private GlobalHotkey e;
        private GlobalHotkey u;
        private GlobalHotkey l;
        private GlobalHotkey one;
        private GlobalHotkey two;
        private GlobalHotkey tree;
        private GlobalHotkey four;
        private GlobalHotkey five;
        private GlobalHotkey six;
        private GlobalHotkey seven;
        private GlobalHotkey eight;
        private GlobalHotkey nine;
        private GlobalHotkey zero;
        private GlobalHotkey play;
        private GlobalHotkey volUp;
        private GlobalHotkey volDown;
        private GlobalHotkey next;
        private GlobalHotkey previous;
        private GlobalHotkey back;
        #endregion Private properts

        #region Construtor
        public frmPlayer()
        {
            PrimeiroAcesso();
            InitializeComponent();
            SetHotKey();
        }
        #endregion Construtor

        #region Form Events
        private void frmPlayer_Load(object sender, EventArgs e)
        {
            //notifyPlayer.ContextMenuStrip = Menu;
            try
            {
                Hide();

                //Util.Ativar(@"\\10.20.18.136\Publico\Softwares\Acesso\Player.xml", Environment.UserName, true);
                //if (DateTime.Now.Date >= new DateTime(2016,09,29))
                //{
                //    MessageBox.Show("A versão grátis de avaliação expirou, contate o desenvolvedor para adiquirir uma licença","Alerta",MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    Application.Exit();
                //}
                //if (!ValidaLicenca())
                //{
                //    MessageBox.Show("Sua licença expirou!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    Application.Exit();
                //}

                Register();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyPlayer.Visible = false;
            Unregiser();

        }


        #endregion Form Events

        #region Menu Events
        private void MenuSuspenderAtalhos_Click(object sender, EventArgs e)
        {
            MenuSuspenderAtalhos.Image = (!Suspend) ? Properties.Resources.Fechado : Properties.Resources.Aberto;
            Suspend = !Suspend;
        }

        private void MenuPlayPause_Click(object sender, EventArgs e)
        {
            Keyboard.SendKey(Keys.MediaPlayPause);
        }

        private void MenuAnterior_Click(object sender, EventArgs e)
        {
            Keyboard.SendKey(Keys.MediaPreviousTrack);
        }

        private void MenuProxima_Click(object sender, EventArgs e)
        {
            Keyboard.SendKey(Keys.MediaNextTrack);
        }

        private void MenuVolumeDown_Click(object sender, EventArgs e)
        {
            Keyboard.SendKey(Keys.VolumeDown);
        }

        private void MenuVolumeUP_Click(object sender, EventArgs e)
        {
            Keyboard.SendKey(Keys.VolumeUp);
        }

        private void MenuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuHelp_Click(object sender, EventArgs e)
        {
            var frm = new frmHelp();
            frm.Show();
        }
        private void MenuConfig_Click(object sender, EventArgs e)
        {
            var frm = new frmConfig();
            frm.Show();
        }
        #endregion Menu Events

        #region Other Methods
        protected override void WndProc(ref Message m)
        {
            const int millisecondsTimeout = 500;
            try
            {
                if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                {

                    switch (GetKey(m.LParam))
                    {
                        case Keys.Enter:
                            if (!Suspend)
                                Keyboard.SendKey(Keys.MediaPlayPause);
                            break;
                        case Keys.Up:
                            if (!Suspend)
                                Keyboard.SendKey(Keys.VolumeUp);
                            break;
                        case Keys.Down:
                            if (!Suspend)
                                Keyboard.SendKey(Keys.VolumeDown);
                            break;
                        case Keys.Right:
                            if (!Suspend)
                                Keyboard.SendKey(Keys.MediaNextTrack);
                            break;
                        case Keys.Left:
                            if (!Suspend)
                                Keyboard.SendKey(Keys.MediaPreviousTrack);
                            break;
                        case Keys.Back:
                            if (!Suspend)
                                Keyboard.SendKey(Keys.VolumeMute);
                            break;
                        case Keys.P:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.P))
                                Process.Start(@hotkeys.P);
                            break;
                        case Keys.V:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.V))
                                Process.Start(@hotkeys.V);
                            break;
                        case Keys.O:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.O))
                                Process.Start(@hotkeys.O);
                            break;
                        case Keys.N:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.N))
                                Process.Start(@hotkeys.N);
                            break;
                        case Keys.S:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.S))
                                Process.Start(@hotkeys.S);
                            break;
                        case Keys.B:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.B))
                                Process.Start(@hotkeys.B);
                            break;
                        case Keys.C:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.C))
                                Process.Start(@hotkeys.C);
                            break;
                        case Keys.F:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.F))
                                Process.Start(@hotkeys.F);
                            break;
                        case Keys.W:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.W))
                                Process.Start(@hotkeys.W);
                            break;
                        case Keys.G:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.G))
                                Process.Start(@hotkeys.G);
                            break;
                        case Keys.I:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.I))
                                Process.Start(@hotkeys.I);
                            break;
                        case Keys.E:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.E))
                                Process.Start(@hotkeys.E);
                            break;
                        case Keys.U:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.U))
                                Process.Start(@hotkeys.U);
                            break;
                        case Keys.L:
                            if (!Suspend && hotkeys != null && !string.IsNullOrWhiteSpace(hotkeys.L))
                                Process.Start(@hotkeys.L);
                            break;
                        case Keys.NumPad1:
                            if (!Suspend && !string.IsNullOrWhiteSpace(hotkeys.NumPad1))
                            {
                                Suspend = true;
                                SendText = true;
                                System.Threading.Thread.Sleep(millisecondsTimeout);
                                SendKeys.Send(hotkeys.NumPad1);
                                TimerKeys.Start();
                            }
                            break;
                        case Keys.NumPad2:
                            if (!Suspend && !string.IsNullOrWhiteSpace(hotkeys.NumPad2))
                            {
                                Suspend = true;
                                SendText = true;
                                System.Threading.Thread.Sleep(millisecondsTimeout);
                                SendKeys.Send(hotkeys.NumPad2);
                                TimerKeys.Start();
                            }
                            break;
                        case Keys.NumPad3:
                            if (!Suspend && !string.IsNullOrWhiteSpace(hotkeys.NumPad3))
                            {
                                Suspend = true;
                                SendText = true;
                                System.Threading.Thread.Sleep(millisecondsTimeout);
                                SendKeys.Send(hotkeys.NumPad3);
                                TimerKeys.Start();
                            }
                            break;
                        case Keys.NumPad4:
                            if (!Suspend && !string.IsNullOrWhiteSpace(hotkeys.NumPad4))
                            {
                                Suspend = true;
                                SendText = true;
                                System.Threading.Thread.Sleep(millisecondsTimeout);
                                SendKeys.Send(hotkeys.NumPad4);
                                TimerKeys.Start();
                            }
                            break;
                        case Keys.NumPad5:
                            if (!Suspend && !string.IsNullOrWhiteSpace(hotkeys.NumPad5))
                            {
                                Suspend = true;
                                SendText = true;
                                System.Threading.Thread.Sleep(millisecondsTimeout);
                                SendKeys.Send(hotkeys.NumPad5);
                                TimerKeys.Start();
                            }
                            break;
                        case Keys.NumPad6:
                            if (!Suspend && !string.IsNullOrWhiteSpace(hotkeys.NumPad6))
                            {
                                Suspend = true;
                                SendText = true;
                                System.Threading.Thread.Sleep(millisecondsTimeout);
                                SendKeys.Send(hotkeys.NumPad6);
                                TimerKeys.Start();
                            }
                            break;
                        case Keys.NumPad7:
                            if (!Suspend && !string.IsNullOrWhiteSpace(hotkeys.NumPad7))
                            {
                                Suspend = true;
                                SendText = true;
                                System.Threading.Thread.Sleep(millisecondsTimeout);
                                SendKeys.Send(hotkeys.NumPad7);
                                TimerKeys.Start();
                            }
                            break;
                        case Keys.NumPad8:
                            if (!Suspend && !string.IsNullOrWhiteSpace(hotkeys.NumPad8))
                            {
                                Suspend = true;
                                SendText = true;
                                System.Threading.Thread.Sleep(millisecondsTimeout);
                                SendKeys.Send(hotkeys.NumPad8);
                                TimerKeys.Start();
                            }
                            break;
                        case Keys.NumPad9:
                            if (!Suspend && !string.IsNullOrWhiteSpace(hotkeys.NumPad9))
                            {
                                Suspend = true;
                                SendText = true;
                                System.Threading.Thread.Sleep(millisecondsTimeout);
                                SendKeys.Send(hotkeys.NumPad9);
                                TimerKeys.Start();
                            }
                            break;
                        case Keys.NumPad0:
                            if (!Suspend && !string.IsNullOrWhiteSpace(hotkeys.NumPad0))
                            {
                                Suspend = true;
                                SendText = true;
                                System.Threading.Thread.Sleep(millisecondsTimeout);
                                SendKeys.Send(hotkeys.NumPad0);
                                TimerKeys.Start();
                            }
                            break;
                    }

                }
                base.WndProc(ref m);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Keys GetKey(IntPtr LParam)
        {
            return (Keys)((LParam.ToInt32()) >> 16);
        }

        private void SetHotKey()
        {

            var Atalho1 = 0;
            var Atalho2 = 0;
            var NomeAtalho1 = default(string);
            var NomeAtalho2 = default(string);


            if (hotkeys != null)
            {
                NomeAtalho1 = hotkeys.Atalho1;
                NomeAtalho2 = hotkeys.Atalho2;
            }
            Atalho1 = Util.GetTecla(NomeAtalho1, true);
            Atalho2 = Util.GetTecla(NomeAtalho2, false);
            Atalho1 = (Atalho1 == 0) ? Constants.ALT : Atalho1;
            //Atalho2 = (Atalho2 == 0) ? Constants.WIN : Atalho2;
            var Atalhos = Atalho1;
            if (Atalho2 != 0)
            {
                Atalhos += Atalho2;
            }
            p = new GlobalHotkey(Atalhos, Keys.P, this);
            v = new GlobalHotkey(Atalhos, Keys.V, this);
            o = new GlobalHotkey(Atalhos, Keys.O, this);
            n = new GlobalHotkey(Atalhos, Keys.N, this);
            s = new GlobalHotkey(Atalhos, Keys.S, this);
            b = new GlobalHotkey(Atalhos, Keys.B, this);
            c = new GlobalHotkey(Atalhos, Keys.C, this);
            f = new GlobalHotkey(Atalhos, Keys.F, this);
            w = new GlobalHotkey(Atalhos, Keys.W, this);
            g = new GlobalHotkey(Atalhos, Keys.G, this);
            i = new GlobalHotkey(Atalhos, Keys.I, this);
            e = new GlobalHotkey(Atalhos, Keys.E, this);
            u = new GlobalHotkey(Atalhos, Keys.U, this);
            l = new GlobalHotkey(Atalhos, Keys.L, this);
            one = new GlobalHotkey(Atalhos, Keys.NumPad1, this);
            two = new GlobalHotkey(Atalhos, Keys.NumPad2, this);
            tree = new GlobalHotkey(Atalhos, Keys.NumPad3, this);
            four = new GlobalHotkey(Atalhos, Keys.NumPad4, this);
            five = new GlobalHotkey(Atalhos, Keys.NumPad5, this);
            six = new GlobalHotkey(Atalhos, Keys.NumPad6, this);
            seven = new GlobalHotkey(Atalhos, Keys.NumPad7, this);
            eight = new GlobalHotkey(Atalhos, Keys.NumPad8, this);
            nine = new GlobalHotkey(Atalhos, Keys.NumPad9, this);
            zero = new GlobalHotkey(Atalhos, Keys.NumPad0, this);
            play = new GlobalHotkey(Atalhos, Keys.Enter, this);
            volUp = new GlobalHotkey(Atalhos, Keys.Up, this);
            volDown = new GlobalHotkey(Atalhos, Keys.Down, this);
            next = new GlobalHotkey(Atalhos, Keys.Right, this);
            previous = new GlobalHotkey(Atalhos, Keys.Left, this);
            back = new GlobalHotkey(Atalhos, Keys.Back, this);
        }

        private void Register()
        {
            p.Register();
            v.Register();
            o.Register();
            n.Register();
            s.Register();
            b.Register();
            c.Register();
            f.Register();
            w.Register();
            g.Register();
            i.Register();
            e.Register();
            u.Register();
            l.Register();
            one.Register();
            two.Register();
            tree.Register();
            four.Register();
            five.Register();
            six.Register();
            seven.Register();
            eight.Register();
            nine.Register();
            zero.Register();
            play.Register();
            volUp.Register();
            volDown.Register();
            next.Register();
            previous.Register();
            back.Register();
        }

        private void Unregiser()
        {
            p.Unregiser();
            v.Unregiser();
            o.Unregiser();
            n.Unregiser();
            s.Unregiser();
            b.Unregiser();
            c.Unregiser();
            f.Unregiser();
            w.Unregiser();
            g.Unregiser();
            i.Unregiser();
            e.Unregiser();
            u.Unregiser();
            l.Unregiser();
            one.Unregiser();
            two.Unregiser();
            tree.Unregiser();
            four.Unregiser();
            five.Unregiser();
            six.Unregiser();
            seven.Unregiser();
            eight.Unregiser();
            nine.Unregiser();
            zero.Unregiser();
            volUp.Unregiser();
            volDown.Unregiser();
            next.Unregiser();
            previous.Unregiser();
            back.Unregiser();
        }

        private void PrimeiroAcesso()
        {
            var caminho = @"C:\Player";
            if (!Directory.Exists(caminho))
            {
                var frm = new frmConfig();
                frm.Show();
            }

        }

        private bool ValidaLicenca()
        {
            return Util.Licenced(@"\\10.20.18.136\Publico\Softwares\Acesso\Player.xml", Environment.UserName);
        }
        #endregion Other Methods

        #region session Events
        void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {

            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                //Keyboard.SendKey(Keys.MediaStop);


            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {

            }
        }



        #endregion session Events

        private void TimerKeys_Tick(object sender, EventArgs e)
        {
            if (Seconds > 0)
            {
                Seconds = 0;
                TimerKeys.Stop();
                SendText = false;
                Suspend = false;
            }
            else
            {
                Seconds++;
            }
        }
    }
}