using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNotificationForm;
using EcuriesDuLoupWin.checker;
using EcuriesDuLoupWin.utils;
using Utils;
using System.Configuration;
using EcuriesDuLoupWin.Options;
using EcuriesDuLoupWin.gui;
using EcuriesDuLoupWin.Album;
using EcuriesDuLoupWin.right;
using EcuriesDuLoupWin.Observer;
using System.Windows.Forms;
using System.IO;

namespace EcuriesDuLoupWin
{
    public class Controleur
    {
        public AuthentificationDataManager AuthentificationDataManager{get; set;}
        public OptionsManager OptionsManager { get; set; }
        public Loop NotifiersCheckProcess { get; set; }

        public AlbumService AlbumService { get; set; }
        public RightService RightService { get; set; }
        public Form1 Windows { get; set; }

        public void init()
        {

            //update sound 
            if (OptionsManager.GetOptions().IsNotificationSoundActivate)
            {
                this.Windows.StartSound();
            }
            else
            {
                this.Windows.StopSound();
            }
            this.StartServices();

            
        }      


        private void StartServices()
        {
            this.AlbumService.Start();
            this.NotifiersCheckProcess.Start();
        }

        public void StopServices()
        {
            //notifier
            this.NotifiersCheckProcess.Stop();
            //album service
            this.AlbumService.Stop();
        }

        public void Logout()
        {
            this.AuthentificationDataManager.DefineAuthentification("", "");
            foreach (CheckerAndNotifier can in this.NotifiersCheckProcess.CheckerAndNotifier)
            {
                can.reset();
            }

            FormAuthentification authForm = FormAuthentification.Instance;
            if (authForm != null)
            {
                authForm.AuthentificationDataManager = this.AuthentificationDataManager;
                authForm.RightService = this.RightService;
                authForm.Show();

                while (!authForm.IsEnd)
                {
                    Application.DoEvents();
                }
                authForm.Dispose();
            }
        }

        public void StartSound()
        {
            OptionsData options = OptionsManager.GetOptions();
            options.IsNotificationSoundActivate = true;
            OptionsManager.DefineOptions(options);
        }

        public void StopSound()
        {
            OptionsData options = OptionsManager.GetOptions();
            options.IsNotificationSoundActivate = false;
            OptionsManager.DefineOptions(options);
        }

        public void UpdateUserRight()
        {
            this.RightService.MajRight();

        }


    }
}
