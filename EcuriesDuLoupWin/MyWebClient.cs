using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace EcuriesDuLoupWin
{
    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var result = base.GetWebRequest(address);
            result.Timeout = -1;
            return result;
        }
    }
}
