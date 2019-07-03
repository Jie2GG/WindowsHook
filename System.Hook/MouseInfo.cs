using System.Runtime.InteropServices;

namespace System.Hooks
{
    [StructLayout (LayoutKind.Sequential)]
    internal struct MouseInfo
    {
        public POINT pt;
        public int mouseData;
        public int flags;
        public int time;
        public int dwExtraInfo;
    }
}
