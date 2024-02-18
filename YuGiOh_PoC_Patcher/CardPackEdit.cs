using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOh_PoC_Patcher.CustomControls;
using YuGiOh_PoC_Patcher.Properties;
using YuGiOh_PoC_Patcher.YuGi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace YuGiOh_PoC_Patcher
{
    public partial class CardPackEdit : Form
    {
        public BindingList<CardPackEntry> cardList = new BindingList<CardPackEntry>();
        private List<CardNameEntry> cardNameList = new List<CardNameEntry>();
        private List<CardListEntry> cardTxtList = new List<CardListEntry>();
        private ContextMenuStrip contextMenuStrip1;

        string _path;

        public CardPackEdit()
        {
            InitializeComponent();
        }

        private void CardPackEdit_Load(object sender, EventArgs e)
        {
            // Initialize the ContextMenuStrip.
            contextMenuStrip1 = new ContextMenuStrip();
            foreach (CardPackType type in Enum.GetValues(typeof(CardPackType)))
            {
                var item = new ToolStripMenuItem(type.ToString());
                item.Click += (s, f) => UpdateSelectedRows(type);
                contextMenuStrip1.Items.Add(item);
            }
        }

        private void UpdateSelectedRows(CardPackType type)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var card = row.DataBoundItem as CardPackEntry;
                if (card != null)
                {
                    // ID 0 is special and not allowed to edit state
                    if(card.Id != 0) {
                        card.CardMode = type;
                    }
                }
            }

            dataGridView1.Refresh();
        }

        private void CellMouseClickFix(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // we selected with right click a unselected row, so we select it and unselect everything else
                if(dataGridView1.Rows[e.RowIndex].Selected == false)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                }

                // e.X and e.Y are a bit sus, so we use this fancy estimation, good enough
                Rectangle cellRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                contextMenuStrip1.Show(dataGridView1, cellRect.X, cellRect.Y);
            }
            
            // full card gfx preview
            if (dataGridView1.CurrentCell is DataGridViewImageCell)
            {
                if (e.Button == MouseButtons.Left)
                {
                    var cc = dataGridView1.CurrentCell as DataGridViewImageCell;
                    var card = dataGridView1.CurrentRow.DataBoundItem as CardPackEntry;

                    if(card.CardImageFull != string.Empty) {
                        Bitmap btm;
                        if (card.CardImageFull == null)
                            btm = new Bitmap(card.CardImage);
                        else
                            btm = new Bitmap(card.CardImageFull);

                        var imgBox = new ImageWindow(btm);
                        imgBox.Show();
                    }
                }
            }
        }

        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        public void InitializeCardList(bool memoryMode = false)
        {
            if (memoryMode)
            {
                _path = System.IO.Path.GetTempPath() + "\\YGO_MODTOOLS_TMP\\";
                Directory.CreateDirectory(_path);
            }

            string path = _path;
            string pathPackBin = path + @"bin#\\card_pack.bin";
            string pathPackYGOBin = path + @"bin\\card_pack.bin";
            string pathNameBin = path + @"bin#\\card_nameeng.bin";
            string pathNameYGOBin = path + @"bin\\card_nameeng.bin";
            string pathListCard = path + @"card\\list_card.txt";
            string pathBitmapCard = path + @"card\\";
            string pathBitmapCardMini = path + @"mini\\";

            cardList.Clear();
            cardNameList.Clear();
            cardTxtList.Clear();

            // YGO1 has a different path
            if (File.Exists(pathPackYGOBin)) pathPackBin = pathPackYGOBin;
            if (File.Exists(pathNameYGOBin)) pathNameBin = pathNameYGOBin;

            if (File.Exists(pathPackBin))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(pathPackBin, FileMode.Open)))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        var entry = new CardPackEntry();
                        entry.Id = cardList.Count;
                        entry.CardName = "Unknown";
                        entry.CardImage = Resources.card_ura; // placeholder
                        ushort cardMode = reader.ReadUInt16();
                        CardPackType cardModeEnum = (CardPackType)cardMode;
                        entry.CardMode = cardModeEnum;

                        cardList.Add(entry);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: card_pack.bin is missing! Stop...");
                cardList.Clear();
                _path = "";
                dataGridView1.ClearSelection();
                dataGridView1.Refresh();
                return;
            }

            bool useNameFallback = false;
            if (File.Exists(pathNameBin))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(pathNameBin, FileMode.Open)))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        var nameEntry = new CardNameEntry();
                        nameEntry.Blob = reader.ReadBytes(0x40);
                        nameEntry.Text = Encoding.ASCII.GetString(nameEntry.Blob).TrimEnd('\0');
                        cardNameList.Add(nameEntry);
                    }
                }

                // out-of-sync check (this happend in one YGO1 patch from 2005-02, p05022401.dat)
                if (cardNameList.Count < cardList.Count)
                {
                    MessageBox.Show("card_nameeng.bin is out of sync! An attempt will be made to load card names from list_card.txt");
                    useNameFallback = true;
                }

                // xref name and list entry
                if(useNameFallback == false) {
                    for (int i = 0; i < cardList.Count; i++)
                    {
                        cardList[i].CardName = cardNameList[i].Text;
                    }
                }
            }
            else
            {
                MessageBox.Show("card_nameeng.bin is missing! An attempt will be made to load card names from list_card.txt");
                useNameFallback = true;
            }

            if (File.Exists(pathListCard))
            {
                string[] lines = File.ReadAllLines(pathListCard);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("//"))
                    {
                        var cEntry = new CardListEntry();
                        cEntry.Name = lines[i].Substring(2).Trim();
                        cEntry.Id = lines[i + 1].Substring(2).Trim();
                        cEntry.ImageName = lines[i + 2].Trim();
                        cardTxtList.Add(cEntry);

                        i += 2; // skip next two lines as they're already processed
                    }
                }

                // xref name and list entry
                for (int i = 0; i < cardList.Count; i++)
                {
                    if(memoryMode == false) {
                        if(File.Exists(pathBitmapCardMini + cardTxtList[i].ImageName)) {
                            cardList[i].CardImage = new Bitmap(pathBitmapCardMini + cardTxtList[i].ImageName);
                            cardList[i].CardImageFull = pathBitmapCard + cardTxtList[i].ImageName;
                        }
                    }

                    // skip first dummy card
                    if (i == 0) continue;

                    //fallback when nameeng bin is missing
                    if (useNameFallback)
                    {
                        cardList[i].CardName = cardTxtList[i].Name;
                    }
                }
            }
            else
            {
                if (useNameFallback)
                {
                    MessageBox.Show("list_card.txt is missing! Card images will be not shown. Card names are also not loaded.");
                }
                else
                {
                    MessageBox.Show("list_card.txt is missing! Card images will be not shown.");
                }
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            InitializeCardList();
            dataGridView1.Refresh();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "card_pack.bin";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (BinaryWriter writer = new BinaryWriter(new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate)))
                {
                    foreach (var card in cardList)
                    {
                        // endianness trick 17 :^)
                        byte val = (byte)card.CardMode;
                        writer.Write(val);
                        writer.Write((byte)0x00);
                    }

                    
                }
            }
        }

        private void btn_OpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserEx.FolderBrowserDialog selectFolderDialog = new FolderBrowserEx.FolderBrowserDialog();
            selectFolderDialog.AllowMultiSelect = false;
            selectFolderDialog.Title = "Select the extracted Yu-Gi-Oh data.dat folder!";
            if (selectFolderDialog.ShowDialog() != DialogResult.OK) return;

            var fl = selectFolderDialog.SelectedFolder;

            // verify integrity
            string binCheckPath = fl + @"\\bin#\\card_pack.bin";
            string binCheckPathYGO = fl + @"\\bin\\card_pack.bin";

            // YGO1 has a different path
            if (File.Exists(binCheckPathYGO)) binCheckPath = binCheckPathYGO;

            // reset table
            cardList.Clear();
            cardNameList.Clear();
            cardTxtList.Clear();
            dataGridView1.ClearSelection();
            dataGridView1.Refresh();

            if (File.Exists(binCheckPath) == false)
            {
                MessageBox.Show("card_pack.bin was not found in selected folder structure. Stop...");
                _path = "";
            }
            else
            {
                _path = fl + @"\\";
                InitializeCardList();
                dataGridView1.DataSource = cardList;

                // datagrid settings
                //dataGridView1.Columns["Id"].Width = 32;
                //dataGridView1.Columns["CardMode"].Width = 50;
                //dataGridView1.Columns["CardImage"].Width = 64;
                dataGridView1.Columns["Id"].ReadOnly = true;
                dataGridView1.Columns["CardName"].ReadOnly = true;
                dataGridView1.Columns["CardImage"].ReadOnly = true;
                dataGridView1.Columns["CardMode"].ReadOnly = true;

                // hide
                dataGridView1.Columns["CardImageFull"].Visible = false;
                dataGridView1.RowTemplate.Height = 72;
            }
        }

        private void btn_OpenDAT_Click(object sender, EventArgs e)
        {
            // TODO: to be implemented
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "YuGi Data Container (*.dat)|*.dat";
            //if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            //textBox_datPath.Text = openFileDialog.FileName;
        }
    }
}