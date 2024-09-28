namespace Gestion_de_Stock.Forms
{
    partial class FrmReglementsalaire
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReglementsalaire));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.salarierBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntitule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontantJournalier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombredeJour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontantTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontantReglé = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontantRestReglé = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridAjouterReglement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemAjouterReglement = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colEtatSalarie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistoriquePaiement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryHistoriquePaiement = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salarierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemAjouterReglement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryHistoriquePaiement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
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
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1096, 390);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(16, 16);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1064, 358);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 25);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1060, 331);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.salarierBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(16, 16);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemAjouterReglement,
            this.repositoryHistoriquePaiement});
            this.gridControl1.Size = new System.Drawing.Size(1028, 299);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // salarierBindingSource
            // 
            this.salarierBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Salarier);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colIntitule,
            this.colMontantJournalier,
            this.colNombredeJour,
            this.colMontantTotal,
            this.colMontantReglé,
            this.colMontantRestReglé,
            this.GridAjouterReglement,
            this.colEtatSalarie,
            this.colHistoriquePaiement});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Entrer un texte pour rechercher...";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // colId
            // 
            this.colId.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colId.AppearanceHeader.Options.UseFont = true;
            this.colId.Caption = "Numéro";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 86;
            // 
            // colIntitule
            // 
            this.colIntitule.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIntitule.AppearanceHeader.Options.UseFont = true;
            this.colIntitule.Caption = "Salarié";
            this.colIntitule.FieldName = "Intitule";
            this.colIntitule.Name = "colIntitule";
            this.colIntitule.OptionsColumn.AllowEdit = false;
            this.colIntitule.Visible = true;
            this.colIntitule.VisibleIndex = 1;
            this.colIntitule.Width = 86;
            // 
            // colMontantJournalier
            // 
            this.colMontantJournalier.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMontantJournalier.AppearanceHeader.Options.UseFont = true;
            this.colMontantJournalier.DisplayFormat.FormatString = "n3";
            this.colMontantJournalier.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontantJournalier.FieldName = "MontantJournalier";
            this.colMontantJournalier.Name = "colMontantJournalier";
            this.colMontantJournalier.OptionsColumn.AllowEdit = false;
            this.colMontantJournalier.Visible = true;
            this.colMontantJournalier.VisibleIndex = 2;
            this.colMontantJournalier.Width = 86;
            // 
            // colNombredeJour
            // 
            this.colNombredeJour.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNombredeJour.AppearanceHeader.Options.UseFont = true;
            this.colNombredeJour.Caption = "Nb Jours Travaillés";
            this.colNombredeJour.DisplayFormat.FormatString = "f0";
            this.colNombredeJour.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNombredeJour.FieldName = "NombredeJour";
            this.colNombredeJour.Name = "colNombredeJour";
            this.colNombredeJour.OptionsColumn.AllowEdit = false;
            this.colNombredeJour.Visible = true;
            this.colNombredeJour.VisibleIndex = 3;
            this.colNombredeJour.Width = 86;
            // 
            // colMontantTotal
            // 
            this.colMontantTotal.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMontantTotal.AppearanceHeader.Options.UseFont = true;
            this.colMontantTotal.DisplayFormat.FormatString = "n3";
            this.colMontantTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontantTotal.FieldName = "MontantTotal";
            this.colMontantTotal.Name = "colMontantTotal";
            this.colMontantTotal.OptionsColumn.AllowEdit = false;
            this.colMontantTotal.OptionsColumn.ReadOnly = true;
            this.colMontantTotal.Visible = true;
            this.colMontantTotal.VisibleIndex = 4;
            this.colMontantTotal.Width = 86;
            // 
            // colMontantReglé
            // 
            this.colMontantReglé.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMontantReglé.AppearanceHeader.Options.UseFont = true;
            this.colMontantReglé.Caption = "Avance";
            this.colMontantReglé.DisplayFormat.FormatString = "n3";
            this.colMontantReglé.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontantReglé.FieldName = "MontantReglé";
            this.colMontantReglé.Name = "colMontantReglé";
            this.colMontantReglé.OptionsColumn.AllowEdit = false;
            this.colMontantReglé.Visible = true;
            this.colMontantReglé.VisibleIndex = 5;
            this.colMontantReglé.Width = 86;
            // 
            // colMontantRestReglé
            // 
            this.colMontantRestReglé.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMontantRestReglé.AppearanceHeader.Options.UseFont = true;
            this.colMontantRestReglé.Caption = "Solde";
            this.colMontantRestReglé.DisplayFormat.FormatString = "n3";
            this.colMontantRestReglé.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontantRestReglé.FieldName = "MontantRestReglé";
            this.colMontantRestReglé.Name = "colMontantRestReglé";
            this.colMontantRestReglé.OptionsColumn.AllowEdit = false;
            this.colMontantRestReglé.Visible = true;
            this.colMontantRestReglé.VisibleIndex = 6;
            this.colMontantRestReglé.Width = 86;
            // 
            // GridAjouterReglement
            // 
            this.GridAjouterReglement.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridAjouterReglement.AppearanceHeader.Options.UseFont = true;
            this.GridAjouterReglement.Caption = "Ajouter Règlement";
            this.GridAjouterReglement.ColumnEdit = this.repositoryItemAjouterReglement;
            this.GridAjouterReglement.MaxWidth = 200;
            this.GridAjouterReglement.Name = "GridAjouterReglement";
            this.GridAjouterReglement.OptionsColumn.AllowSize = false;
            this.GridAjouterReglement.Visible = true;
            this.GridAjouterReglement.VisibleIndex = 8;
            this.GridAjouterReglement.Width = 144;
            // 
            // repositoryItemAjouterReglement
            // 
            this.repositoryItemAjouterReglement.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repositoryItemAjouterReglement.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions1, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryItemAjouterReglement.Name = "repositoryItemAjouterReglement";
            this.repositoryItemAjouterReglement.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemAjouterReglement.Click += new System.EventHandler(this.repositoryItemAjouterReglement_Click);
            // 
            // colEtatSalarie
            // 
            this.colEtatSalarie.Caption = "EtatSalarie";
            this.colEtatSalarie.FieldName = "EtatSalarie";
            this.colEtatSalarie.MaxWidth = 20;
            this.colEtatSalarie.Name = "colEtatSalarie";
            this.colEtatSalarie.OptionsColumn.AllowSize = false;
            this.colEtatSalarie.Visible = true;
            this.colEtatSalarie.VisibleIndex = 7;
            this.colEtatSalarie.Width = 20;
            // 
            // colHistoriquePaiement
            // 
            this.colHistoriquePaiement.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHistoriquePaiement.AppearanceHeader.Options.UseFont = true;
            this.colHistoriquePaiement.Caption = "Historique Paiement";
            this.colHistoriquePaiement.ColumnEdit = this.repositoryHistoriquePaiement;
            this.colHistoriquePaiement.Name = "colHistoriquePaiement";
            this.colHistoriquePaiement.Visible = true;
            this.colHistoriquePaiement.VisibleIndex = 9;
            this.colHistoriquePaiement.Width = 144;
            // 
            // repositoryHistoriquePaiement
            // 
            this.repositoryHistoriquePaiement.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.repositoryHistoriquePaiement.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions2, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.repositoryHistoriquePaiement.Name = "repositoryHistoriquePaiement";
            this.repositoryHistoriquePaiement.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryHistoriquePaiement.Click += new System.EventHandler(this.repositoryHistoriquePaiement_Click);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1060, 331);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1034, 305);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1096, 390);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1070, 364);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmReglementsalaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 390);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmReglementsalaire";
            this.Text = "Règlement Salaire";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReglementsalaire_FormClosing);
            this.Load += new System.EventHandler(this.FrmReglementsalaire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salarierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemAjouterReglement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryHistoriquePaiement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colIntitule;
        private DevExpress.XtraGrid.Columns.GridColumn colMontantJournalier;
        private DevExpress.XtraGrid.Columns.GridColumn colNombredeJour;
        private DevExpress.XtraGrid.Columns.GridColumn colMontantTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colMontantReglé;
        private DevExpress.XtraGrid.Columns.GridColumn colMontantRestReglé;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        public System.Windows.Forms.BindingSource salarierBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn GridAjouterReglement;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemAjouterReglement;
        private DevExpress.XtraGrid.Columns.GridColumn colEtatSalarie;
        private DevExpress.XtraGrid.Columns.GridColumn colHistoriquePaiement;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryHistoriquePaiement;
    }
}