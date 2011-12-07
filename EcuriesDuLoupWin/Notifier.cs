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
         
    
          public string Message { get; set; }
          public string UrlToSend { get; set; }
          public int MessageDurationInSeconde { get; set; }
          public bool IsPlaySound { get; set; }
          public Notificater Notificater { get; set; }

          public Notifier()
          {
              this.Message = "Default Message";
              this.UrlToSend = "http://www.ecuriesduloup.fr";
              this.MessageDurationInSeconde = 5;
              this.IsPlaySound = true;
          }

          public void Show()
          {
              if (this.IsPlaySound)
              {
                  this.PlaySound();
              }
              this.Notificater.ShowNotification(this.MessageDurationInSeconde, this.Message, this.UrlToSend); 
            
          }
        

          private void PlaySound()
          {
              Stream streamWav = EcuriesDuLoupWin.Properties.Resources.loup;
              SoundPlayer s = new SoundPlayer(streamWav);
              s.Play();
          }
      }
}
