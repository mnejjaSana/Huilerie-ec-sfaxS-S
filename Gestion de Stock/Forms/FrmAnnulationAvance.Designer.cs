namespace Gestion_de_Stock.Forms
{
    partial class FrmAnnulationAvance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnnulationAvance));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.searchLookUpAvance = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.achatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BtnValider = new DevExpress.XtraEditors.SimpleButton();
            this.TxtMontant = new DevExpress.XtraEditors.TextEdit();
            this.searchLookUpAgr = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.agriculteurBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpAvance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.achatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMontant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpAgr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agriculteurBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(532, 202);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(508, 178);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.searchLookUpAvance);
            this.layoutControl2.Controls.Add(this.BtnValider);
            this.layoutControl2.Controls.Add(this.TxtMontant);
            this.layoutControl2.Controls.Add(this.searchLookUpAgr);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(504, 156);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // searchLookUpAvance
            // 
            this.searchLookUpAvance.EditValue = "";
            this.searchLookUpAvance.Location = new System.Drawing.Point(91, 46);
            this.searchLookUpAvance.Name = "searchLookUpAvance";
            this.searchLookUpAvance.Properties.AutoHeight = false;
            this.searchLookUpAvance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpAvance.Properties.DataSource = this.achatBindingSource;
            this.searchLookUpAvance.Properties.DisplayMember = "Numero";
            this.searchLookUpAvance.Properties.ValueMember = "Id";
            this.searchLookUpAvance.Properties.View = this.gridView2;
            this.searchLookUpAvance.Size = new System.Drawing.Size(401, 32);
            this.searchLookUpAvance.StyleController = this.layoutControl2;
            this.searchLookUpAvance.TabIndex = 9;
            this.searchLookUpAvance.EditValueChanged += new System.EventHandler(this.searchLookUpAvance_EditValueChanged);
            // 
            // achatBindingSource
            // 
            this.achatBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Achat);
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // BtnValider
            // 
            this.BtnValider.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValider.Appearance.Options.UseFont = true;
            this.BtnValider.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnValider.ImageOptions.Image")));
            this.BtnValider.Location = new System.Drawing.Point(336, 118);
            this.BtnValider.Name = "BtnValider";
            this.BtnValider.Size = new System.Drawing.Size(156, 26);
            this.BtnValider.StyleController = this.layoutControl2;
            this.BtnValider.TabIndex = 6;
            this.BtnValider.Text = "Valider";
            this.BtnValider.Click += new System.EventHandler(this.BtnValider_Click);
            // 
            // TxtMontant
            // 
            this.TxtMontant.Location = new System.Drawing.Point(91, 82);
            this.TxtMontant.Name = "TxtMontant";
            this.TxtMontant.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMontant.Properties.Appearance.Options.UseFont = true;
            this.TxtMontant.Properties.AutoHeight = false;
            this.TxtMontant.Properties.Mask.EditMask = "n3";
            this.TxtMontant.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TxtMontant.Properties.ReadOnly = true;
            this.TxtMontant.Size = new System.Drawing.Size(401, 32);
            this.TxtMontant.StyleController = this.layoutControl2;
            this.TxtMontant.TabIndex = 5;
            // 
            // searchLookUpAgr
            // 
            this.searchLookUpAgr.EditValue = "";
            this.searchLookUpAgr.Location = new System.Drawing.Point(91, 12);
            this.searchLookUpAgr.Name = "searchLookUpAgr";
            this.searchLookUpAgr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.searchLookUpAgr.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLookUpAgr.Properties.Appearance.Options.UseFont = true;
            this.searchLookUpAgr.Properties.AutoHeight = false;
            this.searchLookUpAgr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpAgr.Properties.DataSource = this.agriculteurBindingSource;
            this.searchLookUpAgr.Properties.DisplayMember = "FullName";
            this.searchLookUpAgr.Properties.ValueMember = "Id";
            this.searchLookUpAgr.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpAgr.Size = new System.Drawing.Size(401, 30);
            this.searchLookUpAgr.StyleController = this.layoutControl2;
            this.searchLookUpAgr.TabIndex = 4;
            this.searchLookUpAgr.EditValueChanged += new System.EventHandler(this.searchLookUpAgr_EditValueChanged);
            // 
            // agriculteurBindingSource
            // 
            this.agriculteurBindingSource.DataSource = typeof(Gestion_de_Stock.Model.Agriculteur);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem2,
            this.layoutControlItem7});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(504, 156);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.searchLookUpAgr;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(484, 36);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(116, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(484, 34);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Agriculteur";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(76, 19);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.TxtMontant;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 70);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(484, 36);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(116, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(484, 36);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Montant";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(76, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.BtnValider;
            this.layoutControlItem4.Location = new System.Drawing.Point(324, 106);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(160, 30);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 106);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(324, 30);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.Control = this.searchLookUpAvance;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(484, 36);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(133, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(484, 36);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "Avance";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(76, 19);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(532, 202);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(512, 182);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmAnnulationAvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 202);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAnnulationAvance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Annulation Avance";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAnnulationAvance_FormClosed);
            this.Load += new System.EventHandler(this.FrmAnnulationAvance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpAvance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.achatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMontant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpAgr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agriculteurBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.SimpleButton BtnValider;
        private DevExpress.XtraEditors.TextEdit TxtMontant;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpAgr;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        public System.Windows.Forms.BindingSource agriculteurBindingSource;
        public System.Windows.Forms.BindingSource achatBindingSource;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpAvance;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}