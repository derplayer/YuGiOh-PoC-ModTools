using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using CustomControls;
using YuGiOh_PoC_Patcher.Properties;
using YuGiOh_PoC_Patcher.YuGi;
using YuGiOh_PoC_Patcher.YuGi.Filetypes;
using YuGiOh_PoC_Patcher.YuGi.Values;
using YuGiOh_PoC_Patcher.CustomControls;
using FileDialogExtenders;
using System.Collections.Generic;
using YuGiOh_PoC_Patcher.UserControls;
using System.Linq;
using System.Text;

namespace YuGiOh_PoC_Patcher
{
    public partial class MainWindow : Form
    {
        private static readonly Encoding SHIFT_JIS = Encoding.GetEncoding("Shift_JIS");

        private YuGiStructure _structure = new YuGiStructure();
        private YuGiData _data;
        private bool _loading;
        private Bitmap _background = Resources.fie_normal;
        private Timer _timer = new Timer();

        public MainWindow()
        {
            InitializeComponent();
            _timer.Interval = 250;
            _timer.Enabled = false;
            _timer.Tick += _timer_Tick;

            #if DEBUG
            debugToolStripMenuItem.Enabled = true;
            #else
            debugToolStripMenuItem.Enabled = false;
            #endif

            

            checkBox_Rotate.DataBindings.Add("Checked", _structure, "Rotate", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDown_CardSize_Width.DataBindings.Add("Value", _structure.CardSize, "X", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDown_CardSize_Height.DataBindings.Add("Value", _structure.CardSize, "Y", true, DataSourceUpdateMode.OnPropertyChanged);

            _structure.PropertyChanged += _structure_PropertyChanged;

            pointUserControl_WindowSize.Point = _structure.WindowSizeOffset;

            TreeNode rootNode = new TreeNode("DuelField");
            rootNode.Tag = _structure.DuelField.RootNode;
            GenerateTree(rootNode, _structure.DuelField.RootNode);
            treeView_DuelField.Nodes.Add(rootNode);

            TreeNode rootNode2 = new TreeNode("DeckEditor");
            rootNode2.Tag = _structure.DeckEditor.RootNode;
            GenerateTree(rootNode2, _structure.DeckEditor.RootNode);
            treeView_DeckEditor.Nodes.Add(rootNode2);

            //naice card moving feature buggy as fuck
            //pictureBox_CardTest.Point = _structure.PlayerField.DeckOffset;
            //pictureBox_CardTest2.Point = _structure.EnemyField.DeckOffset;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            UpdatePreviewCheck();
        }

        private void GenerateTree(TreeNode treeNode, YuGiNode yugiNode)
        {
            foreach (YuGiNode node in yugiNode.Children)
            {
                TreeNode n = new TreeNode(node.Name);
                n.Tag = node;

                GenerateTree(n, node);
                treeNode.Nodes.Add(n);
            }
        }

        private void GenerateFileTree()
        {
            if (_data == null) return;
            treeView_Files.Nodes.Clear();

            foreach (YuGiDataEntry node in _data.Files)
            {
                TreeNode n = new TreeNode(node.FileName);
                n.Tag = node;

                treeView_Files.Nodes.Add(n);
            }
        }

        private void _structure_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //needed cause else memory explosion due to drawing garbage
            if (_loading) return;

            _timer.Enabled = false;
            _timer.Enabled = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "YuGiOh Preset|*.joey2";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(YuGiStructure));
                using (StreamReader reader = new StreamReader(new FileStream(openFileDialog.FileName, FileMode.Open)))
                {
                    _loading = true;
                    _structure.CopyValues((YuGiStructure)xmlSerializer.Deserialize(reader));
                    _loading = false;
                    UpdatePreview();

                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "YuGiOh Preset|*.joey2";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(YuGiStructure));
                using (StreamWriter writer = new StreamWriter(new FileStream(saveFileDialog.FileName, FileMode.Create)))
                {
                    xmlSerializer.Serialize(writer, _structure);
                }
            }
        }

