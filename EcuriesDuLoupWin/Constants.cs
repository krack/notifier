using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace EcuriesDuLoupWin
{
    public static class Constants
    {
        public static String GetPathOfRepository(){
            String home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            String repositoryDirectoryName = ConfigurationManager.AppSettings["repositoryDirectory"];

            return home+"\\"+repositoryDirectoryName;
        }
    }
}
