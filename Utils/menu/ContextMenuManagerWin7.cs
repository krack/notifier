using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin.utils.menu
{
    public class ContextMenuManagerWin7 : ContextMenuManager
    {
        private String pathOfApplication;
        private IList<ContextMenu> contextsMenu;

        public ContextMenuManagerWin7(String pathOfApplication)
        {
            this.pathOfApplication = pathOfApplication;
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
            SubMenuContextMenu subMenuContextMenu = new SubMenuContextMenu("Ecuries du loup", subMenu);
            subMenuContextMenu.Icon = Icons.GetLogoIcon();
            subMenuContextMenu.Type = "Folder";

            {
                String command = String.Format("{0} -add -d \"%1\" ", this.pathOfApplication);
                FolderContextMenu sendDirectory = new FolderContextMenu("1-Nouvel album", command);
                sendDirectory.Icon = Icons.GetNewIcon();
                subMenu.Add(sendDirectory);
            }
            {
                String command = String.Format("{0} -append -d \"%1\" ", this.pathOfApplication);
                FolderContextMenu sendDirectory = new FolderContextMenu("2-Ajouter dans album", command);
                sendDirectory.Icon = Icons.GetAddIcon();
                subMenu.Add(sendDirectory);
                sendDirectory.Parent = subMenuContextMenu;
            }

            this.contextsMenu.Add(subMenuContextMenu);
        }

        private void CreateImageMenu()
        {


            IList<ContextMenu> subMenu = new List<ContextMenu>();
            SubMenuContextMenu subMenuContextMenu = new SubMenuContextMenu("Ecuries du loup", subMenu);
            subMenuContextMenu.Icon = Icons.GetLogoIcon();
            subMenuContextMenu.Type = "SystemFileAssociations\\image";
            {
                String command = String.Format("{0} -append -f \"%1\" ", this.pathOfApplication);

                FolderContextMenu sendDirectoryImage = new FolderContextMenu("1-Ajouter dans album", command);
                sendDirectoryImage.Icon = Icons.GetAddIcon();
                subMenu.Add(sendDirectoryImage);
                sendDirectoryImage.Parent = subMenuContextMenu;
            }

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
    }
}
