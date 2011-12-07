using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace EcuriesDuLoupWin.utils.menu
{
    public class SubMenuContextMenu : ContextMenu
    {
        public IList<ContextMenu> Menu;

        public SubMenuContextMenu(String label)
            : base(label)
        {
            this.Menu = new List<ContextMenu>();
        }

        public SubMenuContextMenu(String label, IList<ContextMenu> menu)
            : base(label)
        {
            this.Menu = menu;
        }

        public override void Add()
        {
            String truc = base.GetRegisteryPathForAdd();
            {
                EcuriesDuLoupWin.utils.Registry reg = this.Create(truc, "MUIVerb", this.Label);
                reg.Add();
            }
            {
                EcuriesDuLoupWin.utils.Registry reg = this.Create(truc, "SubCommands", "");
                reg.Add();
            }
            {
                if (this.Icon != null)
                {
                    EcuriesDuLoupWin.utils.Registry reg = this.Create(truc, "Icon", this.Icon);
                    reg.Add();
                }
            }
            {
            EcuriesDuLoupWin.utils.Registry reg = this.Create(this.GetRegisteryPathForAdd());
                reg.Add();
            }
            foreach (ContextMenu contextMenu in this.Menu)
            {
                contextMenu.Parent = this;
                contextMenu.Add();
            }
            /*    this.Command
                RegistryKey rkcu = Microsoft.Win32.Registry.ClassesRoot;

                RegistryKey test = rkcu.CreateSubKey(base.GetRegisteryPathForAdd());
                test.SetValue("MUIVerb", this.Label);
                test.SetValue("SubCommands", "");
                if (this.Icon != null)
                {
                    test.SetValue("Icon", this.Icon);
                }
                rkcu.CreateSubKey(this.GetRegisteryPathForAdd());
                foreach (ContextMenu contextMenu in this.Menu)
                {
                    contextMenu.Parent = this;
                    contextMenu.Add();
                }*/
        }
        
        public override String GetRegisteryPathForAdd()
        {
            return base.GetRegisteryPathForAdd() + "\\Shell\\";
        }

        public override String GetRegisteryPathForRemove()
        {
            return base.GetRegisteryPathForAdd();
        }
    }
}
