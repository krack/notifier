using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using EcuriesDuLoupWin.right;

namespace EcuriesDuLoupWin
{
    public class Loop : LoopAbstract
    {
        public List<CheckerAndNotifier> CheckerAndNotifier { get; set; }


        public Loop() : base()
        {
            this.NameOfThread = "Notifiers";
            this.CheckerAndNotifier = new List<CheckerAndNotifier>();
        }




        protected override void Process()
        {
            foreach (CheckerAndNotifier checker in this.CheckerAndNotifier)
            {
                checker.Run();
            }
        }
    }
}
