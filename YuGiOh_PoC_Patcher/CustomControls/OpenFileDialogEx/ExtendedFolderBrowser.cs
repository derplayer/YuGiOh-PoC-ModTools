using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Security;
using System.Runtime.InteropServices;
using System.Text;

namespace FolderBrowser
{
	public delegate bool ShowNewButtonHandler(string selectedPath);

	/// Created By:				Goldberg Royee
	/// Date:					6/8/2006
	/// Reason:					This class is an extended class
	/// for the folderBrowseDialog of .NET.
	/// This class add a functionality to disable the 'Make New Folder' Button
	/// whenever a CD path selected.
	public class ExtendedFolderBrowser
	{
		#region Win32API Class
		/// <summary>
		/// 
		/// </summary>
		private class Win32API
		{
			[DllImport("shell32.dll", CharSet=CharSet.Auto)]
			public static extern IntPtr SHBrowseForFolder([In] BROWSEINFO lpbi);
			[DllImport("shell32.dll")]
			public static extern int SHGetMalloc([Out, MarshalAs(UnmanagedType.LPArray)] IMalloc[] ppMalloc);
			[DllImport("shell32.dll", CharSet=CharSet.Auto)]
			public static extern bool SHGetPathFromIDList(IntPtr pidl, IntPtr pszPath);
			[DllImport("shell32.dll")]
			public static extern int SHGetSpecialFolderLocation(IntPtr hwnd, int csidl, ref IntPtr ppidl);
			[DllImport("user32.dll", CharSet=CharSet.Auto)]
			public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, string lParam);
			[DllImport("user32.dll", EntryPoint="SendMessage", CharSet=CharSet.Auto)]
			public static extern IntPtr SendMessage2(HandleRef hWnd, int msg, int wParam, int lParam);
			[DllImport("user32.dll")] 
			public static extern bool EnableWindow(IntPtr hWnd,bool bEnable);
			[DllImport("user32.dll") ] 
			public static extern int GetWindowText(int hWnd, StringBuilder text, int count); 
			[DllImport("user32.dll") ] 
			public static extern IntPtr FindWindow(string lpClassName,string lpWindowName);
			[DllImport("user32.dll")] 
			public static extern IntPtr GetWindowThreadProcessId(IntPtr hwnd, IntPtr lpdwProcessId); 

			[DllImport("user32.dll") ] 
			public static extern IntPtr FindWindowEx(IntPtr hwndParent,
				IntPtr hwndChildAfter,
				string lpszClass,
				string lpszWindow
				);
			

			[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto), ComVisible(false)]
			public class BROWSEINFO
			{
				public IntPtr hwndOwner;
				public IntPtr pidlRoot;
				public IntPtr pszDisplayName;
				public string lpszTitle;
				public int ulFlags;
				public BrowseCallbackProc lpfn;
				public IntPtr lParam;
				public int iImage;
			}
			
			[ComImport, Guid("00000002-0000-0000-c000-000000000046"), SuppressUnmanagedCodeSecurity, InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
			public interface IMalloc
			{
				IntPtr Alloc(int cb);
				void Free(IntPtr pv);
				IntPtr Realloc(IntPtr pv, int cb);
				int GetSize(IntPtr pv);
				int DidAlloc(IntPtr pv);
				void HeapMinimize();
			}
 
			public const int WM_LBUTTONDOWN = 0x0201;
			public const int BFFM_INITIALIZED = 1;
			public const int BFFM_SELCHANGED = 2;

			public delegate int BrowseCallbackProc(IntPtr hwnd, int msg, IntPtr lParam, IntPtr lpData);
		}
		#endregion

		#region InternalFolderBrowser Class
		/// <summary>
		/// 
		/// </summary>
		private class InternalFolderBrowser : CommonDialog
		{
			private string m_selectedPath = null;
			private Environment.SpecialFolder m_rootFolder;
			public event EventHandler SelectedFolderChanged;
			private string m_descriptionText = String.Empty;
			/// <summary>
			/// 
			/// </summary>
			/// <returns></returns>
			private Win32API.IMalloc GetSHMalloc()
			{
				Win32API.IMalloc[] mallocArray1 = new Win32API.IMalloc[1];
				Win32API.SHGetMalloc(mallocArray1);
				return mallocArray1[0];
			}

