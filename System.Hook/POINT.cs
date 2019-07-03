using System.Runtime.InteropServices;

namespace System.Hooks
{
    [StructLayout (LayoutKind.Sequential)]
    internal struct POINT
    {
        public int x;
        public int y;
    }
}
