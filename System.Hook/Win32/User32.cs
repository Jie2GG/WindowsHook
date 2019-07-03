using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Hooks
{
    internal static class User32
    {
        internal const string DLL_NAME = "user32.dll";

        [DllImport (DLL_NAME, EntryPoint = "CallNextHookEx", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int CallNextHookEx (IntPtr hhook, int code, int wparam, IntPtr lparam);

        [DllImport (DLL_NAME, EntryPoint = "SetWindowsHookEx", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowsHookEx (int hookid, HookProc pfnhook, IntPtr hinst, int threadid);

        [DllImport (DLL_NAME, EntryPoint = "UnhookWindowsHookEx", ExactSpelling = true)]
        public static extern bool UnhookWindowsHookEx (IntPtr hhook);

        [DllImport (DLL_NAME, EntryPoint = "ToAscii", CharSet = CharSet.Auto)]
        public static extern int ToAscii (int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

        [DllImport (DLL_NAME, EntryPoint = "GetKeyboardState", ExactSpelling = true)]
        public static extern int GetKeyboardState (byte[] keystate);

        [DllImport (DLL_NAME, EntryPoint = "GetKeyState")]
        public static extern short GetKeyState (int keyCode);
    }
}