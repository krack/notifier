using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using EcuriesDuLoupWin.utils;
using System.Windows.Forms;

namespace EcuriesDuLoupWin
{
    public class AuthentificationDataManager
    {

        private static AuthentificationDataManager instance;
        public static AuthentificationDataManager Instance
        {
            get
            {
                if (AuthentificationDataManager.instance == null)
                {
                    AuthentificationDataManager.instance = new AuthentificationDataManager();
                }
                return AuthentificationDataManager.instance;
            }
        }
        public Authentification Authentification { get; private set; }

        private String fileConnection = "conn.dat";
        private BinarySerialiserManager<Authentification> bsm;

        private AuthentificationDataManager()
        {
            this.bsm = new BinarySerialiserManager<Authentification>();
            this.bsm.FilePath = ApplicationPath.GetApplicationFolder()+@"\"+this.fileConnection;
            Authentification auth = this.bsm.Get();
            if (auth != null)
            {
                this.Authentification = auth;
            }
            else
            {
                this.Authentification = new Authentification();
            }
        }

        public Boolean IsDefine
        {
            get
            {
                return !String.IsNullOrEmpty(this.Authentification.Pseudo) && !String.IsNullOrEmpty(this.Authentification.Password);
            }
        }

        public void DefineAuthentification(String pseudo, String password)
        {
            this.Authentification.Pseudo = pseudo;
            this.Authentification.Password = password;

            bsm.Save(this.Authentification);
        }
    }
}
