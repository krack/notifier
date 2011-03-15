using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using EcuriesDuLoupWin.utils;

namespace EcuriesDuLoupWin.Album
{
    public class LocalAlbumManager
    {
        public String LocalPhotoRepository { get; set; }

        public void AddDirectory(String pathDirectory)
        {
            DirectoryInfo dirSource = new DirectoryInfo(pathDirectory);
            DirectoryInfo dirTarget = new DirectoryInfo(this.LocalPhotoRepository+"\\"+dirSource.Name);
            dirTarget.Create();

            this.CopyDirectory(dirSource, dirTarget);
        }

        public void AppendDirectory(String pathDirectory, long idOfAlbum)
        {
            DirectoryInfo dirSource = new DirectoryInfo(pathDirectory);
            DirectoryInfo dirTarget = this.GetDirectoryTarget(idOfAlbum);

            this.CopyDirectory(dirSource, dirTarget);            
        }

        public void AppendFile(String filePath, long idOfAlbum)
        {
            FileInfo picture = new FileInfo(filePath);
            DirectoryInfo dirTarget = this.GetDirectoryTarget(idOfAlbum);

            this.CopyPicture(picture, dirTarget);
        }

        private DirectoryInfo GetDirectoryTarget(long idOfAlbum)
        {
            DirectoryInfo dirTarget = new DirectoryInfo(this.LocalPhotoRepository + "\\" + idOfAlbum);
            if (!dirTarget.Exists)
            {
                dirTarget.Create();
            }
            return dirTarget;
        }

        

        private void CopyDirectory(DirectoryInfo dirSource, DirectoryInfo dirTarget)
        {
            FileInfo[] pictures = dirSource.GetFiles();
            foreach (FileInfo picture in pictures)
            {
                if (Util.IsValidImage(picture))
                {
                    this.CopyPicture(picture, dirTarget);
                }
                else if (Util.IsValidVideo(picture))
                {
                    this.CopyPicture(picture, dirTarget);
                }
            }
        }

        private void CopyPicture(FileInfo picture, DirectoryInfo dirTarget)
        {
            picture.CopyTo(dirTarget.FullName + "\\" + picture.Name);
        }

        
    }
}