			/// <summary>
			/// 
			/// </summary>
			public override void Reset()
			{
				m_rootFolder = Environment.SpecialFolder.Desktop;
				m_selectedPath = string.Empty;
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="hwndOwner"></param>
			/// <returns></returns>
			protected override bool RunDialog(System.IntPtr hwndOwner)
			{
				IntPtr ptr1 = IntPtr.Zero;
				bool flag1 = false;
				Win32API.SHGetSpecialFolderLocation(hwndOwner, (int)m_rootFolder, ref ptr1);
				if (ptr1 == IntPtr.Zero)
				{
					Win32API.SHGetSpecialFolderLocation(hwndOwner, 0, ref ptr1);
					if (ptr1 == IntPtr.Zero)
					{
						throw new Exception("FolderBrowserDialogNoRootFolder");
					}
				}

				//Initialize the OLE to current thread.
				Application.OleRequired();
				IntPtr ptr2 = IntPtr.Zero;
				try
				{
					Win32API.BROWSEINFO browseinfo1 = new Win32API.BROWSEINFO();
					IntPtr ptr3 = Marshal.AllocHGlobal((int) (260 * Marshal.SystemDefaultCharSize));
					IntPtr ptr4 = Marshal.AllocHGlobal((int) (260 * Marshal.SystemDefaultCharSize));
					Win32API.BrowseCallbackProc proc1 = new Win32API.BrowseCallbackProc(this.FolderBrowserDialog_BrowseCallbackProc);
					browseinfo1.pidlRoot = ptr1;
					browseinfo1.hwndOwner = hwndOwner;
					browseinfo1.pszDisplayName = ptr3;
					browseinfo1.lpszTitle = m_descriptionText;
					browseinfo1.ulFlags = 0x40;
					browseinfo1.lpfn = proc1;
					browseinfo1.lParam = IntPtr.Zero;
					browseinfo1.iImage = 0;
					ptr2 = Win32API.SHBrowseForFolder(browseinfo1);

					string s = Marshal.PtrToStringAuto(ptr3);

					if (ptr2 != IntPtr.Zero)
					{
						Win32API.SHGetPathFromIDList(ptr2, ptr4);
						this.m_selectedPath = Marshal.PtrToStringAuto(ptr4);
						Marshal.FreeHGlobal(ptr4);
						Marshal.FreeHGlobal(ptr3);
						flag1 = true;
					}
				}
				finally
				{
					Win32API.IMalloc malloc1 = GetSHMalloc();
					malloc1.Free(ptr1);
					if (ptr2 != IntPtr.Zero)
					{
						malloc1.Free(ptr2);
					}
				}
				return flag1;
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="hwnd"></param>
			/// <param name="msg"></param>
			/// <param name="lParam"></param>
			/// <param name="lpData"></param>
			/// <returns></returns>
			private int FolderBrowserDialog_BrowseCallbackProc(IntPtr hwnd, int msg, IntPtr lParam, IntPtr lpData)
			{
				switch (msg)
				{
					case Win32API.BFFM_INITIALIZED:
						if (m_selectedPath != string.Empty)
						{
							Win32API.SendMessage(new HandleRef(null, hwnd), 0x467, 1, m_selectedPath);
						}
						break;

					case Win32API.BFFM_SELCHANGED: //Selction Changed
					{
						IntPtr ptr1 = lParam;
						if (ptr1 != IntPtr.Zero)
						{
							IntPtr ptr2 = Marshal.AllocHGlobal((int) (260 * Marshal.SystemDefaultCharSize));
							bool flag1 = Win32API.SHGetPathFromIDList(ptr1, ptr2);
							m_selectedPath = Marshal.PtrToStringAuto(ptr2);

							//Fire Event
							if(SelectedFolderChanged != null)
							{
								SelectedFolderChanged(this,null);
							}
							Marshal.FreeHGlobal(ptr2);
							Win32API.SendMessage2(new HandleRef(null, hwnd), 0x465, 0, flag1 ? 1 : 0);
						}
						break;
					}
				}
				return 0;
			}

			/// <summary>
			/// 
			/// </summary>
			public string SelectedPath
			{
				get
				{
					return m_selectedPath;
				}
			}

			/// <summary>
			/// 
			/// </summary>
			public string Description
			{
				get
				{
					return m_descriptionText;
				}
				set
				{
					m_descriptionText = (value == null) ? string.Empty : value;

				}
			}

		}
		#endregion
		
		#region Private Members

		private InternalFolderBrowser m_InternalFolderBrowser = null;
		public event EventHandler SelectedFolderChanged;
		private const string MAKE_NEW_FOLDER_BUTTON = "&Make New Folder";
		
		private ShowNewButtonHandler m_ShowNewButtonHandler = null;
		private const string BROWSE_FOR_FOLDER_CLASS_NAME =  "#32770";
		#endregion

		#region CTOR
		/// <summary>
		/// 
		/// </summary>
		public ExtendedFolderBrowser()
		{
			m_InternalFolderBrowser = new InternalFolderBrowser();
			m_InternalFolderBrowser.SelectedFolderChanged+=new EventHandler(m_InternalFolderBrowser_SelectedFolderChanged);
		}
		#endregion

		#region  Helper Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="handle"></param>
		/// <param name="state"></param>
		private void UpdateButtonState(IntPtr handle, bool state)
		{
			if(handle != IntPtr.Zero)
			{
				Win32API.EnableWindow(handle,state);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="windowHandle"></param>
		/// <returns></returns>
		private bool isFromTheSameThread(IntPtr windowHandle)
		{
			//Get the thread that running given handler
			IntPtr activeThreadID = Win32API.GetWindowThreadProcessId(windowHandle, 
				IntPtr.Zero); 

			//Get current thread
			int currentThread = AppDomain.GetCurrentThreadId();
			
			return (currentThread == activeThreadID.ToInt32());

		}

		private IntPtr GetButtonHandle(IntPtr handle)
		{
			//First time
			if(handle == IntPtr.Zero)
			{
				//Get Handle for class with name "#32770"
				IntPtr parent = Win32API.FindWindow(BROWSE_FOR_FOLDER_CLASS_NAME,null);

				//If the window we found is in the same thread we are running
				//then it is The 'Browse For Folder' Dialog, otherwise keep searching
				if(!isFromTheSameThread(parent))
				{
					//Keep searching from this point
					return GetButtonHandle(parent);
				}
				else
				{
					return   Win32API.FindWindowEx(parent,IntPtr.Zero,"Button", null);
				}
			}
			else
			{
				//Find next window
				IntPtr parent = Win32API.FindWindowEx(IntPtr.Zero,handle,BROWSE_FOR_FOLDER_CLASS_NAME, null);
				if(!isFromTheSameThread(parent))
				{
					return GetButtonHandle(parent);
				}
				else
				{
					//We found the 'Browse For Folder' Dialog handler.
					//Lets return the child handler of 'Maker new Folder' button
					return   Win32API.FindWindowEx(parent,IntPtr.Zero,"Button", null);
				}
			}
		}


		/// <summary>
		/// A different version for finding the 'Make New Foler' button handler.
		/// We currently don't use this version, because it requires a Localization.
		/// </summary>
		/// <returns></returns>
		private IntPtr GetButtonHandle()
		{
			//This should be using localization!!!!!!!!!!!!!!!!!#32770 (Dialog)
			IntPtr root = Win32API.FindWindow(null,"Browse For Folder");
			IntPtr child = Win32API.FindWindowEx(root,IntPtr.Zero,"Button", null);
			return child;
		}

		/// <summary>
		/// Check if we should disable the 'Make New Folder' button
		/// </summary>
		private void CheckState()
		{
			if(m_ShowNewButtonHandler != null)
			{
				if(m_ShowNewButtonHandler(SelectedPath))
				{
					//Disabel the button
					UpdateButtonState(GetButtonHandle(IntPtr.Zero), false);
				}
				else
				{
					//Enable the button
					UpdateButtonState(GetButtonHandle(IntPtr.Zero),true);
				}
			}
		}

		private void m_InternalFolderBrowser_SelectedFolderChanged(object sender, EventArgs e)
		{
			CheckState();

			//Fire event selection has changed in case anyone wants 
			//to be notified.
			if(SelectedFolderChanged != null)
			{
				SelectedFolderChanged(sender,e);
			}
		}
		#endregion

		#region FolderBrowserDialog Mathods

		public DialogResult ShowDialog()
		{
			return ShowDialog(null);
		}

		public DialogResult ShowDialog(IWin32Window owner)
		{
			return m_InternalFolderBrowser.ShowDialog(owner);
		}

		public string SelectedPath
		{
			get
			{
				return m_InternalFolderBrowser.SelectedPath;
			}
		}

		public string Description
		{
			get
			{
				return m_InternalFolderBrowser.Description;
			}
			set
			{
				m_InternalFolderBrowser.Description = value;
			}
		}

		/// <summary>
		/// Pass the delegate to your function, which will decide
		/// if to enable the 'Make New Folder' button or not.
		/// </summary>
		public ShowNewButtonHandler SetNewFolderButtonCondition
		{
			get
			{
				return m_ShowNewButtonHandler;;
			}
			set
			{
				m_ShowNewButtonHandler = value;
			}
		}

		#endregion
	}
}
