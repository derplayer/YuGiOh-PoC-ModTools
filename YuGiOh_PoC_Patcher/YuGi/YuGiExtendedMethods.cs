using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace YuGiOh_PoC_Patcher.YuGi
{
    /// <summary>
    /// Static Extension Methods
    /// </summary>
    public static class YuGiExtendedMethods
    {
        /// <summary>
        /// ArrayItem[0] = directory
        /// ArrayItem[1] = file
        /// </summary>
        /// <param name="exePath"></param>
        /// <returns></returns>
        public static string[] GetDefaultGamePath()
        {
            string[] finalReturn = new string[2];
            string directory = String.Empty;

            //Todo: 32 Bit OS check
            directory = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\YuGiOhModLauncher\\v1\\", "GamePath", -1);
            if (directory == "NaN")
            {
                directory = YuGiExtendedMethods.SetDefaultGamePath();
            }

            finalReturn[0] = directory;
            finalReturn[1] = directory + "joey_pc.exe";

            return finalReturn;
        }

        public static string SetDefaultGamePath()
        {
            string directory = null, file = null;

            OpenFileDialog newPathDlg = new OpenFileDialog();
            newPathDlg.Filter = "Yu-Gi-Oh Executeable|*.exe";

            if (newPathDlg.ShowDialog() == DialogResult.OK)
            {
                file = newPathDlg.FileName;
                directory = Path.GetDirectoryName(file);
            
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true).OpenSubKey("YuGiOhModLauncher", true).OpenSubKey("v1", true);
            key.SetValue("GamePath", directory + "\\", RegistryValueKind.String);
            }
            return (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\YuGiOhModLauncher\\v1\\", "GamePath", -1);
        }

    }
}
