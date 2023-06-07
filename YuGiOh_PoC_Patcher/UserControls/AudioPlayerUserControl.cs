using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using FileDialogExtenders;

namespace YuGiOh_PoC_Patcher.UserControls
{
    public partial class AudioPlayerUserControl : UserControl
    {
        public SoundPlayer player = new SoundPlayer();
        private MemoryStream ms;
        
        public AudioPlayerUserControl()
        {
            InitializeComponent();
            WireUpButtonEvent();
        }

        public void LoadAudioData(byte[] audioData)
        {
            if(ms != null) ms.Dispose();

            ms = new MemoryStream(audioData);
            player.Stream = ms;
            player.Play();
        }

        public void WireUpButtonEvent()
        {
            button_AudioPlay.Click += (sndr, args) =>
            {
                player.Play();
            };
        }

    }
}
