using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player
{
    public class Keyboard
    {
        [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern void keybd_event(byte bVk, byte bScan, Int32 dwFlags, Int32 dwExtraInfo);

        public static void SendKey(Keys key)
        {
            keybd_event(Convert.ToByte(key), 0, 0, 0);
        }
    }
}
