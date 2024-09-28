namespace Gestion_de_Stock.Forms
{
    partial class Coffre
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
            this.colBank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateEcheance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumVente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontantRegle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumCheque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeClient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.label1 = new System.Windows.Forms.Label();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(801, 461);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(777, 437);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.label1);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(773, 415);
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
            this.gridControl1.Size = new System.Drawing.Size(749, 367);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // historiquePaiementVenteBindingSource
            // 
            this.historiquePaiementVenteBindingSource.DataSource = typeof(Gestion_de_Stock.Model.HistoriquePaiementVente);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBank,
            this.colDateEcheance,
            this.Date,
            this.colNumVente,
            this.colClient,
            this.colMontantRegle,
            this.colNumCheque,
            this.colCodeClient});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Entrer un texte pour rechercher...";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colBank
            // 
            this.colBank.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colBank.AppearanceCell.Options.UseFont = true;
            this.colBank.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colBank.AppearanceHeader.Options.UseFont = true;
            this.colBank.Caption = "Banque";
            this.colBank.FieldName = "Bank";
            this.colBank.Name = "colBank";
            this.colBank.OptionsColumn.AllowEdit = false;
            this.colBank.Visible = true;
            this.colBank.VisibleIndex = 5;
            // 
            // colDateEcheance
            // 
            this.colDateEcheance.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDateEcheance.AppearanceCell.Options.UseFont = true;
            this.colDateEcheance.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDateEcheance.AppearanceHeader.Options.UseFont = true;
            this.colDateEcheance.Caption = "Date Echeance";
            this.colDateEcheance.FieldName = "DateEcheance";
            this.colDateEcheance.Name = "colDateEcheance";
            this.colDateEcheance.OptionsColumn.AllowEdit = false;
            this.colDateEcheance.Visible = true;
            this.colDateEcheance.VisibleIndex = 6;
            // 
            // Date
            // 
            this.Date.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.AppearanceCell.Options.UseFont = true;
            this.Date.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.AppearanceHeader.Options.UseFont = true;
            this.Date.Caption = "Date";
            this.Date.FieldName = "DateCreation";
            this.Date.Name = "Date";
            this.Date.OptionsColumn.AllowEdit = false;
            this.Date.Visible = true;
            this.Date.VisibleIndex = 0;
            // 
            // colNumVente
            // 
            this.colNumVente.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumVente.AppearanceCell.Options.UseFont = true;
            this.colNumVente.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumVente.AppearanceHeader.Options.UseFont = true;
            this.colNumVente.Caption = "N° Vente";
            this.colNumVente.FieldName = "NumVente";
            this.colNumVente.Name = "colNumVente";
            this.colNumVente.OptionsColumn.AllowEdit = false;
            this.colNumVente.Visible = true;
            this.colNumVente.VisibleIndex = 1;
            // 
            // colClient
            // 
            this.colClient.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colClient.AppearanceCell.Options.UseFont = true;
            this.colClient.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colClient.AppearanceHeader.Options.UseFont = true;
            this.colClient.Caption = "Cient";
            this.colClient.FieldName = "IntituleClient";
            this.colClient.Name = "colClient";
            this.colClient.OptionsColumn.AllowEdit = false;
            this.colClient.Visible = true;
            this.colClient.VisibleIndex = 3;
            // 
            // colMontantRegle
            // 
            this.colMontantRegle.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMontantRegle.AppearanceCell.Options.UseFont = true;
            this.colMontantRegle.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMontantRegle.AppearanceHeader.Options.UseFont = true;
            this.colMontantRegle.Caption = "Montant";
            this.colMontantRegle.DisplayFormat.FormatString = "n3";
            this.colMontantRegle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontantRegle.FieldName = "MontantRegle";
            this.colMontantRegle.Name = "colMontantRegle";
            this.colMontantRegle.OptionsColumn.AllowEdit = false;
            this.colMontantRegle.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontantRegle", "={0:n3}")});
            this.colMontantRegle.Visible = true;
            this.colMontantRegle.VisibleIndex = 7;
            // 
            // colNumCheque
            // 
            this.colNumCheque.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumCheque.AppearanceCell.Options.UseFont = true;
            this.colNumCheque.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNumCheque.AppearanceHeader.Options.UseFont = true;
            this.colNumCheque.Caption = "N° Chèque";
            this.colNumCheque.FieldName = "NumCheque";
            this.colNumCheque.Name = "colNumCheque";
            this.colNumCheque.OptionsColumn.AllowEdit = false;
            this.colNumCheque.Visible = true;
            this.colNumCheque.VisibleIndex = 4;
            // 
            // colCodeClient
            // 
            this.colCodeClient.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCodeClient.AppearanceCell.Options.UseFont = true;
            this.colCodeClient.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCodeClient.AppearanceHeader.Options.UseFont = true;
            this.colCodeClient.Caption = "Code Client";
            this.colCodeClient.FieldName = "NumClient";
            this.colCodeClient.Name = "colCodeClient";
            this.colCodeClient.OptionsColumn.AllowEdit = false;
            this.colCodeClient.Visible = true;
            this.colCodeClient.VisibleIndex = 2;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup2.Size = new System.Drawing.Size(773, 415);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(753, 371);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(801, 461);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(781, 441);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // label1
            // 
            this.label1.Image = global::Gestion_de_Stock.Properties.Resources.EC;
            this.label1.Location = new System.Drawing.Point(12, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(749, 20);
            this.label1.TabIndex = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.label1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 371);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(753, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // Coffre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 461);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Coffre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liste des Chèques Reçus";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Coffre_FormClosed);
            this.Load += new System.EventHandler(this.Coffre_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        public System.Windows.Forms.BindingSource historiquePaiementVenteBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Date;
        private DevExpress.XtraGrid.Columns.GridColumn colNumVente;
        private DevExpress.XtraGrid.Columns.GridColumn colClient;
        private DevExpress.XtraGrid.Columns.GridColumn colMontantRegle;
        private DevExpress.XtraGrid.Columns.GridColumn colNumCheque;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colBank;
        private DevExpress.XtraGrid.Columns.GridColumn colDateEcheance;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeClient;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}