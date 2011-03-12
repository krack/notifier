using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcuriesDuLoupWin.utils;
using System.Diagnostics;

namespace Utils
{
    public class RegistryExeCommand : Registry
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string KeyDirectory { get; set; }

        public static string RegistyProgramPath
        {
            get { return ApplicationPath.GetApplicationFolder() + "RegistryManager.exe"; }
            private set { }
        }

        public RegistryExeCommand(String keyDirectory, String key, String value)
        {

            this.KeyDirectory = keyDirectory; 
            this.Key = key;
            this.Value = value;
        }

        public RegistryExeCommand(String keyDirectory)
        {

            this.KeyDirectory = keyDirectory;
        }

        public void Add()
        {

            String arguments = String.Format("-add \"{0}\" \"{1}\" \"{2}\"", this.GetKeyDirectoryFormated(), this.Key, this.Value);
            this.LaunchRegistryManager(arguments);
        }

        private string GetKeyDirectoryFormated()
        {
            string keyDirectoryWithout ="" ;
            if (this.KeyDirectory.EndsWith("\\"))
            {
                keyDirectoryWithout = this.KeyDirectory.Substring(0, this.KeyDirectory.Length - 1);
            }
            else
            {
                keyDirectoryWithout = this.KeyDirectory;
            }
            return keyDirectoryWithout;
        }

        public void Remove()
        {
            String arguments = String.Format("-remove \"{0}\"", this.GetKeyDirectoryFormated());
            this.LaunchRegistryManager(arguments);
        }

        private void LaunchRegistryManager(String arguments){
            Process.Start(RegistryExeCommand.RegistyProgramPath, arguments);
        }
    }
}
