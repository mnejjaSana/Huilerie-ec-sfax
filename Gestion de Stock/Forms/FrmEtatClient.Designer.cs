namespace Gestion_de_Stock.Forms
{
    partial class FrmEtatClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEtatClient));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.dateFin = new DevExpress.XtraEditors.DateEdit();
            this.dateDebut = new DevExpress.XtraEditors.DateEdit();
            this.checkTousClients = new DevExpress.XtraEditors.CheckEdit();
            this.BtnImprimerEtat = new DevExpress.XtraEditors.SimpleButton();
            this.radioBtnNonRegle = new System.Windows.Forms.RadioButton();
            this.radioBtnRegle = new System.Windows.Forms.RadioButton();
            this.radioBtnTous = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.searchLookUpClient = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDebut.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDebut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTousClients.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpClient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(516, 341);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(492, 317);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.dateFin);
            this.layoutControl2.Controls.Add(this.dateDebut);
            this.layoutControl2.Controls.Add(this.checkTousClients);
            this.layoutControl2.Controls.Add(this.BtnImprimerEtat);
            this.layoutControl2.Controls.Add(this.radioBtnNonRegle);
            this.layoutControl2.Controls.Add(this.radioBtnRegle);
            this.layoutControl2.Controls.Add(this.radioBtnTous);
            this.layoutControl2.Controls.Add(this.label1);
            this.layoutControl2.Controls.Add(this.searchLookUpClient);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(488, 295);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // dateFin
            // 
            this.dateFin.EditValue = null;
            this.dateFin.Location = new System.Drawing.Point(313, 12);
            this.dateFin.Name = "dateFin";
            this.dateFin.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFin.Properties.Appearance.Options.UseFont = true;
            this.dateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Size = new System.Drawing.Size(163, 26);
            this.dateFin.StyleController = this.layoutControl2;
            this.dateFin.TabIndex = 19;
            // 
            // dateDebut
            // 
            this.dateDebut.EditValue = null;
            this.dateDebut.Location = new System.Drawing.Point(94, 12);
            this.dateDebut.Name = "dateDebut";
            this.dateDebut.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDebut.Properties.Appearance.Options.UseFont = true;
            this.dateDebut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDebut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDebut.Size = new System.Drawing.Size(133, 26);
            this.dateDebut.StyleController = this.layoutControl2;
            this.dateDebut.TabIndex = 17;
            // 
            // checkTousClients
            // 
            this.checkTousClients.Location = new System.Drawing.Point(12, 42);
            this.checkTousClients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkTousClients.MinimumSize = new System.Drawing.Size(396, 28);
            this.checkTousClients.Name = "checkTousClients";
            this.checkTousClients.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTousClients.Properties.Appearance.Options.UseFont = true;
            this.checkTousClients.Properties.AutoHeight = false;
            this.checkTousClients.Properties.Caption = "Tous les clients";
            this.checkTousClients.Size = new System.Drawing.Size(464, 28);
            this.checkTousClients.StyleController = this.layoutControl2;
            this.checkTousClients.TabIndex = 16;
            this.checkTousClients.CheckedChanged += new System.EventHandler(this.checkTousClients_CheckedChanged);
            // 
            // BtnImprimerEtat
            // 
            this.BtnImprimerEtat.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImprimerEtat.Appearance.Options.UseFont = true;
            this.BtnImprimerEtat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnImprimerEtat.ImageOptions.Image")));
            this.BtnImprimerEtat.Location = new System.Drawing.Point(331, 189);
            this.BtnImprimerEtat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnImprimerEtat.Name = "BtnImprimerEtat";
            this.BtnImprimerEtat.Size = new System.Drawing.Size(145, 26);
            this.BtnImprimerEtat.StyleController = this.layoutControl2;
            this.BtnImprimerEtat.TabIndex = 15;
            this.BtnImprimerEtat.Text = "Imprimer";
            this.BtnImprimerEtat.Click += new System.EventHandler(this.BtnImprimerEtat_Click);
            // 
            // radioBtnNonRegle
            // 
            this.radioBtnNonRegle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnNonRegle.Location = new System.Drawing.Point(12, 160);
            this.radioBtnNonRegle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioBtnNonRegle.Name = "radioBtnNonRegle";
            this.radioBtnNonRegle.Size = new System.Drawing.Size(464, 25);
            this.radioBtnNonRegle.TabIndex = 14;
            this.radioBtnNonRegle.TabStop = true;
            this.radioBtnNonRegle.Text = "Non Réglé";
            this.radioBtnNonRegle.UseVisualStyleBackColor = true;
            // 
            // radioBtnRegle
            // 
            this.radioBtnRegle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnRegle.Location = new System.Drawing.Point(12, 131);
            this.radioBtnRegle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioBtnRegle.Name = "radioBtnRegle";
            this.radioBtnRegle.Size = new System.Drawing.Size(464, 25);
            this.radioBtnRegle.TabIndex = 13;
            this.radioBtnRegle.TabStop = true;
            this.radioBtnRegle.Text = "Réglé";
            this.radioBtnRegle.UseVisualStyleBackColor = true;
            // 
            // radioBtnTous
            // 
            this.radioBtnTous.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnTous.Location = new System.Drawing.Point(12, 102);
            this.radioBtnTous.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioBtnTous.Name = "radioBtnTous";
            this.radioBtnTous.Size = new System.Drawing.Size(464, 25);
            this.radioBtnTous.TabIndex = 12;
            this.radioBtnTous.TabStop = true;
            this.radioBtnTous.Text = "Tous";
            this.radioBtnTous.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Image = global::Gestion_de_Stock.Properties.Resources.EC;
            this.label1.Location = new System.Drawing.Point(12, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 30);
            this.label1.TabIndex = 11;
            // 
            // searchLookUpClient
            // 
            this.searchLookUpClient.EditValue = "";
            this.searchLookUpClient.Location = new System.Drawing.Point(94, 69);
            this.searchLookUpClient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchLookUpClient.Name = "searchLookUpClient";
            this.searchLookUpClient.Properties.AutoHeight = false;
            this.searchLookUpClient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpClient.Properties.DataSource = this.clientBindingSource;
            this.searchLookUpClient.Properties.DisplayMember = "Intitule";
            this.searchLookUpClient.Properties.ValueMember = "Id";
            this.searchLookUpClient.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpClient.Size = new System.Drawing.Size(382, 29);
            this.searchLookUpClient.StyleController = this.layoutControl2;
            this.searchLookUpClient.TabIndex = 6;
            this.searchLookUpClient.EditValueChanged += new System.EventHandler(this.searchLookUpClient_EditValueChanged);
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Client);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem9,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem2,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup2.Size = new System.Drawing.Size(488, 295);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 207);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(468, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.searchLookUpClient;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 57);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(169, 28);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(468, 33);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Client";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(78, 19);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.label1;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 241);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(468, 34);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.radioBtnTous;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(468, 29);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.radioBtnRegle;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 119);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(468, 29);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.radioBtnNonRegle;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 148);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(468, 29);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.BtnImprimerEtat;
            this.layoutControlItem8.Location = new System.Drawing.Point(319, 177);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(149, 30);
            this.layoutControlItem8.Text = "Imprimer";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 177);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(319, 30);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.checkTousClients;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(88, 26);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(468, 27);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem11.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem11.Control = this.dateDebut;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(219, 30);
            this.layoutControlItem11.Text = "Date Début";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(78, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.dateFin;
            this.layoutControlItem2.Location = new System.Drawing.Point(219, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(249, 30);
            this.layoutControlItem2.Text = "Date Fin";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(78, 19);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(516, 341);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(496, 321);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmEtatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 341);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmEtatClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Etat Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmEtatClient_FormClosed);
            this.Load += new System.EventHandler(this.EtatClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDebut.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDebut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkTousClients.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpClient;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private System.Windows.Forms.RadioButton radioBtnNonRegle;
        private System.Windows.Forms.RadioButton radioBtnRegle;
        private System.Windows.Forms.RadioButton radioBtnTous;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton BtnImprimerEtat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.CheckEdit checkTousClients;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        public System.Windows.Forms.BindingSource clientBindingSource;
        private DevExpress.XtraEditors.DateEdit dateDebut;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraEditors.DateEdit dateFin;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}