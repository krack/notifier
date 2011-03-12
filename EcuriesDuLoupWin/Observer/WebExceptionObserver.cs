using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin
{
    public interface WebExceptionObserver
    {
        void NotifieUnauthorizedException();
    }
}
