using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace EcuriesDuLoupWin.utils.menu
{
    public class ImageContextMenu : ContextMenu
    {
        public ImageContextMenu(String label, String command)
            : base(label, command)
        {
            this.Type = "SystemFileAssociations\\image";
        }


    }
}
