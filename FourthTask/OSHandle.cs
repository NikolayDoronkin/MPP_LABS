using System;
using System.Runtime.InteropServices;

namespace FourthTask
{
    public class OsHandle : IDisposable
    {
        [DllImport("Kernel32.dll")]
        private static extern bool CloseHandle(IntPtr handle);
        public IntPtr Handle { get; set; }

        public OsHandle()
        {
            Handle = IntPtr.Zero;
        }

        ~OsHandle()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Handle == IntPtr.Zero)
            {
                return;
            }
            Console.WriteLine(CloseHandle(Handle));
            //Console.WriteLine(Handle);
            Handle = IntPtr.Zero;
        }
    }
}