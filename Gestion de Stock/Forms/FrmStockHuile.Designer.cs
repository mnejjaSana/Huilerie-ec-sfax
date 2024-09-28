namespace Gestion_de_Stock.Forms
{
    partial class FrmStockHuile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStockHuile));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.BtnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dateFin = new DevExpress.XtraEditors.DateEdit();
            this.dateDebut = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.mouvementStockBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qteAchte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQteHuileEntrante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPileFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommentaire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPMInitial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntitulé = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumBon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrixMoyenPile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.mouvementStockBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(1176, 578);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(16, 16);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1144, 546);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.BtnExportExcel);
            this.layoutControl2.Controls.Add(this.simpleButton1);
            this.layoutControl2.Controls.Add(this.dateFin);
            this.layoutControl2.Controls.Add(this.dateDebut);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 25);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1140, 519);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // BtnExportExcel
            // 
            this.BtnExportExcel.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportExcel.Appearance.Options.UseFont = true;
            this.BtnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportExcel.ImageOptions.Image")));
            this.BtnExportExcel.Location = new System.Drawing.Point(561, 44);
            this.BtnExportExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExportExcel.Name = "BtnExportExcel";
            this.BtnExportExcel.Size = new System.Drawing.Size(282, 27);
            this.BtnExportExcel.StyleController = this.layoutControl2;
            this.BtnExportExcel.TabIndex = 8;
            this.BtnExportExcel.Text = "Export Excel";
            this.BtnExportExcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(849, 44);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(275, 27);
            this.simpleButton1.StyleController = this.layoutControl2;
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "Export PDF";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dateFin
            // 
            this.dateFin.EditValue = null;
            this.dateFin.Location = new System.Drawing.Point(640, 16);
            this.dateFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateFin.Name = "dateFin";
            this.dateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Size = new System.Drawing.Size(484, 22);
            this.dateFin.StyleController = this.layoutControl2;
            this.dateFin.TabIndex = 6;
            this.dateFin.EditValueChanged += new System.EventHandler(this.dateFin_EditValueChanged);
            // 
            // dateDebut
            // 
            this.dateDebut.EditValue = null;
            this.dateDebut.Location = new System.Drawing.Point(95, 16);
            this.dateDebut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateDebut.Name = "dateDebut";
            this.dateDebut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDebut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDebut.Size = new System.Drawing.Size(460, 22);
            this.dateDebut.StyleController = this.layoutControl2;
            this.dateDebut.TabIndex = 5;
            this.dateDebut.EditValueChanged += new System.EventHandler(this.dateDebut_EditValueChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.mouvementStockBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(16, 77);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1108, 426);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // mouvementStockBindingSource
            // 
            this.mouvementStockBindingSource.DataSource = typeof(Gestion_de_Stock.Model.MouvementStock);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.qteAchte,
            this.colNumero,
            this.colDate,
            this.colPile,
            this.colQteHuileEntrante,
            this.colPileFinal,
            this.gridColumn1,
            this.colCommentaire,
            this.colPMInitial,
            this.Code,
            this.colIntitulé,
            this.colNumBon,
            this.colPrixMoyenPile});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Entrer un texte pour rechercher...";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // qteAchte
            // 
            this.qteAchte.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qteAchte.AppearanceHeader.Options.UseFont = true;
            this.qteAchte.Caption = "Qté Entrante";
            this.qteAchte.FieldName = "QteEntrante";
            this.qteAchte.MinWidth = 80;
            this.qteAchte.Name = "qteAchte";
            this.qteAchte.OptionsColumn.AllowEdit = false;
            this.qteAchte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QteEntrante", "={0:0.##}")});
            this.qteAchte.Visible = true;
            this.qteAchte.VisibleIndex = 4;
            this.qteAchte.Width = 80;
            // 
            // colNumero
            // 
            this.colNumero.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumero.AppearanceHeader.Options.UseFont = true;
            this.colNumero.Caption = "Numéro";
            this.colNumero.FieldName = "Numero";
            this.colNumero.MinWidth = 100;
            this.colNumero.Name = "colNumero";
            this.colNumero.OptionsColumn.AllowEdit = false;
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 0;
            this.colNumero.Width = 100;
            // 
            // colDate
            // 
            this.colDate.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDate.AppearanceHeader.Options.UseFont = true;
            this.colDate.Caption = "Date et Heure";
            this.colDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDate.FieldName = "Date";
            this.colDate.MaxWidth = 100;
            this.colDate.MinWidth = 100;
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowEdit = false;
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;
            this.colDate.Width = 100;
            // 
            // colPile
            // 
            this.colPile.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPile.AppearanceHeader.Options.UseFont = true;
            this.colPile.Caption = "Pile";
            this.colPile.FieldName = "pile.Intitule";
            this.colPile.MaxWidth = 50;
            this.colPile.MinWidth = 40;
            this.colPile.Name = "colPile";
            this.colPile.OptionsColumn.AllowEdit = false;
            this.colPile.Visible = true;
            this.colPile.VisibleIndex = 2;
            this.colPile.Width = 40;
            // 
            // colQteHuileEntrante
            // 
            this.colQteHuileEntrante.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colQteHuileEntrante.AppearanceHeader.Options.UseFont = true;
            this.colQteHuileEntrante.Caption = "Qté Sortante";
            this.colQteHuileEntrante.FieldName = "QteSortante";
            this.colQteHuileEntrante.MinWidth = 80;
            this.colQteHuileEntrante.Name = "colQteHuileEntrante";
            this.colQteHuileEntrante.OptionsColumn.AllowEdit = false;
            this.colQteHuileEntrante.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QteSortante", "={0:0.##}")});
            this.colQteHuileEntrante.Visible = true;
            this.colQteHuileEntrante.VisibleIndex = 5;
            this.colQteHuileEntrante.Width = 80;
            // 
            // colPileFinal
            // 
            this.colPileFinal.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPileFinal.AppearanceHeader.Options.UseFont = true;
            this.colPileFinal.Caption = "Stock physique/Pile";
            this.colPileFinal.FieldName = "QuantitePileFinal";
            this.colPileFinal.Name = "colPileFinal";
            this.colPileFinal.OptionsColumn.AllowEdit = false;
            this.colPileFinal.Visible = true;
            this.colPileFinal.VisibleIndex = 10;
            this.colPileFinal.Width = 91;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "Qualité";
            this.gridColumn1.FieldName = "Qualite";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 59;
            // 
            // colCommentaire
            // 
            this.colCommentaire.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCommentaire.AppearanceHeader.Options.UseFont = true;
            this.colCommentaire.Caption = "Commentaire";
            this.colCommentaire.FieldName = "Commentaire";
            this.colCommentaire.MaxWidth = 110;
            this.colCommentaire.MinWidth = 160;
            this.colCommentaire.Name = "colCommentaire";
            this.colCommentaire.OptionsColumn.AllowEdit = false;
            this.colCommentaire.Visible = true;
            this.colCommentaire.VisibleIndex = 9;
            this.colCommentaire.Width = 160;
            // 
            // colPMInitial
            // 
            this.colPMInitial.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPMInitial.AppearanceHeader.Options.UseFont = true;
            this.colPMInitial.Caption = "Prix Mouvement";
            this.colPMInitial.DisplayFormat.FormatString = "n3";
            this.colPMInitial.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPMInitial.FieldName = "PrixMouvement";
            this.colPMInitial.Name = "colPMInitial";
            this.colPMInitial.OptionsColumn.AllowEdit = false;
            this.colPMInitial.Visible = true;
            this.colPMInitial.VisibleIndex = 11;
            this.colPMInitial.Width = 91;
            // 
            // Code
            // 
            this.Code.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Code.AppearanceHeader.Options.UseFont = true;
            this.Code.Caption = "Code";
            this.Code.FieldName = "Code";
            this.Code.MinWidth = 70;
            this.Code.Name = "Code";
            this.Code.OptionsColumn.AllowEdit = false;
            this.Code.Visible = true;
            this.Code.VisibleIndex = 6;
            this.Code.Width = 80;
            // 
            // colIntitulé
            // 
            this.colIntitulé.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIntitulé.AppearanceHeader.Options.UseFont = true;
            this.colIntitulé.Caption = "Intitulé";
            this.colIntitulé.FieldName = "Intitulé";
            this.colIntitulé.MinWidth = 100;
            this.colIntitulé.Name = "colIntitulé";
            this.colIntitulé.OptionsColumn.AllowEdit = false;
            this.colIntitulé.Visible = true;
            this.colIntitulé.VisibleIndex = 8;
            this.colIntitulé.Width = 100;
            // 
            // colNumBon
            // 
            this.colNumBon.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumBon.AppearanceHeader.Options.UseFont = true;
            this.colNumBon.Caption = "Num Bon";
            this.colNumBon.FieldName = "Achat.NuméroBon";
            this.colNumBon.Name = "colNumBon";
            this.colNumBon.OptionsColumn.AllowEdit = false;
            this.colNumBon.Visible = true;
            this.colNumBon.VisibleIndex = 7;
            this.colNumBon.Width = 59;
            // 
            // colPrixMoyenPile
            // 
            this.colPrixMoyenPile.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPrixMoyenPile.AppearanceHeader.Options.UseFont = true;
            this.colPrixMoyenPile.Caption = "PMP Pile";
            this.colPrixMoyenPile.DisplayFormat.FormatString = "n3";
            this.colPrixMoyenPile.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrixMoyenPile.FieldName = "PMP";
            this.colPrixMoyenPile.Name = "colPrixMoyenPile";
            this.colPrixMoyenPile.OptionsColumn.AllowEdit = false;
            this.colPrixMoyenPile.Visible = true;
            this.colPrixMoyenPile.VisibleIndex = 12;
            this.colPrixMoyenPile.Width = 42;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlItem6});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup2.Size = new System.Drawing.Size(1140, 519);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 61);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1114, 432);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.dateDebut;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(545, 28);
            this.layoutControlItem3.Text = "Date Début";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(75, 17);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.dateFin;
            this.layoutControlItem4.Location = new System.Drawing.Point(545, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(569, 28);
            this.layoutControlItem4.Text = "Date Fin";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(75, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButton1;
            this.layoutControlItem5.Location = new System.Drawing.Point(833, 28);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(281, 33);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 28);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(545, 33);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.BtnExportExcel;
            this.layoutControlItem6.Location = new System.Drawing.Point(545, 28);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(288, 33);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(1176, 578);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1150, 552);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmStockHuile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 578);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmStockHuile";
            this.Text = "Mouvement Stock Pile";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmStockHuile_FormClosed);
            this.Load += new System.EventHandler(this.FrmStockHuile_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.mouvementStockBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton BtnExportExcel;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.DateEdit dateFin;
        private DevExpress.XtraEditors.DateEdit dateDebut;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPile;
        private DevExpress.XtraGrid.Columns.GridColumn colQteHuileEntrante;
        private DevExpress.XtraGrid.Columns.GridColumn colPileFinal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colCommentaire;
        private DevExpress.XtraGrid.Columns.GridColumn qteAchte;
        private DevExpress.XtraGrid.Columns.GridColumn colPMInitial;
        private DevExpress.XtraGrid.Columns.GridColumn Code;
        public System.Windows.Forms.BindingSource mouvementStockBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIntitulé;
        private DevExpress.XtraGrid.Columns.GridColumn colNumBon;
        private DevExpress.XtraGrid.Columns.GridColumn colPrixMoyenPile;
    }
}