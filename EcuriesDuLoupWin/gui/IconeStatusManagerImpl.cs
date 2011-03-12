using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNotificationForm;
using System.Drawing;
using System.ComponentModel;
using System.IO;

namespace EcuriesDuLoupWin.gui
{
    public class IconeStatusManagerImpl : IconeStatusManager
    {
        private Form1 form1;
        private ComponentResourceManager resources;
        private IDictionary<NotifierType, IconStatus> unitaryStatus;

        public IconeStatusManagerImpl(Form1 form1)
        {

            this.unitaryStatus = new Dictionary<NotifierType, IconStatus>();
            this.form1 = form1;
            this.resources = new ComponentResourceManager(typeof(Form1));
           
        }

        public void DefineNormalStatus(NotifierType notifierType)
        {
            this.Put(notifierType, IconStatus.Normal);
            this.updateApplicationStatus();
        }

        public void DefineMessageStatus(NotifierType notifierType)
        {
            this.Put(notifierType, IconStatus.Message);
            this.updateApplicationStatus();
        }

        public void DefineDisconnectStatus(NotifierType notifierType)
        {

            this.Put(notifierType, IconStatus.Disconnect);
            this.updateApplicationStatus();
        }

        private void Put(NotifierType notifierType, IconStatus status){

            if (this.unitaryStatus.ContainsKey(notifierType))
            {
                this.unitaryStatus.Remove(notifierType);
            }
            this.unitaryStatus.Add(notifierType, status);
         }


        private void updateApplicationStatus()
        {
            try
            {
                if (this.isMessageStatus())
                {
                    this.DefineMessageStatus();
                }
                else if (this.isDisconnectStatus())
                {
                    this.DefineDisconnectStatus();
                }
                else
                {
                    this.DefineNormalStatus();
                }
            }
            catch
            {
            }
        }

        private bool isMessageStatus()
        {
            bool isMessageStatus = false;

            foreach (KeyValuePair<NotifierType, IconStatus> iconStatus in this.unitaryStatus)
            {
                if (iconStatus.Value.Equals(IconStatus.Message))
                {
                    isMessageStatus = true;
                }
            }

            return isMessageStatus;
        }

        private bool isDisconnectStatus()
        {
            bool isDisconnectStatus = true;

            foreach (KeyValuePair<NotifierType, IconStatus> iconStatus in this.unitaryStatus)
            {
                if (! iconStatus.Value.Equals(IconStatus.Disconnect))
                {
                    isDisconnectStatus = false;
                }
            }

            return isDisconnectStatus;
        }


        private void DefineNormalStatus()
        {

            Bitmap logo =EcuriesDuLoupWin.Properties.Resources.logo;
            Icon icon = this.bitmapToIcon(logo);
            String message = "Les écuries du loup\r\n\r\nService Actif!";
            this.form1.DefineIcon(icon, message);
        }

        private void DefineMessageStatus()
        {
            Bitmap logo = EcuriesDuLoupWin.Properties.Resources.logo_message;
            Icon icon = this.bitmapToIcon(logo);
            String message = "Les écuries du loup\r\n\r\nNouveau message";
            this.form1.DefineIcon(icon, message);
        }

        private void DefineDisconnectStatus()
        {
            Bitmap logo = EcuriesDuLoupWin.Properties.Resources.logo_error;
            Icon icon = this.bitmapToIcon(logo);
            String message = "Les écuries du loup\r\n\r\nService En erreur!";
            this.form1.DefineIcon(icon, message);
        }

       

        private Icon bitmapToIcon(Bitmap bitmap)
        {
            IntPtr hicone = bitmap.GetHicon();
            Icon icon = Icon.FromHandle(hicone);
            return icon;
        }
    }
}
