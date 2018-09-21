using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Player
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {
            var arquivo = @"C:\Player\PlayerConfig.xml";
            if (File.Exists(arquivo))
            {
                var hotkeys = Util.LerXML(arquivo);
                preencheLabels(hotkeys);
            }
        }
        private void preencheLabels(Hotkeys hotkeys)
        {
            var nomeAtalho1 = default(string);
            var nomeAtalho2 = default(string);
            if (hotkeys != null)
            {
                nomeAtalho1 = hotkeys.Atalho1;
                nomeAtalho2 = hotkeys.Atalho2;
            }
            var Atalhos = nomeAtalho1 + (nomeAtalho2 == "" ? nomeAtalho2 : " + " + nomeAtalho2);
            lblPlayPause.Text = "Play/Pause: " + Atalhos + " + Enter";
            lblProxima.Text = "Próxima Música: " + Atalhos + " +   Direita";
            lblAnterior.Text = "Música Anterior: " + Atalhos + " +  Esquerda";
            lblVolDown.Text = "Diminuir Volume: " + Atalhos + " +  Baixo";
            lblVolUp.Text = "Aumentar Volume: " + Atalhos + " +  Cima";

            if (hotkeys != null)
            {
                Type t = hotkeys.GetType();

                PropertyInfo[] props = t.GetProperties();
                foreach (var c in grbExecutar.Controls)
                {
                    if (c is Label)
                    {
                        var value = props.FirstOrDefault(p => p.Name == ((Label)c).Name.Replace("lbl", "")).GetValue(hotkeys);
                        if (value != null)
                        {
                            var exeName = default(string);
                            exeName = Path.GetFileName(value.ToString());
                            ((Label)c).Text = $"Tecla {((Label)c).Name.Replace("lbl", " ")} : {exeName}";
                        }
                    }
                }
                foreach (var c in grbTextos.Controls)
                {
                    if (c is Label)
                    {
                        var value = props.FirstOrDefault(p => p.Name == ((Label)c).Name.Replace("lbl", "")).GetValue(hotkeys);
                        if (value != null)
                        {
                            var valueDShow = props.FirstOrDefault(p => p.Name == ((Label)c).Name.Replace("lbl", "cb")).GetValue(hotkeys);
                            var dShow = default(bool);
                            if (valueDShow != null)
                            {
                                bool.TryParse(valueDShow.ToString(), out dShow);
                            }
                            if (dShow)
                            {
                                ((Label)c).Text = ((Label)c).Name.Replace("lblNumPad", "NumPad ") + ": ••••••";
                            }
                            else
                            {
                            ((Label)c).Text = ((Label)c).Name.Replace("lblNumPad", "NumPad ") + ": " + value.ToString();
                            }
                        }
                    }
                }
            }
        }
    }
}
