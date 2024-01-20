using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YuGiOh_PoC_Patcher.CustomControls
{
    public class DataGridViewEx : DataGridView
    {
        public DataGridViewEx()
        {
            DoubleBuffered = true;
            this.BackgroundColor = Color.White;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == (System.Windows.Forms.Keys.Space | System.Windows.Forms.Keys.Shift))
            {
                byte[] keyStates = new byte[255];
                UnsafeNativeMethods.GetKeyboardState(keyStates);
                byte shiftKeyState = keyStates[16];
                keyStates[16] = 0; // turn off the shift key
                UnsafeNativeMethods.SetKeyboardState(keyStates);

                System.Windows.Forms.SendKeys.SendWait(" ");

                keyStates[16] = shiftKeyState; // turn the shift key back on
                UnsafeNativeMethods.SetKeyboardState(keyStates);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        [System.Security.SuppressUnmanagedCodeSecurity]
        internal static class UnsafeNativeMethods
        {

            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern int GetKeyboardState(byte[] keystate);


            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern int SetKeyboardState(byte[] keystate);

        }

    }
}
