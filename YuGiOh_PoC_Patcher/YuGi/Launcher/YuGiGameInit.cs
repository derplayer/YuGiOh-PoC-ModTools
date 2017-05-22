using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Net;
using YuGiOh_PoC_Patcher.YuGi;
using System.Runtime.Serialization.Json;
using FileDialogExtenders;
using CustomControls;
using jSkin;
using System.Globalization;

namespace YuGiOh_PoC_Patcher.YuGi.Launcher
{
    public static class YuGiGameInit
    {

        static public void startYuGi()
        {
            startYuGiBase(null, false);
        }

        static public void startYuGi(string exeFilePath)
        {
            startYuGiBase(exeFilePath, true);
        }

        static private void startYuGiBase(string filepath, bool customDirectories)
        {
            Process theGame = new Process();
            string directory, file;

            if (customDirectories)
            {
                directory = Path.GetDirectoryName(filepath);
                file = filepath;
            } else
            {
                string[] FileDirectoryFromGame = YuGiExtendedMethods.GetDefaultGamePath();
                directory = FileDirectoryFromGame[0];
                file = FileDirectoryFromGame[1];
            }

            string registry_flags = "DISABLEDWM";

            theGame.StartInfo.FileName = file;
            theGame.StartInfo.Arguments = "";
            theGame.StartInfo.WorkingDirectory = directory;// + "\\test123\\"; //Anti-Crash fix (konami...), injection point for efficient modlauncher

            RegistryKey checkSettings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\YuGiOhModLauncher\\v1\\", true);
            List<string> parametersExe = new List<string>();

            foreach (var item in checkSettings.GetValueNames())
            {
                bool boolCheck = false;

                if (item != "Language" && item != "GamePath")
                {
                    boolCheck = Convert.ToBoolean(checkSettings.GetValue(item));
                }

                //I like offending people, because I think people who get offended should be offended.
                switch (item)
                {
                    case "60 FPS Mode": if (boolCheck) parametersExe.Add("-speedy"); break;
                    case "Disable Sound": if (boolCheck) parametersExe.Add("-nosound"); break;
                    case "Easy": if (boolCheck) parametersExe.Add("-e"); break;
                    case "FPS Counter": if (boolCheck) parametersExe.Add("-fps"); break;
                    case "Full Screen (16-Bit)": if (boolCheck) parametersExe.Add("-16"); break;
                    case "Full Screen (24-Bit)": if (boolCheck) parametersExe.Add("-24"); break;
                    case "Full Screen (32-Bit)": if (boolCheck) parametersExe.Add("-32"); break;
                    case "Hard": if (boolCheck) parametersExe.Add("-h"); break;
                    case "Language":
                        switch (checkSettings.GetValue(item).ToString())
                        {
                            case "Spanish":
                                parametersExe.Add("-Lspa");
                                break;
                            case "Italian":
                                parametersExe.Add("-Lita");
                                break;
                            case "French":
                                parametersExe.Add("-Lfra");
                                break;
                            case "English":
                                parametersExe.Add("-Leng");
                                break;
                            case "German":
                                parametersExe.Add("-Lger");
                                break;
                            case "Japanese":
                                parametersExe.Add("-Ljpn");
                                break;
                        }
                        break;
                    case "Window Mode": if (boolCheck) parametersExe.Add("-win"); break;
                    case "Windows Vista+ Bugfix":
                        RegistryKey myKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers\\", true);

                        //Bugfix for Windows 7+ (TODO: More...)
                        if (myKey != null)
                        {
                            myKey.SetValue(file, registry_flags, RegistryValueKind.String);
                            myKey.Close();
                        }
                        break;
                }
            }

            try
            {
                theGame.StartInfo.Arguments = String.Join(" ", parametersExe);
                theGame.Start();
            }
            catch //When something fucks up try to start with admin rights
            {
                theGame.StartInfo.Verb = "runas";
                theGame.Start();
            }
        }

    }
}
