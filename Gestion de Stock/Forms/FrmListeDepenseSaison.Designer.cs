namespace Gestion_de_Stock.Forms
{
    partial class FrmListeDepenseSaison
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListeDepenseSaison));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.BtnActualiser = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.depenseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodeAgriculteur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommentaire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModePaiement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTiers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ncheque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GcBanque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GcAppearance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnExportPDF = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.dateFin = new DevExpress.XtraEditors.DateEdit();
            this.dateDebut = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depenseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDebut.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDebut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(1123, 587);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1099, 563);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.BtnActualiser);
            this.layoutControl2.Controls.Add(this.label1);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Controls.Add(this.BtnExportPDF);
            this.layoutControl2.Controls.Add(this.BtnExportExcel);
            this.layoutControl2.Controls.Add(this.dateFin);
            this.layoutControl2.Controls.Add(this.dateDebut);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1095, 541);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // BtnActualiser
            // 
            this.BtnActualiser.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualiser.Appearance.Options.UseFont = true;
            this.BtnActualiser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnActualiser.ImageOptions.Image")));
            this.BtnActualiser.Location = new System.Drawing.Point(952, 12);
            this.BtnActualiser.Name = "BtnActualiser";
            this.BtnActualiser.Size = new System.Drawing.Size(131, 22);
            this.BtnActualiser.StyleController = this.layoutControl2;
            this.BtnActualiser.TabIndex = 10;
            this.BtnActualiser.Text = "Actualiser";
            this.BtnActualiser.Click += new System.EventHandler(this.BtnActualiser_Click);
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(12, 487);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1071, 42);
            this.label1.TabIndex = 9;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.depenseBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(12, 90);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1071, 393);
            this.gridControl1.TabIndex = 8;
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
            this.colCodeAgriculteur,
            this.colDateCreation,
            this.colNumero,
            this.colNature,
            this.colMontant,
            this.colCommentaire,
            this.colModePaiement,
            this.colTiers,
            this.Ncheque,
            this.GcBanque,
            this.GcAppearance});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Entrer un texte pour rechercher...";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colCodeAgriculteur
            // 
            this.colCodeAgriculteur.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCodeAgriculteur.AppearanceHeader.Options.UseFont = true;
            this.colCodeAgriculteur.Caption = "Code Tiers";
            this.colCodeAgriculteur.FieldName = "CodeTiers";
            this.colCodeAgriculteur.Name = "colCodeAgriculteur";
            this.colCodeAgriculteur.OptionsColumn.AllowEdit = false;
            this.colCodeAgriculteur.Visible = true;
            this.colCodeAgriculteur.VisibleIndex = 3;
            // 
            // colDateCreation
            // 
            this.colDateCreation.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDateCreation.AppearanceHeader.Options.UseFont = true;
            this.colDateCreation.Caption = "Date";
            this.colDateCreation.FieldName = "DateCreation";
            this.colDateCreation.MaxWidth = 80;
            this.colDateCreation.Name = "colDateCreation";
            this.colDateCreation.OptionsColumn.AllowEdit = false;
            this.colDateCreation.Visible = true;
            this.colDateCreation.VisibleIndex = 1;
            this.colDateCreation.Width = 60;
            // 
            // colNumero
            // 
            this.colNumero.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumero.AppearanceHeader.Options.UseFont = true;
            this.colNumero.Caption = "Numéro";
            this.colNumero.FieldName = "Numero";
            this.colNumero.MaxWidth = 90;
            this.colNumero.Name = "colNumero";
            this.colNumero.OptionsColumn.AllowEdit = false;
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 0;
            // 
            // colNature
            // 
            this.colNature.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNature.AppearanceHeader.Options.UseFont = true;
            this.colNature.Caption = "Source";
            this.colNature.FieldName = "Nature";
            this.colNature.Name = "colNature";
            this.colNature.OptionsColumn.AllowEdit = false;
            this.colNature.Visible = true;
            this.colNature.VisibleIndex = 2;
            // 
            // colMontant
            // 
            this.colMontant.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMontant.AppearanceHeader.Options.UseFont = true;
            this.colMontant.DisplayFormat.FormatString = "n3";
            this.colMontant.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontant.FieldName = "Montant";
            this.colMontant.Name = "colMontant";
            this.colMontant.OptionsColumn.AllowEdit = false;
            this.colMontant.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Montant", "={0:f3}")});
            this.colMontant.Visible = true;
            this.colMontant.VisibleIndex = 10;
            // 
            // colCommentaire
            // 
            this.colCommentaire.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCommentaire.AppearanceHeader.Options.UseFont = true;
            this.colCommentaire.FieldName = "Commentaire";
            this.colCommentaire.MinWidth = 200;
            this.colCommentaire.Name = "colCommentaire";
            this.colCommentaire.OptionsColumn.AllowEdit = false;
            this.colCommentaire.Visible = true;
            this.colCommentaire.VisibleIndex = 5;
            this.colCommentaire.Width = 200;
            // 
            // colModePaiement
            // 
            this.colModePaiement.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colModePaiement.AppearanceHeader.Options.UseFont = true;
            this.colModePaiement.FieldName = "ModePaiement";
            this.colModePaiement.Name = "colModePaiement";
            this.colModePaiement.OptionsColumn.AllowEdit = false;
            this.colModePaiement.Visible = true;
            this.colModePaiement.VisibleIndex = 6;
            // 
            // colTiers
            // 
            this.colTiers.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTiers.AppearanceHeader.Options.UseFont = true;
            this.colTiers.FieldName = "Tiers";
            this.colTiers.MinWidth = 120;
            this.colTiers.Name = "colTiers";
            this.colTiers.OptionsColumn.AllowEdit = false;
            this.colTiers.Visible = true;
            this.colTiers.VisibleIndex = 4;
            this.colTiers.Width = 120;
            // 
            // Ncheque
            // 
            this.Ncheque.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ncheque.AppearanceHeader.Options.UseFont = true;
            this.Ncheque.Caption = "N° Chèque/Traite ";
            this.Ncheque.FieldName = "NumCheque";
            this.Ncheque.Name = "Ncheque";
            this.Ncheque.OptionsColumn.AllowEdit = false;
            this.Ncheque.Visible = true;
            this.Ncheque.VisibleIndex = 7;
            // 
            // GcBanque
            // 
            this.GcBanque.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GcBanque.AppearanceHeader.Options.UseFont = true;
            this.GcBanque.Caption = "Banque";
            this.GcBanque.FieldName = "Bank";
            this.GcBanque.Name = "GcBanque";
            this.GcBanque.OptionsColumn.AllowEdit = false;
            this.GcBanque.Visible = true;
            this.GcBanque.VisibleIndex = 8;
            // 
            // GcAppearance
            // 
            this.GcAppearance.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GcAppearance.AppearanceHeader.Options.UseFont = true;
            this.GcAppearance.Caption = "Date Echeance";
            this.GcAppearance.FieldName = "DateEcheance";
            this.GcAppearance.Name = "GcAppearance";
            this.GcAppearance.OptionsColumn.AllowEdit = false;
            this.GcAppearance.Visible = true;
            this.GcAppearance.VisibleIndex = 9;
            // 
            // BtnExportPDF
            // 
            this.BtnExportPDF.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportPDF.Appearance.Options.UseFont = true;
            this.BtnExportPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportPDF.ImageOptions.Image")));
            this.BtnExportPDF.Location = new System.Drawing.Point(781, 64);
            this.BtnExportPDF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExportPDF.Name = "BtnExportPDF";
            this.BtnExportPDF.Size = new System.Drawing.Size(302, 22);
            this.BtnExportPDF.StyleController = this.layoutControl2;
            this.BtnExportPDF.TabIndex = 7;
            this.BtnExportPDF.Text = "Export PDF";
            this.BtnExportPDF.Click += new System.EventHandler(this.BtnExportPDF_Click);
            // 
            // BtnExportExcel
            // 
            this.BtnExportExcel.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportExcel.Appearance.Options.UseFont = true;
            this.BtnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportExcel.ImageOptions.Image")));
            this.BtnExportExcel.Location = new System.Drawing.Point(513, 64);
            this.BtnExportExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExportExcel.Name = "BtnExportExcel";
            this.BtnExportExcel.Size = new System.Drawing.Size(264, 22);
            this.BtnExportExcel.StyleController = this.layoutControl2;
            this.BtnExportExcel.TabIndex = 6;
            this.BtnExportExcel.Text = "Export Excel";
            this.BtnExportExcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
            // 
            // dateFin
            // 
            this.dateFin.EditValue = null;
            this.dateFin.Location = new System.Drawing.Point(574, 38);
            this.dateFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateFin.Name = "dateFin";
            this.dateFin.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFin.Properties.Appearance.Options.UseFont = true;
            this.dateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Size = new System.Drawing.Size(509, 22);
            this.dateFin.StyleController = this.layoutControl2;
            this.dateFin.TabIndex = 5;
            this.dateFin.EditValueChanged += new System.EventHandler(this.dateFin_EditValueChanged_1);
            // 
            // dateDebut
            // 
            this.dateDebut.EditValue = null;
            this.dateDebut.Location = new System.Drawing.Point(73, 38);
            this.dateDebut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateDebut.Name = "dateDebut";
            this.dateDebut.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDebut.Properties.Appearance.Options.UseFont = true;
            this.dateDebut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDebut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDebut.Size = new System.Drawing.Size(436, 22);
            this.dateDebut.StyleController = this.layoutControl2;
            this.dateDebut.TabIndex = 4;
            this.dateDebut.EditValueChanged += new System.EventHandler(this.dateDebut_EditValueChanged);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup2.Size = new System.Drawing.Size(1095, 541);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.dateDebut;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(501, 26);
            this.layoutControlItem2.Text = "Date début";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(57, 15);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.dateFin;
            this.layoutControlItem3.Location = new System.Drawing.Point(501, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(574, 26);
            this.layoutControlItem3.Text = "Date fin";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(57, 15);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 52);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(501, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.BtnExportExcel;
            this.layoutControlItem4.Location = new System.Drawing.Point(501, 52);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(268, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.BtnExportPDF;
            this.layoutControlItem5.Location = new System.Drawing.Point(769, 52);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(306, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.gridControl1;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(1075, 397);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.label1;
            this.layoutControlItem7.Image = ((System.Drawing.Image)(resources.GetObject("layoutControlItem7.Image")));
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 475);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(1075, 46);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.BtnActualiser;
            this.layoutControlItem8.Location = new System.Drawing.Point(940, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(135, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(940, 26);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(1123, 587);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1103, 567);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmListeDepenseSaison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 587);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmListeDepenseSaison";
            this.Text = "Liste des dépenses de la Saison";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmListeDepenseSaison_FormClosed);
            this.Load += new System.EventHandler(this.FrmListeDepenseSaison_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depenseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDebut.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDebut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit dateDebut;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DateEdit dateFin;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton BtnExportPDF;
        private DevExpress.XtraEditors.SimpleButton BtnExportExcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreation;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colNature;
        private DevExpress.XtraGrid.Columns.GridColumn colMontant;
        private DevExpress.XtraGrid.Columns.GridColumn colCommentaire;
        private DevExpress.XtraGrid.Columns.GridColumn colModePaiement;
        private DevExpress.XtraGrid.Columns.GridColumn colTiers;
        private DevExpress.XtraGrid.Columns.GridColumn Ncheque;
        private DevExpress.XtraGrid.Columns.GridColumn GcBanque;
        private DevExpress.XtraGrid.Columns.GridColumn GcAppearance;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        public System.Windows.Forms.BindingSource depenseBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeAgriculteur;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.SimpleButton BtnActualiser;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}