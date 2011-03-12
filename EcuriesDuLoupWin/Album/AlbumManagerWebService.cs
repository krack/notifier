using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using log4net;
using EcuriesDuLoupWin.ws;
using System.Windows.Forms;

namespace EcuriesDuLoupWin.Album
{
    public class AlbumManagerWebService : AlbumManager
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(AlbumManagerWebService));

        public Authentification Authentification { get; set; }
        public String UrlRootWS { get; set; }
        public WsRestAuthentified wsRestAuthentified { private get; set; }
        

        public long CreateAlbum(string name)
        {
            
            string url = this.UrlRootWS + "/albumPhoto/album/" + name;
            string serveurResponse = this.wsRestAuthentified.CallUrl(url, "PUT");
            long id = this.ExtractIdAlbum(serveurResponse);

            log.Info("AlbumManagerWebService.CreateAlbum : " + name+" convert in id : "+id);

            return id;
        }

        private long ExtractIdAlbum(String serveurResponse)
        {
            string id = serveurResponse.Split(new String[]{"<value>", "</value>"},StringSplitOptions.None )[1];
            return Int32.Parse(id);
        }


      

       public bool AddPicture(long albumId, System.IO.FileInfo picture)
       {
           log.Info("AlbumManagerWebService.AddPicture : " + picture.FullName + " in album " + albumId);

           string url = this.UrlRootWS + "/albumPhoto/photo/" + albumId;
           try
           {
               string retour = this.wsRestAuthentified.HttpUploadFile(url, picture.FullName, "file", "image", new NameValueCollection());
               string code = retour.Split(new String[] { "<status>", "</status>" }, StringSplitOptions.None)[1];
               return code.Equals("OK");
           }
           catch
           {
               return false;
           }
       }

        private byte[] GetBytesOfFiles(string pathOfFile){

         Stream file = File.OpenRead(pathOfFile);
            byte[] fileInByte= new byte[file.Length];
            file.Read(fileInByte, 0, Convert.ToInt32(file.Length));
            file.Close();
            return fileInByte;
         }

        

        public IList<Album> GetListAlbum()
        {
            try
            {
                WebClient client = new WebClient();
                ICredentials identifiant = new NetworkCredential(this.Authentification.Pseudo, this.Authentification.Password);
                client.Credentials = identifiant;
                string url = this.UrlRootWS + "/albumPhoto/albums";
                string serveurResponse = client.DownloadString(url);
                return this.ExtractListAlbums(serveurResponse);
            }
            catch (Exception e)
            {
                throw new NoGetAlbumException("Get album not possible", e);
            }
        }

        private IList<Album> ExtractListAlbums(String serveurResponse)
        {
            IList<Album> albums = new List<Album>();

            String[] albumsXml =  serveurResponse.Split(new String[]{"<album>", "</album>"},StringSplitOptions.None );

            int i = 0;
            foreach (String ablumXml in albumsXml)
            {
                if (i % 2 != 0)
                {
                    Album album = new Album();
                    string id = ablumXml.Split(new String[] { "<id>", "</id>" }, StringSplitOptions.None)[1];
                    string name = ablumXml.Split(new String[] { "<name>", "</name>" }, StringSplitOptions.None)[1];
               
                    album.Id = Int32.Parse(id);
                    album.Name = name;

                    albums.Add(album);
                }
                i++;
            }
            return albums;
        }

      
    }
}
