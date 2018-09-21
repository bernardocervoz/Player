using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Player
{
    public static class Util
    {
        public static int GetTecla(string Atalho, bool Atalho1)
        {
            switch (Atalho)
            {
                case "ALT":
                    return 0x0001;
                case "CTRL":
                    return 0x0002;
                case "SHIFT":
                    return 0x0004;
                case "WIN":
                    return 0x0008;
                default:
                    return (Atalho1) ? Constants.ALT : 0;
            }

        }

        public static string GetNomeTecla(int Atalho, bool Atalho1)
        {
            switch (Atalho)
            {
                case 0:
                    return "";
                case 1:
                    return "ALT";
                case 2:
                    return "CTRL";
                case 3:
                    return "SHIFT";
                case 4:
                    return "WIN";
                default:
                    return (Atalho1) ? "ALT" : "WIN";
            }
        }

        public static Hotkeys LerXML2(string arquivo)
        {
            var xml = XElement.Load(arquivo);
            var Shortcuts = (from Shortcut in xml.Elements("Shortcuts")
                             select Shortcut).FirstOrDefault();

            var Shortcut1 = Shortcuts.Element("Shortcut1");//.Value.ToString();
            var Shortcut2 = Shortcuts.Element("Shortcut2");//.Value.ToString();
            var b = Shortcuts.Element("Shortcut_b");
            var c = Shortcuts.Element("Shortcut_c");
            var f = Shortcuts.Element("Shortcut_f");
            var n = Shortcuts.Element("Shortcut_n");
            var o = Shortcuts.Element("Shortcut_o");
            var p = Shortcuts.Element("Shortcut_p");
            var s = Shortcuts.Element("Shortcut_s");
            var v = Shortcuts.Element("Shortcut_v");
            var w = Shortcuts.Element("Shortcut_w");
            var g = Shortcuts.Element("Shortcut_g");
            var i = Shortcuts.Element("Shortcut_i");
            var e = Shortcuts.Element("Shortcut_e");
            var u = Shortcuts.Element("Shortcut_u");
            var retorno = new Hotkeys();
            if (Shortcut1 != null)
            {
                retorno.Atalho1 = Shortcut1.Value.ToString();
            }
            else
            {
                retorno.Atalho1 = string.Empty;
            }
            if (Shortcut2 != null)
            {
                retorno.Atalho2 = Shortcut2.Value.ToString();
            }
            else
            {
                retorno.Atalho2 = string.Empty;
            }
            if (b != null)
            {
                retorno.B = b.Value.ToString();
            }
            else
            {
                retorno.B = string.Empty;
            }
            if (c != null)
            {
                retorno.C = c.Value.ToString();
            }
            else
            {
                retorno.C = string.Empty;
            }
            if (f != null)
            {
                retorno.F = f.Value.ToString();
            }
            else
            {
                retorno.F = string.Empty;
            }
            if (n != null)
            {
                retorno.N = n.Value.ToString();
            }
            else
            {
                retorno.N = string.Empty;
            }
            if (o != null)
            {
                retorno.O = o.Value.ToString();
            }
            else
            {
                retorno.O = string.Empty;
            }
            if (s != null)
            {
                retorno.S = s.Value.ToString();
            }
            else
            {
                retorno.S = string.Empty;
            }
            if (p != null)
            {
                retorno.P = p.Value.ToString();
            }
            else
            {
                retorno.P = string.Empty;
            }
            if (v != null)
            {
                retorno.V = v.Value.ToString();
            }
            else
            {
                retorno.V = string.Empty;
            }
            if (w != null)
            {
                retorno.W = w.Value.ToString();
            }
            else
            {
                retorno.W = string.Empty;
            }
            if (g != null)
            {
                retorno.G = g.Value.ToString();
            }
            else
            {
                retorno.G = string.Empty;
            }
            if (i != null)
            {
                retorno.I = i.Value.ToString();
            }
            else
            {
                retorno.I = string.Empty;
            }
            if (e != null)
            {
                retorno.E = e.Value.ToString();
            }
            else
            {
                retorno.E = string.Empty;
            }
            if (u != null)
            {
                retorno.U = u.Value.ToString();
            }
            else
            {
                retorno.U = string.Empty;
            }
            return retorno;
        }

        public static bool Licenced(string arquivo, string userName)
        {
            try
            {
                var xml = XElement.Load(arquivo);
                foreach (XElement node in xml.Elements("UserKey"))
                {
                    if (((XElement)node.LastNode).Name == userName)
                    {
                        bool acess = false;
                        bool.TryParse(((XElement)node.LastNode).Value, out acess);
                        return acess;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2147024843 || ex.Message.Contains("O caminho da rede não foi encontrado"))
                {
                    return true;
                }

                throw ex;
            }
        }

        private static bool HasKey(string file, string userName)
        {
            var xml = XElement.Load(file);
            foreach (XElement node in xml.Elements("UserKey"))
            {
                if (((XElement)node.LastNode).Name == userName)
                {
                    return true;
                }
            }
            return false;
        }

        public static void Ativar(string file, string userName, bool acess)
        {
            try
            {
                if (HasKey(file, userName))
                {
                    return;
                }
                XDocument doc;
                if (!File.Exists(file))
                {
                    doc = new XDocument();
                    doc.Add(new XElement("Root"));
                }
                else
                {
                    doc = XDocument.Load(file);
                }

                doc.Root.Add(
                      new XElement("UserKey",
                                   new XElement(userName, acess.ToString())
                            )
                      );
                doc.Save(file);
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2147024843 || ex.Message.Contains("O caminho da rede não foi encontrado"))
                {
                    return;
                }
                throw ex;
            }
        }

        public static Hotkeys LerXML(string arquivo)
        {
            var xml = XElement.Load(arquivo);
            var Shortcuts = (from Shortcut in xml.Elements("Shortcuts")
                             select Shortcut).FirstOrDefault();

            var Shortcut1 = Shortcuts.Element("Shortcut1");//.Value.ToString();
            var Shortcut2 = Shortcuts.Element("Shortcut2");//.Value.ToString();
            //var b = Shortcuts.Element("Shortcut_b");
            //var c = Shortcuts.Element("Shortcut_c");
            //var f = Shortcuts.Element("Shortcut_f");
            //var n = Shortcuts.Element("Shortcut_n");
            //var o = Shortcuts.Element("Shortcut_o");
            //var p = Shortcuts.Element("Shortcut_p");
            //var s = Shortcuts.Element("Shortcut_s");
            //var v = Shortcuts.Element("Shortcut_v");
            //var w = Shortcuts.Element("Shortcut_w");
            //var g = Shortcuts.Element("Shortcut_g");
            //var i = Shortcuts.Element("Shortcut_i");
            //var e = Shortcuts.Element("Shortcut_e");
            //var u = Shortcuts.Element("Shortcut_u");
            var retorno = new Hotkeys();

            if (Shortcut1 != null)
            {
                retorno.Atalho1 = Shortcut1.Value.ToString();
            }
            else
            {
                retorno.Atalho1 = string.Empty;
            }
            if (Shortcut2 != null)
            {
                retorno.Atalho2 = Shortcut2.Value.ToString();
            }
            else
            {
                retorno.Atalho2 = string.Empty;
            }
            Type t = retorno.GetType();

            PropertyInfo[] props = t.GetProperties();
            foreach (var item in props)
            {
                if (item.Name.Contains("Atalho"))
                {
                    continue;
                }
                var value = Shortcuts.Element("Shortcut_" + item.Name.ToLower());
                if (value != null)
                {
                    SetValue(retorno, item, value.Value.ToString());
                }
                else
                {
                    SetValue(retorno, item, string.Empty);
                }
            }

            #region old Coment
            //if (b != null)
            //{
            //    retorno.B = b.Value.ToString();
            //}
            //else
            //{
            //    retorno.B = string.Empty;
            //}
            //if (c != null)
            //{
            //    retorno.C = c.Value.ToString();
            //}
            //else
            //{
            //    retorno.C = string.Empty;
            //}
            //if (f != null)
            //{
            //    retorno.F = f.Value.ToString();
            //}
            //else
            //{
            //    retorno.F = string.Empty;
            //}
            //if (n != null)
            //{
            //    retorno.N = n.Value.ToString();
            //}
            //else
            //{
            //    retorno.N = string.Empty;
            //}
            //if (o != null)
            //{
            //    retorno.O = o.Value.ToString();
            //}
            //else
            //{
            //    retorno.O = string.Empty;
            //}
            //if (s != null)
            //{
            //    retorno.S = s.Value.ToString();
            //}
            //else
            //{
            //    retorno.S = string.Empty;
            //}
            //if (p != null)
            //{
            //    retorno.P = p.Value.ToString();
            //}
            //else
            //{
            //    retorno.P = string.Empty;
            //}
            //if (v != null)
            //{
            //    retorno.V = v.Value.ToString();
            //}
            //else
            //{
            //    retorno.V = string.Empty;
            //}
            //if (w != null)
            //{
            //    retorno.W = w.Value.ToString();
            //}
            //else
            //{
            //    retorno.W = string.Empty;
            //}
            //if (g != null)
            //{
            //    retorno.G = g.Value.ToString();
            //}
            //else
            //{
            //    retorno.G = string.Empty;
            //}
            //if (i != null)
            //{
            //    retorno.I = i.Value.ToString();
            //}
            //else
            //{
            //    retorno.I = string.Empty;
            //}
            //if (e != null)
            //{
            //    retorno.E = e.Value.ToString();
            //}
            //else
            //{
            //    retorno.E = string.Empty;
            //}
            //if (u != null)
            //{
            //    retorno.U = u.Value.ToString();
            //}
            //else
            //{
            //    retorno.U = string.Empty;
            //}
            #endregion

            return retorno;
        }

        private static void SetValue(Hotkeys retorno, PropertyInfo item, string value)
        {
            switch (item.Name)
            {
                case "NumPad0":
                    string hostName = Dns.GetHostName();
                    item.SetValue(retorno, $"{Environment.MachineName} - {Dns.GetHostByName(hostName).AddressList[0].ToString()}");
                    break;
                case "NumPad1":
                    item.SetValue(retorno, Environment.UserName);
                    break;
                case "NumPad2":
                    item.SetValue(retorno, $"{Environment.UserName}@meta.com.br");
                    break;
                default:
                    item.SetValue(retorno, value);
                    break;
            }
        }
    }
}

