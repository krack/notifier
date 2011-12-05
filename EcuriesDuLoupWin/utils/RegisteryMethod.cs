using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Security.AccessControl;

namespace EcuriesDuLoupWin.utils
{
    public class RegisteryMethod
    {
        private static String getPathOfApplication()
        {
            return Environment.CommandLine.Replace(".vshost","");
        }
        public static void addApplicationOnComputerStart()
         {
             RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
             if (key != null)
             {
                  String s= Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Microsoft\Windows\Start Menu\Programs\Krack\Ecurie du loup\Notifier.appref-ms";
                 key.SetValue("EcurieLoupNotifier", s);
                 key.Close();
             }
             key = null;
         }
    }
}
