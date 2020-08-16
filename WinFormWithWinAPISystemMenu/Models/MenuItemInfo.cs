using System;
using System.Runtime.InteropServices;

namespace WinFormWithWinAPISystemMenu.Models
{
	[StructLayout( LayoutKind.Sequential )]
	public struct MENUITEMINFO
	{
		public uint cbSize;
		public uint fMask;
		public uint fType;
		public uint fState;
		public uint wID;
		public IntPtr hSubMenu;
		public IntPtr hbmpChecked;
		public IntPtr hbmpUnchecked;
		public IntPtr dwItemData;
		public string dwTypeData;
		public uint cch;
		public IntPtr hbmpItem;
	}
}
