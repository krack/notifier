using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using Utils;
using Utils.os;

namespace EcuriesDuLoupWin.utils.menu
{
    public abstract class ContextMenu
    {
        public String Label { get; set; }
        public String Command { get; set; }
        public SubMenuContextMenu Parent { get; set; }
        public String Type { get; set; }
        public String Icon { get; set; }

        protected ContextMenu(String label)
        {
            this.Label = label;
        }

        public ContextMenu(String label, String command)
        {
            this.Label = label;
            this.Command = command;
        }

        public virtual void Add()
        {
            try
            {
                /*RegistryKey rkcu = Microsoft.Win32.Registry.ClassesRoot;
                //create name
                RegistryKey test1 = rkcu.CreateSubKey(this.GetRegisteryPathForAdd());
                test1.SetValue("MUIVerb", this.Label);
                if (this.Icon != null)
                {
                    test1.SetValue("Icon", this.Icon);
                }
                test1.Close();*/


                //create command
                /*RegistryKey test = rkcu.CreateSubKey(this.GetRegisteryPathForAdd() + "\\command");
                test.SetValue("", this.Command);
                test.Close();*/


                String truc  = this.GetRegisteryPathForAdd(); 
                EcuriesDuLoupWin.utils.Registry reg = this.Create(truc, "MUIVerb", this.Label);
                reg.Add();
                 if (this.Icon != null)
                {
                    EcuriesDuLoupWin.utils.Registry regIcon = this.Create(truc, "Icon", this.Icon);
                    regIcon.Add();
                }


                 EcuriesDuLoupWin.utils.Registry regCommand = this.Create(truc + "\\command", "", this.Command);
                 regCommand.Add();
            }
            catch (Exception e)
            {
                MessageBox.Show("ContextMenu.Add : " + e.Message);
            }
        }

        private EcuriesDuLoupWin.utils.Registry Create(String directoryKey,String key, String value)
        {
            EcuriesDuLoupWin.utils.Registry registry = null;
            if(OperatingSystemDeterminer.Is7Version() || OperatingSystemDeterminer.IsVistaVersion()){
                registry = new RegistryExeCommand(directoryKey, key, value);                
            }else{
               registry=  new RegistryWindows(directoryKey, key, value);
            }

            return registry;
        }

        private EcuriesDuLoupWin.utils.Registry Create(String directoryKey)
        {
            EcuriesDuLoupWin.utils.Registry registry = null;
            if (OperatingSystemDeterminer.Is7Version() || OperatingSystemDeterminer.IsVistaVersion())
            {
                registry = new RegistryExeCommand(directoryKey);
            }
            else
            {
                registry = new RegistryWindows(directoryKey);
            }

            return registry;
        }

        private String GetParentRegisteryPath()
        {
            String registeryPath = "";
            if (this.Parent != null)
            {
                registeryPath = this.Parent.GetRegisteryPathForAdd();
            }
            else
            {
                if (this.Type == null)
                {
                    throw new Exception("Type can't be null for root Context Menu");
                }
                registeryPath = this.Type + "\\shell\\";
            }
            return registeryPath;
        }

        public virtual String GetRegisteryPathForAdd()
        {
           return this.GetParentRegisteryPath() + this.Label+"\\";
        }

        public virtual String GetRegisteryPathForRemove()
        {
            return this.GetParentRegisteryPath() + this.Label + "\\";
        }

        public virtual void Remove()
        {
            try
            {
                /*RegistryKey rkcu = Microsoft.Win32.Registry.ClassesRoot;
                if (rkcu.OpenSubKey(this.GetRegisteryPathForRemove()) != null)
                {
                    rkcu.DeleteSubKeyTree(this.GetRegisteryPathForRemove());
                    rkcu.Close();
                }*/

                EcuriesDuLoupWin.utils.Registry reg = this.Create(this.GetRegisteryPathForRemove());
                reg.Remove();
            }
            catch (Exception e)
            {
                MessageBox.Show("Remove : " + e.Message);
            }
        }
    }
}
