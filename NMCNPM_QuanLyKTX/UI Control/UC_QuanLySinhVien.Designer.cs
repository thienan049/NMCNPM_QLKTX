
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QuanLySinhVien));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.qlsv_ActionBtnPanel = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.ql_KTX_DS = new NMCNPM_QuanLyKTX.ql_KTXDataSet();
            this.sinhVienBdS = new System.Windows.Forms.BindingSource(this.components);
            this.sinhVienTableAdapter = new NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.SINHVIENTableAdapter();
            this.tableAdapterManager = new NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.TableAdapterManager();
            this.sINHVIENGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ql_KTX_DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinhVienBdS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sINHVIENGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.qlsv_ActionBtnPanel);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(845, 100);
            this.panelControl1.TabIndex = 2;
            // 
            // qlsv_ActionBtnPanel
            // 
            windowsUIButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions1.SvgImage")));
            this.qlsv_ActionBtnPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Add", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Delete", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.qlsv_ActionBtnPanel.Location = new System.Drawing.Point(272, 22);
            this.qlsv_ActionBtnPanel.Name = "qlsv_ActionBtnPanel";
            this.qlsv_ActionBtnPanel.Size = new System.Drawing.Size(361, 72);
            this.qlsv_ActionBtnPanel.TabIndex = 1;
            this.qlsv_ActionBtnPanel.Text = "windowsUIButtonPanel1";
            this.qlsv_ActionBtnPanel.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.qlsv_ActionBtnPanel_ButtonClick);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(112, 54);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Save";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
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
            // sINHVIENGridControl
            // 
            this.sINHVIENGridControl.DataSource = this.sinhVienBdS;
            this.sINHVIENGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sINHVIENGridControl.Location = new System.Drawing.Point(0, 100);
            this.sINHVIENGridControl.MainView = this.gridView1;
            this.sINHVIENGridControl.Name = "sINHVIENGridControl";
            this.sINHVIENGridControl.Size = new System.Drawing.Size(845, 390);
            this.sINHVIENGridControl.TabIndex = 2;
            this.sINHVIENGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridView1.GridControl = this.sINHVIENGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
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
            // UC_QuanLySinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sINHVIENGridControl);
            this.Controls.Add(this.panelControl1);
            this.Name = "UC_QuanLySinhVien";
            this.Size = new System.Drawing.Size(845, 490);
            this.Load += new System.EventHandler(this.UC_QuanLySinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ql_KTX_DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinhVienBdS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sINHVIENGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private ql_KTXDataSet ql_KTX_DS;
        private System.Windows.Forms.BindingSource sinhVienBdS;
        private ql_KTXDataSetTableAdapters.SINHVIENTableAdapter sinhVienTableAdapter;
        private ql_KTXDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl sINHVIENGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
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
    }
}
