﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binarysharp.MemoryManagement;
using YuGiOh_PoC_Patcher.YuGi.Values;

namespace YuGiOh_PoC_Patcher.YuGi
{
    /// <summary>
    /// [WIP] Debugger for runtime memory changes with MemorySharp
    /// </summary>
    public class YuGiDebugger
    {
        private static YuGiStructure _structure;
        private static volatile YuGiDebugger _instance;
        private static object _syncRoot = new object();

        /// <summary>
        /// YuGi executable process
        /// </summary>
        public static Process Process { get; set; }
        /// <summary>
        /// MemorySharp instance thats hooked to the yugi process
        /// </summary>
        public static MemorySharp MemorySharp { get; set; }

        /// <summary>
        /// Returns the instance of the debugger when it was created
        /// via the YuGiDebugger.Create() method
        /// </summary>
        public static YuGiDebugger Instance
        {
            get
            {
                if (_instance != null) return _instance;
                return null;
                //lock (_syncRoot)
                //{
                //    if (_instance == null) _instance = new YuGiDebugger();
                //}
                //return _instance;
            }
        }

        /// <summary>
        /// Create a YuGiDebugger instance and returns it
        /// </summary>
        /// <param name="structure">Current YuGiStructure instance</param>
        /// <returns>YuGiDebugger instance</returns>
        public static YuGiDebugger Create(YuGiStructure structure)
        {
            _structure = structure;
            _instance = new YuGiDebugger();
            return Instance;
        }

        /// <summary>
        /// Patches the value inside the running process memory
        /// with the value of the given YuGiValue
        /// </summary>
        /// <param name="value">YuGiValue that will be patched inside memory</param>
        public static void PatchMemory(YuGiValue value)
        {
            if (_instance == null) return;
            if (MemorySharp == null) return;

            try
            {
                MemorySharp.Write((IntPtr)value.Offset, value.Value);
            }
            catch (Exception e)
            {
                MessageBox.Show("Critical Error!\n\r\n\rDid you just closed the Game?\n\rApplication will now close!\n\r" + e);
                Application.Exit();
                return;
            }
    
        }

        /// <summary>
        /// Private Constructor
        /// </summary>
        private YuGiDebugger()
        {
            Process = new Process();

            DialogResult dialogResult = MessageBox.Show("Do you want to use the default executeable?\n\rNote: Will also start with all Launch Settings!",
                "Injection - Use the default executeable?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Process = YuGi.Launcher.YuGiGameInit.startYuGiBase(null, false);
            }
            else if (dialogResult == DialogResult.No)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = openFileDialog.FileName;
                startInfo.WorkingDirectory = Path.GetDirectoryName(openFileDialog.FileName);
                
                Process.EnableRaisingEvents = true;
                Process.Exited += Process_Exited;
                Process.StartInfo = startInfo;

                Process.Start();
            }

            MemorySharp = new MemorySharp(Process);

            //timer for delaying the init patching cause sometimes
            //MemorySharps fucks up when hooking to early
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();

            if (YuGiExtendedMethods.IsPatchable(Process.MainModule.FileName) == false)
            {
                Process.Kill();
                MemorySharp.Dispose();
                timer.Stop();
                MessageBox.Show("This executable is not compatible with the patcher.");
                return;
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            _instance = null;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();
            if (Process.HasExited) return;
            DebugPatchWindow patchWindow = new DebugPatchWindow();
            patchWindow.Show();
            MemorySharp.Threads.SuspendAll();
            _structure.DebugPatchValues();
            MemorySharp.Threads.ResumeAll();
            patchWindow.Close();
        }

    }
}
