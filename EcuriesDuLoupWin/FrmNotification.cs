using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EcuriesDuLoupWin;

namespace TestNotificationForm
{
    public partial class FrmNotification : Maf.Windows.Forms.NotificationForm
    {
        public FrmNotification()
        {
            InitializeComponent();
        }

        public string Message {
            get { return this.lbMessage.Text; }
            set { this.lbMessage.Text = value; }
        }

        public string UrlToSend { get; set; }

        private void lbMessage_Click(object sender, EventArgs e)
        {
           WebUtils.LaunchBroswer(this.UrlToSend);
        }

    }
}

