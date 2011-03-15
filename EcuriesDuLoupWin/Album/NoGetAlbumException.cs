using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin.Album
{
    [Serializable]
    public class NoGetAlbumException : Exception
    {
        public NoGetAlbumException()
            : base()
        {
        }
        public NoGetAlbumException(string message)
            : base(message)
        {
        }
        
        public NoGetAlbumException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
