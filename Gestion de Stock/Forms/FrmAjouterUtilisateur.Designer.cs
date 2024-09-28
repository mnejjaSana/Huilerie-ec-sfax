namespace Gestion_de_Stock.Forms
{
    partial class FrmAjouterUtilisateur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAjouterUtilisateur));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.label1 = new System.Windows.Forms.Label();
            this.TxTEmail = new DevExpress.XtraEditors.TextEdit();
            this.checkEditAdmin = new DevExpress.XtraEditors.CheckEdit();
            this.BtnAjouter = new DevExpress.XtraEditors.SimpleButton();
            this.TxtPrenom = new DevExpress.XtraEditors.TextEdit();
            this.TxtNom = new DevExpress.XtraEditors.TextEdit();
            this.TxtPassword = new DevExpress.XtraEditors.TextEdit();
            this.TxtLogin = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxTEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPrenom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.label1);
            this.layoutControl1.Controls.Add(this.TxTEmail);
            this.layoutControl1.Controls.Add(this.checkEditAdmin);
            this.layoutControl1.Controls.Add(this.BtnAjouter);
            this.layoutControl1.Controls.Add(this.TxtPrenom);
            this.layoutControl1.Controls.Add(this.TxtNom);
            this.layoutControl1.Controls.Add(this.TxtPassword);
            this.layoutControl1.Controls.Add(this.TxtLogin);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(488, 280);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // label1
            // 
            this.label1.Image = global::Gestion_de_Stock.Properties.Resources.EC;
            this.label1.Location = new System.Drawing.Point(12, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 36);
            this.label1.TabIndex = 11;
            // 
            // TxTEmail
            // 
            this.TxTEmail.Location = new System.Drawing.Point(61, 108);
            this.TxTEmail.Name = "TxTEmail";
            this.TxTEmail.Size = new System.Drawing.Size(415, 20);
            this.TxTEmail.StyleController = this.layoutControl1;
            this.TxTEmail.TabIndex = 10;
            // 
            // checkEditAdmin
            // 
            this.checkEditAdmin.Location = new System.Drawing.Point(12, 132);
            this.checkEditAdmin.Name = "checkEditAdmin";
            this.checkEditAdmin.Properties.Caption = "Admin";
            this.checkEditAdmin.Size = new System.Drawing.Size(464, 19);
            this.checkEditAdmin.StyleController = this.layoutControl1;
            this.checkEditAdmin.TabIndex = 9;
            // 
            // BtnAjouter
            // 
            this.BtnAjouter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAjouter.ImageOptions.Image")));
            this.BtnAjouter.Location = new System.Drawing.Point(384, 172);
            this.BtnAjouter.Name = "BtnAjouter";
            this.BtnAjouter.Size = new System.Drawing.Size(92, 22);
            this.BtnAjouter.StyleController = this.layoutControl1;
            this.BtnAjouter.TabIndex = 8;
            this.BtnAjouter.Text = "Ajouter";
            this.BtnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);
            // 
            // TxtPrenom
            // 
            this.TxtPrenom.Location = new System.Drawing.Point(61, 84);
            this.TxtPrenom.Name = "TxtPrenom";
            this.TxtPrenom.Size = new System.Drawing.Size(415, 20);
            this.TxtPrenom.StyleController = this.layoutControl1;
            this.TxtPrenom.TabIndex = 7;
            // 
            // TxtNom
            // 
            this.TxtNom.Location = new System.Drawing.Point(61, 60);
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.Size = new System.Drawing.Size(415, 20);
            this.TxtNom.StyleController = this.layoutControl1;
            this.TxtNom.TabIndex = 6;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(61, 36);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(415, 20);
            this.TxtPassword.StyleController = this.layoutControl1;
            this.TxtPassword.TabIndex = 5;
            // 
            // TxtLogin
            // 
            this.TxtLogin.Location = new System.Drawing.Point(61, 12);
            this.TxtLogin.Name = "TxtLogin";
            this.TxtLogin.Size = new System.Drawing.Size(415, 20);
            this.TxtLogin.StyleController = this.layoutControl1;
            this.TxtLogin.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem2,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem3,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(488, 280);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.TxtLogin;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(468, 24);
            this.layoutControlItem1.Text = "Login";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(46, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 143);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(468, 17);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.TxtPassword;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(468, 24);
            this.layoutControlItem2.Text = "Password";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(46, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.TxtNom;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(468, 24);
            this.layoutControlItem3.Text = "Nom";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(46, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.TxtPrenom;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(468, 24);
            this.layoutControlItem4.Text = "Prenom";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(46, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.BtnAjouter;
            this.layoutControlItem5.Location = new System.Drawing.Point(372, 160);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(96, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 160);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(372, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.checkEditAdmin;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(468, 23);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.TxTEmail;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(468, 24);
            this.layoutControlItem7.Text = "Email";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(46, 13);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 186);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(468, 34);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.label1;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 220);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(468, 40);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // FrmAjouterUtilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 280);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAjouterUtilisateur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter Utilisateur";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAjouterUtilisateur_FormClosed);
            this.Load += new System.EventHandler(this.FrmAjouterUtilisateur_Load);
            this.Shown += new System.EventHandler(this.FrmAjouterUtilisateur_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TxTEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPrenom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.CheckEdit checkEditAdmin;
        private DevExpress.XtraEditors.TextEdit TxtPrenom;
        private DevExpress.XtraEditors.TextEdit TxtNom;
        private DevExpress.XtraEditors.TextEdit TxtPassword;
        private DevExpress.XtraEditors.TextEdit TxtLogin;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit TxTEmail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton BtnAjouter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}