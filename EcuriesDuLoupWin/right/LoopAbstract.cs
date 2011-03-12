using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EcuriesDuLoupWin.right
{
    public abstract class LoopAbstract
    {
        private bool Started { get; set; }
        public int TimeToSleepInSecond { get; set; }
        private Thread Thread { get; set; }
        protected String NameOfThread { get; set; }

        public LoopAbstract()
        {
            this.Started = false;
            this.TimeToSleepInSecond = 60;
        }

        public void Start()
        {
            if (!this.Started)
            {
                this.Started = true;
                this.Thread = new Thread(new ThreadStart(Run));
                if (this.NameOfThread != null)
                {
                    this.Thread.Name = this.NameOfThread;
                }
                this.Thread.Start();
            }
        }
        private void Run()
        {
            while (this.Started)
            {
                try
                {
                    this.Process();
                }
                catch
                {
                }
                try
                {
                    Thread.Sleep(this.TimeToSleepInSecond * 1000);
                }
                catch
                {
                }
            }
            
        }

        public void Stop()
        {
            this.Started = false;
            if(this.Thread != null){
                 this.Thread.Abort();
            }
        }

        protected abstract void Process();
    }
}
