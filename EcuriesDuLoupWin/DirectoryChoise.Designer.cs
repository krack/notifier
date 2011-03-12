namespace EcuriesDuLoupWin
{
    partial class DirectoryChoise
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listAlbum = new System.Windows.Forms.ListBox();
            this.load = new System.Windows.Forms.ProgressBar();
            this.panelLoading = new System.Windows.Forms.Panel();
            this.labelLoading = new System.Windows.Forms.Label();
            this.panelSelection = new System.Windows.Forms.Panel();
            this.labelSelectionAlbum = new System.Windows.Forms.Label();
            this.panelError = new System.Windows.Forms.Panel();
            this.titleError = new System.Windows.Forms.Label();
            this.errorMessage = new System.Windows.Forms.Label();
            this.panelLoading.SuspendLayout();
            this.panelSelection.SuspendLayout();
            this.panelError.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(194, 227);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "&Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(18, 227);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "&Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // listAlbum
            // 
            this.listAlbum.DisplayMember = "Display";
            this.listAlbum.FormattingEnabled = true;
            this.listAlbum.Location = new System.Drawing.Point(3, 35);
            this.listAlbum.Name = "listAlbum";
            this.listAlbum.Size = new System.Drawing.Size(254, 160);
            this.listAlbum.TabIndex = 2;
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(3, 81);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(254, 23);
            this.load.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.load.TabIndex = 3;
            // 
            // panelLoading
            // 
            this.panelLoading.Controls.Add(this.labelLoading);
            this.panelLoading.Controls.Add(this.load);
            this.panelLoading.Location = new System.Drawing.Point(12, 12);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(260, 198);
            this.panelLoading.TabIndex = 4;
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Location = new System.Drawing.Point(3, 65);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(99, 13);
            this.labelLoading.TabIndex = 4;
            this.labelLoading.Text = "Veuillez patienter ...";
            // 
            // panelSelection
            // 
            this.panelSelection.Controls.Add(this.labelSelectionAlbum);
            this.panelSelection.Controls.Add(this.listAlbum);
            this.panelSelection.Location = new System.Drawing.Point(12, 13);
            this.panelSelection.Name = "panelSelection";
            this.panelSelection.Size = new System.Drawing.Size(260, 198);
            this.panelSelection.TabIndex = 5;
            this.panelSelection.Visible = false;
            // 
            // labelSelectionAlbum
            // 
            this.labelSelectionAlbum.AutoSize = true;
            this.labelSelectionAlbum.Location = new System.Drawing.Point(3, 11);
            this.labelSelectionAlbum.Name = "labelSelectionAlbum";
            this.labelSelectionAlbum.Size = new System.Drawing.Size(149, 13);
            this.labelSelectionAlbum.TabIndex = 3;
            this.labelSelectionAlbum.Text = "Veuillez sélectionner un album";
            // 
            // panelError
            // 
            this.panelError.BackColor = System.Drawing.SystemColors.Control;
            this.panelError.Controls.Add(this.errorMessage);
            this.panelError.Controls.Add(this.titleError);
            this.panelError.Location = new System.Drawing.Point(9, 9);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(263, 212);
            this.panelError.TabIndex = 5;
            this.panelError.Visible = false;
            // 
            // titleError
            // 
            this.titleError.AutoSize = true;
            this.titleError.ForeColor = System.Drawing.Color.Red;
            this.titleError.Location = new System.Drawing.Point(6, 12);
            this.titleError.Name = "titleError";
            this.titleError.Size = new System.Drawing.Size(35, 13);
            this.titleError.TabIndex = 0;
            this.titleError.Text = "Erreur";
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.Location = new System.Drawing.Point(6, 52);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(180, 13);
            this.errorMessage.TabIndex = 1;
            this.errorMessage.Text = "Impossible de récupérer les albums ! ";
            // 
            // DirectoryChoise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.panelError);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.panelLoading);
            this.Controls.Add(this.panelSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DirectoryChoise";
            this.Text = "DirectoryChoise";
            this.panelLoading.ResumeLayout(false);
            this.panelLoading.PerformLayout();
            this.panelSelection.ResumeLayout(false);
            this.panelSelection.PerformLayout();
            this.panelError.ResumeLayout(false);
            this.panelError.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ProgressBar load;
        private System.Windows.Forms.Panel panelLoading;
        private System.Windows.Forms.Label labelLoading;
        private System.Windows.Forms.Panel panelSelection;
        private System.Windows.Forms.Label labelSelectionAlbum;
        private System.Windows.Forms.ListBox listAlbum;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.Label titleError;
        private System.Windows.Forms.Label errorMessage;
    }
}