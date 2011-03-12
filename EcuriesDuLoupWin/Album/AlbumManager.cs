using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EcuriesDuLoupWin.Album
{
    public interface AlbumManager
    {
        long CreateAlbum(String name);

        bool AddPicture(long albumId, FileInfo picture);

        IList<Album> GetListAlbum();
    }
}
