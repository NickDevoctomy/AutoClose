using System;
using System.Runtime.InteropServices;

namespace AutoClose.Win32
{
    internal sealed class NativeMethods
    {

        #region public constants

        public static Guid GUID_MONITOR_POWER_ON = new Guid(0x02731015, 0x4510, 0x4526, 0x99, 0xe6, 0xe5, 0xa1, 0x7e, 0xbd, 0x1a, 0xea);
        public const String GUID_MONITOR_POWER_ON_STRING = "02731015-4510-4526-99e6-e5a17ebd1aea";
        public const Int32 DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000;
        public const Int32 WM_POWERBROADCAST = 0x0218;
        public const Int32 PBT_POWERSETTINGCHANGE = 0x8013;
        public const int WM_COMMAND = 0x111;
        public const int MIN_ALL = 419;

        #endregion

        #region public structs

        public struct POWERBROADCAST_SETTING
        {
            public Guid PowerSetting;
            public uint DataLength;
            public Byte Data;
        }

        #endregion

        #region public methods

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport(@"User32", SetLastError = true, EntryPoint = "RegisterPowerSettingNotification", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr RegisterPowerSettingNotification(IntPtr hRecipient, ref Guid PowerSettingGuid, Int32 Flags);


        #endregion

    }
}
