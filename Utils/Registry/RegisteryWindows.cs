using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Utils
{
    public class RegistryWindows : EcuriesDuLoupWin.utils.Registry
    {
        public String Key { get; set; }
        public String Value { get; set; }
        public String KeyDirectory { get; set; }

        public RegistryWindows(String keyDirectory, String key, String value)
        {

            this.KeyDirectory = keyDirectory; 
            this.Key = key;
            this.Value = value;
        }

        public RegistryWindows(String keyDirectory)
        {

            this.KeyDirectory = keyDirectory;
        }



        public void Remove()
        {
            RegistryKey rkcu = Registry.ClassesRoot;
            if (rkcu.OpenSubKey(this.KeyDirectory) != null)
            {
                rkcu.DeleteSubKeyTree(this.KeyDirectory);
                rkcu.Close();
            }
        }

        public void Add()
        {
            RegistryKey rkcu = Registry.ClassesRoot;

            RegistryKey registeryKey = rkcu.CreateSubKey(this.KeyDirectory);
            if ((this.Key != null) && (this.Value != null))
            {
                registeryKey.SetValue(this.Key, this.Value);
            }
               
            registeryKey.Close();
        }
    }
}
