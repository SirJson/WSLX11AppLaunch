using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WSLXAppLaunch
{
    internal class Program
    {
        [DllImport("user32.dll", SetLastError = true, CharSet= CharSet.Auto)]
        public static extern int MessageBox(int hWnd, string text, string caption, uint type);

        private static void Main(string[] args) {
            if (args.Length <= 0)
            {
                _ = MessageBox(0, "USAGE: WSLXAppLaunch [WSLX11Application]\n\nExample: WSLXAppLaunch gedit ~/.bashrc", "Missing argument", 0);
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
                    Arguments = $"exec-x11wsl {string.Join(' ',args)}",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = false,
                    RedirectStandardInput = false,
                    RedirectStandardOutput = false
                }
            };

            try
            {
                _ = x11Srv.Start();
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is Win32Exception || ex is PlatformNotSupportedException)
            {
                // No X420 Server installed :(
            }
            
            _ = appStart.Start();
            appStart.WaitForExit();
        }
    }
}
