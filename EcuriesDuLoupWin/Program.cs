using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EcuriesDuLoupWin;
using EcuriesDuLoupWin.checker;
using EcuriesDuLoupWin.Observer;
using EcuriesDuLoupWin.Album;
using System.IO;
using EcuriesDuLoupWin.utils;
using Utils;

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

            //Register application for too lauch when application start
            RegisteryMethod.addApplicationOnComputerStart();
            //download Registery Manager
            DowloadRegistryManager();
            if (args.Length == 1)
            {
                Factory factory = new Factory();
                Form1 form = factory.Form1;
                Application.Run(form);

                //no saved authentification
             /*   if (!factory.AuthentificationDataManager.IsDefine)
                {
                    factory.ObserverAuthentification.NotifieUnauthorizedException();
                }
              * */
            }
            else
            {
                ConsoleManager consoleManager = new ConsoleManager(args);
                consoleManager.Run();
            }
        }


        private static void DowloadRegistryManager()
        {
            String exeRegistryManager = RegistryExeCommand.RegistyProgramPath;

            WebUtils.UpdateDownloadFile("http://www.ecuriesduloup.fr/registryManager/RegistryManager.exe", exeRegistryManager);

        }
    }
}