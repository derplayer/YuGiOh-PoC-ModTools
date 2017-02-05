using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOh_PoC_Patcher.YuGi;
using YuGiOh_PoC_Patcher.YuGi.Values;

namespace YuGiOh_PoC_Patcher
{
    public class PictureBoxEx : PictureBox
    {
        private YuGiPoint _point;

        public bool Selected { get; set; }
        public Point MouseOffset { get; set; }

        public YuGiPoint Point
        {
            get { return _point; }
            set
            {
                _point = value;
                UpdateBinding();
            }
        }


        public PictureBoxEx()
        {
            MouseLeave += PictureBoxEx_MouseLeave;
            MouseClick += PictureBoxEx_MouseClick;
            MouseMove += PictureBoxEx_MouseMove;

            ParentChanged += PictureBoxEx_ParentChanged;
        }

        private void PictureBoxEx_MouseLeave(object sender, EventArgs e)
        {
            if (!Selected) return;

            Selected = false;
            Point.X.ValueInt32 = Left + Width / 2;
            Point.Y.ValueInt32 = Top + Height / 2;
        }

        private void UpdateBinding()
        {
            if (Point == null) return;

            Point.PropertyChanged += Point_PropertyChanged;
        }

        private void Point_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Selected) return;
            Left = Point.X.ValueInt32 + Width / 2;
            Top = Point.Y.ValueInt32 + Height / 2;
        }

        private void PictureBoxEx_ParentChanged(object sender, EventArgs e)
        {
            Parent.MouseMove += Parent_MouseMove;

            
        }

        private void Parent_MouseMove(object sender, MouseEventArgs e)
        {
            if (Selected)
            {
                Left = e.X - MouseOffset.X;
                Top = e.Y - MouseOffset.Y;
            }
        }

        private void PictureBoxEx_MouseClick(object sender, MouseEventArgs e)
        {
            if (Selected)
            {
                Point.X.ValueInt32 = Left + Width / 2;
                Point.Y.ValueInt32 = Top + Height / 2;

                Selected = false;
                return;
            }
            Selected = true;
            MouseOffset = e.Location;
        }


        private void PictureBoxEx_MouseMove(object sender, MouseEventArgs e)
        {
            if (Selected)
            {
                if (e.X > MouseOffset.X)
                {
                    Left += e.X - MouseOffset.X;
                }
                else
                {
                    Left -= MouseOffset.X - e.X;
                }

                if (e.Y > MouseOffset.Y)
                {
                    Top += e.Y - MouseOffset.Y;
                }
                else
                {
                    Top -= MouseOffset.Y - e.Y;
                }
            }
        }

    }
}
