using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using EcuriesDuLoupWin.right;
using System.Security;
using System.Windows.Forms;
using EcuriesDuLoupWin.utils;
using EcuriesDuLoupWin.Converter;

namespace EcuriesDuLoupWin.Album
{
    public class AlbumService : LoopAbstract
    {
        public AlbumManager albumManager{ get; set; }
        public String PicturesRepository { get; set; }

        public AlbumService()
            : base()
        {
            this.NameOfThread = "album service";
        }

        protected override void Process()
        {
            bool hasPhotoSend;
            do
            {
                hasPhotoSend = false;

                DirectoryInfo rootDirectory = new DirectoryInfo(this.PicturesRepository);
                if (rootDirectory.Exists)
                {
                    foreach (DirectoryInfo album in rootDirectory.GetDirectories())
                    {
                        hasPhotoSend |= this.AlbumManage(album);
                    }
                }
                else
                {
                    rootDirectory.Create();
                }
            } while (hasPhotoSend);
        }


        private bool AlbumManage(DirectoryInfo directory)
        {
            long albumId = this.CreateAlbumIfNessesary(directory);
            return this.SendPicturesOfDirectory(albumId, directory);
        }

        private long CreateAlbumIfNessesary(DirectoryInfo directory)
        {

            String name = directory.Name;
            long id;
            bool isId = Int64.TryParse(name, out id);
            if(this.hasNeedCreateAlbume(isId)){
                id = this.albumManager.CreateAlbum(name);
                directory.MoveTo(directory.Parent.FullName + "\\" + id);
            }
            return id;
           
        }


        public bool hasNeedCreateAlbume(bool idIsLong)
        {
            return !idIsLong;
        }

        private bool SendPicturesOfDirectory(long albumId, DirectoryInfo directory)
        {
            bool hasNewPictureSend = false;

            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                if (Util.IsValidImage(file))
                {
                    this.SendPicture(albumId, file);
                }
                else if (Util.IsValidVideo(file))
                {

                    if (!file.NameWitoutExtention().EndsWith("_out"))
                    {
                        FileInfo convertedFile = this.ConvertVideo(file);
                        if (!file.FullName.Equals(convertedFile.FullName))
                        {
                            file.Delete();
                            convertedFile.MoveTo(file.FullNameWitoutExtention() + ".ogv");
                        }
                        this.SendVideo(albumId, convertedFile);
                    }
                }
                else
                {
                    file.Delete();
                }
                hasNewPictureSend = true;
            }

            return hasNewPictureSend;
        }

        private void SendPicture(long albumId, FileInfo picture)
        {
            try
            {
                if (this.albumManager.AddPicture(albumId, picture))
                {
                    while (picture.Exists)
                    {

                        picture.Refresh();
                        try
                        {
                            picture.Delete();
                        }
                        catch (Exception e)
                        {
                             Thread.Sleep(500);
                             MessageBox.Show("Excption Album Service : " + e.Message);
                        }                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private FileInfo ConvertVideo(FileInfo video)
        {
            if (!video.Extension.ToLower().Equals(".ogv"))
            {
                EcuriesDuLoupWin.Converter.Convert convert = new ConvertFFmpeg2Theora();
                String convertedFile = convert.ConvertToTheora(video.FullName);

                FileInfo file = new FileInfo(convertedFile );
                return file;
            }
            else
            {
                return video;
            }
        }

        private void SendVideo(long albumId, FileInfo video)
        {
            try
            {
                if (this.albumManager.AddVideo(albumId, video))
                {
                    while (video.Exists)
                    {

                        video.Refresh();
                        try
                        {
                            video.Delete();
                        }
                        catch (Exception e)
                        {
                            Thread.Sleep(500);
                            MessageBox.Show("Excption Album Service : " + e.Message);
                        }


                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        
    }
}
