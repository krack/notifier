using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EcuriesDuLoupWin.Album;
using System.Threading;

namespace EcuriesDuLoupWin
{
    public partial class DirectoryChoise : Form
    {
        public AlbumManager AlbumManager { get; set; }
        public DirectoryChoise()
        {
            InitializeComponent();
        }

        public void InitAlbum()
        {
            Thread thread = new Thread(new ThreadStart(InitListAsync));
            thread.Start();
        }

        private void InitListAsync()
        {
            try
            {
                this.InitList(this.AlbumManager.GetListAlbum());
                this.SwitchLoadingInit();
            }
            catch (NoGetAlbumException e )
            {

                this.SwitchInerror();
                MessageBox.Show("NoGetAlbumException " + e.InnerException.Message); 
            }
        }

        public Album.Album GetValueOfSelectedAlbum()
        {
            return (Album.Album)this.listAlbum.SelectedItem;
        }

        private void InitList(IList<Album.Album> albums)
        {
            if (this.listAlbum.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(InitList);
                this.Invoke(d, new object[] { albums });
            }
            else
            {
                foreach (Album.Album album in albums)
                {
                    this.listAlbum.Items.Add(album);
                }
            }
            
        }

        private void SwitchLoadingInit(){

            if (this.panelLoading.InvokeRequired || this.panelSelection.InvokeRequired || this.buttonOk.InvokeRequired)
            {
                SwitchDelegate d = new SwitchDelegate(SwitchLoadingInit);
                this.Invoke(d);
            }
            else
            {
                this.panelSelection.Visible = true;
                this.panelLoading.Visible = false;
                this.buttonOk.Enabled = true;
            }

        }

        private void SwitchInerror()
        {
            if (this.panelLoading.InvokeRequired || this.panelSelection.InvokeRequired || this.panelError.InvokeRequired)
            {
                SwitchDelegate d = new SwitchDelegate(SwitchInerror);
                this.Invoke(d);
            }
            else
            {
                this.panelSelection.Visible = false;
                this.panelLoading.Visible = false;
                this.panelError.Visible = true;
            }
        }

        delegate void SwitchDelegate();
        delegate void SetTextCallback(IList<Album.Album> albums);

       
    }

}
