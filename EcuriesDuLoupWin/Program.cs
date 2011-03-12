using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EcuriesDuLoupWin;
using EcuriesDuLoupWin.checker;
using EcuriesDuLoupWin.Observer;
using EcuriesDuLoupWin.Album;
using System.IO;

namespace TestNotificationForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String[] args = Environment.GetCommandLineArgs();

            if (args.Length == 1)
            {
               


                Form1 form = new Form1();
                Application.Run(form);
            }
            else
            {
                ConsoleManager consoleManager = new ConsoleManager(args);
                consoleManager.Run();
            }
        }
    }
}