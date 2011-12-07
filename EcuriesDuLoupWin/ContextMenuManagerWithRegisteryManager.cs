using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcuriesDuLoupWin.utils.menu;
using Utils;
using System.Diagnostics;
using EcuriesDuLoupWin.utils;

namespace EcuriesDuLoupWin
{
    public class ContextMenuManagerWithRegisteryManager : ContextMenuManager
    {
        public void AddEcurieDuLoupInContextualsMenu()
        {
            String arguments = String.Format("-addimages {0}", ApplicationPath.GetApplicationPath());
            this.LaunchRegistryManager(arguments);
        }

        public void RemoveEcurieDuLoupInContextualsMenu()
        {
            String arguments = String.Format("-removeimages {0}", ApplicationPath.GetApplicationPath());
            this.LaunchRegistryManager(arguments);
        }

        private void LaunchRegistryManager(String arguments)
        {

            ProcessStartInfo start = new ProcessStartInfo(RegistryExeCommand.RegistyProgramPath, arguments);
            start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            Process.Start(start);
        }
    }
}
