using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Tools.Applications.Deployment;
using System.IO;

namespace ClickOnceUtils
{
    public class OnInstall : IAddInPostDeploymentAction
    {
        public void Execute(AddInPostDeploymentActionArgs args)
        {
            File.Create(@"C:\Users\krack\Desktop\testAjout.txt");
        }
    }
}
