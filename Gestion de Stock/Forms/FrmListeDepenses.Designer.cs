namespace Gestion_de_Stock.Forms
{
    partial class FrmListeDepenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListeDepenses));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.BtnActualiser = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExportPDF = new DevExpress.XtraEditors.SimpleButton();
            this.dateFin = new DevExpress.XtraEditors.DateEdit();
            this.dateDebut = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.depenseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommentaire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tiers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcodeAgr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depenseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(945, 565);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(921, 541);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.BtnActualiser);
            this.layoutControl2.Controls.Add(this.label1);
            this.layoutControl2.Controls.Add(this.BtnExportExcel);
            this.layoutControl2.Controls.Add(this.BtnExportPDF);
            this.layoutControl2.Controls.Add(this.dateFin);
            this.layoutControl2.Controls.Add(this.dateDebut);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(917, 519);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // BtnActualiser
            // 
            this.BtnActualiser.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualiser.Appearance.Options.UseFont = true;
            this.BtnActualiser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnActualiser.ImageOptions.Image")));
            this.BtnActualiser.Location = new System.Drawing.Point(795, 12);
            this.BtnActualiser.Name = "BtnActualiser";
            this.BtnActualiser.Size = new System.Drawing.Size(110, 22);
            this.BtnActualiser.StyleController = this.layoutControl2;
            this.BtnActualiser.TabIndex = 11;
            this.BtnActualiser.Text = "Actualiser";
            this.BtnActualiser.Click += new System.EventHandler(this.BtnActualiser_Click);
            // 
            // label1
            // 
            this.label1.Image = global::Gestion_de_Stock.Properties.Resources.EC;
            this.label1.Location = new System.Drawing.Point(12, 473);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(893, 34);
            this.label1.TabIndex = 10;
            // 
            // BtnExportExcel
            // 
            this.BtnExportExcel.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportExcel.Appearance.Options.UseFont = true;
            this.BtnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportExcel.ImageOptions.Image")));
            this.BtnExportExcel.Location = new System.Drawing.Point(452, 62);
            this.BtnExportExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExportExcel.Name = "BtnExportExcel";
            this.BtnExportExcel.Size = new System.Drawing.Size(215, 22);
            this.BtnExportExcel.StyleController = this.layoutControl2;
            this.BtnExportExcel.TabIndex = 9;
            this.BtnExportExcel.Text = "Export Excel";
            this.BtnExportExcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
            // 
            // BtnExportPDF
            // 
            this.BtnExportPDF.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportPDF.Appearance.Options.UseFont = true;
            this.BtnExportPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportPDF.ImageOptions.Image")));
            this.BtnExportPDF.Location = new System.Drawing.Point(671, 62);
            this.BtnExportPDF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExportPDF.Name = "BtnExportPDF";
            this.BtnExportPDF.Size = new System.Drawing.Size(234, 22);
            this.BtnExportPDF.StyleController = this.layoutControl2;
            this.BtnExportPDF.TabIndex = 8;
            this.BtnExportPDF.Text = "Export PDF";
            this.BtnExportPDF.Click += new System.EventHandler(this.BtnExportPDF_Click);
            // 
            // dateFin
            // 
            this.dateFin.EditValue = null;
            this.dateFin.Location = new System.Drawing.Point(513, 38);
            this.dateFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateFin.Name = "dateFin";
            this.dateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Size = new System.Drawing.Size(392, 20);
            this.dateFin.StyleController = this.layoutControl2;
            this.dateFin.TabIndex = 7;
            this.dateFin.EditValueChanged += new System.EventHandler(this.dateFin_EditValueChanged);
            // 
            // dateDebut
            // 
            this.dateDebut.EditValue = null;
            this.dateDebut.Location = new System.Drawing.Point(73, 38);
            this.dateDebut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateDebut.Name = "dateDebut";
            this.dateDebut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDebut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDebut.Size = new System.Drawing.Size(375, 20);
            this.dateDebut.StyleController = this.layoutControl2;
            this.dateDebut.TabIndex = 6;
            this.dateDebut.EditValueChanged += new System.EventHandler(this.dateDebut_EditValueChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.depenseBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(12, 88);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(893, 381);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // depenseBindingSource
            // 
            this.depenseBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Depense);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNum,
            this.colDate,
            this.colSource,
            this.colCommentaire,
            this.tiers,
            this.colMontant,
            this.colcodeAgr});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Entrer un texte pour rechercher...";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colNum
            // 
            this.colNum.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNum.AppearanceHeader.Options.UseFont = true;
            this.colNum.Caption = "Numéro";
            this.colNum.FieldName = "Numero";
            this.colNum.MaxWidth = 100;
            this.colNum.MinWidth = 10;
            this.colNum.Name = "colNum";
            this.colNum.OptionsColumn.AllowEdit = false;
            this.colNum.Visible = true;
            this.colNum.VisibleIndex = 0;
            // 
            // colDate
            // 
            this.colDate.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDate.AppearanceHeader.Options.UseFont = true;
            this.colDate.Caption = "Date";
            this.colDate.FieldName = "DateCreation";
            this.colDate.MaxWidth = 100;
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowEdit = false;
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;
            // 
            // colSource
            // 
            this.colSource.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSource.AppearanceHeader.Options.UseFont = true;
            this.colSource.Caption = "Source";
            this.colSource.FieldName = "Nature";
            this.colSource.MaxWidth = 120;
            this.colSource.Name = "colSource";
            this.colSource.OptionsColumn.AllowEdit = false;
            this.colSource.Visible = true;
            this.colSource.VisibleIndex = 2;
            // 
            // colCommentaire
            // 
            this.colCommentaire.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCommentaire.AppearanceHeader.Options.UseFont = true;
            this.colCommentaire.Caption = "Commentaire";
            this.colCommentaire.FieldName = "Commentaire";
            this.colCommentaire.Name = "colCommentaire";
            this.colCommentaire.OptionsColumn.AllowEdit = false;
            this.colCommentaire.Visible = true;
            this.colCommentaire.VisibleIndex = 5;
            this.colCommentaire.Width = 150;
            // 
            // tiers
            // 
            this.tiers.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiers.AppearanceHeader.Options.UseFont = true;
            this.tiers.Caption = "Tiers";
            this.tiers.FieldName = "Tiers";
            this.tiers.MinWidth = 120;
            this.tiers.Name = "tiers";
            this.tiers.OptionsColumn.AllowEdit = false;
            this.tiers.Visible = true;
            this.tiers.VisibleIndex = 3;
            this.tiers.Width = 120;
            // 
            // colMontant
            // 
            this.colMontant.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMontant.AppearanceHeader.Options.UseFont = true;
            this.colMontant.Caption = "Montant";
            this.colMontant.DisplayFormat.FormatString = "n3";
            this.colMontant.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontant.FieldName = "Montant";
            this.colMontant.Name = "colMontant";
            this.colMontant.OptionsColumn.AllowEdit = false;
            this.colMontant.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Montant", "Total={0:f3}")});
            this.colMontant.Visible = true;
            this.colMontant.VisibleIndex = 6;
            // 
            // colcodeAgr
            // 
            this.colcodeAgr.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colcodeAgr.AppearanceHeader.Options.UseFont = true;
            this.colcodeAgr.Caption = "Code Tiers";
            this.colcodeAgr.FieldName = "Salarie.numero";
            this.colcodeAgr.MaxWidth = 150;
            this.colcodeAgr.Name = "colcodeAgr";
            this.colcodeAgr.OptionsColumn.AllowEdit = false;
            this.colcodeAgr.Visible = true;
            this.colcodeAgr.VisibleIndex = 4;
            this.colcodeAgr.Width = 80;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem2,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup2.Size = new System.Drawing.Size(917, 519);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(897, 385);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.dateDebut;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(440, 24);
            this.layoutControlItem4.Text = "Date début";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(57, 15);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.dateFin;
            this.layoutControlItem5.Location = new System.Drawing.Point(440, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(457, 24);
            this.layoutControlItem5.Text = "Date fin";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(57, 15);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.BtnExportPDF;
            this.layoutControlItem6.Location = new System.Drawing.Point(659, 50);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(238, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 50);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(440, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.BtnExportExcel;
            this.layoutControlItem7.Location = new System.Drawing.Point(440, 50);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(219, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.label1;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 461);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(897, 38);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BtnActualiser;
            this.layoutControlItem3.Location = new System.Drawing.Point(783, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(114, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(783, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(945, 565);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(925, 545);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmListeDepenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 565);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmListeDepenses";
            this.Text = "Liste des dépenses divers";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmListeDepenses_FormClosed);
            this.Load += new System.EventHandler(this.FrmListeDepenses_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depenseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNum;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCommentaire;
        private DevExpress.XtraGrid.Columns.GridColumn colMontant;
        public System.Windows.Forms.BindingSource depenseBindingSource;
        private DevExpress.XtraEditors.SimpleButton BtnExportExcel;
        private DevExpress.XtraEditors.SimpleButton BtnExportPDF;
        private DevExpress.XtraEditors.DateEdit dateFin;
        private DevExpress.XtraEditors.DateEdit dateDebut;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.Columns.GridColumn tiers;
        private DevExpress.XtraGrid.Columns.GridColumn colcodeAgr;
        private DevExpress.XtraEditors.SimpleButton BtnActualiser;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}