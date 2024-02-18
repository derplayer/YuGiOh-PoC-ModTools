using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace YuGiOh_PoC_Patcher.UserControls
{
    // https://stackoverflow.com/a/46125277
    // credit: Davide Cannizzo
    public partial class FastTextBox : TextBox
    {
        public FastTextBox()
        {
            InitializeComponent();
        }

        [DebuggerHidden, DebuggerNonUserCode, DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string hint = string.Empty;

        /// <summary>
        /// Is called in preview the system handle the changes, and determines whether the text will be accepted and handled by the system.
        /// </summary>
        /// <param name="oldText">The old text.</param>
        /// <param name="newText">The current text (included the newer changes).</param>
        /// <param name="input">The newer changes.</param>
        /// <param name="offset">Start position of changes.</param>
        /// <param name="length">Length of <paramref name="input"/>.</param>
        /// <returns>Whether the system can handle the text.</returns>
        public delegate bool TextAcceptorEventHandler(string oldText, string newText, string input, int offset, int length);

        /// <summary>
        /// Is called in preview of or after the system handle the changes.
        /// </summary>
        /// <param name="oldText">The old text.</param>
        /// <param name="newText">The current text (included the newer changes).</param>
        /// <param name="input">The newer changes.</param>
        /// <param name="offset">Start position of changes.</param>
        /// <param name="length">Length of <paramref name="input"/>.</param>
        public delegate void TextEventHandler(string oldText, string newText, string input, int offset, int length);

        /// <summary>
        /// Is called in preview of the system handle the changes.
        /// </summary>
        public event TextEventHandler PreviewTextChange = null;

        /// <summary>
        /// Is called after the system handled the changes.
        /// </summary>
        public event TextEventHandler AfterTextChange = null;

        public string Hint
        {
            [DebuggerHidden]
            get
            {
                return hint;
            }
            [DebuggerHidden]
            set
            {
                if (value == hint)
                    return;
                hint = value;
                SendMessage(Handle, 0x1501, 1, value);
            }
        }

        public TextAcceptorEventHandler TextAcceptor
        {
            [DebuggerHidden]
            get;
            [DebuggerHidden]
            set;
        }

        [DebuggerHidden]
        protected override void CreateHandle()
        {
            base.CreateHandle();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.FixedWidth | ControlStyles.FixedHeight | ControlStyles.Opaque, DoubleBuffered = true);
        }

        /// <summary>
        /// Is called in preview of a text change, before the system handles it, and determines whether the text will be accepted and handled by system.
        /// </summary>
        /// <param name="oldText">The last written text.</param>
        /// <param name="newText">The current text (included the newer changes).</param>
        /// <param name="input">The newer changes.</param>
        /// <param name="offset">Start position of changes.</param>
        /// <param name="length">Length of <paramref name="input"/>.</param>
        /// <returns></returns>
        [DebuggerHidden]
        protected virtual bool OnAcceptTextInput(string oldText, string newText, string input, int offset, int length)
        {
            return TextAcceptor == null ? true : TextAcceptor.Invoke(oldText, newText, input, offset, length);
        }

        /// <summary>
        /// Is called in preview of a text change, before the system handles it.
        /// </summary>
        /// <param name="oldText">The last written text.</param>
        /// <param name="newText">The current text (included the newer changes).</param>
        /// <param name="input">The newer changes.</param>
        /// <param name="offset">Start position of changes.</param>
        /// <param name="length">Length of <paramref name="input"/>.</param>
        [DebuggerHidden]
        protected virtual void OnPreviewTextChange(string oldText, string newText, string input, int offset, int length)
        {
            if (PreviewTextChange != null)
                PreviewTextChange.Invoke(oldText, newText, input, offset, length);
        }

        /// <summary>
        /// Is called after the system handled the changes.
        /// </summary>
        /// <param name="oldText">The old text.</param>
        /// <param name="newText">The current text (included the newer changes).</param>
        /// <param name="input">The newer changes.</param>
        /// <param name="offset">Start position of changes.</param>
        /// <param name="length">Length of <paramref name="input"/>.</param>
        [DebuggerHidden]
        protected virtual void OnAfterTextChange(string oldText, string newText, string input, int offset, int length)
        {
            if (AfterTextChange != null)
                AfterTextChange.Invoke(oldText, newText, input, offset, length);
        }

        [DebuggerHidden]
        private bool CallbackPreview(string oldText, string newText, string input, int offset, int length)
        {
            if (string.IsNullOrEmpty(newText) ? true : OnAcceptTextInput(oldText, newText, input, offset, length))
            {
                OnPreviewTextChange(oldText, newText, input, offset, length);
                return true;
            }
            return false;
        }

        [DebuggerHidden]
        private bool CallbackPreview(ref string newText, string oldText, string input, int offset, int length)
        {
            newText = GetNewText(oldText, input, offset, length);
            return CallbackPreview(oldText, newText, input, offset, length);
        }

        [DebuggerHidden]
        private string GetNewText(string oldText, string input, int offset, int length)
        {
            if (input.Length == 1 ? input.ToCharArray()[0] == (int)Keys.Back : false)
                return Text.Length > 0 ? $"{oldText.Substring(0, offset - (length == 0 ? 1 : 0))}{oldText.Substring(offset + length)}" : string.Empty;
            else
                return $"{(offset > 0 ? oldText.Substring(0, offset) : string.Empty)}{input}{(offset == oldText.Length - 1 ? string.Empty : oldText.Substring(offset + length))}";
        }

        [DebuggerHidden]
        protected override void WndProc(ref Message m)
        {
            string text = "";
            switch (m.Msg)
            {
                case 0x102:
                    int code = m.WParam.ToInt32();
                    if (code == 22 && ModifierKeys.HasFlag(Keys.Control))
                        goto case 0x302;
                    text = ((char)code).ToString();
                    goto case 0xC;
                case 0x302:
                    text = Clipboard.GetText();
                    goto case 0xC;
                case 0xC:
                    string input = string.Empty, newText = string.Empty;
                    if (string.IsNullOrEmpty(text))
                    {
                        newText = Marshal.PtrToStringUni(m.LParam);
                        if (CallbackPreview(Text, newText, string.Empty, SelectionStart, SelectionLength))
                            base.WndProc(ref m);
                    }
                    else
                    {
                        input = text;
                        if (CallbackPreview(ref newText, Text, input, SelectionStart, SelectionLength))
                            base.WndProc(ref m);
                    }
                    OnAfterTextChange(Text, newText, input, SelectionStart, SelectionLength);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
