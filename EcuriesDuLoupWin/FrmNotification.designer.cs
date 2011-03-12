namespace TestNotificationForm
{
    partial class FrmNotification
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
            this.lbMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMessage
            // 
            this.lbMessage.BackColor = System.Drawing.Color.Transparent;
            this.lbMessage.Location = new System.Drawing.Point(0, 24);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(298, 76);
            this.lbMessage.TabIndex = 1;
            this.lbMessage.Text = "label1";
            this.lbMessage.UseVisualStyleBackColor = false;
            this.lbMessage.Click += new System.EventHandler(this.lbMessage_Click);
            // 
            // FrmNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(300, 100);
            this.Controls.Add(this.lbMessage);
            this.Name = "FrmNotification";
            this.ShowCloseButton = true;
            this.Controls.SetChildIndex(this.lbMessage, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lbMessage;
    }
}
