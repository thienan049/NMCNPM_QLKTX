﻿
namespace NMCNPM_QuanLyKTX.UI_Control
{
    partial class UC_QuanLyPhong
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QuanLyPhong));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions4 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.qlp_HeaderPanel = new DevExpress.XtraEditors.PanelControl();
            this.qlp_ActionBtnPanel2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.qlp_ActionBtnPanel = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.ql_KTX_DS = new NMCNPM_QuanLyKTX.ql_KTXDataSet();
            this.phongBdS = new System.Windows.Forms.BindingSource(this.components);
            this.phongTableAdapter = new NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.PHONGTableAdapter();
            this.tableAdapterManager = new NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.TableAdapterManager();
            this.qlp_GridCtl = new DevExpress.XtraGrid.GridControl();
            this.qlp_GridVw = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTINHTRANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSUCCHUA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKHU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMALOAIPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAQL = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qlp_HeaderPanel)).BeginInit();
            this.qlp_HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ql_KTX_DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phongBdS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlp_GridCtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlp_GridVw)).BeginInit();
            this.SuspendLayout();
            // 
            // qlp_HeaderPanel
            // 
            this.qlp_HeaderPanel.Controls.Add(this.qlp_ActionBtnPanel2);
            this.qlp_HeaderPanel.Controls.Add(this.qlp_ActionBtnPanel);
            this.qlp_HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.qlp_HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.qlp_HeaderPanel.Name = "qlp_HeaderPanel";
            this.qlp_HeaderPanel.Size = new System.Drawing.Size(833, 100);
            this.qlp_HeaderPanel.TabIndex = 3;
            // 
            // qlp_ActionBtnPanel2
            // 
            this.qlp_ActionBtnPanel2.ButtonInterval = 50;
            windowsUIButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions1.Image")));
            this.qlp_ActionBtnPanel2.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Reload", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.qlp_ActionBtnPanel2.Location = new System.Drawing.Point(448, 23);
            this.qlp_ActionBtnPanel2.Name = "qlp_ActionBtnPanel2";
            this.qlp_ActionBtnPanel2.Size = new System.Drawing.Size(361, 72);
            this.qlp_ActionBtnPanel2.TabIndex = 2;
            this.qlp_ActionBtnPanel2.Text = "windowsUIButtonPanel1";
            this.qlp_ActionBtnPanel2.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.qlp_ActionBtnPanel2_ButtonClick);
            // 
            // qlp_ActionBtnPanel
            // 
            this.qlp_ActionBtnPanel.ButtonInterval = 50;
            windowsUIButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions2.Image")));
            windowsUIButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions3.Image")));
            windowsUIButtonImageOptions4.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions4.Image")));
            this.qlp_ActionBtnPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Add", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Delete", true, windowsUIButtonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.qlp_ActionBtnPanel.Location = new System.Drawing.Point(48, 23);
            this.qlp_ActionBtnPanel.Name = "qlp_ActionBtnPanel";
            this.qlp_ActionBtnPanel.Size = new System.Drawing.Size(361, 72);
            this.qlp_ActionBtnPanel.TabIndex = 1;
            this.qlp_ActionBtnPanel.Text = "windowsUIButtonPanel1";
            this.qlp_ActionBtnPanel.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.qlp_ActionBtnPanel_ButtonClick);
            // 
            // ql_KTX_DS
            // 
            this.ql_KTX_DS.DataSetName = "ql_KTXDataSet";
            this.ql_KTX_DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // phongBdS
            // 
            this.phongBdS.DataMember = "PHONG";
            this.phongBdS.DataSource = this.ql_KTX_DS;
            // 
            // phongTableAdapter
            // 
            this.phongTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.HOADONDIENTableAdapter = null;
            this.tableAdapterManager.HOPDONGTableAdapter = null;
            this.tableAdapterManager.LOAIPHONGTableAdapter = null;
            this.tableAdapterManager.PHANQUYENTableAdapter = null;
            this.tableAdapterManager.PHONGTableAdapter = this.phongTableAdapter;
            this.tableAdapterManager.QUANLYTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.TAIKHOANTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VATTUTableAdapter = null;
            this.tableAdapterManager.VT_PHONGTableAdapter = null;
            // 
            // qlp_GridCtl
            // 
            this.qlp_GridCtl.DataSource = this.phongBdS;
            this.qlp_GridCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qlp_GridCtl.Location = new System.Drawing.Point(0, 100);
            this.qlp_GridCtl.MainView = this.qlp_GridVw;
            this.qlp_GridCtl.Name = "qlp_GridCtl";
            this.qlp_GridCtl.Size = new System.Drawing.Size(833, 389);
            this.qlp_GridCtl.TabIndex = 4;
            this.qlp_GridCtl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.qlp_GridVw});
            // 
            // qlp_GridVw
            // 
            this.qlp_GridVw.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAPHONG,
            this.colTINHTRANG,
            this.colSUCCHUA,
            this.colKHU,
            this.colMALOAIPHONG,
            this.colMAQL});
            this.qlp_GridVw.GridControl = this.qlp_GridCtl;
            this.qlp_GridVw.Name = "qlp_GridVw";
            this.qlp_GridVw.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            // 
            // colMAPHONG
            // 
            this.colMAPHONG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMAPHONG.AppearanceHeader.Options.UseFont = true;
            this.colMAPHONG.Caption = "Mã phòng";
            this.colMAPHONG.FieldName = "MAPHONG";
            this.colMAPHONG.Name = "colMAPHONG";
            this.colMAPHONG.Visible = true;
            this.colMAPHONG.VisibleIndex = 0;
            // 
            // colTINHTRANG
            // 
            this.colTINHTRANG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTINHTRANG.AppearanceHeader.Options.UseFont = true;
            this.colTINHTRANG.Caption = "Tình trạng";
            this.colTINHTRANG.FieldName = "TINHTRANG";
            this.colTINHTRANG.Name = "colTINHTRANG";
            this.colTINHTRANG.Visible = true;
            this.colTINHTRANG.VisibleIndex = 1;
            // 
            // colSUCCHUA
            // 
            this.colSUCCHUA.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSUCCHUA.AppearanceHeader.Options.UseFont = true;
            this.colSUCCHUA.Caption = "Sức chứa";
            this.colSUCCHUA.FieldName = "SUCCHUA";
            this.colSUCCHUA.Name = "colSUCCHUA";
            this.colSUCCHUA.Visible = true;
            this.colSUCCHUA.VisibleIndex = 2;
            // 
            // colKHU
            // 
            this.colKHU.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colKHU.AppearanceHeader.Options.UseFont = true;
            this.colKHU.Caption = "Khu";
            this.colKHU.FieldName = "KHU";
            this.colKHU.Name = "colKHU";
            this.colKHU.Visible = true;
            this.colKHU.VisibleIndex = 3;
            // 
            // colMALOAIPHONG
            // 
            this.colMALOAIPHONG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMALOAIPHONG.AppearanceHeader.Options.UseFont = true;
            this.colMALOAIPHONG.Caption = "Loại phòng";
            this.colMALOAIPHONG.FieldName = "MALOAIPHONG";
            this.colMALOAIPHONG.Name = "colMALOAIPHONG";
            this.colMALOAIPHONG.Visible = true;
            this.colMALOAIPHONG.VisibleIndex = 4;
            // 
            // colMAQL
            // 
            this.colMAQL.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMAQL.AppearanceHeader.Options.UseFont = true;
            this.colMAQL.Caption = "Mã QL";
            this.colMAQL.FieldName = "MAQL";
            this.colMAQL.Name = "colMAQL";
            this.colMAQL.Visible = true;
            this.colMAQL.VisibleIndex = 5;
            // 
            // UC_QuanLyPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.qlp_GridCtl);
            this.Controls.Add(this.qlp_HeaderPanel);
            this.Name = "UC_QuanLyPhong";
            this.Size = new System.Drawing.Size(833, 489);
            this.Load += new System.EventHandler(this.UC_QuanLyPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qlp_HeaderPanel)).EndInit();
            this.qlp_HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ql_KTX_DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phongBdS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlp_GridCtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlp_GridVw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl qlp_HeaderPanel;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel qlp_ActionBtnPanel2;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel qlp_ActionBtnPanel;
        private ql_KTXDataSet ql_KTX_DS;
        private System.Windows.Forms.BindingSource phongBdS;
        private ql_KTXDataSetTableAdapters.PHONGTableAdapter phongTableAdapter;
        private ql_KTXDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl qlp_GridCtl;
        private DevExpress.XtraGrid.Views.Grid.GridView qlp_GridVw;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn colTINHTRANG;
        private DevExpress.XtraGrid.Columns.GridColumn colSUCCHUA;
        private DevExpress.XtraGrid.Columns.GridColumn colKHU;
        private DevExpress.XtraGrid.Columns.GridColumn colMALOAIPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn colMAQL;
    }
}
