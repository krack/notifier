using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EcuriesDuLoupWin.Album;
using EcuriesDuLoupWin.right;

namespace EcuriesDuLoupWin
{
    public partial class FormAuthentification : Form
    {
        private static FormAuthentification _instance;
        public static FormAuthentification Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FormAuthentification();
                    return _instance;
                }
                else
                {
                    return null;
                }
               
            }
        }

        public AuthentificationDataManager AuthentificationDataManager { private get; set; }
        public RightService RightService { private get; set; }
        public bool IsEnd { get; private set; }
        private FormAuthentification()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string pseudo = this.pseudo.Text;
            string password = this.password.Text;

            this.AuthentificationDataManager.DefineAuthentification(pseudo, password);
            if (this.RightService != null)
            {
                this.RightService.MajRightForAppliChange();
            }
            this.IsEnd = true;
            this.Close();
            _instance = null;
        }

        private void buttonCancer_Click(object sender, EventArgs e)
        {
            this.IsEnd = true;
            this.Close();
            _instance = null;
        }

   
    }
}
