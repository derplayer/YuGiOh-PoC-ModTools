using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace YuGiOh_PoC_Patcher.YuGi
{
    /// <summary>
    /// Static Extension Methods
    /// </summary>
    public static class YuGiExtendedMethods
    {
        // JTP v1
        public static string POC_JTP_US_HASH = "E438A082105F1045B92922504A93A8AD26846DC2";
        public static string POC_JTP_US_SRLESS_HASH = "4F24EFDD237408EA27384A00C627A4D85E8439B1";
        // JTP v1.1
        public static string POC_JTP_EUR_HASH = "3B12FDEB63B6359561FBBDE21F9D7ED922245152";
        public static string POC_JTP_EUR_SRLESS_HASH = "EDC4B7249423AF32ABB08B6A4F97D5549A7BD937";

        public static bool IsPatchable(string exePath)
        {
            // Allow "genesis" v1.1 exe
            byte[] genStrCheck = new byte[7];
            using (BinaryReader reader = new BinaryReader(new FileStream(exePath, FileMode.Open, FileAccess.Read)))
            {
                reader.BaseStream.Seek(0xAB4, SeekOrigin.Begin);
                reader.Read(genStrCheck, 0, 7);
            }

            string exeLabel = System.Text.Encoding.ASCII.GetString(genStrCheck).ToLower();
            if (exeLabel == "genesis")
            {
                return true;
            }

            // Check exe hash
            byte[] hash;
            using (Stream stream = File.OpenRead(exePath))
            {
                hash = SHA1.Create().ComputeHash(stream);
            }
            string hashStr = BitConverter.ToString(hash).Replace("-", "");

            // TODO: read region.dat for more accurate detection? (mods change hash)
            if (hashStr == POC_JTP_US_HASH || hashStr == POC_JTP_US_SRLESS_HASH)
            {
                return false; // v1.0
            }

            //return true; // v1.1
            // TODO: The offsets are missing for the normal version...
            return false; 
        }

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
