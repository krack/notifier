using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EcuriesDuLoupWin.utils
{
    public static class ApplicationPath
    {
        public static String GetApplicationPath()
        {
            String pathExeWithoutVshost = ApplicationPath.GetPathOfExe().Replace(".vshost", "");
             return pathExeWithoutVshost;
        }

        public static String GetApplicationFolder()
        {
            String pathOfExe = ApplicationPath.GetPathOfExe();
            //get all test of second value (afert " char) jusqu'a \
            String pathOfFolder = pathOfExe.Substring(1, pathOfExe.LastIndexOf('\\'));
            return pathOfFolder;
        }

        private static String GetPathOfExe()
        {
            String pathOfExe = Environment.CommandLine.Split(new String[]{"\" "}, StringSplitOptions.None)[0];
            return (pathOfExe.EndsWith("\""))? pathOfExe : pathOfExe+"\"";
        }
    }
}