        private void checkEmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "YuGiOh PoC Executable|*.exe";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            string fileName = openFileDialog.FileName;
            using (BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.Open)))
            {
                _loading = true;
                _structure.LoadValue(reader, true);
                _loading = false;
                UpdatePreviewCheck();
            }

            /*
            string addedLinkes = String.Empty;
            foreach (var line in YuGiValue.debugLog)
            {
                addedLinkes += line;
            }

            MessageBox.Show(addedLinkes);
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            string fileName = openFileDialog.FileName;

            if(YuGiExtendedMethods.IsPatchable(fileName) == false)
            {
                MessageBox.Show("This executable is not compatible with the patcher.");
                return;
            }

            using (BinaryWriter writer = new BinaryWriter(new FileStream(fileName, FileMode.Open)))
            {
                _structure.PatchValue(writer);
            }

            DialogResult dialogResult = MessageBox.Show("Do you want to test the new patch?", "Patch successful!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                YuGi.Launcher.YuGiGameInit.startYuGi(fileName);
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }

        }   

        private void UpdatePreview()
        {
            if (_structure.WindowSizeOffset.X.ValueInt32 == 0 || _structure.WindowSizeOffset.Y.ValueInt32 == 0) return;
            Bitmap bitmap = new Bitmap(_structure.WindowSizeOffset.X.ValueInt32, _structure.WindowSizeOffset.Y.ValueInt32);        

            using (Graphics graphic = Graphics.FromImage(bitmap))
            {
                graphic.Clear(Color.White);

                graphic.DrawImage(_background, new Rectangle(230, 0, _structure.WindowSizeOffset.X.ValueInt32 - 230, _structure.WindowSizeOffset.Y.ValueInt32), new Rectangle(0, 0, _background.Width, _background.Height), GraphicsUnit.Pixel);

                DrawField(graphic, _structure.DuelField.RootNode.GetNode<YuGiNode>("PlayerField"), _structure.CardSize, false, _structure.Rotate);
                DrawField(graphic, _structure.DuelField.RootNode.GetNode<YuGiNode>("EnemyField"), _structure.CardSize, true, _structure.Rotate);

                graphic.DrawImage(Resources.detail, 0, 0);
            }

            pictureBox_Preview.Image = bitmap;

            //Field resize based on loaded values
            this.Width = splitContainer1.Panel1.Width + 32 + _structure.WindowSizeOffset.X.ValueInt32;
            this.Height = 72 + _structure.WindowSizeOffset.Y.ValueInt32;
        }

        private void DrawField(Graphics graphic, YuGiNode node, PointEx cardSize, bool top, bool rotate)
        {
            //570 field size
            //800 window size
            //230 left side menu size

            Bitmap card = Properties.Resources.card_ura;
            Bitmap removedSymbol = Properties.Resources.jyogai_ai1;
            Bitmap removedSymbolEnemy = Properties.Resources.jyogai_ji1;
            Bitmap deckCardZone = Properties.Resources.hand_deck;

            Bitmap deckDepth = GenerateDeckBitmap();
            Bitmap deckShadow = GenerateDeckShadowBitmap();

            //offset to the center from the cards edge
            int centerOffsetX = cardSize.X / 2;
            int centerOffsetY = cardSize.Y / 2;

            int centerRemovedOffsetX = removedSymbol.Width / 2;
            int centerRemovedOffsetY = removedSymbol.Height / 2;
            int centerHandOffsetOffsetX = deckCardZone.Width / 2;
            int centerHandOffsetOffsetY = deckCardZone.Height / 2;

            //removing the draw method extra pixel
            Point cardSizePoint = new Point(cardSize.X - 1, cardSize.Y - 1);

            YuGiPoint deckOffset = node.GetNode<YuGiPoint>("Deck");
            DrawDeck(graphic, card, deckShadow, deckDepth, new Rectangle(deckOffset.X.ValueInt32 - centerOffsetX, deckOffset.Y.ValueInt32 - centerOffsetY, cardSizePoint.X, cardSizePoint.Y), top);

            YuGiPoint graveyardOffset = node.GetNode<YuGiPoint>("Graveyard");
            YuGiPoint fusionOffset = node.GetNode<YuGiPoint>("Fusion");
            YuGiPoint fieldEffectOffset = node.GetNode<YuGiPoint>("Field Effect Card");
            YuGiPoint removedFromGameOffset = node.GetNode<YuGiPoint>("Removed From Game");
            YuGiPoint handOffset = node.GetNode<YuGiPoint>("Hand");
            if (top)
            {
                DrawCard(graphic, card, new Rectangle(graveyardOffset.X.ValueInt32 - centerOffsetX, graveyardOffset.Y.ValueInt32 - centerOffsetY, cardSizePoint.X, cardSizePoint.Y), 180);
                DrawCard(graphic, card, new Rectangle(fusionOffset.X.ValueInt32 - centerOffsetX, fusionOffset.Y.ValueInt32 - centerOffsetY, cardSizePoint.X, cardSizePoint.Y), 180);
                DrawCard(graphic, card, new Rectangle(fieldEffectOffset.X.ValueInt32 - centerOffsetX, fieldEffectOffset.Y.ValueInt32 - centerOffsetY, cardSizePoint.X, cardSizePoint.Y), 180);
                graphic.DrawImage(removedSymbol, new Rectangle(removedFromGameOffset.X.ValueInt32 - centerRemovedOffsetX, removedFromGameOffset.Y.ValueInt32 - centerRemovedOffsetY, removedSymbol.Width, removedSymbol.Height), new Rectangle(0, 0, removedSymbol.Width, removedSymbol.Height), GraphicsUnit.Pixel);
                graphic.DrawImage(deckCardZone, new Rectangle(handOffset.X.ValueInt32 - centerHandOffsetOffsetX, (handOffset.Y.ValueInt32 - centerHandOffsetOffsetY) + 19, deckCardZone.Width, deckCardZone.Height), new Rectangle(0, 0, deckCardZone.Width, deckCardZone.Height), GraphicsUnit.Pixel);
            }
            else
            {
                DrawCard(graphic, card, new Rectangle(graveyardOffset.X.ValueInt32 - centerOffsetX, graveyardOffset.Y.ValueInt32 - centerOffsetY, cardSizePoint.X, cardSizePoint.Y), 0);
                DrawCard(graphic, card, new Rectangle(fusionOffset.X.ValueInt32 - centerOffsetX, fusionOffset.Y.ValueInt32 - centerOffsetY, cardSizePoint.X, cardSizePoint.Y), 0);
                DrawCard(graphic, card, new Rectangle(fieldEffectOffset.X.ValueInt32 - centerOffsetX, fieldEffectOffset.Y.ValueInt32 - centerOffsetY, cardSizePoint.X, cardSizePoint.Y), 0);
                graphic.DrawImage(removedSymbolEnemy, new Rectangle(removedFromGameOffset.X.ValueInt32 - centerRemovedOffsetX, removedFromGameOffset.Y.ValueInt32 - centerRemovedOffsetY, removedSymbolEnemy.Width, removedSymbolEnemy.Height), new Rectangle(0, 0, removedSymbolEnemy.Width, removedSymbolEnemy.Height), GraphicsUnit.Pixel);
                graphic.DrawImage(deckCardZone, new Rectangle(handOffset.X.ValueInt32 - centerHandOffsetOffsetX, (handOffset.Y.ValueInt32 - centerHandOffsetOffsetY) - 19, deckCardZone.Width, deckCardZone.Height), new Rectangle(0, 0, deckCardZone.Width, deckCardZone.Height), GraphicsUnit.Pixel);
            }

            for (int i = 0; i < 5; i++)
            {
                YuGiPointBundle monsterCards = node.GetNode<YuGiPointBundle>("Monster Cards");
                YuGiPointBundle magicCards = node.GetNode<YuGiPointBundle>("Spell/Trap Cards");
                YuGiPoint monsterCardStart = (YuGiPoint)monsterCards.Children[0];
                YuGiPoint magicCardStart = (YuGiPoint)magicCards.Children[0];

                if (rotate)
                {
                    Rectangle rect = new Rectangle(monsterCardStart.X.ValueInt32 + i * monsterCards.Gap - centerOffsetX, monsterCardStart.Y.ValueInt32 - centerOffsetY, cardSizePoint.X, cardSizePoint.Y);
                    if (top)
                    {
                        DrawCard(graphic, card, rect, 270);
                    }
                    else
                    {
                        DrawCard(graphic, card, rect, 90);
                    }

                }
                else
                {
                    if (top)
                    {
                        DrawCard(graphic, card, new Rectangle(monsterCardStart.X.ValueInt32 + i * monsterCards.Gap - centerOffsetX, monsterCardStart.Y.ValueInt32 - centerOffsetY, cardSizePoint.X, cardSizePoint.Y), 180);
                    }
                    else
                    {
                        DrawCard(graphic, card, new Rectangle(monsterCardStart.X.ValueInt32 + i * monsterCards.Gap - centerOffsetX, monsterCardStart.Y.ValueInt32 - centerOffsetY, cardSizePoint.X, cardSizePoint.Y), 0);
                    }
                }


                if (top)
                {
                    DrawCard(graphic, card, new Rectangle(magicCardStart.X.ValueInt32 + i * magicCards.Gap - centerOffsetX, magicCardStart.Y.ValueInt32 - centerOffsetY, cardSizePoint.X - 1, cardSizePoint.Y - 1), 180);
                }
                else
                {
                    DrawCard(graphic, card, new Rectangle(magicCardStart.X.ValueInt32 + i * magicCards.Gap - centerOffsetX, magicCardStart.Y.ValueInt32 - centerOffsetY, cardSizePoint.X - 1, cardSizePoint.Y - 1), 0);
                }
            }
        }

        private void DrawDeck(Graphics graphic, Bitmap cardBitmap, Bitmap deckShadow, Bitmap deckDepth, Rectangle rectangle, bool top)
        {
            Bitmap deckShadowAlpha = new Bitmap(deckShadow.Width, deckDepth.Height);
            using (Graphics g = Graphics.FromImage(deckShadowAlpha))
            {
                g.Clear(Color.FromArgb(0, 0, 0, 0));

                for (int i = 0; i < deckShadow.Width; i++)
                {
                    for (int j = 0; j < deckShadow.Height; j++)
                    {
                        if (deckShadow.GetPixel(i, j) == Color.FromArgb(255, 255, 255, 255)) continue;
                        deckShadowAlpha.SetPixel(i, j, Color.FromArgb((int)(255 * deckShadow.GetPixel(i, j).GetBrightness() * 5), deckShadow.GetPixel(i, j)));
                    }
                }
            }

            Bitmap deckDepthAlpha = new Bitmap(deckDepth.Width / 2, deckDepth.Height);
            using (Graphics g = Graphics.FromImage(deckDepthAlpha))
            {
                g.Clear(Color.FromArgb(0, 0, 0, 0));

                int startIndex = 0;
                if (top)
                {
                    for (int i = deckDepth.Width / 2; i < deckDepth.Width; i++)
                    {
                        for (int j = 0; j < deckDepth.Height; j++)
                        {
                            if (deckDepth.GetPixel(i, j) == Color.FromArgb(0, 255, 0)) continue;
                            deckDepthAlpha.SetPixel(i - deckDepth.Width / 2, j, deckDepth.GetPixel(i, j));
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < deckDepth.Width / 2; i++)
                    {
                        for (int j = 0; j < deckDepth.Height; j++)
                        {
                            if (deckDepth.GetPixel(i, j) == Color.FromArgb(0, 255, 0)) continue;
                            deckDepthAlpha.SetPixel(i, j, deckDepth.GetPixel(i, j));
                        }
                    }
                }
            }


            using (Matrix matrix = new Matrix())
            {
                if (top)
                {
                    graphic.DrawImage(deckShadowAlpha, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + 10, rectangle.Height + 10), new Rectangle(0, 0, deckShadowAlpha.Width, deckShadowAlpha.Height), GraphicsUnit.Pixel);

                    matrix.Invert();
                    graphic.Transform = matrix;
                    graphic.DrawImage(deckDepthAlpha, new Rectangle(rectangle.X - 10, rectangle.Y - 10, rectangle.Width + 10, rectangle.Height + 10), new Rectangle(0, 0, deckDepthAlpha.Width, deckDepthAlpha.Height), GraphicsUnit.Pixel);

                    matrix.Invert();
                    matrix.RotateAt(180, new PointF(rectangle.Left + (rectangle.Width / 2), rectangle.Top + (rectangle.Height / 2)));
                    graphic.Transform = matrix;
                    graphic.DrawImage(cardBitmap, new Rectangle(rectangle.X + 9, rectangle.Y + 9, rectangle.Width, rectangle.Height), new Rectangle(0, 0, cardBitmap.Width, cardBitmap.Height), GraphicsUnit.Pixel);
                    graphic.ResetTransform();
                }
                else
                {
                    graphic.DrawImage(deckShadowAlpha, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + 10, rectangle.Height + 10), new Rectangle(0, 0, deckShadowAlpha.Width, deckShadowAlpha.Height), GraphicsUnit.Pixel);
                    graphic.DrawImage(deckDepthAlpha, new Rectangle(rectangle.X, rectangle.Y - 10, rectangle.Width + 10, rectangle.Height + 10), new Rectangle(0, 0, deckDepthAlpha.Width, deckDepthAlpha.Height), GraphicsUnit.Pixel);
                    graphic.DrawImage(cardBitmap, new Rectangle(rectangle.X + 10, rectangle.Y - 10, rectangle.Width, rectangle.Height), new Rectangle(0, 0, cardBitmap.Width, cardBitmap.Height), GraphicsUnit.Pixel);
                }   
            }
        }

        private void DrawCard(Graphics graphic, Bitmap cardBitmap, Rectangle rectangle, float rotation)
        {
            using (Matrix matrix = new Matrix())
            {
                matrix.RotateAt(rotation, new PointF(rectangle.Left + (rectangle.Width / 2), rectangle.Top + (rectangle.Height / 2)));
                graphic.Transform = matrix;
                graphic.DrawImage(cardBitmap, rectangle, new Rectangle(0, 0, cardBitmap.Width, cardBitmap.Height), GraphicsUnit.Pixel);
                graphic.ResetTransform();
            }
        }



        private void checkBox_Rotate_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreviewCheck();
        }

        private void pictureBox_Preview_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                cm.MenuItems.Add("Save as field.png", OnSavePreviewClick);
                cm.Show(pictureBox_Preview, e.Location);
            }
        }

        private void OnSavePreviewClick(object sender, EventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Portable Network Graphics|*.png";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //saveFileDialog.FileName

                Bitmap outputBitmap = new Bitmap(pictureBox_Preview.Image.Width - 230, pictureBox_Preview.Image.Height);

                using (Graphics graphic = Graphics.FromImage(outputBitmap))
                {
                    graphic.DrawImage(pictureBox_Preview.Image, new Rectangle(0, 0, outputBitmap.Width, outputBitmap.Height), new Rectangle(230, 0, pictureBox_Preview.Image.Width - 230, pictureBox_Preview.Image.Height), GraphicsUnit.Pixel);
                }

                outputBitmap.Save(saveFileDialog.FileName);
            }
        }

        private void generateImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateImages();
        }

        private void GenerateImages()
        {
            //Card Size: 50x72, 102x152, 200x290
            //deck.bmp Size: 120x82, 224x162, 420x300 (width = card.width * 2 + 20, height = card.height + 10)


            //deck.bmp
            Bitmap deckBitmap = GenerateDeckBitmap();

            ImageWindow imageWindowDeck = new ImageWindow(deckBitmap);
            imageWindowDeck.Show();

            //grave.bmp
            Bitmap graveBitmap = GenerateGraveBitmap();

            ImageWindow imageWindowGrave = new ImageWindow(graveBitmap);
            imageWindowGrave.Show();


            //Card Size: 50x72, 102x152, 200x290
            //deck_shadow.bmp Size: 60x82, 112x162, 210x300 (width = card.width + 10, height = card.height + 10)

            //deck_shadow.bmp
            Bitmap deckShadowBitmap = GenerateDeckShadowBitmap();

            ImageWindow imageWindowDeckShadow = new ImageWindow(deckShadowBitmap);
            imageWindowDeckShadow.Show();


        }

        private Bitmap GenerateDeckShadowBitmap()
        {
            Color alphaColor = Color.FromArgb(255, 255, 255);
            Color shadowColor = Color.FromArgb(45, 30, 4);

            Bitmap deckShadowBitmap = new Bitmap(_structure.CardSize.X + 10, _structure.CardSize.Y + 10);

            using (Graphics graphic = Graphics.FromImage(deckShadowBitmap))
            {
                graphic.Clear(alphaColor);
                Pen pen = new Pen(shadowColor);

                for (int i = 0; i < 10; i++)
                {
                    graphic.DrawLine(pen, i + 1, deckShadowBitmap.Height - (10 - i), deckShadowBitmap.Width - 1, deckShadowBitmap.Height - (10 - i));
                    graphic.DrawLine(pen, deckShadowBitmap.Width - (10 - i), i + 1, deckShadowBitmap.Width - (10 - i), deckShadowBitmap.Height - 1);
                }
            }

            return deckShadowBitmap;
        }

        private Bitmap GenerateDeckBitmap()
        {
            Bitmap deckBitmap = new Bitmap(_structure.CardSize.X * 2 + 20, _structure.CardSize.Y + 10);

            Color alphaColor = Color.FromArgb(0, 255, 0);

            Color leftSideColorLight = Color.FromArgb(190, 152, 104);
            Color leftSideColorLightEnd = Color.FromArgb(234, 200, 157);
            Color leftSideColorDark = Color.FromArgb(128, 94, 51);
            Color leftSideColorDarkEnd = Color.FromArgb(190, 152, 104); //dark end same as light start

            Color rightSideColorLight = Color.FromArgb(112, 75, 28);
            Color rightSideColorLightEnd = Color.FromArgb(160, 116, 60);
            Color rightSideColorDark = Color.FromArgb(62, 39, 9);
            Color rightSideColorDarkEnd = Color.FromArgb(112, 75, 28); //dark end same as light start

            Color bottomColorLight = Color.FromArgb(85, 61, 26);
            Color bottomColorDark = Color.FromArgb(0, 0, 0);
            Color bottomColorEnd = Color.FromArgb(39, 27, 10);

            using (Graphics graphic = Graphics.FromImage(deckBitmap))
            {
                graphic.Clear(alphaColor);

                Brush brushLeftSideLight = new LinearGradientBrush(new Point(0, 1), new Point(0, deckBitmap.Height - 1), leftSideColorLightEnd, leftSideColorLight);
                Brush brushLeftSideDark = new LinearGradientBrush(new Point(0, 1), new Point(0, deckBitmap.Height - 1), leftSideColorDarkEnd, leftSideColorDark);
                Brush brushLeftBottomLight = new LinearGradientBrush(new Point(0, 0), new Point(deckBitmap.Width / 2, 0), bottomColorLight, bottomColorEnd);
                Brush brushLeftBottomDark = new LinearGradientBrush(new Point(0, 0), new Point(deckBitmap.Width / 2, 0), bottomColorDark, bottomColorEnd);

                Brush brushRightSideLight = new LinearGradientBrush(new Point(0, 1), new Point(0, deckBitmap.Height - 1), rightSideColorLightEnd, rightSideColorLight);
                Brush brushRightSideDark = new LinearGradientBrush(new Point(0, 1), new Point(0, deckBitmap.Height - 1), rightSideColorDarkEnd, rightSideColorDark);
                Brush brushRightBottomLight = new LinearGradientBrush(new Point(deckBitmap.Width / 2, 0), new Point(deckBitmap.Width, 0), bottomColorEnd, bottomColorLight);
                Brush brushRightBottomDark = new LinearGradientBrush(new Point(deckBitmap.Width / 2, 0), new Point(deckBitmap.Width, 0), bottomColorEnd, bottomColorDark);

                Pen penLeftSideLight = new Pen(brushLeftSideLight);
                Pen penLeftSideDark = new Pen(brushLeftSideDark);
                Pen penLeftBottomLight = new Pen(brushLeftBottomLight);
                Pen penLeftBottomDark = new Pen(brushLeftBottomDark);

                Pen penRightSideLight = new Pen(brushRightSideLight);
                Pen penRightSideDark = new Pen(brushRightSideDark);
                Pen penRightBottomLight = new Pen(brushRightBottomLight);
                Pen penRightBottomDark = new Pen(brushRightBottomDark);


                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 == 0)
                    {
                        graphic.DrawLine(penLeftSideLight, i, 10 - i, i, deckBitmap.Height - 1);
                    }
                    else
                    {
                        graphic.DrawLine(penLeftSideDark, i, 10 - i, i, deckBitmap.Height - 1);
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 != 0)
                    {
                        graphic.DrawLine(penLeftBottomLight, i, deckBitmap.Height - i - 1, deckBitmap.Width / 2 - (11 - i), deckBitmap.Height - i - 1);
                    }
                    else
                    {
                        graphic.DrawLine(penLeftBottomDark, i, deckBitmap.Height - i - 1, deckBitmap.Width / 2 - (11 - i), deckBitmap.Height - i - 1);
                    }
                }


                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 == 0)
                    {
                        graphic.DrawLine(penRightSideLight, deckBitmap.Width - i - 1, 10 - i, deckBitmap.Width - i - 1, deckBitmap.Height - 1);
                    }
                    else
                    {
                        graphic.DrawLine(penRightSideDark, deckBitmap.Width - i - 1, 10 - i, deckBitmap.Width - i - 1, deckBitmap.Height - 1);
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 != 0)
                    {
                        graphic.DrawLine(penRightBottomLight, deckBitmap.Width / 2 - i + 10, deckBitmap.Height - i - 1, deckBitmap.Width - i - 1, deckBitmap.Height - i - 1);
                    }
                    else
                    {
                        graphic.DrawLine(penRightBottomDark, deckBitmap.Width / 2 - i + 10, deckBitmap.Height - i - 1, deckBitmap.Width - i - 1, deckBitmap.Height - i - 1);
                    }
                }

            }
            return deckBitmap;
        }

        private Bitmap GenerateGraveBitmap()
        {
            Bitmap deckBitmap = new Bitmap(_structure.CardSize.X * 2 + 20, _structure.CardSize.Y + 10);

            Color alphaColor = Color.FromArgb(0, 255, 0);

            Color leftSideColorLight = Color.FromArgb(80, 77, 111);
            Color leftSideColorLightEnd = Color.FromArgb(132, 128, 168);
            Color leftSideColorDark = Color.FromArgb(39, 38, 59);
            Color leftSideColorDarkEnd = Color.FromArgb(80, 77, 111); //dark end same as light start

            Color rightSideColorLight = Color.FromArgb(53, 51, 74);
            Color rightSideColorLightEnd = Color.FromArgb(88, 85, 112);
            Color rightSideColorDark = Color.FromArgb(26, 25, 39);
            Color rightSideColorDarkEnd = Color.FromArgb(53, 51, 74); //dark end same as light start

            Color bottomColorLight = Color.FromArgb(44, 42, 58);
            Color bottomColorDark = Color.FromArgb(0, 0, 0);
            Color bottomColorEnd = Color.FromArgb(19, 18, 26);

            using (Graphics graphic = Graphics.FromImage(deckBitmap))
            {
                graphic.Clear(alphaColor);

                Brush brushLeftSideLight = new LinearGradientBrush(new Point(0, 1), new Point(0, deckBitmap.Height - 1), leftSideColorLightEnd, leftSideColorLight);
                Brush brushLeftSideDark = new LinearGradientBrush(new Point(0, 1), new Point(0, deckBitmap.Height - 1), leftSideColorDarkEnd, leftSideColorDark);
                Brush brushLeftBottomLight = new LinearGradientBrush(new Point(0, 0), new Point(deckBitmap.Width / 2, 0), bottomColorLight, bottomColorEnd);
                Brush brushLeftBottomDark = new LinearGradientBrush(new Point(0, 0), new Point(deckBitmap.Width / 2, 0), bottomColorDark, bottomColorEnd);

                Brush brushRightSideLight = new LinearGradientBrush(new Point(0, 1), new Point(0, deckBitmap.Height - 1), rightSideColorLightEnd, rightSideColorLight);
                Brush brushRightSideDark = new LinearGradientBrush(new Point(0, 1), new Point(0, deckBitmap.Height - 1), rightSideColorDarkEnd, rightSideColorDark);
                Brush brushRightBottomLight = new LinearGradientBrush(new Point(deckBitmap.Width / 2, 0), new Point(deckBitmap.Width, 0), bottomColorEnd, bottomColorLight);
                Brush brushRightBottomDark = new LinearGradientBrush(new Point(deckBitmap.Width / 2, 0), new Point(deckBitmap.Width, 0), bottomColorEnd, bottomColorDark);

                Pen penLeftSideLight = new Pen(brushLeftSideLight);
                Pen penLeftSideDark = new Pen(brushLeftSideDark);
                Pen penLeftBottomLight = new Pen(brushLeftBottomLight);
                Pen penLeftBottomDark = new Pen(brushLeftBottomDark);

                Pen penRightSideLight = new Pen(brushRightSideLight);
                Pen penRightSideDark = new Pen(brushRightSideDark);
                Pen penRightBottomLight = new Pen(brushRightBottomLight);
                Pen penRightBottomDark = new Pen(brushRightBottomDark);


                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 == 0)
                    {
                        graphic.DrawLine(penLeftSideLight, i, 10 - i, i, deckBitmap.Height - 1);
                    }
                    else
                    {
                        graphic.DrawLine(penLeftSideDark, i, 10 - i, i, deckBitmap.Height - 1);
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 != 0)
                    {
                        graphic.DrawLine(penLeftBottomLight, i, deckBitmap.Height - i - 1, deckBitmap.Width / 2 - (11 - i), deckBitmap.Height - i - 1);
                    }
                    else
                    {
                        graphic.DrawLine(penLeftBottomDark, i, deckBitmap.Height - i - 1, deckBitmap.Width / 2 - (11 - i), deckBitmap.Height - i - 1);
                    }
                }


                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 == 0)
                    {
                        graphic.DrawLine(penRightSideLight, deckBitmap.Width - i - 1, 10 - i, deckBitmap.Width - i - 1, deckBitmap.Height - 1);
                    }
                    else
                    {
                        graphic.DrawLine(penRightSideDark, deckBitmap.Width - i - 1, 10 - i, deckBitmap.Width - i - 1, deckBitmap.Height - 1);
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 != 0)
                    {
                        graphic.DrawLine(penRightBottomLight, deckBitmap.Width / 2 - i + 10, deckBitmap.Height - i - 1, deckBitmap.Width - i - 1, deckBitmap.Height - i - 1);
                    }
                    else
                    {
                        graphic.DrawLine(penRightBottomDark, deckBitmap.Width / 2 - i + 10, deckBitmap.Height - i - 1, deckBitmap.Width - i - 1, deckBitmap.Height - i - 1);
                    }
                }

            }
            return deckBitmap;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            UpdatePreview(); //Update for default values
        }

        private void button_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bitmap (*.bmp)|*.bmp";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            textBox_FieldBackground.Text = openFileDialog.FileName;
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox_FieldBackground.Text))
            {
                textBox_FieldBackground.Text = "";
                _background = Resources.fie_normal;
                UpdatePreview();
                return;
            }
            _background = new Bitmap(textBox_FieldBackground.Text);
            UpdatePreview();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Yu-Gi-Oh Data File (*.dat)|*.dat";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            YuGiData data = new YuGiData(openFileDialog.FileName);
            data.LoadFileList();
        }

        private void dankYGAToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MyOpenFileDialogControl openFileDialog = new MyOpenFileDialogControl();

            //openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog(this) == DialogResult.OK){
                //lblFilePath.Text = openDialog.MSDialog.FileName;
            }
            else
            {
                return;
            }

            CustomControls.FolderSelectDialog saveFileDialog = new CustomControls.FolderSelectDialog();
            if (!saveFileDialog.ShowDialog()) return;

            foreach (var item in openFileDialog.FileDlgFileNames)
            {
                YGAFile file = new YGAFile(item);
                file.Decompress(saveFileDialog.FileName + @"\" + Path.GetFileNameWithoutExtension(item) + ".png");
            }
        }

        private void dankToYGAToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            openFileDialog.Filter = "Portable Network Graphic (*.png)|*.png";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            CustomControls.FolderSelectDialog saveFileDialog = new CustomControls.FolderSelectDialog();
            if (!saveFileDialog.ShowDialog()) return;

            foreach (var item in openFileDialog.FileNames)
            {
                YGAFile.ConvertToYGA(item, saveFileDialog.FileName + @"\" + Path.GetFileNameWithoutExtension(item) + ".yga");
            }
        }

        private void lZZSToDankToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            using (BinaryReader reader = new BinaryReader(new FileStream(openFileDialog.FileName, FileMode.Open)))
            {
                byte[] buffer = new byte[reader.BaseStream.Length];
                reader.Read(buffer, 0, buffer.Length);

                byte[] output = YuGiLZSS.Decompress(buffer);

                using (BinaryWriter writer = new BinaryWriter(new FileStream(openFileDialog.FileName + ".OUT", FileMode.Create)))
                {
                    writer.Write(output);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void runToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            YuGiDebugger debug = YuGiDebugger.Create(_structure);
        }

        private void treeView_DuelField_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panel_DuelField_ValueEditor.Controls.Clear();
            if (e.Node.Tag.GetType() == typeof(YuGiPoint))
            {
                PointUserControl userControl = new PointUserControl();
                userControl.Point = (YuGiPoint)e.Node.Tag;
                panel_DuelField_ValueEditor.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
            }
            if (e.Node.Tag.GetType() == typeof(YuGiPointBundle))
            {
                PointBundleUserControl userControl = new PointBundleUserControl();
                userControl.PointBundle = (YuGiPointBundle)e.Node.Tag;
                panel_DuelField_ValueEditor.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
            }
            if (e.Node.Tag.GetType() == typeof(YuGiValue))
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Text = ((YuGiValue)e.Node.Tag).Name;
                ValueUserControl userControl = new ValueUserControl();
                userControl.Value = (YuGiValue)e.Node.Tag;
                groupBox.Controls.Add(userControl);
                panel_DuelField_ValueEditor.Controls.Add(groupBox);
                groupBox.Dock = DockStyle.Fill;
                userControl.Dock = DockStyle.Fill;
            }
            if (e.Node.Tag.GetType() == typeof(YuGiRectangle))
            {
                RectangleUserControl userControl = new RectangleUserControl();
                userControl.Rectangle = (YuGiRectangle)e.Node.Tag;
                panel_DuelField_ValueEditor.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
            }
            if (e.Node.Tag.GetType() == typeof(YuGiValueList))
            {
                ValueListUserControl userControl = new ValueListUserControl();
                userControl.Value = (YuGiValueList)e.Node.Tag;
                panel_DuelField_ValueEditor.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
            }
        }

        private void treeView_DeckEditor_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panel_DeckEditor_ValueEditor.Controls.Clear();
            if (e.Node.Tag.GetType() == typeof(YuGiPoint))
            {
                PointUserControl userControl = new PointUserControl();
                userControl.Point = (YuGiPoint)e.Node.Tag;
                panel_DeckEditor_ValueEditor.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
            }
            if (e.Node.Tag.GetType() == typeof(YuGiPointBundle))
            {
                PointBundleUserControl userControl = new PointBundleUserControl();
                userControl.PointBundle = (YuGiPointBundle)e.Node.Tag;
                panel_DeckEditor_ValueEditor.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
            }
            if (e.Node.Tag.GetType() == typeof(YuGiValue))
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Text = ((YuGiValue)e.Node.Tag).Name;
                ValueUserControl userControl = new ValueUserControl();
                userControl.Value = (YuGiValue)e.Node.Tag;
                groupBox.Controls.Add(userControl);
                panel_DeckEditor_ValueEditor.Controls.Add(groupBox);
                groupBox.Dock = DockStyle.Fill;
                userControl.Dock = DockStyle.Fill;
            }
            if (e.Node.Tag.GetType() == typeof(YuGiRectangle))
            {
                RectangleUserControl userControl = new RectangleUserControl();
                userControl.Rectangle = (YuGiRectangle)e.Node.Tag;
                panel_DeckEditor_ValueEditor.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
            }
            if (e.Node.Tag.GetType() == typeof(YuGiValueList))
            {
                ValueListUserControl userControl = new ValueListUserControl();
                userControl.Value = (YuGiValueList)e.Node.Tag;
                panel_DeckEditor_ValueEditor.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePreviewCheck();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePreviewCheck();
        }

        private void UpdatePreviewCheck()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                UpdatePreview();
                return;
            }
            pictureBox_Preview.Image = null;
            richTextBox_Data.Visible = false;
            audioPlayer_Preview.Visible = false; // TODO: stop playing audio too
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lZSSDecompressRecrusiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DecompressRecrusive("*.txt");
        }

        private void lZSSDecompressRecrusiveBinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DecompressRecrusive("*.bin");
        }

        private void DecompressRecrusive(string wildcard)
        {
            FolderBrowserEx.FolderBrowserDialog selectFolderDialog = new FolderBrowserEx.FolderBrowserDialog();
            if (selectFolderDialog.ShowDialog() != DialogResult.OK) return;

            var selectedFolder = selectFolderDialog.SelectedFolder;

            // decompress txt files
            foreach (var file in Directory.EnumerateFiles(selectedFolder, wildcard, SearchOption.AllDirectories))
            {
                byte[] bufferClean;

                using (BinaryReader reader = new BinaryReader(new FileStream(file, FileMode.Open)))
                {
                    byte[] buffer = new byte[reader.BaseStream.Length];
                    reader.Read(buffer, 0, buffer.Length);

                    bufferClean = DecompressPipeline(buffer, file);
                }

                // Write to file
                using (BinaryWriter writer = new BinaryWriter(new FileStream(file, FileMode.OpenOrCreate)))
                {
                    writer.Write(bufferClean);
                }

            }
        }

        private byte[] DecompressPipeline(byte[] buffer, string filename)
        {
            bool alternativeTrim = false; // only for testing
            byte[] bufferClean;
            bool decompressFlag = false;
            
            // Some files in Yu-Gi-Oh: Online are empty placeholder (for future patches?)
            if (buffer.Length <= 0)
            {
                return buffer;
            }

            // *.bin files are a bit... special
            if (filename.Contains(".bin"))
            {
                // Identifier list: JTP: 0xFF (generic), 0xAA (dlg_), 0xFE (card_prop), 0xF0 (card_name), 0x7F (card_pack)
                // 0xAA (card_index)
                // YGO2: 0x55 (card_index)

                // Decompression file blacklist for card_id.bin (has a 0xFF flag, but is NEVER compressed!)
                if (filename.Contains("card_id")) return buffer;

                // It's "compressed" in older ver. of PoC, but not in YGOv2+
                if (filename.Contains("card_intid") && buffer[0] != 0xFF) return buffer; 
                
                // Wildcard, try to decompress them always (this was tested, but you never know)
                decompressFlag = true;
            }

            // Yu-Gi-Oh: Online 2 - Index table for strings blob (bin)
            if (filename.Contains(".idx"))
            {
                decompressFlag = true;
            }

            // Yu-Gi-Oh: Online 2 - Flag for list_card is different (JTP: 0xFF, YGO2: 0xFD)
            if (filename.Contains(".txt"))
            {
                if (filename.Contains("list_card") && buffer[0] == 0xFD) decompressFlag = true;
            }

            // Power of Chaos - Joey standard identifiers
            if (buffer[0] == 0xFF || buffer[0] == 0xDF || buffer[0] == 0x7F)
            {
                decompressFlag = true;
            }

            // 0x5F found in other Power of Chaos variants (eg. win00#.bmp in PoC - Yugi trial)
            if (buffer[0] == 0x5F)
            {
                decompressFlag = true;
            }

            // 0xAF found in Yu-Gi-Oh Online 2005+ patch dat variants (many .bmp files)
            if (buffer[0] == 0xAF)
            {
                decompressFlag = true;
            }

            // Compressed file flag check!
            if (decompressFlag)
            {
                byte[] o = YuGiLZSS.Decompress(buffer);
                int s = 0;

                // The input size equals the valid output size, when the circular buffer does not move?
                if (alternativeTrim == false)
                {
                    s = buffer.Length;
                }
                else
                {
                    // try to detect stream garbage
                    for (int i = 0; i < o.Length; i++)
                    {
                        // pre-check
                        if (o[i] == 0x00)
                        {
                            // real EOF detected, skip garbage anti-modding protection
                            if (o[i] == 0x00 && o[i + 1] == 0x00 && o[i + 2] == 0x00 && o[i + 3] == 0x00 && o[i + 4] == 0x00)
                            {
                                s = i;
                                break;
                            }
                        }
                    }
                }

                bufferClean = new byte[s];
                Array.Copy(o, bufferClean, s);
                return bufferClean;
            }
            else
            {
                return buffer; // just passtrough bytes, when flags are not there
            }
        }

        private void button_datBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "YuGi Data Container (*.dat)|*.dat";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            textBox_datPath.Text = openFileDialog.FileName;
        }

        private void button_datLoad_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox_datPath.Text))
            {
                textBox_datPath.Text = "";
                MessageBox.Show("File path is invalid!");
                return;
            }

            // Init. data object
            _data = new YuGiData(textBox_datPath.Text);
            _data.LoadFileList();

            // Generate tree for path and assign to ui
            GenerateFileTree();
        }

        private void toolStripMenuItem_AudioTest_Click(object sender, EventArgs e)
        {
            var audioTest = new AudioPlayerUserControl();
            var dummyForm = new Form();
            dummyForm.Size = new Size(350, 150);
            dummyForm.Controls.Add(audioTest);
            dummyForm.Show();
            //this.Controls.Add(dummyForm);
        }
        private void rtb_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            ((RichTextBox)sender).Height = e.NewRectangle.Height + 5;
        }

        private void treeView_Files_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = (TreeNode)e.Node;

            // Find file in data container
            var file = _data.FindFileByName(node.Text);
            var res = _data.GetDataFromEntry(file);

            // Handle casting for filetypes
            var fileType = Path.GetExtension(file.FileName);
            pictureBox_Preview.Image = null;
            audioPlayer_Preview.Visible = false;
            richTextBox_Data.Visible = false;

            // Some files are randomly compressed
            res = DecompressPipeline(res, file.FileName);

            // PNG is in YGO 2006+ builds
            if (fileType == ".bmp" || fileType == ".png")
            {
                try
                {
                    Bitmap image;
                    using (var ms = new MemoryStream(res))
                    {
                        image = new Bitmap(ms);
                    }
                    pictureBox_Preview.Image = image;
                    return;
                }
                catch (Exception)
                {
                    MessageBox.Show("File ERROR!");
                    return;
                }

            }

            if (fileType == ".yga")
            {
                YGAFile ygaFile = new YGAFile(res);
                ygaFile.Filename = file.FileName;

                pictureBox_Preview.Image = ygaFile.Decompress();
                return;
            }

            if (fileType == ".wav")
            {
                audioPlayer_Preview.Visible = true;
                audioPlayer_Preview.LoadAudioData(res, file.FileName);

                return;
            }

            // CSV is in YGO 2006+ builds
            if (fileType == ".txt" || fileType == ".csv")
            {
                var text = SHIFT_JIS.GetString(res, 0, res.Length);
                richTextBox_Data.Visible = true;
                richTextBox_Data.Text = text;
                return;
            }

            MessageBox.Show("Prevew for this file is unsupported yet!");
        }

        private void openToolStrip_CPackEdit_Click(object sender, EventArgs e)
        {
            var dummyForm = new CardPackEdit();
            //dummyForm.Size = new Size(350, 150);
            //dummyForm.Controls.Add(audioTest);
            dummyForm.Show();
        }

        #region COPYPASTA_EXPORT_BTN_MESS
        private void button_ExportFile_Click(object sender, EventArgs e)
        {
            var node = (TreeNode)treeView_Files.SelectedNode;

            // Find file in data container
            var file = _data.FindFileByName(node.Text);
            var res = _data.GetDataFromEntry(file);
            var fileType = Path.GetExtension(file.FileName);
            var fileName = Path.GetFileName(file.FileName);

            byte[] exportBuffer = DecompressPipeline(res, file.FileName);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (BinaryWriter writer = new BinaryWriter(new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate)))
                {
                    writer.Write(exportBuffer);
                }
            }
        }
        private void button_ExportFiles_Click(object sender, EventArgs e)
        {
            FolderBrowserEx.FolderBrowserDialog selectFolderDialog = new FolderBrowserEx.FolderBrowserDialog();
            if (selectFolderDialog.ShowDialog() != DialogResult.OK) return;

            var selectedFolder = selectFolderDialog.SelectedFolder;

            foreach (var file in _data.Files)
            {
                var res = _data.GetDataFromEntry(file);
                byte[] exportBuffer = DecompressPipeline(res, file.FileName);
                var fileType = Path.GetExtension(file.FileName);

                var filePath = selectedFolder + "\\" + file.FileName;
                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (BinaryWriter writer = new BinaryWriter(new FileStream(filePath, FileMode.OpenOrCreate)))
                {
                    writer.Write(exportBuffer);
                }
            }
        }

        private void button_ExportFilesRaw_Click(object sender, EventArgs e)
        {
            FolderBrowserEx.FolderBrowserDialog selectFolderDialog = new FolderBrowserEx.FolderBrowserDialog();
            if (selectFolderDialog.ShowDialog() != DialogResult.OK) return;

            var selectedFolder = selectFolderDialog.SelectedFolder;

            foreach (var file in _data.Files)
            {
                var res = _data.GetDataFromEntry(file);
                byte[] exportBuffer = res;
                var fileType = Path.GetExtension(file.FileName);

                var filePath = selectedFolder + "\\" + file.FileName;
                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (BinaryWriter writer = new BinaryWriter(new FileStream(filePath, FileMode.OpenOrCreate)))
                {
                    writer.Write(exportBuffer);
                }
            }
        }

        private void button_ExportFileRaw_Click(object sender, EventArgs e)
        {
            var node = (TreeNode)treeView_Files.SelectedNode;

            // Find file in data container
            var file = _data.FindFileByName(node.Text);
            var res = _data.GetDataFromEntry(file);
            var fileType = Path.GetExtension(file.FileName);
            var fileName = Path.GetFileName(file.FileName);

            byte[] exportBuffer = res;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (BinaryWriter writer = new BinaryWriter(new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate)))
                {
                    writer.Write(exportBuffer);
                }
            }
        }
        #endregion

        private void cardsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
