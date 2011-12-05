using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using EcuriesDuLoupWin.utils;
using EcuriesDuLoupWin.utils.menu;
using System.Windows.Forms;
using System.IO;

namespace EcuriesDuLoupWin.right
{
    public class RightService
    {
        public RightDao RightDao { get; set; }
        public Authentification Authentification { get; set; }
        public ContextMenuManager ContextMenuManager { get; set; }


        public void MajRightForAppliChange()
        {
            //launch maj right (if install change)
            String rightFilePath = ApplicationPath.GetApplicationFolder() + @"\right";
            if (!File.Exists(rightFilePath))
            {
                this.MajRight();
                File.Create(rightFilePath);
            }
        }
        public void MajRight()
        {
            IList<Right> rights = this.RightDao.GetListRight(this.Authentification);
            if (this.MustBeRemovePhotoRight(rights))
            {
                this.RemovePhotoRight();
            }
            else if (this.MustBeAddPhotoRight(rights))
            {
                this.AddPhotoRight();
            }
        }

        private bool MustBeRemovePhotoRight(IList<Right> rights)
        {
            if (rights.Contains(Right.ADMINISTRATOR_PHOTO))
            {
                return false;
            }
            return true;
        }

        private void RemovePhotoRight()
        {

            this.ContextMenuManager.RemoveEcurieDuLoupInContextualsMenu();
        }

        private bool MustBeAddPhotoRight(IList<Right> rights)
        {
            if (!rights.Contains(Right.ADMINISTRATOR_PHOTO))
            {
                return false;
            }          
            return true;
        }

        private void AddPhotoRight()
        {
            try
            {
                this.ContextMenuManager.AddEcurieDuLoupInContextualsMenu();
            }catch{

            }
        }       
    }
}
