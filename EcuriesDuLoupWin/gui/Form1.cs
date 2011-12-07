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
    public partial class Form1 : Form, Notificater
    {

        public Controleur Controleur { get; set; }
       
        private bool maximized;

        public Form1()
        {           
            InitializeComponent();
            this.notifyIcon1.BalloonTipClicked += new EventHandler(notifyIcon1_BalloonTipClicked);
        }

       
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Controleur.StopServices();
           

            this.Dispose();
            Application.Exit();

        }

        private void openWebSite_Click(object sender, EventArgs e)
        {
            String urlSite = ConfigurationManager.AppSettings["siteUrl"];
            WebUtils.LaunchBroswer(urlSite);
        }


         private void isSoundNotifierActivate_CheckedChanged(object sender, System.EventArgs e)
        {
             if(this.isSoundNotifierActivate.Checked){
                 this.Controleur.StartSound();
             }else{
                 this.Controleur.StopSound();
             }           
        }

        public void StartSound(){
            this.isSoundNotifierActivate.Checked = true;
        }
        public void StopSound(){
            this.isSoundNotifierActivate.Checked = true;
        }
         

         private void seDéconnecterToolStripMenuItem_Click(object sender, EventArgs e)
         {
             this.Controleur.Logout();
             
         }
        
         public void ShowNotification(int secondesDuration, String message, String url)
         {
             this.notifyIcon1.ShowBalloonTip(secondesDuration * 1000, "Ecuries du loup", message, ToolTipIcon.Info);
             this.notifyIcon1.Tag = url;
             
         }

         void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
         {
             String url = ((NotifyIcon)sender).Tag.ToString();
             WebUtils.LaunchBroswer(url);

         }

         public void DefineIcon(Icon icon, String message)
         {
             this.notifyIcon1.Icon = icon;
             this.notifyIcon1.Text = message;
         }

         private void majRights_Click(object sender, EventArgs e)
         {
             this.Controleur.UpdateUserRight();             
         }

        
         private void Form1_FormClosing(object sender, FormClosingEventArgs e)
         {
             if (e.CloseReason != CloseReason.WindowsShutDown)
             {
                 e.Cancel = true;
                 this.Minimized();
             }
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