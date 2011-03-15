using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EcuriesDuLoupWin
{
    public static  class Extentions
    {
        
            public static String NameWitoutExtention(this FileInfo file)
            {
                int indexOfStartExtention = file.Name.LastIndexOf(".");
                String nameWitoutExtention = file.Name.Remove(indexOfStartExtention);

                return nameWitoutExtention;
            }

            public static String FullNameWitoutExtention(this FileInfo file)
            {
                int indexOfStartExtention = file.FullName.LastIndexOf(".");
                String nameWitoutExtention = file.FullName.Remove(indexOfStartExtention);

                return nameWitoutExtention;
            }
    }
}
