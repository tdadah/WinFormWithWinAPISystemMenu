using System;
using System.Runtime.InteropServices;

using WinFormWithWinAPISystemMenu.Models;

namespace WinFormWithWinAPISystemMenu
{
	public class SystemMenuItem
	{
		#region Public methods

		public void AddSystemMenuItem( IntPtr applicationHandle, ApplicationType application )
		{
			/// Get the Handle for the System Menu of the provided handle
			var systemMenuHandle = WindowsApi.GetSystemMenu( applicationHandle, WindowsApi.B_REVERT );
			var count = WindowsApi.GetMenuItemCount( systemMenuHandle );

			var separator = new MENUITEMINFO
			{
				cbSize = (uint)Marshal.SizeOf( typeof( MENUITEMINFO ) ),
				fMask = WindowsApi.MIIM_TYPE | WindowsApi.MIIM_ID,
				fState = 0,
				fType = WindowsApi.MF_SEPARATOR,
				wID = application == ApplicationType.LocalApplication
					? WindowsApi.LOCAL_MENU_ITEM_SEPARATOR
					: WindowsApi.CALCULATOR_MENU_SEPARATOR
			};

			var id = application == ApplicationType.LocalApplication
					? WindowsApi.LOCAL_MENU_ITEM_ID
					: WindowsApi.CALCULATOR_MENU_ITEM_ID;
			var menuItem = new MENUITEMINFO
			{
				cbSize = (uint)Marshal.SizeOf( typeof( MENUITEMINFO ) ),
				cch = 255,
				dwTypeData = WindowsApi.MENU_ITEM_TEXT,
				fMask = WindowsApi.MIIM_STATE | WindowsApi.MIIM_ID | WindowsApi.MIIM_TYPE,
				fState = application == ApplicationType.LocalApplication
					? WindowsApi.MFS_ENABLED
					: WindowsApi.MFS_DISABLED,
				fType = WindowsApi.MF_STRING,
				wID = id
			};

			// Add a seperator and a new menu item before the last menu item, Close
			WindowsApi.InsertMenuItem( systemMenuHandle, (uint)( count - 1 ), true /* fByPosition */, ref separator );
			WindowsApi.InsertMenuItem( systemMenuHandle, (uint)( count - 1 ), true /* fByPosition */, ref menuItem );

			// Add an icon to th menu item for the LocalApplication.
			if( application == ApplicationType.LocalApplication )
			{
				var icon = WindowsApi.LoadImage( (IntPtr)null, $"..\\..\\Resources\\MenuItemIcon.bmp", WindowsApi.IMAGE_BITMAP, 0, 0, WindowsApi.LR_LOADFROMFILE );
				WindowsApi.SetMenuItemBitmaps( systemMenuHandle, id, WindowsApi.MF_BYCOMMAND, icon, icon );
			}

			// This function must be called to draw the changed menu bar because the menu bar changed after the system had created the window.
			WindowsApi.DrawMenuBar( systemMenuHandle );
		}

		public void CheckForCalculatorAndAddMenuItem()
		{
			var handle = WindowsApi.FindWindow( null, "Calculator" );

			if( handle != IntPtr.Zero )
			{
				var systemMenuHandle = WindowsApi.GetSystemMenu( handle, WindowsApi.B_REVERT );

				var lpmii = new MENUITEMINFO
				{
					cbSize = (uint)Marshal.SizeOf( typeof( MENUITEMINFO ) ),
					dwTypeData = null,
					fMask = WindowsApi.MIIM_STATE | WindowsApi.MIIM_ID | WindowsApi.MIIM_TYPE,
					fType = WindowsApi.MF_STRING
				};

				if( systemMenuHandle != IntPtr.Zero && !WindowsApi.GetMenuItemInfo( systemMenuHandle, WindowsApi.CALCULATOR_MENU_ITEM_ID, WindowsApi.BY_IDENTIFIER, ref lpmii ) )
				{
					AddSystemMenuItem( handle, ApplicationType.Calculator );
				}
			}
		}

		public void RemoveCalculatorMenuItem()
		{
			var handle = WindowsApi.FindWindow( null, "Calculator" );

			if( handle != IntPtr.Zero )
			{
				var systemMenuHandle = WindowsApi.GetSystemMenu( handle, WindowsApi.B_REVERT );

				var lpmii = new MENUITEMINFO
				{
					cbSize = (uint)Marshal.SizeOf( typeof( MENUITEMINFO ) ),
					dwTypeData = null,
					fMask = WindowsApi.MIIM_STATE | WindowsApi.MIIM_ID | WindowsApi.MIIM_TYPE,
					fType = WindowsApi.MF_STRING
				};

				// If the menu item has been added to the calculator, get the count, and remove the separator and new menu item.
				if( systemMenuHandle != IntPtr.Zero && WindowsApi.GetMenuItemInfo( systemMenuHandle, WindowsApi.CALCULATOR_MENU_ITEM_ID, WindowsApi.BY_IDENTIFIER, ref lpmii ) )
				{
					WindowsApi.RemoveMenu( systemMenuHandle, WindowsApi.CALCULATOR_MENU_ITEM_ID, WindowsApi.MF_BYCOMMAND  );
					WindowsApi.RemoveMenu( systemMenuHandle, WindowsApi.CALCULATOR_MENU_SEPARATOR, WindowsApi.MF_BYCOMMAND  );

					// This function must be called to draw the changed menu bar because the menu bar changed after the system had created the window.
					WindowsApi.DrawMenuBar( systemMenuHandle );
				}
			}
		}

		#endregion Public methods
	}
}
