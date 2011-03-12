using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin
{
    public interface SerialiserManager<T>
    {
        String FilePath { get; set; }

        T Get();

        void Save(T t);
    }
}
