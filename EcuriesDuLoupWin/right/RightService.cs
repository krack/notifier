using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using EcuriesDuLoupWin.utils;
using EcuriesDuLoupWin.utils.menu;
using System.Windows.Forms;

namespace EcuriesDuLoupWin.right
{
    public class RightService
    {
        public RightDao RightDao { get; set; }
        public Authentification Authentification { get; set; }
        public ContextMenuManager ContextMenuManager { get; set; }
        private bool HasRight { get; set; }
        private bool FirstCheck { get; set; }


        public RightService()
        {
            this.FirstCheck = true;
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

            this.FirstCheck = false;
        }

        private bool MustBeRemovePhotoRight(IList<Right> rights)
        {
            if (rights.Contains(Right.ADMINISTRATOR_PHOTO))
            {
                return false;
            }
            if (!this.HasRight  && !this.FirstCheck)
            {
                return false;
            }
            return true;
        }

        private void RemovePhotoRight()
        {

            this.ContextMenuManager.RemoveEcurieDuLoupInContextualsMenu();
            this.HasRight = false;
        }

        private bool MustBeAddPhotoRight(IList<Right> rights)
        {
            if (!rights.Contains(Right.ADMINISTRATOR_PHOTO))
            {
                return false;
            }
            if (this.HasRight)
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
                this.HasRight = true;
            }catch{

            }
        }       
    }
}
