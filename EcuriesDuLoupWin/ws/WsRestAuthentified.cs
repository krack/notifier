using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace EcuriesDuLoupWin.ws
{
    public class WsRestAuthentified
    {

        public Authentification Authentification { get; set; }
        public String UrlRootWS { get; set; }

        

        public String CallUrl(String url, String method)
        {

            WebRequest webRequest = WebRequest.Create(url);
            ICredentials identifiant = new NetworkCredential(this.Authentification.Pseudo, this.Authentification.Password);

            webRequest.Credentials = identifiant;

            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = method;
            if (method.Equals("POST"))
            {
                byte[] bytes = Encoding.ASCII.GetBytes("");
                Stream os = null;
                // send the Post
                webRequest.ContentLength = bytes.Length;
                os = webRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);
                os.Close();
            }
            // get the response
            WebResponse webResponse = webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());
            return sr.ReadToEnd().Trim();

        }

        public String HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
        {


            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            ICredentials identifiant = new NetworkCredential(this.Authentification.Pseudo, this.Authentification.Password);
            wr.Credentials = identifiant;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Dispose();
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            string response = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                response = reader2.ReadToEnd();
            }
            catch
            {
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
                throw new Exception();
            }
            finally
            {
                wr = null;
            }
            return response;
        }
    }
}
