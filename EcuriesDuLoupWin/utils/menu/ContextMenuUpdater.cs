using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcuriesDuLoupWin.right;
using EcuriesDuLoupWin.Album;

namespace EcuriesDuLoupWin.utils.menu
{
    public class ContextMenuUpdater : LoopAbstract
    {

        public ContextMenuManager ContextMenuManager { get; set; }
        public AlbumManager AlbumManger { get; set; }

        public ContextMenuUpdater()
            : base()
        {

            this.NameOfThread = "menu updater";
        }

        protected override void Process()
        {
            try
            {
                IList<Album.Album> albums = this.AlbumManger.GetListAlbum();
                this.ContextMenuManager.UpdateListAlbum(albums);
            }
            catch (NoGetAlbumException)
            {
            }
        }
    }
}
