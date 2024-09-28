namespace Gestion_de_Stock.Forms
{
    partial class FrmListeReglementFounisseur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListeReglementFounisseur));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnActualiser = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.fournisseurBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRaisonSociale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNbrdesfactures = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPaye = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSommedesFacture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.fournisseurBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
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
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(872, 339);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(848, 315);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.label1);
            this.layoutControl2.Controls.Add(this.BtnActualiser);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(844, 293);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // label1
            // 
            this.label1.Image = global::Gestion_de_Stock.Properties.Resources.EC;
            this.label1.Location = new System.Drawing.Point(12, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(820, 21);
            this.label1.TabIndex = 6;
            // 
            // BtnActualiser
            // 
            this.BtnActualiser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnActualiser.ImageOptions.Image")));
            this.BtnActualiser.Location = new System.Drawing.Point(756, 12);
            this.BtnActualiser.Name = "BtnActualiser";
            this.BtnActualiser.Size = new System.Drawing.Size(76, 22);
            this.BtnActualiser.StyleController = this.layoutControl2;
            this.BtnActualiser.TabIndex = 5;
            this.BtnActualiser.Text = "Actualiser";
            this.BtnActualiser.Click += new System.EventHandler(this.BtnActualiser_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.fournisseurBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(820, 218);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // fournisseurBindingSource
            // 
            this.fournisseurBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Agriculteur);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colRaisonSociale,
            this.colFullName,
            this.colTelResponsable,
            this.colNbrdesfactures,
            this.colTotalPaye,
            this.colTotalCredit,
            this.colSommedesFacture});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            // 
            // colRaisonSociale
            // 
            this.colRaisonSociale.FieldName = "RaisonSociale";
            this.colRaisonSociale.Name = "colRaisonSociale";
            this.colRaisonSociale.OptionsColumn.AllowEdit = false;
            this.colRaisonSociale.Visible = true;
            this.colRaisonSociale.VisibleIndex = 1;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "Responsable";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.AllowEdit = false;
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 2;
            // 
            // colTelResponsable
            // 
            this.colTelResponsable.FieldName = "TelResponsable";
            this.colTelResponsable.Name = "colTelResponsable";
            this.colTelResponsable.OptionsColumn.AllowEdit = false;
            this.colTelResponsable.Visible = true;
            this.colTelResponsable.VisibleIndex = 3;
            // 
            // colNbrdesfactures
            // 
            this.colNbrdesfactures.FieldName = "Nbrdesfactures";
            this.colNbrdesfactures.Name = "colNbrdesfactures";
            this.colNbrdesfactures.OptionsColumn.AllowEdit = false;
            this.colNbrdesfactures.Visible = true;
            this.colNbrdesfactures.VisibleIndex = 4;
            // 
            // colTotalPaye
            // 
            this.colTotalPaye.FieldName = "TotalPaye";
            this.colTotalPaye.Name = "colTotalPaye";
            this.colTotalPaye.OptionsColumn.AllowEdit = false;
            this.colTotalPaye.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPaye", "T.P={0:c3}")});
            this.colTotalPaye.Visible = true;
            this.colTotalPaye.VisibleIndex = 5;
            // 
            // colTotalCredit
            // 
            this.colTotalCredit.FieldName = "TotalCredit";
            this.colTotalCredit.Name = "colTotalCredit";
            this.colTotalCredit.OptionsColumn.AllowEdit = false;
            this.colTotalCredit.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCredit", "T.C={0:c3}")});
            this.colTotalCredit.Visible = true;
            this.colTotalCredit.VisibleIndex = 6;
            // 
            // colSommedesFacture
            // 
            this.colSommedesFacture.Caption = "Somme des Factures TTC";
            this.colSommedesFacture.FieldName = "SommedesFacture";
            this.colSommedesFacture.Name = "colSommedesFacture";
            this.colSommedesFacture.OptionsColumn.AllowEdit = false;
            this.colSommedesFacture.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SommedesFacture", "T.S.F={0:c3}")});
            this.colSommedesFacture.Visible = true;
            this.colSommedesFacture.VisibleIndex = 7;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(844, 293);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(824, 222);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BtnActualiser;
            this.layoutControlItem3.Location = new System.Drawing.Point(744, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(744, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.label1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 248);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(824, 25);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(872, 339);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(852, 319);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmListeReglementFounisseur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 339);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmListeReglementFounisseur";
            this.Text = "Liste Reglements Founisseurs";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmListeReglementFounisseur_FormClosed);
            this.Load += new System.EventHandler(this.FrmListeReglementFounisseur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fournisseurBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
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
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource fournisseurBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRaisonSociale;
        private DevExpress.XtraGrid.Columns.GridColumn colTelResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colNbrdesfactures;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPaye;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCredit;
        private DevExpress.XtraGrid.Columns.GridColumn colSommedesFacture;
        private DevExpress.XtraEditors.SimpleButton BtnActualiser;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}