﻿namespace Gestion_de_Stock.Forms
{
    partial class FrmReleveeFournisseurs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReleveeFournisseurs));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dateEditDateFin = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dateEditDateDebut = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.BtnImprimer = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.BtnRechercher = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateDebut.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateDebut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(601, 349);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(601, 349);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(577, 325);
            this.groupControl1.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(581, 329);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.BtnRechercher);
            this.layoutControl2.Controls.Add(this.BtnImprimer);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Controls.Add(this.searchLookUpEdit1);
            this.layoutControl2.Controls.Add(this.dateEditDateDebut);
            this.layoutControl2.Controls.Add(this.dateEditDateFin);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(573, 303);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
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
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(573, 303);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // dateEditDateFin
            // 
            this.dateEditDateFin.EditValue = null;
            this.dateEditDateFin.Location = new System.Drawing.Point(385, 12);
            this.dateEditDateFin.Name = "dateEditDateFin";
            this.dateEditDateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDateFin.Size = new System.Drawing.Size(176, 20);
            this.dateEditDateFin.StyleController = this.layoutControl2;
            this.dateEditDateFin.TabIndex = 4;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateEditDateFin;
            this.layoutControlItem2.Location = new System.Drawing.Point(276, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(277, 24);
            this.layoutControlItem2.Text = "Date Fin :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(93, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 257);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(392, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dateEditDateDebut
            // 
            this.dateEditDateDebut.EditValue = null;
            this.dateEditDateDebut.Location = new System.Drawing.Point(109, 12);
            this.dateEditDateDebut.Name = "dateEditDateDebut";
            this.dateEditDateDebut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDateDebut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDateDebut.Size = new System.Drawing.Size(175, 20);
            this.dateEditDateDebut.StyleController = this.layoutControl2;
            this.dateEditDateDebut.TabIndex = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dateEditDateDebut;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(276, 24);
            this.layoutControlItem3.Text = "Date Debut :";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(93, 13);
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.Location = new System.Drawing.Point(109, 36);
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         
            this.searchLookUpEdit1.Size = new System.Drawing.Size(452, 20);
            this.searchLookUpEdit1.StyleController = this.layoutControl2;
            this.searchLookUpEdit1.TabIndex = 6;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.searchLookUpEdit1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(553, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(93, 13);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 60);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(549, 205);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridControl1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(553, 209);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // BtnImprimer
            // 
            this.BtnImprimer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnImprimer.ImageOptions.Image")));
            this.BtnImprimer.Location = new System.Drawing.Point(491, 269);
            this.BtnImprimer.Name = "BtnImprimer";
            this.BtnImprimer.Size = new System.Drawing.Size(70, 22);
            this.BtnImprimer.StyleController = this.layoutControl2;
            this.BtnImprimer.TabIndex = 8;
            this.BtnImprimer.Text = "Imprimer";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.BtnImprimer;
            this.layoutControlItem6.Location = new System.Drawing.Point(479, 257);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(74, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // BtnRechercher
            // 
            this.BtnRechercher.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnRechercher.ImageOptions.Image")));
            this.BtnRechercher.Location = new System.Drawing.Point(404, 269);
            this.BtnRechercher.Name = "BtnRechercher";
            this.BtnRechercher.Size = new System.Drawing.Size(83, 22);
            this.BtnRechercher.StyleController = this.layoutControl2;
            this.BtnRechercher.TabIndex = 9;
            this.BtnRechercher.Text = "Rechercher";
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.BtnRechercher;
            this.layoutControlItem7.Location = new System.Drawing.Point(392, 257);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(87, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // FrmReleveeFournisseurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 349);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmReleveeFournisseurs";
            this.Text = "Relevee Fournisseurs";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmReleveeFournisseurs_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateDebut.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDateDebut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.SimpleButton BtnRechercher;
        private DevExpress.XtraEditors.SimpleButton BtnImprimer;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.DateEdit dateEditDateDebut;
        private DevExpress.XtraEditors.DateEdit dateEditDateFin;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}