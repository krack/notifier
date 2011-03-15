using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcuriesDuLoupWin.utils;
using System.Diagnostics;

namespace EcuriesDuLoupWin.Converter
{
    public class ConvertFFmpeg2Theora : Convert
    {
        public static String ExePath
        {
            get
            {
                return ApplicationPath.GetApplicationFolder() + "ffmpeg2theora.exe";
            }
        }
        public String ConvertToTheora(string videoFilePath)
        {
            int indexOfStartExtention = videoFilePath.LastIndexOf(".");
            String pathWitoutExtention = videoFilePath.Remove(indexOfStartExtention);

            String outputPath =  pathWitoutExtention + "_out.ogv";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = ConvertFFmpeg2Theora.ExePath;
            start.Arguments = " -o \"" + outputPath + "\" \"" + videoFilePath + "\"";
           start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = false;
          


            Process p = Process.Start(start);
            p.WaitForExit();

            return outputPath;
        }
    }

}
