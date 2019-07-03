using System.Runtime.InteropServices;

namespace System.Hooks
{
    [StructLayout (LayoutKind.Sequential)]
    internal struct KeyboardInfo
    {
        public int wVk;
        public int wScan;
        public int dwFlags;
        public int time;
        public IntPtr dwExtraInfo;
    }
}
