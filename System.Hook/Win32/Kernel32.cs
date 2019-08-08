using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Hooks
{
    internal static class Kernel32
    {
        internal const string DLL_NAME = "kernel32.dll";

        [DllImport (DLL_NAME, EntryPoint = "GetCurrentThreadId", SetLastError = true)]
        public static extern int GetCurrentThreadId ();

        [DllImport (DLL_NAME, EntryPoint = "GetLastError", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int GetLastError ();

        [DllImport (DLL_NAME, BestFitMapping = false, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle (string moduleName);

        [DllImport (DLL_NAME, EntryPoint = "CloseHandle")]
        public static extern bool CloseHandle (IntPtr handle);
    }
}
