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

                 key.SetValue("EcurieLoupNotifier", RegisteryMethod.getPathOfApplication());
                 key.Close();
             }
             key = null;
         }


        public static void AddFolder(String label, String command)
        {
            RegistryKey rkcu = Microsoft.Win32.Registry.ClassesRoot;

            RegistryKey test = rkcu.CreateSubKey("Folder\\shell\\"+label+"\\command");
            test.SetValue("", command);
            test.Close();
        }

        public static void RemoveFolder(String label)
        {
            try
            {
                RegistryKey rkcu = Microsoft.Win32.Registry.ClassesRoot;
                rkcu.DeleteSubKey("Folder\\shell\\" + label + "\\command");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void addPictureContextuelMenuEntry()
        {

            String pathOfApplication = RegisteryMethod.getPathOfApplication();
            RegistryKey rkcu = Microsoft.Win32.Registry.ClassesRoot;

             RegistryKey test = rkcu.CreateSubKey("Folder\\shell\\Edl envoi\\command");
            String command = String.Format("{0} -add -d %1 ", pathOfApplication);
            test.SetValue("", command);
            test.Close();
           /* RegistrySecurity rs = new RegistrySecurity();

            String user = Environment.UserDomainName+"\\"+Environment.UserName;

            rs.AddAccessRule(new RegistryAccessRule(user, RegistryRights.FullControl, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow));

            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"jpegfile\shell", RegistryKeyPermissionCheck.Default, rs))
            {

                if (key.GetValue("(par défaut)") == null)
                {
                    string pathProgramme = @"rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen %1";
                    key.SetValue("(par défaut)", WindowsRegistery.getPathOfApplication());
                }

            }
      */
        }
    }
}
