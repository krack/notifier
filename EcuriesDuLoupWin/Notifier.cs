using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNotificationForm;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.Reflection;
using System.IO;

namespace EcuriesDuLoupWin
{
    public class Notifier
    {
        public static int nomberOfNotifier = 0;
    
        public string Message { get; set; }
        public string UrlToSend { get; set; }
        public int MessageDurationInSeconde { get; set; }
        public bool IsPlaySound { get; set; }

        public Notifier()
        {
            this.Message = "Default Message";
            this.UrlToSend = "http://www.ecuriesduloup.fr";
            this.MessageDurationInSeconde = 5;
            this.IsPlaySound = true;
        }

        public void Show()
        {
           
            Thread thread = new Thread(LaunchNotification);
            thread.Start();
           
            
        }

        private void LaunchNotification()
        {
            int number = 0;
            lock (this)
            {
                number = ++Notifier.nomberOfNotifier;
            }

            using (FrmNotification f = new FrmNotification())
            {
                f.AutoHide = true;
                f.AutoHideTime = this.MessageDurationInSeconde;
                f.Message = this.Message;
                f.UrlToSend = this.UrlToSend;
                f.Location = new Point(
                        SystemInformation.WorkingArea.Right - f.Width - SystemInformation.VerticalScrollBarWidth,
                        SystemInformation.WorkingArea.Bottom - ((Notifier.nomberOfNotifier) * (f.Height + 10)) - SystemInformation.HorizontalScrollBarHeight
                    );
                if (this.IsPlaySound)
                {
                    this.PlaySound();
                }
                f.ShowDialog();
            }
            lock (this)
            {
                Notifier.nomberOfNotifier--;
            }
        }
        

        private void PlaySound()
        {
            Stream streamWav = EcuriesDuLoupWin.Properties.Resources.loup;
            SoundPlayer s = new SoundPlayer(streamWav);
            s.Play();
        }
    }
}
