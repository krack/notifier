using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin.utils.menu
{
    public class ContextMenuManagerWinXp : ContextMenuManager
    {

        private IList<ContextMenu> contextsMenu;

        public ContextMenuManagerWinXp()
        {
            this.Create();
        }

        private void Create()
        {
            this.contextsMenu = new List<ContextMenu>();
            this.CreateFolderMenu();
            this.CreateImageMenu();
            this.CreateVideoMenu();
         //   this.AddEcurieDuLoupInContextualsMenu();
           
        }

        private void CreateFolderMenu()
        {
            {
                String command = String.Format("{0} -add -d \"%1\" ", ApplicationPath.GetApplicationPath());
                FolderContextMenu sendDirectory = new FolderContextMenu("1-Nouvel album", command);
                sendDirectory.Icon = Icons.GetNewIcon();
                this.contextsMenu.Add(sendDirectory);
            }
            {
                String command = String.Format("{0} -append -d \"%1\" ", ApplicationPath.GetApplicationPath());
                FolderContextMenu sendDirectory = new FolderContextMenu("2-Ajouter dans album", command);
                sendDirectory.Icon = Icons.GetAddIcon();
                this.contextsMenu.Add(sendDirectory);
            }            
        }

        private void CreateImageMenu()
        {
           
            {
                String command = String.Format("{0} -append -f \"%1\" ", ApplicationPath.GetApplicationPath());
                ImageContextMenu sendDirectory = new ImageContextMenu("1-Ajouter dans album", command);
                sendDirectory.Icon = Icons.GetAddIcon();
                this.contextsMenu.Add(sendDirectory);
            }
        }

        private void CreateVideoMenu()
        {

            {
                String command = String.Format("{0} -append -f \"%1\" ", ApplicationPath.GetApplicationPath());
                VideoContextMenu sendDirectory = new VideoContextMenu("1-Ajouter dans album", command);
                sendDirectory.Icon = Icons.GetAddIcon();
                this.contextsMenu.Add(sendDirectory);
            }
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
           
        }
    }
}
