using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using FourthTask;
using Microsoft.Win32.SafeHandles;

namespace fourthLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var handle = CreateFile(
                lpFileName: @"C:\Users\nicol\OneDrive\Рабочий стол\Рабочий стол\5 СЕМЕСТР\СПП\4лр\test.txt",
                dwDesiredAccess: FileAccess.Read,
                dwShareMode: FileShare.ReadWrite,
                lpSecurityAttributes: IntPtr.Zero,
                dwCreationDisposition: FileMode.OpenOrCreate,
                dwFlagsAndAttributes: FileAttributes.Normal,
                hTemplateFile: IntPtr.Zero );
            using (var osHandle = new OsHandle())
            {
                osHandle.Handle = handle.DangerousGetHandle();
                Console.WriteLine(osHandle.Handle);
            }
        }
        
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern SafeFileHandle CreateFile(
            string lpFileName,
            [MarshalAs(UnmanagedType.U4)] FileAccess dwDesiredAccess,
            [MarshalAs(UnmanagedType.U4)] FileShare dwShareMode,
            IntPtr lpSecurityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode dwCreationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes dwFlagsAndAttributes,
            IntPtr hTemplateFile);
    }
}
