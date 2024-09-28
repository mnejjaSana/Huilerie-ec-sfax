namespace Gestion_de_Stock.Forms
{
    partial class FrmClient
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClient));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExporterXLS = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExporterPDF = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAjouter = new DevExpress.XtraEditors.SimpleButton();
            this.BtnModifer = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSupprimer = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Nom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdresse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Telephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.BtnActualiser = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton3);
            this.layoutControl1.Controls.Add(this.BtnActualiser);
            this.layoutControl1.Controls.Add(this.label1);
            this.layoutControl1.Controls.Add(this.BtnExporterXLS);
            this.layoutControl1.Controls.Add(this.BtnExporterPDF);
            this.layoutControl1.Controls.Add(this.BtnAjouter);
            this.layoutControl1.Controls.Add(this.BtnModifer);
            this.layoutControl1.Controls.Add(this.BtnSupprimer);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(873, 461);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // label1
            // 
            this.label1.Image = global::Gestion_de_Stock.Properties.Resources.EC;
            this.label1.Location = new System.Drawing.Point(12, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(849, 22);
            this.label1.TabIndex = 20;
            // 
            // BtnExporterXLS
            // 
            this.BtnExporterXLS.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExporterXLS.Appearance.Options.UseFont = true;
            this.BtnExporterXLS.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExporterXLS.ImageOptions.Image")));
            this.BtnExporterXLS.Location = new System.Drawing.Point(567, 12);
            this.BtnExporterXLS.Name = "BtnExporterXLS";
            this.BtnExporterXLS.Size = new System.Drawing.Size(142, 22);
            this.BtnExporterXLS.StyleController = this.layoutControl1;
            this.BtnExporterXLS.TabIndex = 19;
            this.BtnExporterXLS.Text = "Exporter XLS";
            this.BtnExporterXLS.Click += new System.EventHandler(this.BtnExporterXLS_Click);
            // 
            // BtnExporterPDF
            // 
            this.BtnExporterPDF.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExporterPDF.Appearance.Options.UseFont = true;
            this.BtnExporterPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExporterPDF.ImageOptions.Image")));
            this.BtnExporterPDF.Location = new System.Drawing.Point(713, 12);
            this.BtnExporterPDF.Name = "BtnExporterPDF";
            this.BtnExporterPDF.Size = new System.Drawing.Size(148, 22);
            this.BtnExporterPDF.StyleController = this.layoutControl1;
            this.BtnExporterPDF.TabIndex = 18;
            this.BtnExporterPDF.Text = "Exporter PDF";
            this.BtnExporterPDF.Click += new System.EventHandler(this.BtnExporterPDF_Click);
            // 
            // BtnAjouter
            // 
            this.BtnAjouter.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAjouter.Appearance.Options.UseFont = true;
            this.BtnAjouter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAjouter.ImageOptions.Image")));
            this.BtnAjouter.Location = new System.Drawing.Point(445, 371);
            this.BtnAjouter.Name = "BtnAjouter";
            this.BtnAjouter.Size = new System.Drawing.Size(143, 26);
            this.BtnAjouter.StyleController = this.layoutControl1;
            this.BtnAjouter.TabIndex = 16;
            this.BtnAjouter.Text = "Ajouter";
            this.BtnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);
            // 
            // BtnModifer
            // 
            this.BtnModifer.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModifer.Appearance.Options.UseFont = true;
            this.BtnModifer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnModifer.ImageOptions.Image")));
            this.BtnModifer.Location = new System.Drawing.Point(592, 371);
            this.BtnModifer.Name = "BtnModifer";
            this.BtnModifer.Size = new System.Drawing.Size(142, 26);
            this.BtnModifer.StyleController = this.layoutControl1;
            this.BtnModifer.TabIndex = 15;
            this.BtnModifer.Text = "Modifer";
            this.BtnModifer.Click += new System.EventHandler(this.BtnEnregister_Click);
            // 
            // BtnSupprimer
            // 
            this.BtnSupprimer.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSupprimer.Appearance.Options.UseFont = true;
            this.BtnSupprimer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSupprimer.ImageOptions.Image")));
            this.BtnSupprimer.Location = new System.Drawing.Point(738, 371);
            this.BtnSupprimer.Name = "BtnSupprimer";
            this.BtnSupprimer.Size = new System.Drawing.Size(123, 26);
            this.BtnSupprimer.StyleController = this.layoutControl1;
            this.BtnSupprimer.TabIndex = 14;
            this.BtnSupprimer.Text = "Supprimer";
            this.BtnSupprimer.Click += new System.EventHandler(this.BtnSupprimer_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.clientBindingSource;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(12, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(849, 329);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Client);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.Nom,
            this.colAdresse,
            this.Telephone,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Entrer un texte pour rechercher...";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsPrint.PrintFilterInfo = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colCode
            // 
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.Caption = "Numéro";
            this.colCode.FieldName = "Numero";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            // 
            // Nom
            // 
            this.Nom.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nom.AppearanceHeader.Options.UseFont = true;
            this.Nom.Caption = "Intitulé";
            this.Nom.FieldName = "Intitule";
            this.Nom.Name = "Nom";
            this.Nom.Visible = true;
            this.Nom.VisibleIndex = 1;
            // 
            // colAdresse
            // 
            this.colAdresse.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAdresse.AppearanceHeader.Options.UseFont = true;
            this.colAdresse.FieldName = "Adresse";
            this.colAdresse.Name = "colAdresse";
            this.colAdresse.Visible = true;
            this.colAdresse.VisibleIndex = 2;
            // 
            // Telephone
            // 
            this.Telephone.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Telephone.AppearanceHeader.Options.UseFont = true;
            this.Telephone.Caption = "Téléphone";
            this.Telephone.FieldName = "Tel";
            this.Telephone.Name = "Telephone";
            this.Telephone.Visible = true;
            this.Telephone.VisibleIndex = 3;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "Matricule Fiscale";
            this.gridColumn1.FieldName = "MatriculeFiscale";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem8,
            this.layoutControlItem13,
            this.layoutControlItem14,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(873, 461);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(853, 333);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.BtnSupprimer;
            this.layoutControlItem11.Location = new System.Drawing.Point(726, 359);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(127, 30);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.BtnModifer;
            this.layoutControlItem12.Location = new System.Drawing.Point(580, 359);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(146, 30);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.BtnAjouter;
            this.layoutControlItem8.Location = new System.Drawing.Point(433, 359);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(147, 30);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.BtnExporterPDF;
            this.layoutControlItem13.Location = new System.Drawing.Point(701, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(152, 26);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.BtnExporterXLS;
            this.layoutControlItem14.Location = new System.Drawing.Point(555, 0);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(424, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 359);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(433, 30);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.label1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 389);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(853, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // BtnActualiser
            // 
            this.BtnActualiser.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualiser.Appearance.Options.UseFont = true;
            this.BtnActualiser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.BtnActualiser.Location = new System.Drawing.Point(436, 12);
            this.BtnActualiser.Name = "BtnActualiser";
            this.BtnActualiser.Size = new System.Drawing.Size(127, 22);
            this.BtnActualiser.StyleController = this.layoutControl1;
            this.BtnActualiser.TabIndex = 21;
            this.BtnActualiser.Text = "Actualiser";
            this.BtnActualiser.Click += new System.EventHandler(this.BtnActualiser_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BtnActualiser;
            this.layoutControlItem3.Location = new System.Drawing.Point(424, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(131, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(12, 427);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(849, 22);
            this.simpleButton3.StyleController = this.layoutControl1;
            this.simpleButton3.TabIndex = 23;
            this.simpleButton3.Text = "simpleButton3";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButton3;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 415);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(853, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // FrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 461);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmClient";
            this.Text = "Liste des Clients";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmClient_FormClosed);
            this.Load += new System.EventHandler(this.FrmClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAdresse;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton BtnModifer;
        private DevExpress.XtraEditors.SimpleButton BtnSupprimer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraGrid.Columns.GridColumn Telephone;
        private DevExpress.XtraEditors.SimpleButton BtnAjouter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        public System.Windows.Forms.BindingSource clientBindingSource;
        private DevExpress.XtraEditors.SimpleButton BtnExporterXLS;
        private DevExpress.XtraEditors.SimpleButton BtnExporterPDF;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn Nom;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton BtnActualiser;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}