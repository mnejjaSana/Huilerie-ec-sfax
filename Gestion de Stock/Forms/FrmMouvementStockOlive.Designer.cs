namespace Gestion_de_Stock.Forms
{
    partial class FrmMouvementStockOlive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMouvementStockOlive));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.exportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.exportPDF = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.DateFin = new DevExpress.XtraEditors.DateEdit();
            this.DateDebut = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.mouvementStockOliveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIntitulé = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommentaire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantiteMasrafFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrixMouvement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQteEntrante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQteSortante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemdementMov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRendementMoyenne = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasraf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDebut.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDebut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mouvementStockOliveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(16, 16);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1219, 473);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.exportExcel);
            this.layoutControl2.Controls.Add(this.exportPDF);
            this.layoutControl2.Controls.Add(this.label1);
            this.layoutControl2.Controls.Add(this.DateFin);
            this.layoutControl2.Controls.Add(this.DateDebut);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 25);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1215, 446);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // exportExcel
            // 
            this.exportExcel.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportExcel.Appearance.Options.UseFont = true;
            this.exportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("exportExcel.ImageOptions.Image")));
            this.exportExcel.Location = new System.Drawing.Point(885, 16);
            this.exportExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exportExcel.Name = "exportExcel";
            this.exportExcel.Size = new System.Drawing.Size(151, 28);
            this.exportExcel.StyleController = this.layoutControl2;
            this.exportExcel.TabIndex = 12;
            this.exportExcel.Text = "Export Excel";
            this.exportExcel.Click += new System.EventHandler(this.exportExcel_Click);
            // 
            // exportPDF
            // 
            this.exportPDF.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportPDF.Appearance.Options.UseFont = true;
            this.exportPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("exportPDF.ImageOptions.Image")));
            this.exportPDF.Location = new System.Drawing.Point(1042, 16);
            this.exportPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(157, 28);
            this.exportPDF.StyleController = this.layoutControl2;
            this.exportPDF.TabIndex = 11;
            this.exportPDF.Text = "Export PDF";
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // label1
            // 
            this.label1.Image = global::Gestion_de_Stock.Properties.Resources.EC;
            this.label1.Location = new System.Drawing.Point(16, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1183, 39);
            this.label1.TabIndex = 10;
            // 
            // DateFin
            // 
            this.DateFin.EditValue = null;
            this.DateFin.Location = new System.Drawing.Point(690, 50);
            this.DateFin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DateFin.Name = "DateFin";
            this.DateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateFin.Size = new System.Drawing.Size(509, 22);
            this.DateFin.StyleController = this.layoutControl2;
            this.DateFin.TabIndex = 6;
            // 
            // DateDebut
            // 
            this.DateDebut.EditValue = null;
            this.DateDebut.Location = new System.Drawing.Point(97, 50);
            this.DateDebut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DateDebut.Name = "DateDebut";
            this.DateDebut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateDebut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateDebut.Size = new System.Drawing.Size(506, 22);
            this.DateDebut.StyleController = this.layoutControl2;
            this.DateDebut.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.mouvementStockOliveBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(16, 78);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1183, 307);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // mouvementStockOliveBindingSource
            // 
            this.mouvementStockOliveBindingSource.DataSource = typeof(Gestion_de_Stock.Model.MouvementStockOlive);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIntitulé,
            this.colNumero,
            this.colCommentaire,
            this.colDate,
            this.colQuantiteMasrafFinal,
            this.colPrixMouvement,
            this.colQteEntrante,
            this.colQteSortante,
            this.code,
            this.colRemdementMov,
            this.colRendementMoyenne,
            this.colMasraf});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Entrer un texte pour rechercher...";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colIntitulé
            // 
            this.colIntitulé.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIntitulé.AppearanceCell.Options.UseFont = true;
            this.colIntitulé.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIntitulé.AppearanceHeader.Options.UseFont = true;
            this.colIntitulé.FieldName = "Intitulé";
            this.colIntitulé.MaxWidth = 88;
            this.colIntitulé.MinWidth = 88;
            this.colIntitulé.Name = "colIntitulé";
            this.colIntitulé.OptionsColumn.AllowEdit = false;
            this.colIntitulé.Visible = true;
            this.colIntitulé.VisibleIndex = 5;
            this.colIntitulé.Width = 88;
            // 
            // colNumero
            // 
            this.colNumero.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumero.AppearanceCell.Options.UseFont = true;
            this.colNumero.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumero.AppearanceHeader.Options.UseFont = true;
            this.colNumero.Caption = "Numéro";
            this.colNumero.FieldName = "Numero";
            this.colNumero.MaxWidth = 110;
            this.colNumero.MinWidth = 110;
            this.colNumero.Name = "colNumero";
            this.colNumero.OptionsColumn.AllowEdit = false;
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 0;
            this.colNumero.Width = 110;
            // 
            // colCommentaire
            // 
            this.colCommentaire.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCommentaire.AppearanceCell.Options.UseFont = true;
            this.colCommentaire.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCommentaire.AppearanceHeader.Options.UseFont = true;
            this.colCommentaire.FieldName = "Commentaire";
            this.colCommentaire.MaxWidth = 160;
            this.colCommentaire.MinWidth = 160;
            this.colCommentaire.Name = "colCommentaire";
            this.colCommentaire.OptionsColumn.AllowEdit = false;
            this.colCommentaire.Visible = true;
            this.colCommentaire.VisibleIndex = 9;
            this.colCommentaire.Width = 160;
            // 
            // colDate
            // 
            this.colDate.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDate.AppearanceCell.Options.UseFont = true;
            this.colDate.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDate.AppearanceHeader.Options.UseFont = true;
            this.colDate.FieldName = "Date";
            this.colDate.MaxWidth = 70;
            this.colDate.MinWidth = 70;
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowEdit = false;
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;
            this.colDate.Width = 70;
            // 
            // colQuantiteMasrafFinal
            // 
            this.colQuantiteMasrafFinal.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colQuantiteMasrafFinal.AppearanceCell.Options.UseFont = true;
            this.colQuantiteMasrafFinal.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colQuantiteMasrafFinal.AppearanceHeader.Options.UseFont = true;
            this.colQuantiteMasrafFinal.Caption = "Stock physique/Masraf ";
            this.colQuantiteMasrafFinal.FieldName = "QuantiteMasrafFinal";
            this.colQuantiteMasrafFinal.MaxWidth = 130;
            this.colQuantiteMasrafFinal.MinWidth = 130;
            this.colQuantiteMasrafFinal.Name = "colQuantiteMasrafFinal";
            this.colQuantiteMasrafFinal.OptionsColumn.AllowEdit = false;
            this.colQuantiteMasrafFinal.Visible = true;
            this.colQuantiteMasrafFinal.VisibleIndex = 7;
            this.colQuantiteMasrafFinal.Width = 130;
            // 
            // colPrixMouvement
            // 
            this.colPrixMouvement.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPrixMouvement.AppearanceCell.Options.UseFont = true;
            this.colPrixMouvement.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPrixMouvement.AppearanceHeader.Options.UseFont = true;
            this.colPrixMouvement.DisplayFormat.FormatString = "n3";
            this.colPrixMouvement.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrixMouvement.FieldName = "PrixMouvement";
            this.colPrixMouvement.MaxWidth = 100;
            this.colPrixMouvement.MinWidth = 100;
            this.colPrixMouvement.Name = "colPrixMouvement";
            this.colPrixMouvement.OptionsColumn.AllowEdit = false;
            this.colPrixMouvement.Visible = true;
            this.colPrixMouvement.VisibleIndex = 11;
            this.colPrixMouvement.Width = 100;
            // 
            // colQteEntrante
            // 
            this.colQteEntrante.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colQteEntrante.AppearanceCell.Options.UseFont = true;
            this.colQteEntrante.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colQteEntrante.AppearanceHeader.Options.UseFont = true;
            this.colQteEntrante.Caption = "Qté Entrante";
            this.colQteEntrante.FieldName = "QteEntrante";
            this.colQteEntrante.MaxWidth = 90;
            this.colQteEntrante.MinWidth = 90;
            this.colQteEntrante.Name = "colQteEntrante";
            this.colQteEntrante.OptionsColumn.AllowEdit = false;
            this.colQteEntrante.Visible = true;
            this.colQteEntrante.VisibleIndex = 2;
            this.colQteEntrante.Width = 90;
            // 
            // colQteSortante
            // 
            this.colQteSortante.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colQteSortante.AppearanceCell.Options.UseFont = true;
            this.colQteSortante.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colQteSortante.AppearanceHeader.Options.UseFont = true;
            this.colQteSortante.Caption = "Qté Sortante";
            this.colQteSortante.FieldName = "QteSortante";
            this.colQteSortante.MaxWidth = 90;
            this.colQteSortante.MinWidth = 90;
            this.colQteSortante.Name = "colQteSortante";
            this.colQteSortante.OptionsColumn.AllowEdit = false;
            this.colQteSortante.Visible = true;
            this.colQteSortante.VisibleIndex = 3;
            this.colQteSortante.Width = 90;
            // 
            // code
            // 
            this.code.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code.AppearanceCell.Options.UseFont = true;
            this.code.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code.AppearanceHeader.Options.UseFont = true;
            this.code.Caption = "Code";
            this.code.FieldName = "Code";
            this.code.MaxWidth = 90;
            this.code.MinWidth = 90;
            this.code.Name = "code";
            this.code.OptionsColumn.AllowEdit = false;
            this.code.Visible = true;
            this.code.VisibleIndex = 4;
            this.code.Width = 90;
            // 
            // colRemdementMov
            // 
            this.colRemdementMov.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colRemdementMov.AppearanceCell.Options.UseFont = true;
            this.colRemdementMov.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colRemdementMov.AppearanceHeader.Options.UseFont = true;
            this.colRemdementMov.Caption = "Rendement Mvt";
            this.colRemdementMov.DisplayFormat.FormatString = "n3";
            this.colRemdementMov.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRemdementMov.FieldName = "RENDEMENTMVT";
            this.colRemdementMov.MaxWidth = 100;
            this.colRemdementMov.MinWidth = 140;
            this.colRemdementMov.Name = "colRemdementMov";
            this.colRemdementMov.OptionsColumn.AllowEdit = false;
            this.colRemdementMov.Visible = true;
            this.colRemdementMov.VisibleIndex = 8;
            this.colRemdementMov.Width = 140;
            // 
            // colRendementMoyenne
            // 
            this.colRendementMoyenne.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colRendementMoyenne.AppearanceCell.Options.UseFont = true;
            this.colRendementMoyenne.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colRendementMoyenne.AppearanceHeader.Options.UseFont = true;
            this.colRendementMoyenne.Caption = "Rendement Moyen Prévu";
            this.colRendementMoyenne.DisplayFormat.FormatString = "n3";
            this.colRendementMoyenne.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRendementMoyenne.FieldName = "RENDEMENMOY";
            this.colRendementMoyenne.MaxWidth = 140;
            this.colRendementMoyenne.MinWidth = 140;
            this.colRendementMoyenne.Name = "colRendementMoyenne";
            this.colRendementMoyenne.OptionsColumn.AllowEdit = false;
            this.colRendementMoyenne.Visible = true;
            this.colRendementMoyenne.VisibleIndex = 10;
            this.colRendementMoyenne.Width = 140;
            // 
            // colMasraf
            // 
            this.colMasraf.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMasraf.AppearanceCell.Options.UseFont = true;
            this.colMasraf.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMasraf.AppearanceHeader.Options.UseFont = true;
            this.colMasraf.Caption = "Masraf";
            this.colMasraf.FieldName = "Emplacement.Intitule";
            this.colMasraf.MaxWidth = 100;
            this.colMasraf.MinWidth = 100;
            this.colMasraf.Name = "colMasraf";
            this.colMasraf.OptionsColumn.AllowEdit = false;
            this.colMasraf.Visible = true;
            this.colMasraf.VisibleIndex = 6;
            this.colMasraf.Width = 100;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlItem6});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1215, 446);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 62);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1189, 313);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.DateDebut;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(593, 28);
            this.layoutControlItem3.Text = "Date Début";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(78, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.DateFin;
            this.layoutControlItem4.Location = new System.Drawing.Point(593, 34);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(596, 28);
            this.layoutControlItem4.Text = "Date Fin";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(78, 19);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.label1;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 375);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(1189, 45);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.exportPDF;
            this.layoutControlItem5.Location = new System.Drawing.Point(1026, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(163, 34);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(869, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.exportExcel;
            this.layoutControlItem6.Location = new System.Drawing.Point(869, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(157, 34);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(1251, 505);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1225, 479);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1251, 505);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // FrmMouvementStockOlive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 505);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMouvementStockOlive";
            this.Text = "Mouvement Stock Olive";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMouvementStockOlive_FormClosed);
            this.Load += new System.EventHandler(this.FrmMouvementStockOlive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DateFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDebut.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDebut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mouvementStockOliveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit DateFin;
        private DevExpress.XtraEditors.DateEdit DateDebut;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIntitulé;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colCommentaire;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantiteMasrafFinal;
        private DevExpress.XtraGrid.Columns.GridColumn colPrixMouvement;
        private DevExpress.XtraGrid.Columns.GridColumn colQteEntrante;
        private DevExpress.XtraGrid.Columns.GridColumn colQteSortante;
        private DevExpress.XtraGrid.Columns.GridColumn code;
        private DevExpress.XtraGrid.Columns.GridColumn colRemdementMov;
        private DevExpress.XtraGrid.Columns.GridColumn colRendementMoyenne;
        private DevExpress.XtraGrid.Columns.GridColumn colMasraf;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton exportExcel;
        private DevExpress.XtraEditors.SimpleButton exportPDF;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        public System.Windows.Forms.BindingSource mouvementStockOliveBindingSource;
    }
}