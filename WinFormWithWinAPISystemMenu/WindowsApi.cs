using System;
using System.Runtime.InteropServices;
using WinFormWithWinAPISystemMenu.Models;

namespace WinFormWithWinAPISystemMenu
{
	public static class WindowsApi
	{
		#region Windows API methods

		[DllImport( "user32.dll" )]
		public static extern bool DrawMenuBar( IntPtr hWnd );

		[DllImport( "user32.dll", SetLastError = true )]
		public static extern IntPtr FindWindow( string lpClassName, string lpWindowName );

		[DllImport( "user32.dll" )]
		public static extern int GetMenuItemCount( IntPtr hmenu );

		[DllImport( "user32.dll", CharSet = CharSet.Auto )]
		public static extern bool GetMenuItemInfo( IntPtr hmenu, uint item, bool fByPosition, [In] ref MENUITEMINFO lpmii );

		[DllImport( "user32.dll" )]
		public static extern IntPtr GetSystemMenu( IntPtr hWnd, bool bRevert );

		[DllImport( "user32.dll" )]
		public static extern bool InsertMenuItem( IntPtr hmenu, uint item, bool fByPosition, [In] ref MENUITEMINFO lpmi );

		[DllImport( "user32.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern IntPtr LoadImage( IntPtr hinst, string lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad );
		
		[DllImport( "user32.dll" )]
		public static extern bool RemoveMenu( IntPtr hMenu, uint uPosition, uint uFlags );

		[DllImport( "user32.dll" )]
		public static extern bool SetMenuItemBitmaps( IntPtr hMenu, uint uPosition, uint uFlags, IntPtr hBitmapUnchecked, IntPtr hBitmapChecked );

		#endregion Windows API methods

		#region Windows constants

		public const uint IMAGE_BITMAP = 0;
		public const uint LR_LOADFROMFILE = 0x00000010;
		public const uint MF_BYCOMMAND = 0x00000000;
		public const uint MF_BYPOSITION = 0x00000400;
		public const uint MF_SEPARATOR = 0x800;
		public const uint MF_STRING = 0x0;
		public const uint MFS_DISABLED = 0x00000003;
		public const uint MFS_ENABLED = 0x00000000;
		public const uint MIIM_BITMAP = 0x00000080;
		public const uint MIIM_ID = 0x00000002;
		public const uint MIIM_STATE = 0x00000001;
		public const uint MIIM_TYPE = 0x00000010;
		public const uint WM_SYSCOMMAND = 0x112;

		#endregion Windows constants

		#region Local constants

		public const bool B_REVERT = false;
		public const bool BY_IDENTIFIER = false;
		public const uint CALCULATOR_MENU_ITEM_ID = 1000;
		public const uint CALCULATOR_MENU_SEPARATOR = 1001;
		public const uint LOCAL_MENU_ITEM_ID = 1002;
		public const uint LOCAL_MENU_ITEM_SEPARATOR = 1003;
		public const string MENU_ITEM_TEXT = "Code assessment";

		#endregion Local constants
	}
}
