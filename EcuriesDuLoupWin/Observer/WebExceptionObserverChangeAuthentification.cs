using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using EcuriesDuLoupWin.gui;
using EcuriesDuLoupWin.right;

namespace EcuriesDuLoupWin.Observer
{
    public class WebExceptionObserverChangeAuthentification : WebExceptionObserver
    {
        public RightService RightService { get; set; }
       

        public void NotifieUnauthorizedException()
        {
            AuthentificationDataManager authMangaer = AuthentificationDataManager.Instance;
            FormAuthentification authForm = FormAuthentification.Instance;
            if(authForm != null){
                authForm.AuthentificationDataManager = authMangaer;
                authForm.RightService = this.RightService;
                authForm.Show();

                while (!authForm.IsEnd)
                {
                    Application.DoEvents();
                }

                authForm.Dispose();
            }
        }
    }
}
