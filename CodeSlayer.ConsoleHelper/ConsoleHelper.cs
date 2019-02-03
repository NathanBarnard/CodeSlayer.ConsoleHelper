using System;
using System.Diagnostics;

namespace CodeSlayer.ConsoleHelper
{
    public static class ConsoleHelper
    {
        public static void AllocConsole()
        {
            Show();
            var writer = new TextWriterTraceListener(Console.Out);
            Debug.Listeners.Add(writer);
        }

        public static void Show()
        {
            // If we already have a console window, show it.
            var handle = Native.GetConsoleWindow();
            if (handle != IntPtr.Zero)
            {
                Native.ShowWindow(handle, Native.SW_SHOW);
                return;
            }

            // Create a new console if we don't have one to attach to.
            if (!Native.AttachConsole(-1))
            {
                Native.AllocConsole();
            }


            /*
            Native.AllocConsole();
            var stdHandle = Native.GetStdHandle(Native.STD_OUTPUT_HANDLE);
            var safeFileHandle = new SafeFileHandle(stdHandle, true);
            var fileStream = new FileStream(safeFileHandle, FileAccess.Write);
            var encoding = Encoding.GetEncoding(Native.MY_CODE_PAGE);
            var standardOutput = new StreamWriter(fileStream, encoding);
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
            */



        }
        public static void Hide()
        {
            var handle = Native.GetConsoleWindow();
            if (handle != IntPtr.Zero)
            {
                Native.ShowWindow(handle, Native.SW_HIDE);
            }
        }
    }
}
