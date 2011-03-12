namespace EcuriesDuLoupWin
{
    partial class FormAuthentification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAuthentification));
            this.pseudo = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.labelPseudo = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonCancer = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pseudo
            // 
            this.pseudo.Location = new System.Drawing.Point(87, 51);
            this.pseudo.Name = "pseudo";
            this.pseudo.Size = new System.Drawing.Size(132, 20);
            this.pseudo.TabIndex = 0;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(87, 90);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(132, 20);
            this.password.TabIndex = 1;
            this.password.UseSystemPasswordChar = true;
            // 
            // labelPseudo
            // 
            this.labelPseudo.AutoSize = true;
            this.labelPseudo.Location = new System.Drawing.Point(13, 54);
            this.labelPseudo.Name = "labelPseudo";
            this.labelPseudo.Size = new System.Drawing.Size(43, 13);
            this.labelPseudo.TabIndex = 2;
            this.labelPseudo.Text = "Pseudo";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(13, 93);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(13, 20);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(179, 13);
            this.labelMessage.TabIndex = 4;
            this.labelMessage.Text = "Vos identifiants de connexion du site";
            // 
            // buttonCancer
            // 
            this.buttonCancer.Location = new System.Drawing.Point(13, 128);
            this.buttonCancer.Name = "buttonCancer";
            this.buttonCancer.Size = new System.Drawing.Size(75, 23);
            this.buttonCancer.TabIndex = 5;
            this.buttonCancer.Text = "&Annuler";
            this.buttonCancer.UseVisualStyleBackColor = true;
            this.buttonCancer.Click += new System.EventHandler(this.buttonCancer_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(122, 127);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "&Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // FormAuthentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 162);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancer);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelPseudo);
            this.Controls.Add(this.password);
            this.Controls.Add(this.pseudo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAuthentification";
            this.Text = "FormAuthentification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pseudo;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label labelPseudo;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonCancer;
        private System.Windows.Forms.Button buttonOk;

    }
}