using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Microsoft.Win32;
using System.Reflection;

namespace Player
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }
        #region Form Events
        private void frmConfig_Load(object sender, EventArgs e)
        {
            PreencheCombo();
            LerXML();
            ckbStarWindows.Checked = HasKeyInRegistry();

        }

        private void cmbAtalho1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemSelecionado = -1;
            int.TryParse(cmbAtalho1.SelectedValue.ToString(), out itemSelecionado);
            var itemRemove = "";
            switch (itemSelecionado)
            {
                case 0:
                    itemRemove = "--SELECIONE--";
                    break;
                case 1:
                    itemRemove = "ALT";
                    break;
                case 2:
                    itemRemove = "CTRL";
                    break;
                case 3:
                    itemRemove = "SHIFT";
                    break;
                case 4:
                    itemRemove = "WIN";
                    break;
            }
            PreencheCombo(itemRemove);

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmbAtalho1.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Selecione um atalho", "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Application.StartupPath != @"C:\Player" && ckbStarWindows.Checked)
                {
                    MessageBox.Show("Para que a aplicação inicie com o windows ela deve estar no seguinte diretório:" + System.Environment.NewLine + "C:\\Player\\", "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var caminho = @"C:\Player";
                if (!Directory.Exists(caminho))
                {
                    Directory.CreateDirectory(caminho);
                }
                var arquivo = "PlayerConfig.xml";
                arquivo = Path.Combine(caminho, arquivo);
                var writer = new XmlTextWriter(arquivo, null);
                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                writer.WriteStartElement("Shortcuts");
                var atalho1 = cmbAtalho1.Text;
                writer.WriteElementString("Shortcut1", atalho1);
                var atalho2 = cmbAtalho2.Text;
                if (!string.IsNullOrWhiteSpace(atalho2) && !atalho2.Equals("--SELECIONE--"))
                {
                    writer.WriteElementString("Shortcut2", atalho2);
                }

                foreach (var iten in Controls)
                {
                    if (iten is TextBox)
                    {
                        var txtName = ((TextBox)iten).Name.Replace("txt", "").ToLower();
                        var value = ((TextBox)iten).Text;
                        if (!string.IsNullOrWhiteSpace(value))
                            writer.WriteElementString(string.Format("Shortcut_{0}", txtName), value);
                    }
                    else if (iten is CheckBox)
                    {
                        var cbName = ((CheckBox)iten).Name.ToLower();
                        var value = ((CheckBox)iten).Checked;
                        writer.WriteElementString(string.Format("Shortcut_{0}", cbName), value.ToString());
                    }
                }

                writer.WriteEndElement();
                writer.Close();
                Application.Restart();
                Close();
                StarWindows(ckbStarWindows.Checked);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Erro ao Salvar os atalhos. " + Environment.NewLine + "Erro: " + ex.Message,
                    "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Salvar os atalhos. " + Environment.NewLine + "Erro: " + ex.Message,
                    "Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btn_Click(object sender, EventArgs e)
        {
            GetExe(((Button)sender).Name.Replace("btn", ""));
        }

        private void cbNumPad_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                var cbNumpad = sender as CheckBox;
                var nameCheckBox = cbNumpad.Name.Replace("cb", "");

                if (Controls["txt" + nameCheckBox] is TextBox)
                {
                    ((TextBox)(Controls["txt" + nameCheckBox])).UseSystemPasswordChar = cbNumpad.Checked;
                }

            }
        }

        #endregion Form Events

        #region Other Methods
        private void LerXML()
        {
            var arquivo = @"C:\Player\PlayerConfig.xml";
            if (File.Exists(arquivo))
            {
                var Atalho1 = default(string);
                var Atalho2 = default(string);
                var hotkeys = Util.LerXML(arquivo);
                if (hotkeys != null)
                {
                    Type t = hotkeys.GetType();

                    PropertyInfo[] props = t.GetProperties();
                    foreach (var c in this.Controls)
                    {
                        if (c is TextBox)
                        {
                            var value = props.FirstOrDefault(p => p.Name == ((TextBox)c).Name.Replace("txt", "")).GetValue(hotkeys);
                            if (value != null)
                            {
                                ((TextBox)c).Text = value.ToString();
                            }
                        }
                        else if (c is CheckBox)
                        {
                            if (((CheckBox)c).Name.Contains("Windows"))
                            {
                                continue;
                            }
                            var value = props.FirstOrDefault(p => p.Name == ((CheckBox)c).Name).GetValue(hotkeys);
                            if (value != null)
                            {
                                var check = default(bool);
                                bool.TryParse(value.ToString(), out check);
                                ((CheckBox)c).Checked = check;
                            }
                        }
                    }
                    Atalho1 = hotkeys.Atalho1;
                    Atalho2 = hotkeys.Atalho2;
                }
                cmbAtalho1.SelectedIndex = cmbAtalho1.FindString(Atalho1);
                cmbAtalho2.SelectedIndex = cmbAtalho2.FindString(Atalho2);
            }
        }

        private void PreencheCombo(string itemRemove = null)
        {
            if (!String.IsNullOrWhiteSpace(itemRemove))
            {
                if (itemRemove == "--SELECIONE--")
                {
                    cmbAtalho2.Enabled = false;
                    return;
                }
            }
            var list = new ArrayList();
            var Nomes = new string[5] { "--SELECIONE--", "ALT", "CTRL", "SHIFT", "WIN" };
            if (!String.IsNullOrWhiteSpace(itemRemove))
            {
                Nomes = Nomes.Where(x => x != itemRemove).ToArray();
            }
            for (int i = 0; i < Nomes.Count(); i++)
            {
                var Dados = new
                {
                    Name = Nomes[i].ToString(),
                    Value = i
                };
                list.Add(Dados);
            }
            if (String.IsNullOrWhiteSpace(itemRemove))
            {
                cmbAtalho1.DisplayMember = "Name";
                cmbAtalho1.ValueMember = "Value";
                cmbAtalho1.DataSource = list;
            }
            else
            {
                cmbAtalho2.DisplayMember = "Name";
                cmbAtalho2.ValueMember = "Value";
                cmbAtalho2.DataSource = list;
                cmbAtalho2.Enabled = true;
            }
        }

        private void GetExe(string Atalho)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Exe Files|*.exe; *.lnk";
            openFileDialog.Title = "Selecione o executável para o atalho " + Atalho;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Controls["txt" + Atalho].Text = openFileDialog.FileName;
            }
        }

        private void StarWindows(bool start)
        {
            try
            {
                if (start)
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        key.SetValue(@"C:\Player\Player.exe", "\"" + Application.ExecutablePath + "\"");
                    }
                }
                else
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        key.DeleteValue(@"C:\Player\Player.exe", false);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool HasKeyInRegistry()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                return key.GetValue(@"C:\Player\Player.exe") != null;
            }
        }


        #endregion Other Methods
    }
}



