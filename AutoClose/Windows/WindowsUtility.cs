using AutoClose.Win32;
using System;

namespace AutoClose.Windows
{
    internal static class WindowsUtility
    {

        #region public methods

        public static void MinimiseAll()
        {
            IntPtr lHwnd = NativeMethods.FindWindow("Shell_TrayWnd", null);
            NativeMethods.SendMessage(lHwnd, NativeMethods.WM_COMMAND, (IntPtr)NativeMethods.MIN_ALL, IntPtr.Zero);
        }

        #endregion

    }

}
