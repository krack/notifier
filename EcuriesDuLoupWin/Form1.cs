using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using EcuriesDuLoupWin;
using EcuriesDuLoupWin.checker;
using System.Diagnostics;
using EcuriesDuLoupWin.Observer;
using EcuriesDuLoupWin.Options;
using Microsoft.Win32;
using EcuriesDuLoupWin.gui;
using EcuriesDuLoupWin.utils;
using EcuriesDuLoupWin.Album;
using EcuriesDuLoupWin.right;
using EcuriesDuLoupWin.ws;
using EcuriesDuLoupWin.utils.menu;
using System.IO;
using Utils;

namespace TestNotificationForm
{
    public partial class Form1 : Form
    {
        public AuthentificationDataManager authentificationDataManager;
        private OptionsManager optionsManager;

        private IconeStatusManager iconStatusManager;
        private IList<WebExceptionObserver> observers;
        private OptionsData options;
        private Loop loop;

        private string UrlWebService { get; set; }
        private AlbumService albumService;
        private ContextMenuUpdater contextMenuUpdater;
   //     private RightUpdater rightUpdater;
        private RightService rightService;
        private bool maximized;

        public Form1()
        {
           
            InitializeComponent();

            Factory factory = new Factory();
            factory.Form1 = this;
            factory.Init();
            this.UrlWebService = factory.UrlWebService;

            this.iconStatusManager = factory.IconStatusManager;

            this.Create();
        
            this.optionsManager = OptionsManager.Instance;
            this.options = optionsManager.GetOptions();

           this.observers = new List<WebExceptionObserver>();

            WebExceptionObserverChangeAuthentification observerAuthentification = new WebExceptionObserverChangeAuthentification();
            this.observers.Add(observerAuthentification);

            this.authentificationDataManager = factory.AuthentificationDataManager;
            this.rightService = factory.RightService;
           // this.rightUpdater = factory.RightUpdater;
            if (!factory.AuthentificationDataManager.IsDefine)
            {
                observerAuthentification.NotifieUnauthorizedException();
            }
          
            this.loop = new Loop();
            this.loop.TimeToSleepInSecond = Int32.Parse(ConfigurationManager.AppSettings["TimeInSecondeToWait"]);
          
            loop.CheckerAndNotifier.Add(this.createPictureNotifier());
            loop.CheckerAndNotifier.Add(this.createForumNotifier());


            this.isSoundNotifierActivate.Checked = options.IsNotificationSoundActivate;
            loop.Start();
            //this.rightUpdater.Start();
            this.albumService = factory.AlbumService;
            this.albumService.Start();
            this.contextMenuUpdater = factory.ContextMenuUpdater;
            this.contextMenuUpdater.Start();

        }

        private void Create()
        {
             RegisteryMethod.addApplicationOnComputerStart();
             this.DowloadRegistryManager();
        }

        private void DowloadRegistryManager()
        {
            String exeRegistryManager = RegistryExeCommand.RegistyProgramPath;
            FileInfo file = new FileInfo(exeRegistryManager);
            if (!file.Exists)
            {
                WebUtils.Download("http://www.ecuriesduloup.fr/registryManager/RegistryManager.exe", exeRegistryManager);
            }
        }

        private CheckerAndNotifier createForumNotifier()
        {
            CheckerAndNotifier checkWSForum = new CheckerAndNotifier();
            checkWSForum.Message = "Nouveau(x) message(s)";
            checkWSForum.Options = this.options;
            checkWSForum.UrlToSend = ConfigurationManager.AppSettings["forumUrl"];

            checkWSForum.Checker = new WebServiceChecker(iconStatusManager, NotifierType.Forum);
            checkWSForum.Checker.StatusUrl = this.UrlWebService + "/status/forum";
            checkWSForum.Checker.Authentification = this.authentificationDataManager.Authentification;
            ((WebServiceChecker)checkWSForum.Checker).RegisterObservers(this.observers);

            return checkWSForum;
        }

        private CheckerAndNotifier createPictureNotifier()
        {

            CheckerAndNotifier checkWSPhotos = new CheckerAndNotifier();
            checkWSPhotos.Message = "Nouvelle(s) photo(s)";
            checkWSPhotos.Options = this.options;
            checkWSPhotos.UrlToSend = ConfigurationManager.AppSettings["photosUrl"];

            checkWSPhotos.Checker = new WebServiceChecker(iconStatusManager, NotifierType.Picture);
            checkWSPhotos.Checker.StatusUrl = this.UrlWebService + "/status/photos";
            checkWSPhotos.Checker.Authentification = this.authentificationDataManager.Authentification;
            ((WebServiceChecker)checkWSPhotos.Checker).RegisterObservers(this.observers);

            return checkWSPhotos;

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            //notifier
            this.loop.Stop();
            //album service
            this.albumService.Stop();
            //menu updater
            this.contextMenuUpdater.Stop();
            //right updater
            //this.rightUpdater.Stop();

            this.Dispose();
            this.Close();
            Application.Exit();

        }

        private void openWebSite_Click(object sender, EventArgs e)
        {
            String urlSite = ConfigurationManager.AppSettings["siteUrl"];
            WebUtils.LaunchBroswer(urlSite);
        }


         private void isSoundNotifierActivate_CheckedChanged(object sender, System.EventArgs e)
        {
            
            OptionsData options = optionsManager.GetOptions();
            options.IsNotificationSoundActivate = this.isSoundNotifierActivate.Checked;
            optionsManager.DefineOptions(options);
        }

         

         private void seDéconnecterToolStripMenuItem_Click(object sender, EventArgs e)
         {
             this.authentificationDataManager.DefineAuthentification("", "");
             foreach (CheckerAndNotifier can in this.loop.CheckerAndNotifier)
             {
                 can.reset();
             }


             FormAuthentification authForm = new FormAuthentification();
             authForm.AuthentificationDataManager = this.authentificationDataManager;
             authForm.Show();

             while (!authForm.IsEnd)
             {
                 Application.DoEvents();
             }
         }

         public void DefineIcon(Icon icon, String message)
         {
             this.notifyIcon1.Icon = icon;
             this.notifyIcon1.Text = message;
         }

         private void majRights_Click(object sender, EventArgs e)
         {
             this.rightService.MajRight();
         }

        
         private void Form1_FormClosing(object sender, FormClosingEventArgs e)
         {
             e.Cancel = true;
             this.Minimized();

         }

         private void Minimized()
         {
             this.WindowState = FormWindowState.Minimized;
             this.ShowInTaskbar = false;
         }

         private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
         {
             if (e.Button == MouseButtons.Left)
             {
                 if (this.WindowState.Equals(FormWindowState.Normal))
                 {
                     this.Minimized();
                     this.maximized = false;

                 }
                 else if (this.WindowState.Equals(FormWindowState.Maximized))
                 {
                     this.Minimized();
                     this.maximized = true;
                 }
                 else if (this.WindowState.Equals(FormWindowState.Minimized))
                 {
                     if (this.maximized)
                     {
                         this.WindowState = FormWindowState.Maximized;
                     }
                     else
                     {
                         this.WindowState = FormWindowState.Normal;
                     }
                     this.ShowInTaskbar = true;
                 }
                 else
                 {
                     new Exception("Internal erreur. Case not supported.");
                 }
             }
         }
         
    }
}