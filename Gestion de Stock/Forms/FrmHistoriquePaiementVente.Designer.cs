namespace Gestion_de_Stock.Forms
{
    partial class FrmHistoriquePaiementVente
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.historiquePaiementVenteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateEcheance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBnak = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumVente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModeReglement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontantReglement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontantRegle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResteApayer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumCheque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommentaire = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.historiquePaiementVenteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1174, 346);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1150, 322);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1146, 300);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.historiquePaiementVenteBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1122, 276);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // historiquePaiementVenteBindingSource
            // 
            this.historiquePaiementVenteBindingSource.DataSource = typeof(Gestion_de_Stock.Model.HistoriquePaiementVente);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colDateEcheance,
            this.colBnak,
            this.colDateCreation,
            this.colNumVente,
            this.colClient,
            this.colModeReglement,
            this.colMontantReglement,
            this.colMontantRegle,
            this.colResteApayer,
            this.colNumCheque,
            this.colCommentaire});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Entrer un texte pour rechercher...";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colCode
            // 
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.Caption = "Code Client";
            this.colCode.FieldName = "NumClient";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 2;
            // 
            // colDateEcheance
            // 
            this.colDateEcheance.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDateEcheance.AppearanceHeader.Options.UseFont = true;
            this.colDateEcheance.Caption = "Date Echeance";
            this.colDateEcheance.FieldName = "DateEcheance";
            this.colDateEcheance.Name = "colDateEcheance";
            this.colDateEcheance.OptionsColumn.AllowEdit = false;
            this.colDateEcheance.Visible = true;
            this.colDateEcheance.VisibleIndex = 7;
            // 
            // colBnak
            // 
            this.colBnak.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colBnak.AppearanceHeader.Options.UseFont = true;
            this.colBnak.Caption = "Banque";
            this.colBnak.FieldName = "Bank";
            this.colBnak.Name = "colBnak";
            this.colBnak.OptionsColumn.AllowEdit = false;
            this.colBnak.Visible = true;
            this.colBnak.VisibleIndex = 6;
            // 
            // colDateCreation
            // 
            this.colDateCreation.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDateCreation.AppearanceHeader.Options.UseFont = true;
            this.colDateCreation.Caption = "Date Vente";
            this.colDateCreation.FieldName = "DateCreation";
            this.colDateCreation.Name = "colDateCreation";
            this.colDateCreation.OptionsColumn.AllowEdit = false;
            this.colDateCreation.OptionsFilter.AllowAutoFilter = false;
            this.colDateCreation.Visible = true;
            this.colDateCreation.VisibleIndex = 1;
            // 
            // colNumVente
            // 
            this.colNumVente.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumVente.AppearanceHeader.Options.UseFont = true;
            this.colNumVente.Caption = "N° Vente";
            this.colNumVente.FieldName = "NumVente";
            this.colNumVente.Name = "colNumVente";
            this.colNumVente.OptionsColumn.AllowEdit = false;
            this.colNumVente.OptionsFilter.AllowAutoFilter = false;
            this.colNumVente.Visible = true;
            this.colNumVente.VisibleIndex = 0;
            // 
            // colClient
            // 
            this.colClient.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colClient.AppearanceHeader.Options.UseFont = true;
            this.colClient.Caption = "Client";
            this.colClient.FieldName = "IntituleClient";
            this.colClient.Name = "colClient";
            this.colClient.OptionsColumn.AllowEdit = false;
            this.colClient.OptionsFilter.AllowAutoFilter = false;
            this.colClient.Visible = true;
            this.colClient.VisibleIndex = 3;
            // 
            // colModeReglement
            // 
            this.colModeReglement.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colModeReglement.AppearanceHeader.Options.UseFont = true;
            this.colModeReglement.Caption = "Mode Paiement";
            this.colModeReglement.FieldName = "ModeReglement";
            this.colModeReglement.Name = "colModeReglement";
            this.colModeReglement.OptionsColumn.AllowEdit = false;
            this.colModeReglement.OptionsFilter.AllowAutoFilter = false;
            this.colModeReglement.Visible = true;
            this.colModeReglement.VisibleIndex = 4;
            // 
            // colMontantReglement
            // 
            this.colMontantReglement.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMontantReglement.AppearanceHeader.Options.UseFont = true;
            this.colMontantReglement.Caption = "Total Commande";
            this.colMontantReglement.DisplayFormat.FormatString = "n3";
            this.colMontantReglement.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontantReglement.FieldName = "MontantReglement";
            this.colMontantReglement.Name = "colMontantReglement";
            this.colMontantReglement.OptionsColumn.AllowEdit = false;
            this.colMontantReglement.OptionsFilter.AllowAutoFilter = false;
            this.colMontantReglement.Visible = true;
            this.colMontantReglement.VisibleIndex = 8;
            // 
            // colMontantRegle
            // 
            this.colMontantRegle.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMontantRegle.AppearanceHeader.Options.UseFont = true;
            this.colMontantRegle.Caption = "Mt Règlement";
            this.colMontantRegle.DisplayFormat.FormatString = "n3";
            this.colMontantRegle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontantRegle.FieldName = "MontantRegle";
            this.colMontantRegle.Name = "colMontantRegle";
            this.colMontantRegle.OptionsColumn.AllowEdit = false;
            this.colMontantRegle.OptionsFilter.AllowAutoFilter = false;
            this.colMontantRegle.Visible = true;
            this.colMontantRegle.VisibleIndex = 9;
            // 
            // colResteApayer
            // 
            this.colResteApayer.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colResteApayer.AppearanceHeader.Options.UseFont = true;
            this.colResteApayer.Caption = "Solde";
            this.colResteApayer.DisplayFormat.FormatString = "n3";
            this.colResteApayer.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colResteApayer.FieldName = "ResteApayer";
            this.colResteApayer.Name = "colResteApayer";
            this.colResteApayer.OptionsColumn.AllowEdit = false;
            this.colResteApayer.OptionsFilter.AllowAutoFilter = false;
            this.colResteApayer.Visible = true;
            this.colResteApayer.VisibleIndex = 10;
            // 
            // colNumCheque
            // 
            this.colNumCheque.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumCheque.AppearanceHeader.Options.UseFont = true;
            this.colNumCheque.Caption = "Numéro Chèque";
            this.colNumCheque.FieldName = "NumCheque";
            this.colNumCheque.Name = "colNumCheque";
            this.colNumCheque.OptionsColumn.AllowEdit = false;
            this.colNumCheque.OptionsFilter.AllowAutoFilter = false;
            this.colNumCheque.Visible = true;
            this.colNumCheque.VisibleIndex = 5;
            // 
            // colCommentaire
            // 
            this.colCommentaire.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCommentaire.AppearanceHeader.Options.UseFont = true;
            this.colCommentaire.Caption = "Commentaire";
            this.colCommentaire.FieldName = "Commentaire";
            this.colCommentaire.MinWidth = 120;
            this.colCommentaire.Name = "colCommentaire";
            this.colCommentaire.OptionsColumn.AllowEdit = false;
            this.colCommentaire.Visible = true;
            this.colCommentaire.VisibleIndex = 11;
            this.colCommentaire.Width = 120;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup2.Size = new System.Drawing.Size(1146, 300);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1126, 280);
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
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1174, 346);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1154, 326);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmHistoriquePaiementVente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 346);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmHistoriquePaiementVente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historique Paiement Vente";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmHistoriquePaiementVente_FormClosed);
            this.Load += new System.EventHandler(this.FrmHistoriquePaiementVente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historiquePaiementVenteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreation;
        private DevExpress.XtraGrid.Columns.GridColumn colNumVente;
        private DevExpress.XtraGrid.Columns.GridColumn colClient;
        private DevExpress.XtraGrid.Columns.GridColumn colModeReglement;
        private DevExpress.XtraGrid.Columns.GridColumn colMontantReglement;
        private DevExpress.XtraGrid.Columns.GridColumn colMontantRegle;
        private DevExpress.XtraGrid.Columns.GridColumn colResteApayer;
        private DevExpress.XtraGrid.Columns.GridColumn colNumCheque;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        public System.Windows.Forms.BindingSource historiquePaiementVenteBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDateEcheance;
        private DevExpress.XtraGrid.Columns.GridColumn colBnak;
        private DevExpress.XtraGrid.Columns.GridColumn colCommentaire;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
    }
}