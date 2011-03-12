using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcuriesDuLoupWin.ws;

namespace EcuriesDuLoupWin.right
{
    public class RightDao
    {
        public WsRestAuthentified wsRestAuthentified { private get; set; }
        public IList<Right> GetListRight(Authentification user)
        {
            String url = this.wsRestAuthentified.UrlRootWS + "/user/rights";
            String xmlRight = this.wsRestAuthentified.CallUrl(url, "GET");
            IList<Right> rights = Get(xmlRight);
            return rights;

        }

        private IList<Right> Get(String xmlRight)
        {
            IList<Right> rights = new List<Right>();
            String[] xmlSplits = xmlRight.Split(new String[] { "<string>", "</string>" }, StringSplitOptions.None);

            int i = 0;
            foreach (String xmlSplit in xmlSplits)
            {
                if (i != 0)
                {
                    if (!xmlSplit.Equals(""))
                    {
                        Right right = Right.GetRight(xmlSplit);
                        if (right != null)
                        {
                            rights.Add(right);
                        }
                    }
                }
                i++;
            }

            return rights;
        }

    }
}
