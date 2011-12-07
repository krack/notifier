using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin
{
    public interface Notificater
    {
        void ShowNotification(int secondesDuration, String message, String urlToOpen);
    }
}
