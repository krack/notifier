using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcuriesDuLoupWin.Album;
using TestNotificationForm;
using System.Windows.Forms;

namespace EcuriesDuLoupWin
{
    public class ConsoleManager
    {
        public String[] args { get; set; }

        public ConsoleManager(String[] args)
        {
            this.args = args;
        }

        public void Run()
        {
            this.ChooseAction();   
        }

        private void ChooseAction()
        {

            if (args[1].Equals("-add"))
            {
               this.AddAction();
            }
            else if (args[1].Equals("-append"))
            {
                this.AppendAction();
            }
        }


        private void AddAction()
        {
            if (args[2].Equals("-d"))
            {
                LocalAlbumManager albumManager = new LocalAlbumManager();
                albumManager.LocalPhotoRepository = Constants.GetPathOfRepository();
                albumManager.AddDirectory(args[3]);
            }
        }

        private void AppendAction()
        {
            LocalAlbumManager albumManager = new LocalAlbumManager();
            albumManager.LocalPhotoRepository = Constants.GetPathOfRepository();
            if(args.Length == 5){
                if (args[2].Equals("-d"))
                {
                    albumManager.AppendDirectory(args[3], Int32.Parse(args[4]));
                }
                else if (args[2].Equals("-f"))
                {
                    albumManager.AppendFile(args[3], Int32.Parse(args[4]));
                }
            }else if(args.Length == 4){
                Factory factory = new Factory();
                factory.ConsoleInit();
                using (DirectoryChoise directoryChoise = new DirectoryChoise())
                {
                    directoryChoise.AlbumManager = factory.AlbumManager;
                    Album.Album value = null;
                    bool ok = false;
                    do
                    {

                        directoryChoise.InitAlbum();
                        DialogResult res = directoryChoise.ShowDialog();
                        if (res == DialogResult.OK)
                        {
                            ok = true;
                            value = directoryChoise.GetValueOfSelectedAlbum();
                        }
                        else
                        {
                            ok = false;
                        }
                    } while (ok && value == null);

                    if (ok)
                    {
                        if (args[2].Equals("-d"))
                        {
                            albumManager.AppendDirectory(args[3], value.Id);
                        }
                        else if (args[2].Equals("-f"))
                        {
                            albumManager.AppendFile(args[3], value.Id);
                        }
                    }
                }
            }
        }
    }
}
