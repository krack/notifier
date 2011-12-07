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
using EcuriesDuLoupWin.checker;
using EcuriesDuLoupWin.Observer;
using EcuriesDuLoupWin.Options;

namespace EcuriesDuLoupWin
{
    public class Factory
    {

        public string UrlWebService {
            get
            {
                if (ConfigurationManager.AppSettings["Mode"] == "DEV")
                {
                    return ConfigurationManager.AppSettings["urlWsDEV"];
                }
                else
                {
                    return ConfigurationManager.AppSettings["urlWsPROD"];
                }
            }
        }
        private Form1 _form;
        public Form1 Form1 {
            get
            {
                if (this._form == null)
                {
                    this._form = new Form1();
                    this._form.Controleur = this.Controleur;
                    this.Controleur.Windows = this._form;
                    this.Controleur.init();
                }
                return this._form;
            }
            private set
            {
               this._form = value ;
            }
        }

        private ContextMenuManager _contextMenuManager;
        public ContextMenuManager ContextMenuManager {
            get
            {
                if(_contextMenuManager==null){
                    this.CreateMenuIcon();
                    _contextMenuManager = new ContextMenuManagerWithRegisteryManager();
                }
                return _contextMenuManager;
            }
            private set{
                this._contextMenuManager = value;
            }
        }

        private AuthentificationDataManager _authentificationDataManager;
        public AuthentificationDataManager AuthentificationDataManager
        {
            get
            {
                if (this._authentificationDataManager == null)
                {
                    this.CreateAuthentificationManager();
                };
                return this._authentificationDataManager;
            }
            private set
            {
                this._authentificationDataManager = value;
            }
        }

        private AlbumService _albumService;
        public AlbumService AlbumService { 
            get{
                 if(this._albumService == null){
                    this.CreateAlbumService();
                };
                return this._albumService;
            }
            private set
            {
                this._albumService = value;
            }
           }

        private AlbumManager _albumManager;
        public AlbumManager AlbumManager { 
            get{
             if(_albumManager == null){
                 this.CreateAlbumManager();
             }
                return _albumManager;
            }
            private set
            {
                this._albumManager = value;
            }
        }

        private WsRestAuthentified _wsRestAuthentified;
        public WsRestAuthentified WsRestAuthentified { 
            get{
                if(_wsRestAuthentified == null){
              CreateRestAuthentifier();  
                }
                return _wsRestAuthentified;
            }
            private set
            {
                this._wsRestAuthentified = value;
            }
        }

        private RightDao _rightDao;
        public RightDao RightDao
        {
            get
            {
                if (_rightDao==null)
                {
                     this.CreateRightDao();
                }
                return _rightDao;
            }
            private set
            {
                this._rightDao = value;
            }
        }

        private RightService _rightService;
        public RightService RightService
        {
            get
            {
                if (_rightService == null)
                {
                    this.CreateRightUpdate();
                } 
                return _rightService;
            }
            private set
            {
                this._rightService = value;
            }
        }

        private IconeStatusManager _iconStatusManager;
        public IconeStatusManager IconStatusManager
        {
            get
            {
                if (_iconStatusManager == null)
                {
                    this.CreateIconStatusManager();
                }
                return _iconStatusManager;
            }
            private set
            {
                this._iconStatusManager = value;
            }
        }
        private CheckerAndNotifier _forumNotifier;
        public CheckerAndNotifier ForumNotifier
        {
            get
            {
                if (_forumNotifier == null)
                {
                    this.createForumNotifier();
                }
                return _forumNotifier;
            }
            private set
            {
                this._forumNotifier = value;
            }
        }

        private CheckerAndNotifier _pictureNotifier;
        public CheckerAndNotifier PictureNotifier
        {
            get
            {
                if (_pictureNotifier == null)
                {
                    this.createPictureNotifier();
                }
                return _pictureNotifier;
            }
            private set
            {
                this._pictureNotifier = value;
            }
        }

