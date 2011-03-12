﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EcuriesDuLoupWin
{
    public partial class FormAuthentification : Form
    {
        public AuthentificationDataManager AuthentificationDataManager { private get; set; }
        public bool IsEnd { get; private set; }
        public FormAuthentification()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string pseudo = this.pseudo.Text;
            string password = this.password.Text;

            this.AuthentificationDataManager.DefineAuthentification(pseudo, password);

            this.IsEnd = true;
            this.Close();
        }

        private void buttonCancer_Click(object sender, EventArgs e)
        {
            this.IsEnd = true;
            this.Close();
        }

   
    }
}