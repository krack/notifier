using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net;

namespace EcuriesDuLoupWin
{
    public static class WebUtils
    {
        public static void LaunchBroswer(String url)
        {
            Process.Start(url);
        }

        public static void Download(String url, String path)
        {
            WebClient webClient = new WebClient();

            webClient.DownloadFile(url, path);

            webClient.Dispose();

        }
    }
}
