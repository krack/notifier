using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace EcuriesDuLoupWin.utils
{
    public static class Util
    {
        public static bool IsValidImage(FileInfo file){

            try
            {
                Image newImage = Image.FromFile(file.FullName);
                newImage.Dispose();
            }
            catch
            {
                return false;
            }
            return true;
        }


        public static bool IsValidVideo(FileInfo file)
        {

            if (
                    file.Extension.ToLower().Equals(".ogv")
                ||
                    file.Extension.ToLower().Equals(".mp4")
                ||
                    file.Extension.ToLower().Equals(".avi")
                 ||
                    file.Extension.ToLower().Equals(".mov")
                 ||
                    file.Extension.ToLower().Equals(".mpg")
                 ||
                    file.Extension.ToLower().Equals(".mpa")
                 ||
                    file.Extension.ToLower().Equals(".asf")
                 ||
                    file.Extension.ToLower().Equals(".wma")
                 ||
                    file.Extension.ToLower().Equals(".mp2")
                 ||
                    file.Extension.ToLower().Equals(".m2p")
                 ||
                    file.Extension.ToLower().Equals(".flv")         
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
