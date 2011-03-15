using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcuriesDuLoupWin.utils.menu;
using EcuriesDuLoupWin.Album;
using EcuriesDuLoupWin.ws;
using EcuriesDuLoupWin.right;
using EcuriesDuLoupWin.gui;
using TestNotificationForm;
using System.Configuration;
using System.Drawing;
using System.IO;
using EcuriesDuLoupWin.utils;
using System.Windows.Forms;

namespace EcuriesDuLoupWin
{
    public class Factory
    {
        public string UrlWebService {get; set; }
        public Form1 Form1 { private get; set; }

        public ContextMenuManager ContextMenuManager { get; private set; }
        public AuthentificationDataManager AuthentificationDataManager { get; private set; }
        public AlbumService AlbumService { get; private set; }
        public AlbumManager AlbumManager { get; private set; }
        public WsRestAuthentified WsRestAuthentified { get; private set; }
        public RightDao RightDao { get; private set; }
        public RightService RightService { get; private set; }
        public IconeStatusManager IconStatusManager { get; private set; }
        public ContextMenuUpdater ContextMenuUpdater { get; private set; }

        public void ConsoleInit()
        {
            this.LoadSettings();
            this.CreateAuthentificationManager();
            this.CreateRestAuthentifier();
            this.CreateAlbumManager();
        }

        public void Init()
        {
            this.LoadSettings();
            this.CreateIconStatusManager();
            this.CreateAuthentificationManager();
            this.CreateRestAuthentifier();
            this.CreateAlbumManager();
            this.CreateAlbumService();
            this.CreateContextMenuManager();
            this.CreateRightDao();
            this.CreateRightUpdate();
            //this.CreateRightUpdater();
            this.CreateContextMenuUpdater();

        }

        

        private void LoadSettings()
        {
            this.UrlWebService = ConfigurationManager.AppSettings["urlWs"];
        }

        private void CreateIconStatusManager()
        {
            this.IconStatusManager = new IconeStatusManagerImpl(this.Form1);
            this.IconStatusManager.DefineDisconnectStatus(NotifierType.Forum);
            this.IconStatusManager.DefineDisconnectStatus(NotifierType.Picture);
        }

        private void CreateAuthentificationManager()
        {
            this.AuthentificationDataManager = AuthentificationDataManager.Instance;
        }
        private void CreateRestAuthentifier()
        {
            this.WsRestAuthentified = new WsRestAuthentified();
            this.WsRestAuthentified.Authentification = this.AuthentificationDataManager.Authentification;
            this.WsRestAuthentified.UrlRootWS = this.UrlWebService;
        }
        private void CreateAlbumManager()
        {
            this.AlbumManager = new AlbumManagerWebService();
            ((AlbumManagerWebService)this.AlbumManager).UrlRootWS = this.UrlWebService;
            ((AlbumManagerWebService)this.AlbumManager).Authentification = this.AuthentificationDataManager.Authentification;
            ((AlbumManagerWebService)this.AlbumManager).wsRestAuthentified = this.WsRestAuthentified;
        }


        private void CreateAlbumService()
        {
            this.AlbumService = new AlbumService();
            this.AlbumService.albumManager = this.AlbumManager;
            this.AlbumService.PicturesRepository = Constants.GetPathOfRepository();

        }

        private void CreateContextMenuManager(){
            this.CreateMenuIcon();
            OperatingSystem os = Environment.OSVersion;
         
            /*if (this.Is7Version(os))
            {
                this.ContextMenuManager = new ContextMenuManagerWin7();
            }
            else
            {*/
                this.ContextMenuManager = new ContextMenuManagerWinXp();

           // }
            
        }

        private void CreateMenuIcon()
        {
            this.CreateIcon(ApplicationPath.GetApplicationFolder()+@"\add.ico", EcuriesDuLoupWin.Properties.Resources.icon_add);
            this.CreateIcon(ApplicationPath.GetApplicationFolder() + @"\new.ico", EcuriesDuLoupWin.Properties.Resources.icon_new);
            this.CreateIcon(ApplicationPath.GetApplicationFolder() + @"\logo.ico", EcuriesDuLoupWin.Properties.Resources.icon_logo);
            
        }

        private void CreateIcon(String name, Icon icon)
        {
            using (Stream iconStream = new FileStream(name, FileMode.Create))
            {
                icon.Save(iconStream);
            }
            icon.Dispose();
        }

       

       /* private void CreateRightUpdater()
        {
            this.RightUpdater = new RightUpdater();
            RightUpdater.Authentification = this.AuthentificationDataManager.Authentification;
            RightUpdater.RightDao = this.RightDao;
            RightUpdater.ContextMenuManager = this.ContextMenuManager;
        }*/

        private void CreateRightDao()
        {
            this.RightDao = new RightDao();
            this.RightDao.wsRestAuthentified = this.WsRestAuthentified;
        }

        private void CreateRightUpdate()
        {
            this.RightService = new RightService();
            this.RightService.Authentification = this.AuthentificationDataManager.Authentification;
            this.RightService.ContextMenuManager = this.ContextMenuManager;
            this.RightService.RightDao = this.RightDao;
        }

        private void CreateContextMenuUpdater()
        {
            this.ContextMenuUpdater = new ContextMenuUpdater();
            this.ContextMenuUpdater.ContextMenuManager = this.ContextMenuManager;
            this.ContextMenuUpdater.AlbumManger = this.AlbumManager;
        }       
    }
}
