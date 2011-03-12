using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin.utils.menu
{
    public static class Icons
    {
        public static string GetAddIcon()
        {
            return Icons.GetFolderOfIcon() + "add.ico";
        }

        public static string GetNewIcon()
        {
            return Icons.GetFolderOfIcon() + "new.ico";
        }

        public static string GetLogoIcon()
        {
            return Icons.GetFolderOfIcon()+"logo.ico";
        }

        private static string GetFolderOfIcon()
        {
            return ApplicationPath.GetApplicationFolder() + @"\";
        }
    }
}
