
namespace NMCNPM_QuanLyKTX.UI_Control
{
    partial class UC_QuanLySinhVien
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions4 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QuanLySinhVien));
            this.qlsv_HeaderPanel = new DevExpress.XtraEditors.PanelControl();
            this.qlsv_ActionBtnPanel = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.ql_KTX_DS = new NMCNPM_QuanLyKTX.ql_KTXDataSet();
            this.sinhVienBdS = new System.Windows.Forms.BindingSource(this.components);
            this.sinhVienTableAdapter = new NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.SINHVIENTableAdapter();
            this.tableAdapterManager = new NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.TableAdapterManager();
            this.qlsv_GridCtl = new DevExpress.XtraGrid.GridControl();
            this.qlsv_GridVw = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMASV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYSINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGIOITINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXETDIEUKIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVIPHAMNOIQUY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMALOP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAQL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qlsv_ActionBtnPanel2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.qlsv_HeaderPanel)).BeginInit();
            this.qlsv_HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ql_KTX_DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinhVienBdS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlsv_GridCtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlsv_GridVw)).BeginInit();
            this.SuspendLayout();
            // 
            // qlsv_HeaderPanel
            // 
            this.qlsv_HeaderPanel.Controls.Add(this.qlsv_ActionBtnPanel2);
            this.qlsv_HeaderPanel.Controls.Add(this.qlsv_ActionBtnPanel);
            this.qlsv_HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.qlsv_HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.qlsv_HeaderPanel.Name = "qlsv_HeaderPanel";
            this.qlsv_HeaderPanel.Size = new System.Drawing.Size(845, 100);
            this.qlsv_HeaderPanel.TabIndex = 2;
            // 
            // qlsv_ActionBtnPanel
            // 
            this.qlsv_ActionBtnPanel.ButtonInterval = 50;
            windowsUIButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions2.Image")));
            windowsUIButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions3.Image")));
            windowsUIButtonImageOptions4.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions4.Image")));
            this.qlsv_ActionBtnPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Add", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Delete", true, windowsUIButtonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.qlsv_ActionBtnPanel.Location = new System.Drawing.Point(48, 23);
            this.qlsv_ActionBtnPanel.Name = "qlsv_ActionBtnPanel";
            this.qlsv_ActionBtnPanel.Size = new System.Drawing.Size(361, 72);
            this.qlsv_ActionBtnPanel.TabIndex = 1;
            this.qlsv_ActionBtnPanel.Text = "windowsUIButtonPanel1";
            this.qlsv_ActionBtnPanel.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.qlsv_ActionBtnPanel_ButtonClick);
            // 
            // ql_KTX_DS
            // 
            this.ql_KTX_DS.DataSetName = "ql_KTXDataSet";
            this.ql_KTX_DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sinhVienBdS
            // 
            this.sinhVienBdS.DataMember = "SINHVIEN";
            this.sinhVienBdS.DataSource = this.ql_KTX_DS;
            // 
            // sinhVienTableAdapter
            // 
            this.sinhVienTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.HOADONDIENTableAdapter = null;
            this.tableAdapterManager.HOPDONGTableAdapter = null;
            this.tableAdapterManager.LOAIPHONGTableAdapter = null;
            this.tableAdapterManager.PHANQUYENTableAdapter = null;
            this.tableAdapterManager.PHONGTableAdapter = null;
            this.tableAdapterManager.QUANLYTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = this.sinhVienTableAdapter;
            this.tableAdapterManager.TAIKHOANTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VATTUTableAdapter = null;
            this.tableAdapterManager.VT_PHONGTableAdapter = null;
            // 
            // qlsv_GridCtl
            // 
            this.qlsv_GridCtl.DataSource = this.sinhVienBdS;
            this.qlsv_GridCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qlsv_GridCtl.Location = new System.Drawing.Point(0, 100);
            this.qlsv_GridCtl.MainView = this.qlsv_GridVw;
            this.qlsv_GridCtl.Name = "qlsv_GridCtl";
            this.qlsv_GridCtl.Size = new System.Drawing.Size(845, 390);
            this.qlsv_GridCtl.TabIndex = 2;
            this.qlsv_GridCtl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.qlsv_GridVw});
            // 
            // qlsv_GridVw
            // 
            this.qlsv_GridVw.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMASV,
            this.colHO,
            this.colTEN,
            this.colNGAYSINH,
            this.colDIACHI,
            this.colSDT,
            this.colGIOITINH,
            this.colXETDIEUKIEN,
            this.colVIPHAMNOIQUY,
            this.colMALOP,
            this.colMAQL});
            this.qlsv_GridVw.GridControl = this.qlsv_GridCtl;
            this.qlsv_GridVw.Name = "qlsv_GridVw";
            this.qlsv_GridVw.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNGAYSINH, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colMASV
            // 
            this.colMASV.Caption = "Mã Sinh Viên";
            this.colMASV.FieldName = "MASV";
            this.colMASV.Name = "colMASV";
            this.colMASV.Visible = true;
            this.colMASV.VisibleIndex = 0;
            this.colMASV.Width = 114;
            // 
            // colHO
            // 
            this.colHO.Caption = "Họ";
            this.colHO.FieldName = "HO";
            this.colHO.Name = "colHO";
            this.colHO.Visible = true;
            this.colHO.VisibleIndex = 1;
            this.colHO.Width = 44;
            // 
            // colTEN
            // 
            this.colTEN.Caption = "Tên";
            this.colTEN.FieldName = "TEN";
            this.colTEN.Name = "colTEN";
            this.colTEN.Visible = true;
            this.colTEN.VisibleIndex = 2;
            this.colTEN.Width = 105;
            // 
            // colNGAYSINH
            // 
            this.colNGAYSINH.Caption = "Ngày Sinh";
            this.colNGAYSINH.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNGAYSINH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNGAYSINH.FieldName = "NGAYSINH";
            this.colNGAYSINH.Name = "colNGAYSINH";
            this.colNGAYSINH.Visible = true;
            this.colNGAYSINH.VisibleIndex = 3;
            this.colNGAYSINH.Width = 74;
            // 
            // colDIACHI
            // 
            this.colDIACHI.Caption = "Địa Chỉ";
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 4;
            this.colDIACHI.Width = 89;
            // 
            // colSDT
            // 
            this.colSDT.Caption = "Số ĐT";
            this.colSDT.FieldName = "SDT";
            this.colSDT.Name = "colSDT";
            this.colSDT.Visible = true;
            this.colSDT.VisibleIndex = 5;
            this.colSDT.Width = 52;
            // 
            // colGIOITINH
            // 
            this.colGIOITINH.Caption = "Giới Tính";
            this.colGIOITINH.FieldName = "GIOITINH";
            this.colGIOITINH.Name = "colGIOITINH";
            this.colGIOITINH.Visible = true;
            this.colGIOITINH.VisibleIndex = 6;
            this.colGIOITINH.Width = 54;
            // 
            // colXETDIEUKIEN
            // 
            this.colXETDIEUKIEN.Caption = "Xét ĐK";
            this.colXETDIEUKIEN.FieldName = "XETDIEUKIEN";
            this.colXETDIEUKIEN.Name = "colXETDIEUKIEN";
            this.colXETDIEUKIEN.Visible = true;
            this.colXETDIEUKIEN.VisibleIndex = 7;
            this.colXETDIEUKIEN.Width = 51;
            // 
            // colVIPHAMNOIQUY
            // 
            this.colVIPHAMNOIQUY.Caption = "Vi Phạm NQ";
            this.colVIPHAMNOIQUY.FieldName = "VIPHAMNOIQUY";
            this.colVIPHAMNOIQUY.Name = "colVIPHAMNOIQUY";
            this.colVIPHAMNOIQUY.Visible = true;
            this.colVIPHAMNOIQUY.VisibleIndex = 8;
            this.colVIPHAMNOIQUY.Width = 99;
            // 
            // colMALOP
            // 
            this.colMALOP.Caption = "Mã Lớp";
            this.colMALOP.FieldName = "MALOP";
            this.colMALOP.Name = "colMALOP";
            this.colMALOP.Visible = true;
            this.colMALOP.VisibleIndex = 9;
            this.colMALOP.Width = 85;
            // 
            // colMAQL
            // 
            this.colMAQL.Caption = "Mã Q.Lý";
            this.colMAQL.FieldName = "MAQL";
            this.colMAQL.Name = "colMAQL";
            this.colMAQL.Visible = true;
            this.colMAQL.VisibleIndex = 10;
            this.colMAQL.Width = 51;
            // 
            // qlsv_ActionBtnPanel2
            // 
            this.qlsv_ActionBtnPanel2.ButtonInterval = 50;
            windowsUIButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions1.Image")));
            this.qlsv_ActionBtnPanel2.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Reload", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.qlsv_ActionBtnPanel2.Location = new System.Drawing.Point(448, 23);
            this.qlsv_ActionBtnPanel2.Name = "qlsv_ActionBtnPanel2";
            this.qlsv_ActionBtnPanel2.Size = new System.Drawing.Size(361, 72);
            this.qlsv_ActionBtnPanel2.TabIndex = 2;
            this.qlsv_ActionBtnPanel2.Text = "windowsUIButtonPanel1";
            this.qlsv_ActionBtnPanel2.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.qlsv_ActionBtnPanel2_ButtonClick);
            // 
            // UC_QuanLySinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.qlsv_GridCtl);
            this.Controls.Add(this.qlsv_HeaderPanel);
            this.Name = "UC_QuanLySinhVien";
            this.Size = new System.Drawing.Size(845, 490);
            this.Load += new System.EventHandler(this.UC_QuanLySinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qlsv_HeaderPanel)).EndInit();
            this.qlsv_HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ql_KTX_DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinhVienBdS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlsv_GridCtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlsv_GridVw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl qlsv_HeaderPanel;
        private ql_KTXDataSet ql_KTX_DS;
        private System.Windows.Forms.BindingSource sinhVienBdS;
        private ql_KTXDataSetTableAdapters.SINHVIENTableAdapter sinhVienTableAdapter;
        private ql_KTXDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl qlsv_GridCtl;
        private DevExpress.XtraGrid.Views.Grid.GridView qlsv_GridVw;
        private DevExpress.XtraGrid.Columns.GridColumn colMASV;
        private DevExpress.XtraGrid.Columns.GridColumn colHO;
        private DevExpress.XtraGrid.Columns.GridColumn colTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYSINH;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colSDT;
        private DevExpress.XtraGrid.Columns.GridColumn colGIOITINH;
        private DevExpress.XtraGrid.Columns.GridColumn colXETDIEUKIEN;
        private DevExpress.XtraGrid.Columns.GridColumn colVIPHAMNOIQUY;
        private DevExpress.XtraGrid.Columns.GridColumn colMALOP;
        private DevExpress.XtraGrid.Columns.GridColumn colMAQL;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel qlsv_ActionBtnPanel;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel qlsv_ActionBtnPanel2;
    }
}
