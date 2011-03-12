using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin.gui
{
    public interface IconeStatusManager
    {
        void DefineNormalStatus(NotifierType notifierType);

        void DefineDisconnectStatus(NotifierType notifierType);

        void DefineMessageStatus(NotifierType notifierType);
    }
}
