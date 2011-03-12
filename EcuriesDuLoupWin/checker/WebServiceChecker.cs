using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Xml.Linq;
using System.Windows.Forms;
using EcuriesDuLoupWin.Observer;
using EcuriesDuLoupWin.gui;

namespace EcuriesDuLoupWin.checker
{
    public class WebServiceChecker : AbstractGenericSubject<WebExceptionObserver>, GenericSubject<WebExceptionObserver>, Checker
    {
        public String StatusUrl { get; set; }
        public Authentification Authentification { get; set; }
         private IconeStatusManager iconStatusManager;
         private NotifierType notifierType;

        private bool inProgress;
        private bool fail;
        private Status status;
        private long lastTimelastAction = 0;



        public WebServiceChecker(IconeStatusManager iconStatusManager, NotifierType notifierType)
        {
            this.iconStatusManager = iconStatusManager;
            this.notifierType = notifierType;
        }
       
        public bool HasNews()
        {
            WebClient client = new WebClient();
            this.inProgress = true;
            this.fail = false;
            client.Encoding = Encoding.UTF8;
            ICredentials identifiant = new NetworkCredential(this.Authentification.Pseudo, this.Authentification.Password);
          
            client.Credentials = identifiant;
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
              
            client.DownloadStringAsync(new Uri(this.StatusUrl), UriKind.Absolute);
            
            while (this.inProgress)
            {
                Thread.Sleep(100);
            }
            if (this.fail)
            {
                return false;
            }

            bool isNewAction = this.lastTimelastAction < this.status.TimeLastAction;
            this.lastTimelastAction = this.status.TimeLastAction;
            bool hasNew = this.status.HasNew && isNewAction;
            if (this.status.HasNew)
            {
                this.iconStatusManager.DefineMessageStatus(this.notifierType);
            }
            else
            {
                this.iconStatusManager.DefineNormalStatus(this.notifierType);
            }
            return hasNew;
            
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                string s = e.Result;
                string[] separatorHasNew = new string[] { "<hasNew>", "</hasNew>" };
                string hasNew = s.Split(separatorHasNew, StringSplitOptions.RemoveEmptyEntries)[1];
                string[] separatorTimeLastAction = new string[] { "<timeLastAction>", "</timeLastAction>" };
                string timeLastAction = s.Split(separatorTimeLastAction, StringSplitOptions.RemoveEmptyEntries)[1];
                Status stat = new Status();
                stat.HasNew = Boolean.Parse(hasNew);
                stat.TimeLastAction = Int64.Parse(timeLastAction);
                this.status = stat;
                this.inProgress = false;

            }
            catch (Exception exc)
            {
                this.iconStatusManager.DefineDisconnectStatus(this.notifierType);
                if (exc.InnerException is WebException)
                {
                    WebException webException = (WebException)exc.InnerException;
                    if (webException.Status == WebExceptionStatus.ProtocolError)
                    {
                        if (HttpStatusCode.Unauthorized == ((HttpWebResponse)webException.Response).StatusCode)
                        {
                            this.NotifieUnauthorizedException();
                        }
                    }
                }
                else
                {
                    Console.WriteLine(exc.Message);
                }
                this.inProgress = false;
                this.fail = true;
            }
        }
       
        private void NotifieUnauthorizedException()
        {
            foreach (WebExceptionObserver observer in this.Observers)
            {
                observer.NotifieUnauthorizedException();
            }
        }

        public void reset()
        {
            this.lastTimelastAction = 0;
        }
    }
}
