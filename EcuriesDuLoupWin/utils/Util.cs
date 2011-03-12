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
    }
}
