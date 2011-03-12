namespace TestNotificationForm
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuNotifier = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openWebSite = new System.Windows.Forms.ToolStripMenuItem();
            this.isSoundNotifierActivate = new System.Windows.Forms.ToolStripMenuItem();
            this.seDéconnecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitContext = new System.Windows.Forms.ToolStripMenuItem();
            this.majRights = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuNotifier.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuNotifier;
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuNotifier
            // 
            this.contextMenuNotifier.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWebSite,
            this.isSoundNotifierActivate,
            this.seDéconnecterToolStripMenuItem,
            this.ExitContext});
            this.contextMenuNotifier.Name = "contextMenuNotifier";
            this.contextMenuNotifier.Size = new System.Drawing.Size(156, 92);
            // 
            // openWebSite
            // 
            this.openWebSite.Name = "openWebSite";
            this.openWebSite.Size = new System.Drawing.Size(155, 22);
            this.openWebSite.Text = "Le site";
            this.openWebSite.Click += new System.EventHandler(this.openWebSite_Click);
            // 
            // isSoundNotifierActivate
            // 
            this.isSoundNotifierActivate.Checked = true;
            this.isSoundNotifierActivate.CheckOnClick = true;
            this.isSoundNotifierActivate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isSoundNotifierActivate.Name = "isSoundNotifierActivate";
            this.isSoundNotifierActivate.Size = new System.Drawing.Size(155, 22);
            this.isSoundNotifierActivate.Text = "Son";
            this.isSoundNotifierActivate.CheckedChanged += new System.EventHandler(this.isSoundNotifierActivate_CheckedChanged);
            // 
            // seDéconnecterToolStripMenuItem
            // 
            this.seDéconnecterToolStripMenuItem.Name = "seDéconnecterToolStripMenuItem";
            this.seDéconnecterToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.seDéconnecterToolStripMenuItem.Text = "Se déconnecter";
            this.seDéconnecterToolStripMenuItem.Click += new System.EventHandler(this.seDéconnecterToolStripMenuItem_Click);
            // 
            // ExitContext
            // 
            this.ExitContext.Name = "ExitContext";
            this.ExitContext.Size = new System.Drawing.Size(155, 22);
            this.ExitContext.Text = "Quitter";
            this.ExitContext.Click += new System.EventHandler(this.Exit_Click);
            // 
            // majRights
            // 
            this.majRights.Location = new System.Drawing.Point(149, 24);
            this.majRights.Name = "majRights";
            this.majRights.Size = new System.Drawing.Size(75, 23);
            this.majRights.TabIndex = 1;
            this.majRights.Text = "Mettre à jour";
            this.majRights.UseVisualStyleBackColor = true;
            this.majRights.Click += new System.EventHandler(this.majRights_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.majRights);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 93);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(366, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Il est possible que cela demande des droits spécifique plusieurs fois de suite.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mettre à jour vos droits";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 359);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Les écuries du loup - notifier";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.contextMenuNotifier.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuNotifier;
        private System.Windows.Forms.ToolStripMenuItem openWebSite;
        private System.Windows.Forms.ToolStripMenuItem ExitContext;
        private System.Windows.Forms.ToolStripMenuItem isSoundNotifierActivate;
        private System.Windows.Forms.ToolStripMenuItem seDéconnecterToolStripMenuItem;
        private System.Windows.Forms.Button majRights;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

