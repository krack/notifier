using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace EcuriesDuLoupWin
{
    public static class WebUtils
    {
        public static void LaunchBroswer(String url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
            }
        }

        public static void UpdateDownloadFile(String url, String path)
        {
            FileInfo file = new FileInfo(path);
             if (!file.Exists)
             {
                 using (WebClient webClient = new WebClient())
                 {

                     webClient.DownloadFile(url, path);

                 }
             }
        }
    }
}
