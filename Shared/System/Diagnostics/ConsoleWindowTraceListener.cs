using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Diagnostics
{
    /// <summary>
    /// Trace listener implementation that outputs Trace messages to a newly created console window.
    /// </summary>
    public class ConsoleWindowTraceListener : TraceListener
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <exception cref="NotSupportedException">thrown if current environment is not user interactive.</exception>
        /// <exception cref="Win32Exception">thrown in case console cant be allocated.</exception>
        public ConsoleWindowTraceListener()
            : base()
        {
            //check current environment
            if (!Environment.UserInteractive)
                throw new NotSupportedException("Only user interactive environment is supported.");

            if (!AllocConsole())
                throw new Win32Exception();
        }
        #endregion

        #region NATIVE

        #region AllocConsole
        [SuppressUnmanagedCodeSecurity()]
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
        #endregion

        #region FreeConsole
        [SuppressUnmanagedCodeSecurity()]
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeConsole();
        #endregion

        #endregion

        #region OVERRIDES

        public override void Write(string message)
        {
            if (Environment.UserInteractive)
                Console.Write(message);
        }

        public override void WriteLine(string message)
        {
            if (Environment.UserInteractive)
                Console.WriteLine(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                FreeConsole();
            }
        }

        #endregion
    }
}
