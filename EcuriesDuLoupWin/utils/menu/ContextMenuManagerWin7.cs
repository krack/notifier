using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EcuriesDuLoupWin.utils.menu
{
    public class ContextMenuManagerWin7 : ContextMenuManager
    {

        private IList<Album.Album> albums;
        private IDictionary<Album.Album, ContextMenu> linkAlbumContextFolder;
        private IDictionary<Album.Album, ContextMenu> linkAlbumContextImage;

        private IList<ContextMenu> contextsMenu;
        private SubMenuContextMenu sendDirectoryFolder;
        private SubMenuContextMenu sendDirectoryImage;

        public ContextMenuManagerWin7()
        {
            this.albums = new List<Album.Album>();
            this.linkAlbumContextFolder = new Dictionary<Album.Album, ContextMenu>();
            this.linkAlbumContextImage = new Dictionary<Album.Album, ContextMenu>();
            this.Create();
        }

        private void Create()
        {
            this.contextsMenu = new List<ContextMenu>();
            this.CreateFolderMenu();
            this.CreateImageMenu();
           
        }

        private void CreateFolderMenu()
        {
            IList<ContextMenu> subMenu = new List<ContextMenu>();
            {
                String command = String.Format("{0} -add -d \"%1\" ", this.getPathOfApplication());
                FolderContextMenu sendDirectory = new FolderContextMenu("1-Nouvel album", command);
                sendDirectory.Icon = Icons.GetNewIcon();
                subMenu.Add(sendDirectory);
            }
            {
                this.sendDirectoryFolder = new SubMenuContextMenu("2-Ajouter dans album");
                this.sendDirectoryFolder.Icon = Icons.GetAddIcon();
                subMenu.Add(this.sendDirectoryFolder);
            }
            SubMenuContextMenu subMenuContextMenu = new SubMenuContextMenu("Ecuries du loup", subMenu);
            subMenuContextMenu.Icon = Icons.GetLogoIcon();
            subMenuContextMenu.Type = "Folder";

            this.sendDirectoryFolder.Parent = subMenuContextMenu;

            //delete album already exist 
            this.sendDirectoryFolder.Remove();
            this.contextsMenu.Add(subMenuContextMenu);
        }

        private void CreateImageMenu()
        {
            IList<ContextMenu> subMenu = new List<ContextMenu>();
           
            {
                this.sendDirectoryImage = new SubMenuContextMenu("1-Ajouter dans album");
                this.sendDirectoryImage.Icon = Icons.GetAddIcon();
                subMenu.Add(this.sendDirectoryImage);
            }

            SubMenuContextMenu subMenuContextMenu = new SubMenuContextMenu("Ecuries du loup", subMenu);
            subMenuContextMenu.Icon = Icons.GetLogoIcon();
            subMenuContextMenu.Type = "SystemFileAssociations\\image";

            this.sendDirectoryImage.Parent = subMenuContextMenu;
            this.sendDirectoryImage.Remove();

            this.contextsMenu.Add(subMenuContextMenu);
        }

        private String getPathOfApplication()
        {
            return Environment.CommandLine.Replace(".vshost", "").Replace("\"", "");
        }

        public void AddEcurieDuLoupInContextualsMenu()
        {
            foreach (ContextMenu contextMenu in this.contextsMenu)
            {
                contextMenu.Add();
            }
        }
        public void RemoveEcurieDuLoupInContextualsMenu()
        {
            foreach (ContextMenu contextMenu in this.contextsMenu)
            {
                contextMenu.Remove();
            }
        }

        public void UpdateListAlbum(IList<Album.Album> albumsInMoment)
        {
            IEnumerable<Album.Album> albumsToRemove = this.albums.Except(albumsInMoment);
            IList<Album.Album> tmp = new List<Album.Album>();
            foreach (Album.Album albumToRemove in albumsToRemove)
            {
                this.RemoveAlbum(albumToRemove);
                tmp.Add(albumToRemove);
            }
            foreach (Album.Album albumTmp in tmp)
            {
                this.albums.Remove(albumTmp);
            }

            IEnumerable<Album.Album> albumsToAdd =  albumsInMoment.Except(this.albums);
            foreach (Album.Album albumToAdd in albumsToAdd)
            {
                this.AddAlbum(albumToAdd);
            }
        }

        private void AddAlbum(Album.Album album)
        {
            {
                String command = String.Format("{0} -append -{1} \"%1\" {2}", this.getPathOfApplication(), "d", album.Id);
                FolderContextMenu sendDirectory = new FolderContextMenu(album.Id + "-" + album.Name, command);
                sendDirectory.Parent = this.sendDirectoryFolder;
                this.sendDirectoryFolder.Menu.Add(sendDirectory);
                sendDirectory.Add();
                this.linkAlbumContextFolder.Add(album, sendDirectory);
            }
            {
                String command = String.Format("{0} -append -{1} \"%1\" {2}", this.getPathOfApplication(), "f", album.Id);
                FolderContextMenu sendDirectory = new FolderContextMenu(album.Id + "-" + album.Name, command);
                sendDirectory.Parent = this.sendDirectoryImage;
                this.sendDirectoryImage.Menu.Add(sendDirectory);
                sendDirectory.Add();
                this.linkAlbumContextImage.Add(album, sendDirectory);
            }

            this.albums.Add(album);
        }

        private void RemoveAlbum(Album.Album album)
        {
            this.linkAlbumContextFolder[album].Remove();
            this.linkAlbumContextFolder.Remove(album);
            this.linkAlbumContextImage[album].Remove();
            this.linkAlbumContextImage.Remove(album);
        }
    }
}
