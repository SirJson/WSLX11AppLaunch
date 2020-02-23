using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace RunX11App
{
    internal class Program
    {
        [DllImport("user32.dll", SetLastError = true, CharSet= CharSet.Auto)]
        public static extern int MessageBox(int hWnd, string text, string caption, uint type);

        private static void Main(string[] args)
        {
            var appname = Path.GetFileName(Environment.GetCommandLineArgs()[0]);
            if (args.Length <= 0)
            {
                _ = MessageBox(0, $"USAGE: {appname} [Command]\n\nExample: {appname} gedit ~/.bashrc", "Missing argument", 0);
                Environment.Exit(1);
            }

            var x11Srv = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "x410.exe",
                    Arguments = "/wm",
                    UseShellExecute = true,
                }
            };

            var appStart = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "wsl.exe",
                    Arguments = $"-- execwsl {string.Join(' ',args)}",
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    RedirectStandardError = false,
                    RedirectStandardInput = false,
                    RedirectStandardOutput = false
                }
            };

            try
            {
                _ = x11Srv.Start();
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is Win32Exception || ex is PlatformNotSupportedException || ex is ObjectDisposedException)
            {
                _ = MessageBox(0,$"Failed to start the local X11 Server\n\n{ex.Message}\n\nStack Trace\n{ex.StackTrace}", "Failed to start X11", 0);
                Environment.Exit(1);
            }

            _ = appStart.Start();
//appStart.WaitForExit();
        }
    }
}
