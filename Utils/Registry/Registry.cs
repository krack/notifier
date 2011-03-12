using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin.utils
{
    public interface Registry
    {

        String Key { get; set; }
        String Value { get; set; }
        String KeyDirectory { get; set; }

        void Add();
        void Remove();
    }
}