        private Loop _loop;
        public Loop Loop {  get
            {
                if (_loop == null)
                {
                    this.createNotifierLoop();
                }
                return _loop;
            }
            private set
            {
                this._loop = value;
            } }

        private IList<WebExceptionObserver> _observers;
        public IList<WebExceptionObserver> Observers
        {
            get
            {
                if (_observers == null)
                {
                    this.createObserver();
                }
                return _observers;
            }
            private set
            {
                this._observers = value;
            }
        }
        public WebExceptionObserverChangeAuthentification ObserverAuthentification { get; private set; }

        private OptionsData _options;
        public OptionsData Options
        {
            get
            {
                if (_options == null)
                {
                    this.Options = OptionsManager.Instance.GetOptions();
                }
                return _options;
            }
            private set
            {
                this._options = value;
            }
        }

        private Controleur _controleur;
        public Controleur Controleur
        {
            get
            {
                if (_controleur == null)
                {
                    this.createControleur();
                }
                return _controleur;
            }
            private set
            {
                this._controleur = value;
            }
        }

        public Factory()
        {
            ;
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

        private void createForumNotifier()
        {
            CheckerAndNotifier checkWSForum = new CheckerAndNotifier();
            checkWSForum.Message = "Nouveau(x) message(s)";
            checkWSForum.Options = this.Options;
            checkWSForum.UrlToSend = ConfigurationManager.AppSettings["forumUrl"];
            checkWSForum.Notificater = this.Form1;

            checkWSForum.Checker = new WebServiceChecker(this.IconStatusManager, NotifierType.Forum);
            checkWSForum.Checker.StatusUrl = this.UrlWebService + "/status/forum";
            checkWSForum.Checker.Authentification = this.AuthentificationDataManager.Authentification;
            ((WebServiceChecker)checkWSForum.Checker).RegisterObservers(this.Observers);

            this.ForumNotifier = checkWSForum;
        }

        private void createPictureNotifier()
        {

            CheckerAndNotifier checkWSPhotos = new CheckerAndNotifier();
            checkWSPhotos.Message = "Nouvelle(s) photo(s)";
            checkWSPhotos.Options = this.Options;
            checkWSPhotos.UrlToSend = ConfigurationManager.AppSettings["photosUrl"];
            checkWSPhotos.Notificater = this.Form1;

            checkWSPhotos.Checker = new WebServiceChecker(this.IconStatusManager, NotifierType.Picture);
            checkWSPhotos.Checker.StatusUrl = this.UrlWebService + "/status/photos";
            checkWSPhotos.Checker.Authentification = this.AuthentificationDataManager.Authentification;
            ((WebServiceChecker)checkWSPhotos.Checker).RegisterObservers(this.Observers);

            this.PictureNotifier  = checkWSPhotos;

        }

        private void createNotifierLoop()
        {
            this.Loop = new Loop();
            this.Loop.TimeToSleepInSecond = Int32.Parse(ConfigurationManager.AppSettings["TimeInSecondeToWait"]);

            Loop.CheckerAndNotifier.Add(this.PictureNotifier);
            Loop.CheckerAndNotifier.Add(this.ForumNotifier);
        }


        private void createObserver()
        {

            this.Observers = new List<WebExceptionObserver>();

            this.ObserverAuthentification = new WebExceptionObserverChangeAuthentification();
            this.ObserverAuthentification.RightService = this.RightService;
            this.Observers.Add(this.ObserverAuthentification);

        }

        private void createControleur()
        {
            this.Controleur = new Controleur();
            this.Controleur.AuthentificationDataManager = this.AuthentificationDataManager;
            this.Controleur.NotifiersCheckProcess = this.Loop;
              this.Controleur.OptionsManager = OptionsManager.Instance;

              this.Controleur.RightService = this.RightService;

              this.Controleur.AlbumService = this.AlbumService;
        }
    }
}
