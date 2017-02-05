using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel.Design;
using System.Drawing.Text;


namespace jSkin
{

    /*
    Copyright (c) 2013 jn4kim

    Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
    The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
    
    http://jskin.codeplex.com/
    http://developert.com/
     */

    /* 
     * You can alter the Form title & ICON by simply altering the property of the Parent Form.
     * If you want to enable Run-time resize, set the Stretch Property of the jSkin 'true',
     * set the minimumsize property of the Parent Form
     * and insert following code in the constructor of the Form.
     * 
     * MaximizedBounds = Screen.GetWorkingArea(this);
     * 
     * 폼의 제목과 아이콘은 폼의 속성을 변경하면 자동으로 적용됩니다.
     * 런타임 폼 사이즈 조정을 가능케 하시려면 유저컨트롤의 Stretch속성을 true로 설정,
     * 폼의 MinimumSize 속성을 설정 후
     * 폼의 생성자부분에 다음 코드를 삽입하세요: 
     * 
     * MaximizedBounds = Screen.GetWorkingArea(this);
     * 
     */

    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))] //ControlContainer
    public partial class ctlModernBlack : UserControl
    {

        #region - Property -
        bool _Stretch = false;
        [Category("Stretch"), Description("Runtime Form Resizing")]
        public bool Stretch
        {
            get
            {
                return _Stretch;
            }
            set
            {
                _Stretch = value;
                if (value)
                    FixedSingle = false;
                this.Invalidate();
            }
        }

        bool _FixedSingle = false;
        [Category("FixedSingle"), Description("단일고정 여부 (최소화, 최대화 없음)")]
        public bool FixedSingle
        {
            get
            {
                return _FixedSingle;
            }
            set
            {
                _FixedSingle = value;
                if (value)
                    Stretch = false;
                this.Invalidate();
            }
        }
        #endregion

        #region - CheckFont -

        private bool IsFontInstalled(string fontName)
        {
            using (var testFont = new Font(fontName, 8))
            {
                return 0 == string.Compare(
                  fontName,
                  testFont.Name,
                  StringComparison.InvariantCultureIgnoreCase);
            }
        }

        #endregion

        #region - Resizing API & Const -

        [System.Runtime.InteropServices.DllImport("User32")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, UIntPtr wParam, IntPtr lParam);

        [System.Runtime.InteropServices.DllImport("User32")]
        private static extern int ReleaseCapture();

        const uint WM_SYSCOMMAND = 0x112;
        const uint SC_DRAG_RESIZEL = 0xF001;  // left resize
        const uint SC_DRAG_RESIZER = 0xF002;  // right resize
        const uint SC_DRAG_RESIZEU = 0xF003;  // upper resize
        const uint SC_DRAG_RESIZEUL = 0xF004;  // upper-left resize
        const uint SC_DRAG_RESIZEUR = 0xF005;  // upper-right resize
        const uint SC_DRAG_RESIZED = 0xF006;  // down resize
        const uint SC_DRAG_RESIZEDL = 0xF007;  // down-left resize
        const uint SC_DRAG_RESIZEDR = 0xF008;  // down-right resize
        const uint SC_DRAG_MOVE = 0xF012;  // move

        #endregion

        #region - FormSkin Setting -
        const int _layoutW = 64; // 레이아웃 이미지 사이즈 w*w

        const int _upCornerW = 10; // ↖ 너비
        const int _upH = 32; // ↑높이
        const int _downH = 10; // ↓ 높이
        const int _barH = 22; // 레이아웃 이미지 에서의 ↔ 높이

        const int _btH = 21; // 버튼 높이
        const int _btL = 113;  // 버튼의 left
        const int _btMinW = 29; //최소화버튼 너비
        const int _btMaxW = 27; //최대화버튼 너비
        const int _btExitW = 49; //종료버튼 너비

        const int _btRight = _btL - _btMinW - _btMaxW - _btExitW;

        const int _TitleBarT = 30;// 타이틀 바 높이
        #endregion

        #region - Button Variables -
        bool _isMin = false, _isMax = false, _isExit = false; // 마우스가 해당 버튼의 위치에 있는지 여부
        public bool _isMaxed = false; // 최대화가 돼있는지 여부
        bool _isReset = false; //마우스가 버튼 위치에서 벗어났을때, 한번 원상복귀 했는지 여부
        #endregion

        #region - Mouse API & Variables -
        bool _isMouseIn = false;
        bool _isClicked = false;
        int _RightX = 0;
        int _DownY = 0;
        #endregion

        #region - Private Methods -
        private void ctlSkin_Paint(object sender, PaintEventArgs e)
        {
            BufferedGraphics buff = BufferedGraphicsManager.Current.Allocate(e.Graphics, this.ClientRectangle);

            buff.Graphics.Clear(this.BackColor);
            buff.Graphics.InterpolationMode = InterpolationMode.High;

            //위
            buff.Graphics.DrawImage(pLayout.Image, new Rectangle(0, 0, _upCornerW, _upH), 0, 0, _upCornerW, _upH, GraphicsUnit.Pixel);
            buff.Graphics.DrawImage(pLayout.Image, new Rectangle(_upCornerW, 0, this.Width - 2 * _upCornerW, _upH), _upCornerW, 0, _layoutW - 2 * _upCornerW, _upH, GraphicsUnit.Pixel);
            buff.Graphics.DrawImage(pLayout.Image, new Rectangle(this.Width - _upCornerW, 0, _upCornerW, _upH), _layoutW - _upCornerW, 0, _upCornerW, _upH, GraphicsUnit.Pixel);

            //중간
            buff.Graphics.DrawImage(pLayout.Image, new Rectangle(0, _upH, _upCornerW, this.Height - _upH - _downH), 0, _upH, _upCornerW, _barH, GraphicsUnit.Pixel);
            buff.Graphics.DrawImage(pLayout.Image, new Rectangle(_upCornerW, _upH, this.Width - 2 * _upCornerW, this.Height - _upH - _downH), _upCornerW, _upH, _layoutW - 2 * _upCornerW, _barH, GraphicsUnit.Pixel);
            buff.Graphics.DrawImage(pLayout.Image, new Rectangle(this.Width - _upCornerW, _upH, _upCornerW, this.Height - _upH - _downH), _layoutW - _upCornerW, _upH, _upCornerW, _barH, GraphicsUnit.Pixel);

            //아래
            buff.Graphics.DrawImage(pLayout.Image, new Rectangle(0, this.Height - _downH, _upCornerW, _downH), 0, _layoutW - _downH, _upCornerW, _downH, GraphicsUnit.Pixel);
            buff.Graphics.DrawImage(pLayout.Image, new Rectangle(_upCornerW, this.Height - _downH, this.Width - 2 * _upCornerW, _downH), _upCornerW, _layoutW - _downH, _layoutW - 2 * _upCornerW, _downH, GraphicsUnit.Pixel);
            buff.Graphics.DrawImage(pLayout.Image, new Rectangle(this.Width - _upCornerW, this.Height - _downH, _upCornerW, _downH), _layoutW - _upCornerW, _layoutW - _downH, _upCornerW, _downH, GraphicsUnit.Pixel);

            Form frm = (this.Parent as Form);

            //아이콘 그리기
            Icon ico = new Icon(frm.Icon, new Size(16, 16));
            buff.Graphics.DrawIcon(ico, new Rectangle(7, 7, 16, 16));

            string fontName = "";
            int fontSize = 10;
            int fonttop = 7;
            FontStyle fontStyle = FontStyle.Regular;
            SolidBrush myBrush = new SolidBrush(Color.WhiteSmoke);


            if (IsFontInstalled("맑은 고딕") || IsFontInstalled("Malgun Gothic"))
            {
                fontName = "Malgun Gothic";
                fonttop = 4;
                fontSize = 10;
                fontStyle = FontStyle.Bold;
            }
            else if (IsFontInstalled("나눔고딕") || IsFontInstalled("NanumGothic"))
            {
                fontName = "NanumGothic";
                fonttop = 7;
                fontSize = 10;
                fontStyle = FontStyle.Bold;
            }
            else if (IsFontInstalled("Segoe UI Symbol"))
            {
                fontStyle = FontStyle.Bold;
                fontName = "Segoe UI Symbol";
                fonttop = 5;
                fontSize = 10;
            }
            else
            {
                fontName = DefaultFont.Name;
                fontSize = 9;
                fonttop = 10;
            }

            buff.Graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
            buff.Graphics.DrawString(frm.Text, new Font(fontName, fontSize, fontStyle), myBrush, 25, fonttop);

            //buff.Graphics.DrawString(frm.Text, new Font("맑은 고딕", fontSize, FontStyle.Bold), Brushes.WhiteSmoke, 25, 7);


            if (_isMouseIn)
            {   // 마우스 커서가 버튼 구간에 있음


                if (_RightX - _btRight <= _btExitW)
                {//종료 버튼 구간에 있음
                    _isExit = true;
                    _isMin = false;
                    _isMax = false;

                    if (_isClicked)
                        buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW + _btMaxW, 0, _btExitW, _btH), _btMinW + _btMaxW, 2 * _btH, _btExitW, _btH, GraphicsUnit.Pixel);
                    else
                        buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW + _btMaxW, 0, _btExitW, _btH), _btMinW + _btMaxW, 1 * _btH, _btExitW, _btH, GraphicsUnit.Pixel);


                    //다른버튼들은 초기화
                    if (!FixedSingle)
                    {
                        if (Stretch)
                            if (_isMaxed)
                                buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), 0, 4 * _btH, _btMaxW, _btH, GraphicsUnit.Pixel);
                            else
                                buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), _btMinW, 0, _btMaxW, _btH, GraphicsUnit.Pixel);
                        else
                            buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), _btMinW, 3 * _btH, _btMaxW, _btH, GraphicsUnit.Pixel);

                        buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL, 0, _btMinW, _btH), 0, 0, _btMinW, _btH, GraphicsUnit.Pixel);
                    }
                }
                else if (_RightX - _btRight <= _btExitW + _btMaxW)
                {//최대화 버튼 구간에 있음
                    _isMin = false;
                    _isExit = false;
                    if (!FixedSingle)
                    {
                        _isMax = true;

                        if (Stretch)
                        {
                            if (_isClicked)
                                if (_isMaxed)
                                    buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), _btMaxW * 2, 4 * _btH, _btMaxW, _btH, GraphicsUnit.Pixel);
                                else
                                    buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), _btMinW, 2 * _btH, _btMaxW, _btH, GraphicsUnit.Pixel);
                            else
                                if (_isMaxed)
                                    buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), _btMaxW, 4 * _btH, _btMaxW, _btH, GraphicsUnit.Pixel);
                                else
                                    buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), _btMinW, 1 * _btH, _btMaxW, _btH, GraphicsUnit.Pixel);
                        }
                        else
                            buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), _btMinW, 3 * _btH, _btMaxW, _btH, GraphicsUnit.Pixel);


                        //다른버튼 초기화
                        buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL, 0, _btMinW, _btH), 0, 0, _btMinW, _btH, GraphicsUnit.Pixel);
                    }
                    buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW + _btMaxW, 0, _btExitW, _btH), _btMinW + _btMaxW, 0, _btExitW, _btH, GraphicsUnit.Pixel);


                }
                else if (_RightX - Right <= _btExitW + _btMaxW + _btMinW)
                {//최소화 구간에있음
                    if (!FixedSingle)
                    {
                        _isMin = true;
                        _isMax = false;
                        _isExit = false;

                        if (_isClicked)
                            buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL, 0, _btMinW, _btH), 0, 2 * _btH, _btMinW, _btH, GraphicsUnit.Pixel);
                        else
                            buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL, 0, _btMinW, _btH), 0, 1 * _btH, _btMinW, _btH, GraphicsUnit.Pixel);

                        //다른버튼 초기화
                        if (Stretch)
                            if (_isMaxed)
                                buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), 0, 4 * _btH, _btMaxW, _btH, GraphicsUnit.Pixel);
                            else
                                buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), _btMinW, 0, _btMaxW, _btH, GraphicsUnit.Pixel);
                        else
                            buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), _btMinW, 3 * _btH, _btMaxW, _btH, GraphicsUnit.Pixel);
                    }
                    buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW + _btMaxW, 0, _btExitW, _btH), _btMinW + _btMaxW, 0, _btExitW, _btH, GraphicsUnit.Pixel);
                }
            }
            else
            {
                // 커서가 버튼구간에 있지 않으면 원상복구

                if (!FixedSingle)
                {
                    buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL, 0, _btMinW, _btH), 0, 0, _btMinW, _btH, GraphicsUnit.Pixel);
                    if (Stretch)
                        if (_isMaxed)
                            buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), 0, 4 * _btH, _btMaxW, _btH, GraphicsUnit.Pixel);
                        else
                            buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), _btMinW, 0, _btMaxW, _btH, GraphicsUnit.Pixel);
                    else
                        buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW, 0, _btMaxW, _btH), _btMinW, 3 * _btH, _btMaxW, _btH, GraphicsUnit.Pixel);
                }
                buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW + _btMaxW, 0, _btExitW, _btH), _btMinW + _btMaxW, 0, _btExitW, _btH, GraphicsUnit.Pixel);
            }

            //FixedSingle일때 X버튼 왼쪽부분에 회색선 그리기
            if (FixedSingle)
                buff.Graphics.DrawImage(pButtons.Image, new Rectangle(Width - _btL + _btMinW + _btMaxW - 2, 0, 2, _btH), 0, 0, 2, _btH, GraphicsUnit.Pixel);



            buff.Render(e.Graphics);
            buff.Dispose();
        }

        private void ctlSkin_MouseDown(object sender, MouseEventArgs e)
        {
            _RightX = this.Width - e.X;
            _DownY = this.Height - e.Y;

            if (e.Button == MouseButtons.Left)
            {
                _isClicked = true;
                this.Invalidate();
            }

            //Resizing
            if (e.Button == MouseButtons.Left && !_isMouseIn && !_isMaxed && Stretch)
            {
                uint SysCommWparam = 0;

                if ((e.X < 4) && (e.Y < 4))
                    SysCommWparam = SC_DRAG_RESIZEUL; // ↖
                else if ((_RightX < 4) && (_DownY < 4))
                    SysCommWparam = SC_DRAG_RESIZEDR; // ↘
                else if ((e.X < 4) && (_DownY < 4))
                    SysCommWparam = SC_DRAG_RESIZEDL; // ↙
                else if ((_RightX < 4) && (e.Y < 4))
                    SysCommWparam = SC_DRAG_RESIZEUR; // ↗
                else if ((e.X < 4))
                    SysCommWparam = SC_DRAG_RESIZEL; // ←
                else if ((_RightX < 4))
                    SysCommWparam = SC_DRAG_RESIZER; // →
                else if ((e.Y < 4))
                    SysCommWparam = SC_DRAG_RESIZEU; // ↑
                else if ((_DownY < 4))
                    SysCommWparam = SC_DRAG_RESIZED; // ↓


                if (SysCommWparam != 0)
                {
                    ReleaseCapture();
                    DefWindowProc(Parent.Handle, WM_SYSCOMMAND, (UIntPtr)SysCommWparam, IntPtr.Zero);
                    this.Cursor = Cursors.Default;
                }
            }

        }

        private void ctlSkin_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_isMouseIn || e.Button != MouseButtons.Left) { return; }

            _isClicked = false;

            Form frm = (this.Parent as Form);
            if (_isExit)
                frm.Close();

            if (_isMin)
                frm.WindowState = FormWindowState.Minimized;

            if (_isMax && Stretch)
            {
                if (!_isMaxed)
                {
                    _isMaxed = true;
                    frm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    _isMaxed = false;
                    frm.WindowState = FormWindowState.Normal;
                }

            }

            if ((this.Parent as Form) == null)
                return;

            this.Invalidate();
        }

        private void ctlSkin_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            _isMouseIn = false;
            _isClicked = false;
            this.Invalidate();
        }

        private void ctlSkin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Stretch)
                {
                    Form frm = (this.Parent as Form);

                    if (!_isMaxed)
                    {
                        _isMaxed = true;
                        frm.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        _isMaxed = false;
                        frm.WindowState = FormWindowState.Normal;
                    }
                }
            }
        }

        private void ctlSkin_MouseMove(object sender, MouseEventArgs e)
        {
            _RightX = this.Width - e.X;
            _DownY = this.Height - e.Y;

            if (0 < e.Y && e.Y < _btH && _btRight < _RightX && _RightX < _btL)
            {
                _isMouseIn = true;
                this.Cursor = Cursors.Default;
            }
            else
            {
                _isMouseIn = false;
            }


            if (_isMouseIn)
            {
                this.Invalidate();
                _isReset = true;
            }

            if (_isReset && !_isMouseIn)
            {
                this.Invalidate();
                _isReset = false;
            }




            //폼드래그이동
            if (!_isMaxed && !_isMouseIn && e.Y < _TitleBarT && e.X > 4 && e.X < Width - 4 && e.Button == MouseButtons.Left)
            {
                DefWindowProc(Parent.Handle, WM_SYSCOMMAND, (UIntPtr)SC_DRAG_MOVE, IntPtr.Zero);
                ReleaseCapture();
            }

            //사이즈조정 커서설정
            if (!_isMaxed && Stretch && !_isMouseIn)
            {

                if ((e.X < 4) && (e.Y < 4) || (_RightX < 4) && (_DownY < 4))
                    this.Cursor = Cursors.SizeNWSE;
                else if ((_RightX < 4) && (e.Y < 4) || ((e.X < 4) && _DownY < 4))
                    this.Cursor = Cursors.SizeNESW;
                else if ((e.X < 4) || (_RightX < 4))
                    this.Cursor = Cursors.SizeWE;
                else if ((e.Y < 4) || (_DownY < 4))
                    this.Cursor = Cursors.SizeNS;
                else
                    this.Cursor = Cursors.Default;
            }
        }

        private void ctlSkin_Resize(object sender, EventArgs e)
        {
            if ((this.Parent as Form) == null)
                return;

            this.Invalidate();
        }

        private void ParentForm_TextChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        #endregion

        #region - Constructor -
        public ctlModernBlack()
        {
            InitializeComponent();
        }
        #endregion

        #region - Load -
        private void ctlModernBlack_Load(object sender, EventArgs e)
        {
            ParentForm.TextChanged += new System.EventHandler(ParentForm_TextChanged);
            ParentForm.FormBorderStyle = FormBorderStyle.None;
            SendToBack();
            Dock = DockStyle.Fill;

        }
        #endregion

    }
}