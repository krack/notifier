using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin
{
    public interface Checker
    {
        String StatusUrl { get; set; }
        Authentification Authentification { get; set; }

        bool HasNews();

        void reset();
    }
}
