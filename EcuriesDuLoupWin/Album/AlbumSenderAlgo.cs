using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EcuriesDuLoupWin
{
    public class AlbumSenderAlgo
    {
        public bool Start { get; set; }
        public List<CheckerAndNotifier> CheckerAndNotifier { get; set; }
        public int TimeInSecondeToWait { get; set; }


        public AlbumSenderAlgo()
        {
          
            this.CheckerAndNotifier = new List<CheckerAndNotifier>();
            this.TimeInSecondeToWait = 5;
        }
        public void Run()
        {
            this.Start = true;
            Thread thread = new Thread(Launch);
            thread.Start();
        }

        private void Launch()
        {
            while (this.Start)
            {
                foreach (CheckerAndNotifier checker in this.CheckerAndNotifier)
                {
                    checker.Run();
                }
                Thread.Sleep(this.TimeInSecondeToWait * 1000);
            }
        }

        public void Stop()
        {
            this.Start = false;
        }
    }
}
