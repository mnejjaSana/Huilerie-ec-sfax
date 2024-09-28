namespace Gestion_de_Stock.Forms
{
    partial class FrmListeProduction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListeProduction));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnActualiser = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExportPDF = new DevExpress.XtraEditors.SimpleButton();
            this.BtnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.dateFin = new DevExpress.XtraEditors.DateEdit();
            this.dateDébut = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.productionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChaine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAchat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQteHuile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatutProd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryBtnDetail = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.coldatefin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPoid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgriculteur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeAchat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreSacs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumBon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasraf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQteOlive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRendement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRendementRéel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDébut.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDébut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBtnDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(1174, 434);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1150, 410);
            this.groupControl1.TabIndex = 0;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.label1);
            this.layoutControl2.Controls.Add(this.BtnActualiser);
            this.layoutControl2.Controls.Add(this.BtnExportPDF);
            this.layoutControl2.Controls.Add(this.BtnExportExcel);
            this.layoutControl2.Controls.Add(this.dateFin);
            this.layoutControl2.Controls.Add(this.dateDébut);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1146, 388);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // label1
            // 
            this.label1.Image = global::Gestion_de_Stock.Properties.Resources.EC;
            this.label1.Location = new System.Drawing.Point(12, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1122, 20);
            this.label1.TabIndex = 15;
            // 
            // BtnActualiser
            // 
            this.BtnActualiser.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualiser.Appearance.Options.UseFont = true;
            this.BtnActualiser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnActualiser.ImageOptions.Image")));
            this.BtnActualiser.Location = new System.Drawing.Point(1015, 12);
            this.BtnActualiser.Name = "BtnActualiser";
            this.BtnActualiser.Size = new System.Drawing.Size(119, 22);
            this.BtnActualiser.StyleController = this.layoutControl2;
            this.BtnActualiser.TabIndex = 14;
            this.BtnActualiser.Text = "Actualiser";
            this.BtnActualiser.Click += new System.EventHandler(this.BtnActualiser_Click);
            // 
            // BtnExportPDF
            // 
            this.BtnExportPDF.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportPDF.Appearance.Options.UseFont = true;
            this.BtnExportPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportPDF.ImageOptions.Image")));
            this.BtnExportPDF.Location = new System.Drawing.Point(796, 62);
            this.BtnExportPDF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExportPDF.Name = "BtnExportPDF";
            this.BtnExportPDF.Size = new System.Drawing.Size(338, 22);
            this.BtnExportPDF.StyleController = this.layoutControl2;
            this.BtnExportPDF.TabIndex = 13;
            this.BtnExportPDF.Text = "Export PDF";
            this.BtnExportPDF.Click += new System.EventHandler(this.BtnExportPDF_Click);
            // 
            // BtnExportExcel
            // 
            this.BtnExportExcel.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportExcel.Appearance.Options.UseFont = true;
            this.BtnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportExcel.ImageOptions.Image")));
            this.BtnExportExcel.Location = new System.Drawing.Point(464, 62);
            this.BtnExportExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExportExcel.Name = "BtnExportExcel";
            this.BtnExportExcel.Size = new System.Drawing.Size(328, 22);
            this.BtnExportExcel.StyleController = this.layoutControl2;
            this.BtnExportExcel.TabIndex = 12;
            this.BtnExportExcel.Text = "Export Excel";
            this.BtnExportExcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
            // 
            // dateFin
            // 
            this.dateFin.EditValue = null;
            this.dateFin.Location = new System.Drawing.Point(528, 38);
            this.dateFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateFin.Name = "dateFin";
            this.dateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Size = new System.Drawing.Size(606, 20);
            this.dateFin.StyleController = this.layoutControl2;
            this.dateFin.TabIndex = 10;
            this.dateFin.EditValueChanged += new System.EventHandler(this.dateFin_EditValueChanged);
            // 
            // dateDébut
            // 
            this.dateDébut.EditValue = null;
            this.dateDébut.Location = new System.Drawing.Point(76, 38);
            this.dateDébut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateDébut.Name = "dateDébut";
            this.dateDébut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDébut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDébut.Size = new System.Drawing.Size(384, 20);
            this.dateDébut.StyleController = this.layoutControl2;
            this.dateDébut.TabIndex = 9;
            this.dateDébut.EditValueChanged += new System.EventHandler(this.dateDébut_EditValueChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.productionBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(12, 88);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryBtnDetail});
            this.gridControl1.Size = new System.Drawing.Size(1122, 264);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // productionBindingSource
            // 
            this.productionBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Production);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colNumero,
            this.colDate,
            this.colChaine,
            this.colAchat,
            this.colQteHuile,
            this.colStatutProd,
            this.colDetail,
            this.coldatefin,
            this.colPoid,
            this.colAgriculteur,
            this.colTypeAchat,
            this.colNombreSacs,
            this.colNumBon,
            this.colMasraf,
            this.colQteOlive,
            this.colRendement,
            this.colRendementRéel});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Entrer un texte pour rechercher...";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "Date Saisie";
            this.gridColumn1.FieldName = "DateOperation";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // colNumero
            // 
            this.colNumero.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumero.AppearanceHeader.Options.UseFont = true;
            this.colNumero.Caption = "N° Prod";
            this.colNumero.DisplayFormat.FormatString = "f0";
            this.colNumero.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNumero.FieldName = "NumeroProduction";
            this.colNumero.Name = "colNumero";
            this.colNumero.OptionsColumn.AllowEdit = false;
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 0;
            // 
            // colDate
            // 
            this.colDate.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDate.AppearanceHeader.Options.UseFont = true;
            this.colDate.Caption = "Début Prod";
            this.colDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDate.FieldName = "DateProd";
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowEdit = false;
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 4;
            // 
            // colChaine
            // 
            this.colChaine.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colChaine.AppearanceHeader.Options.UseFont = true;
            this.colChaine.Caption = "Chaîne Prod";
            this.colChaine.FieldName = "Machine";
            this.colChaine.Name = "colChaine";
            this.colChaine.OptionsColumn.AllowEdit = false;
            this.colChaine.Visible = true;
            this.colChaine.VisibleIndex = 3;
            // 
            // colAchat
            // 
            this.colAchat.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAchat.AppearanceHeader.Options.UseFont = true;
            this.colAchat.Caption = "N° Achat";
            this.colAchat.FieldName = "Achat.Numero";
            this.colAchat.Name = "colAchat";
            this.colAchat.OptionsColumn.AllowEdit = false;
            this.colAchat.Visible = true;
            this.colAchat.VisibleIndex = 6;
            // 
            // colQteHuile
            // 
            this.colQteHuile.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colQteHuile.AppearanceHeader.Options.UseFont = true;
            this.colQteHuile.Caption = "Qté Huile Produite";
            this.colQteHuile.DisplayFormat.FormatString = "f0";
            this.colQteHuile.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQteHuile.FieldName = "QuantiteHuile";
            this.colQteHuile.Name = "colQteHuile";
            this.colQteHuile.OptionsColumn.AllowEdit = false;
            this.colQteHuile.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QuantiteHuile", "={0:f0}")});
            this.colQteHuile.Visible = true;
            this.colQteHuile.VisibleIndex = 11;
            // 
            // colStatutProd
            // 
            this.colStatutProd.FieldName = "StatutProd";
            this.colStatutProd.MaxWidth = 20;
            this.colStatutProd.Name = "colStatutProd";
            this.colStatutProd.OptionsColumn.AllowEdit = false;
            this.colStatutProd.Visible = true;
            this.colStatutProd.VisibleIndex = 12;
            this.colStatutProd.Width = 20;
            // 
            // colDetail
            // 
            this.colDetail.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDetail.AppearanceHeader.Options.UseFont = true;
            this.colDetail.Caption = "Détails Emplacement";
            this.colDetail.ColumnEdit = this.repositoryBtnDetail;
            this.colDetail.MaxWidth = 20;
            this.colDetail.Name = "colDetail";
            this.colDetail.Visible = true;
            this.colDetail.VisibleIndex = 13;
            this.colDetail.Width = 20;
            // 
            // repositoryBtnDetail
            // 
            this.repositoryBtnDetail.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repositoryBtnDetail.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions1, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryBtnDetail.Name = "repositoryBtnDetail";
            this.repositoryBtnDetail.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryBtnDetail.Click += new System.EventHandler(this.repositoryBtnDetail_Click);
            // 
            // coldatefin
            // 
            this.coldatefin.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coldatefin.AppearanceHeader.Options.UseFont = true;
            this.coldatefin.Caption = "Fin Prod";
            this.coldatefin.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.coldatefin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coldatefin.FieldName = "DateFinProd";
            this.coldatefin.Name = "coldatefin";
            this.coldatefin.OptionsColumn.AllowEdit = false;
            this.coldatefin.Visible = true;
            this.coldatefin.VisibleIndex = 5;
            // 
            // colPoid
            // 
            this.colPoid.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPoid.AppearanceHeader.Options.UseFont = true;
            this.colPoid.Caption = "Qté Achetée";
            this.colPoid.FieldName = "Achat.Poids";
            this.colPoid.Name = "colPoid";
            this.colPoid.OptionsColumn.AllowEdit = false;
            this.colPoid.Visible = true;
            this.colPoid.VisibleIndex = 10;
            // 
            // colAgriculteur
            // 
            this.colAgriculteur.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAgriculteur.AppearanceHeader.Options.UseFont = true;
            this.colAgriculteur.Caption = "Agriculteur";
            this.colAgriculteur.FieldName = "Achat.Founisseur.FullName";
            this.colAgriculteur.Name = "colAgriculteur";
            this.colAgriculteur.OptionsColumn.AllowEdit = false;
            this.colAgriculteur.Visible = true;
            this.colAgriculteur.VisibleIndex = 8;
            // 
            // colTypeAchat
            // 
            this.colTypeAchat.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTypeAchat.AppearanceHeader.Options.UseFont = true;
            this.colTypeAchat.Caption = "Type Achat";
            this.colTypeAchat.FieldName = "Achat.TypeAchat";
            this.colTypeAchat.Name = "colTypeAchat";
            this.colTypeAchat.OptionsColumn.AllowEdit = false;
            this.colTypeAchat.Visible = true;
            this.colTypeAchat.VisibleIndex = 7;
            // 
            // colNombreSacs
            // 
            this.colNombreSacs.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNombreSacs.AppearanceHeader.Options.UseFont = true;
            this.colNombreSacs.Caption = "Nb Sacs";
            this.colNombreSacs.FieldName = "Achat.NbSacs";
            this.colNombreSacs.MaxWidth = 40;
            this.colNombreSacs.MinWidth = 40;
            this.colNombreSacs.Name = "colNombreSacs";
            this.colNombreSacs.OptionsColumn.AllowEdit = false;
            this.colNombreSacs.Visible = true;
            this.colNombreSacs.VisibleIndex = 9;
            this.colNombreSacs.Width = 40;
            // 
            // colNumBon
            // 
            this.colNumBon.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumBon.AppearanceHeader.Options.UseFont = true;
            this.colNumBon.Caption = "Num Bon";
            this.colNumBon.FieldName = "NuméroBon";
            this.colNumBon.Name = "colNumBon";
            this.colNumBon.OptionsColumn.AllowEdit = false;
            this.colNumBon.Visible = true;
            this.colNumBon.VisibleIndex = 2;
            // 
            // colMasraf
            // 
            this.colMasraf.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMasraf.AppearanceHeader.Options.UseFont = true;
            this.colMasraf.Caption = "Masraf";
            this.colMasraf.FieldName = "Emplacement.Intitule";
            this.colMasraf.MaxWidth = 60;
            this.colMasraf.MinWidth = 60;
            this.colMasraf.Name = "colMasraf";
            this.colMasraf.OptionsColumn.AllowEdit = false;
            this.colMasraf.Visible = true;
            this.colMasraf.VisibleIndex = 14;
            this.colMasraf.Width = 60;
            // 
            // colQteOlive
            // 
            this.colQteOlive.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colQteOlive.AppearanceHeader.Options.UseFont = true;
            this.colQteOlive.Caption = "Qté Olive";
            this.colQteOlive.FieldName = "QuantiteOlive";
            this.colQteOlive.MaxWidth = 60;
            this.colQteOlive.MinWidth = 60;
            this.colQteOlive.Name = "colQteOlive";
            this.colQteOlive.OptionsColumn.AllowEdit = false;
            this.colQteOlive.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QuantiteOlive", "={0:0.##}")});
            this.colQteOlive.Visible = true;
            this.colQteOlive.VisibleIndex = 15;
            this.colQteOlive.Width = 60;
            // 
            // colRendement
            // 
            this.colRendement.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colRendement.AppearanceHeader.Options.UseFont = true;
            this.colRendement.Caption = "Rendement Moyen Prévu";
            this.colRendement.DisplayFormat.FormatString = "n3";
            this.colRendement.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRendement.FieldName = "RendementMoyenPrevu";
            this.colRendement.MaxWidth = 80;
            this.colRendement.MinWidth = 80;
            this.colRendement.Name = "colRendement";
            this.colRendement.OptionsColumn.AllowEdit = false;
            this.colRendement.Visible = true;
            this.colRendement.VisibleIndex = 16;
            this.colRendement.Width = 80;
            // 
            // colRendementRéel
            // 
            this.colRendementRéel.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colRendementRéel.AppearanceHeader.Options.UseFont = true;
            this.colRendementRéel.Caption = "Rendement Réel";
            this.colRendementRéel.DisplayFormat.FormatString = "n3";
            this.colRendementRéel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRendementRéel.FieldName = "RendementReel";
            this.colRendementRéel.Name = "colRendementRéel";
            this.colRendementRéel.OptionsColumn.AllowEdit = false;
            this.colRendementRéel.Visible = true;
            this.colRendementRéel.VisibleIndex = 17;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.emptySpaceItem2,
            this.layoutControlItem8});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup2.Size = new System.Drawing.Size(1146, 388);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1126, 268);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.dateDébut;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(452, 24);
            this.layoutControlItem3.Text = "Date Début";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 15);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.dateFin;
            this.layoutControlItem4.Location = new System.Drawing.Point(452, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(674, 24);
            this.layoutControlItem4.Text = "Date Fin";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 15);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 50);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(452, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.BtnExportExcel;
            this.layoutControlItem6.Location = new System.Drawing.Point(452, 50);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(332, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.BtnExportPDF;
            this.layoutControlItem5.Location = new System.Drawing.Point(784, 50);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(342, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.BtnActualiser;
            this.layoutControlItem7.Location = new System.Drawing.Point(1003, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(123, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(1003, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.label1;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 344);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(1126, 24);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(1174, 434);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1154, 414);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmListeProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 434);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmListeProduction";
            this.Text = "Liste des Productions";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmListeProduction_FormClosed);
            this.Load += new System.EventHandler(this.FrmListeProduction_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmListeProduction_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDébut.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDébut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryBtnDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        public System.Windows.Forms.BindingSource productionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colChaine;
        private DevExpress.XtraGrid.Columns.GridColumn colAchat;
        private DevExpress.XtraGrid.Columns.GridColumn colQteHuile;
        private DevExpress.XtraGrid.Columns.GridColumn colStatutProd;
        private DevExpress.XtraEditors.SimpleButton BtnExportExcel;
        private DevExpress.XtraEditors.DateEdit dateFin;
        private DevExpress.XtraEditors.DateEdit dateDébut;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryBtnDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colDetail;
        private DevExpress.XtraGrid.Columns.GridColumn coldatefin;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraGrid.Columns.GridColumn colPoid;
        private DevExpress.XtraGrid.Columns.GridColumn colAgriculteur;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeAchat;
        private DevExpress.XtraEditors.SimpleButton BtnExportPDF;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreSacs;
        private DevExpress.XtraGrid.Columns.GridColumn colNumBon;
        private DevExpress.XtraEditors.SimpleButton BtnActualiser;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colMasraf;
        private DevExpress.XtraGrid.Columns.GridColumn colQteOlive;
        private DevExpress.XtraGrid.Columns.GridColumn colRendement;
        private DevExpress.XtraGrid.Columns.GridColumn colRendementRéel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}