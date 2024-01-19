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
using System.Text.RegularExpressions;

namespace YuGiOh_PoC_Patcher.UserControls
{
    /// <summary>
    /// WAV audio player widget.
    /// TODO: The complete SoundPlayer is ass and to replace. No volume control and crash prone with wav files over 20mb.
    /// </summary>
    public partial class AudioPlayerUserControl : UserControl
    {
        public SoundPlayer player = new SoundPlayer();
        private MemoryStream ms;

        private Dictionary<string, string> subChunkDescriptions = new Dictionary<string, string>
    {
        { "INAM", "Track title: " },
        { "IPRD", "Album title: " },
        { "IART", "Artist: " },
        { "ICRD", "Date: " },
        { "ITRK", "Track number: " },
        { "ICMT", "A text comment: " },
        { "IKEY", "Keywords for the project or file: " },
        { "ISFT", "Software used to create the file: " },
        { "IENG", "The engineer: " },
        { "ITCH", "The technician: " },
        { "IGNR", "Genre: " },
        { "ICOP", "Copyright information: " },
        { "ISBJ", "Subject: " },
        { "ISRC", "Source: " }
    };

        public AudioPlayerUserControl()
        {
            InitializeComponent();
            WireUpButtonEvent();
        }

        public void LoadAudioData(byte[] audioData, string filename = "")
        {
            if (ms != null) ms.Dispose();

            ms = new MemoryStream(audioData);
            // bext metadata identifier check & label reset
            var headerSeek = SearchIdentifier(audioData, Encoding.ASCII.GetBytes("bext"));
            var headerSeekL = SearchIdentifier(audioData, Encoding.ASCII.GetBytes("LIST"));
            richTextBox_Metadata.Text = "No metadata found inside this audio file!";

            using (var reader = new BinaryReader(ms))
            {
                if (headerSeek != -1 || headerSeekL != -1) richTextBox_Metadata.Text = ""; // reset box when one of headers found

                // bext metadata parse when there
                if (headerSeek != -1)
                {
                    reader.BaseStream.Seek(headerSeek, SeekOrigin.Begin);
                    string chunkID = new string(reader.ReadChars(4));
                    uint chunkSize = reader.ReadUInt32();

                    if (chunkID == "bext")
                    {
                        string description = new string(reader.ReadChars(256)).TrimEnd('\0');
                        string originator = new string(reader.ReadChars(32)).TrimEnd('\0');
                        string originatorReference = new string(reader.ReadChars(32)).TrimEnd('\0');
                        string originationDate = new string(reader.ReadChars(10)).TrimEnd('\0');
                        string originationTime = new string(reader.ReadChars(8)).TrimEnd('\0');
                        //other params are skipped, because they do not exist in our WAVs...

                        //apply to richtextbox
                        richTextBox_Metadata.Text += "Header found (BEXT):" + Environment.NewLine;
                        richTextBox_Metadata.Text += "Description: " + description + Environment.NewLine;
                        richTextBox_Metadata.Text += "Producer: " + originator + Environment.NewLine;
                        richTextBox_Metadata.Text += "Producer ref. ID: " + originatorReference + Environment.NewLine;
                        richTextBox_Metadata.Text += "Encoded date: " + originationDate + " " + originationTime + Environment.NewLine;
                    }


                }

                // list metadata parse when there
                if (headerSeekL != -1)
                {
                    reader.BaseStream.Seek(headerSeekL, SeekOrigin.Begin);
                    string chunkID = new string(reader.ReadChars(4));
                    uint chunkSize = reader.ReadUInt32();

                    if (chunkID == "LIST")
                    {
                        richTextBox_Metadata.Text += "Header found (LIST):" + Environment.NewLine;

                        string listType = new string(reader.ReadChars(4));
                        if (listType == "INFO")
                        {
                            // Read the sub-chunks until the end of the LIST chunk
                            long listEndPosition = reader.BaseStream.Position + chunkSize - 4;
                            while (reader.BaseStream.Position < listEndPosition)
                            {
                                // Read the sub-chunk ID and size
                                string subChunkId = new string(reader.ReadChars(4));
                                int subChunkSize = reader.ReadInt32() + 1; // +1 is a hack, but 99% of YGO wavs seems to be this way...

                                // TODO: and for the other 1%... This parser is not perfect...
                                if (subChunkSize >= 1024)
                                {
                                    richTextBox_Metadata.Text += Environment.NewLine + "Error at parsing file metadata..." + Environment.NewLine;
                                    break;
                                }

                                // Read the sub-chunk data, assuming it's a null-terminated string
                                string subChunkData = new string(reader.ReadChars(subChunkSize)).TrimEnd('\0');
                                subChunkData = new string(subChunkData.Where(x => ' ' <= x && x <= '~').ToArray());

                                // Get the description for the sub-chunk ID
                                string description = subChunkDescriptions.ContainsKey(subChunkId) ? subChunkDescriptions[subChunkId] : "Unknown";

                                //apply to richtextbox
                                Console.WriteLine($"{description}: {subChunkData}");
                                richTextBox_Metadata.Text += $"{description}{subChunkData}" + Environment.NewLine;
                            }
                        }
                    }

                }

                ms.Seek(0, SeekOrigin.Begin);

                try
                {
                    if (filename.Contains("m_duel2")) // seems to be in all versions... tutomenu does it too but very rare(?)
                    {
                        throw new Exception("This files is broken and crashes the .NET SoundPlayer...LOL");
                    }
                    else
                    {
                        player.Stream = ms;
                        player.Play();
                    }

                }
                catch (Exception e)
                {
                    richTextBox_Metadata.Text += Environment.NewLine + "Error at playing WAV file " + filename + "..." + Environment.NewLine;
                    player.Stop();
                }
            }
        }

        public void WireUpButtonEvent()
        {
            button_AudioPlay.Click += (sndr, args) =>
            {
                player.Play();
            };
        }

        private int SearchIdentifier(byte[] src, byte[] pattern)
        {
            int maxFirstCharSlot = src.Length - pattern.Length + 1;
            for (int i = 0; i < maxFirstCharSlot; i++)
            {
                if (src[i] != pattern[0]) // compare only first byte
                    continue;

                // found a match on first byte, now try to match rest of the pattern
                for (int j = pattern.Length - 1; j >= 1; j--)
                {
                    if (src[i + j] != pattern[j]) break;
                    if (j == 1) return i;
                }
            }
            return -1;
        }

    }
}
