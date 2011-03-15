using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using EcuriesDuLoupWin.gui;

namespace EcuriesDuLoupWin.Observer
{
    public class WebExceptionObserverChangeAuthentification : WebExceptionObserver
    {

       

        public void NotifieUnauthorizedException()
        {
            AuthentificationDataManager authMangaer = AuthentificationDataManager.Instance;
            using (FormAuthentification authForm = new FormAuthentification())
            {
                authForm.AuthentificationDataManager = authMangaer;
                authForm.Show();

                while (!authForm.IsEnd)
                {
                    Application.DoEvents();
                }
            }
        }
    }
}
