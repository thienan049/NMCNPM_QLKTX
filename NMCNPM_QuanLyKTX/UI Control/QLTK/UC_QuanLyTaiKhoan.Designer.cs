
namespace NMCNPM_QuanLyKTX.UI_Control.QLTK
{
    partial class UC_QuanLyTaiKhoan
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions6 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QuanLyTaiKhoan));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions7 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions8 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions9 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions10 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.qltk_HeaderPanel = new DevExpress.XtraEditors.PanelControl();
            this.qltk_ActionBtnPanel2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.qltk_ActionBtnPanel = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.ql_KTX_DS = new NMCNPM_QuanLyKTX.ql_KTXDataSet();
            this.taiKhoanBdS = new System.Windows.Forms.BindingSource(this.components);
            this.taiKhoanTableAdapter = new NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.TAIKHOANTableAdapter();
            this.tableAdapterManager = new NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.TableAdapterManager();
            this.qltk_GridCtl = new DevExpress.XtraGrid.GridControl();
            this.qltk_GridVw = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUSERNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPASSWORD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAPQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.maPQCbBoxCol = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colTINHTRANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.phanQuyenBdS = new System.Windows.Forms.BindingSource(this.components);
            this.phanQuyenTableAdapter = new NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.PHANQUYENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.qltk_HeaderPanel)).BeginInit();
            this.qltk_HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ql_KTX_DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBdS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qltk_GridCtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qltk_GridVw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maPQCbBoxCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phanQuyenBdS)).BeginInit();
            this.SuspendLayout();
            // 
            // qltk_HeaderPanel
            // 
            this.qltk_HeaderPanel.Controls.Add(this.qltk_ActionBtnPanel2);
            this.qltk_HeaderPanel.Controls.Add(this.qltk_ActionBtnPanel);
            this.qltk_HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.qltk_HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.qltk_HeaderPanel.Name = "qltk_HeaderPanel";
            this.qltk_HeaderPanel.Size = new System.Drawing.Size(831, 100);
            this.qltk_HeaderPanel.TabIndex = 3;
            // 
            // qltk_ActionBtnPanel2
            // 
            this.qltk_ActionBtnPanel2.ButtonInterval = 50;
            windowsUIButtonImageOptions6.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions6.Image")));
            windowsUIButtonImageOptions7.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions7.SvgImage")));
            this.qltk_ActionBtnPanel2.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Reload", true, windowsUIButtonImageOptions6, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Show Password", true, windowsUIButtonImageOptions7, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.qltk_ActionBtnPanel2.Location = new System.Drawing.Point(448, 23);
            this.qltk_ActionBtnPanel2.Name = "qltk_ActionBtnPanel2";
            this.qltk_ActionBtnPanel2.Size = new System.Drawing.Size(361, 72);
            this.qltk_ActionBtnPanel2.TabIndex = 2;
            this.qltk_ActionBtnPanel2.Text = "windowsUIButtonPanel1";
            this.qltk_ActionBtnPanel2.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.qltk_ActionBtnPanel2_ButtonClick);
            // 
            // qltk_ActionBtnPanel
            // 
            this.qltk_ActionBtnPanel.ButtonInterval = 50;
            windowsUIButtonImageOptions8.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions8.Image")));
            windowsUIButtonImageOptions9.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions9.Image")));
            windowsUIButtonImageOptions10.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions10.Image")));
            this.qltk_ActionBtnPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Add", true, windowsUIButtonImageOptions8, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save", true, windowsUIButtonImageOptions9, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Delete", true, windowsUIButtonImageOptions10, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.qltk_ActionBtnPanel.Location = new System.Drawing.Point(48, 23);
            this.qltk_ActionBtnPanel.Name = "qltk_ActionBtnPanel";
            this.qltk_ActionBtnPanel.Size = new System.Drawing.Size(361, 72);
            this.qltk_ActionBtnPanel.TabIndex = 1;
            this.qltk_ActionBtnPanel.Text = "windowsUIButtonPanel1";
            this.qltk_ActionBtnPanel.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.qltk_ActionBtnPanel_ButtonClick);
            // 
            // ql_KTX_DS
            // 
            this.ql_KTX_DS.DataSetName = "ql_KTXDataSet";
            this.ql_KTX_DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taiKhoanBdS
            // 
            this.taiKhoanBdS.DataMember = "TAIKHOAN";
            this.taiKhoanBdS.DataSource = this.ql_KTX_DS;
            // 
            // taiKhoanTableAdapter
            // 
            this.taiKhoanTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.HOADONDIENTableAdapter = null;
            this.tableAdapterManager.HOPDONGTableAdapter = null;
            this.tableAdapterManager.LOAIPHONGTableAdapter = null;
            this.tableAdapterManager.PERMISSIONTableAdapter = null;
            this.tableAdapterManager.PHANCONGVIECTableAdapter = null;
            this.tableAdapterManager.PHANQUYENTableAdapter = null;
            this.tableAdapterManager.PHONGTableAdapter = null;
            this.tableAdapterManager.QUANLYTableAdapter = null;
            this.tableAdapterManager.QUYENTAIKHOANTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.TAIKHOANTableAdapter = this.taiKhoanTableAdapter;
            this.tableAdapterManager.UpdateOrder = NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VATTUTableAdapter = null;
            this.tableAdapterManager.VT_PHONGTableAdapter = null;
            // 
            // qltk_GridCtl
            // 
            this.qltk_GridCtl.DataSource = this.taiKhoanBdS;
            this.qltk_GridCtl.Location = new System.Drawing.Point(0, 100);
            this.qltk_GridCtl.MainView = this.qltk_GridVw;
            this.qltk_GridCtl.Name = "qltk_GridCtl";
            this.qltk_GridCtl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.maPQCbBoxCol});
            this.qltk_GridCtl.Size = new System.Drawing.Size(828, 647);
            this.qltk_GridCtl.TabIndex = 4;
            this.qltk_GridCtl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.qltk_GridVw});
            // 
            // qltk_GridVw
            // 
            this.qltk_GridVw.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUSERNAME,
            this.colPASSWORD,
            this.colMAPQ,
            this.colTINHTRANG});
            this.qltk_GridVw.GridControl = this.qltk_GridCtl;
            this.qltk_GridVw.Name = "qltk_GridVw";
            this.qltk_GridVw.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            // 
            // colUSERNAME
            // 
            this.colUSERNAME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colUSERNAME.AppearanceHeader.Options.UseFont = true;
            this.colUSERNAME.Caption = "Username";
            this.colUSERNAME.FieldName = "USERNAME";
            this.colUSERNAME.Name = "colUSERNAME";
            this.colUSERNAME.Visible = true;
            this.colUSERNAME.VisibleIndex = 0;
            // 
            // colPASSWORD
            // 
            this.colPASSWORD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPASSWORD.AppearanceHeader.Options.UseFont = true;
            this.colPASSWORD.Caption = "Password";
            this.colPASSWORD.FieldName = "PASSWORD";
            this.colPASSWORD.Name = "colPASSWORD";
            this.colPASSWORD.Visible = true;
            this.colPASSWORD.VisibleIndex = 1;
            // 
            // colMAPQ
            // 
            this.colMAPQ.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMAPQ.AppearanceHeader.Options.UseFont = true;
            this.colMAPQ.Caption = "Mã phân quyền";
            this.colMAPQ.ColumnEdit = this.maPQCbBoxCol;
            this.colMAPQ.FieldName = "MAPQ";
            this.colMAPQ.Name = "colMAPQ";
            this.colMAPQ.Visible = true;
            this.colMAPQ.VisibleIndex = 2;
            // 
            // maPQCbBoxCol
            // 
            this.maPQCbBoxCol.AutoHeight = false;
            this.maPQCbBoxCol.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.maPQCbBoxCol.Name = "maPQCbBoxCol";
            // 
            // colTINHTRANG
            // 
            this.colTINHTRANG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTINHTRANG.AppearanceHeader.Options.UseFont = true;
            this.colTINHTRANG.Caption = "Tình trạng";
            this.colTINHTRANG.FieldName = "TINHTRANG";
            this.colTINHTRANG.Name = "colTINHTRANG";
            this.colTINHTRANG.Visible = true;
            this.colTINHTRANG.VisibleIndex = 3;
            // 
            // phanQuyenBdS
            // 
            this.phanQuyenBdS.DataMember = "PHANQUYEN";
            this.phanQuyenBdS.DataSource = this.ql_KTX_DS;
            // 
            // phanQuyenTableAdapter
            // 
            this.phanQuyenTableAdapter.ClearBeforeFill = true;
            // 
            // UC_QuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.qltk_GridCtl);
            this.Controls.Add(this.qltk_HeaderPanel);
            this.Name = "UC_QuanLyTaiKhoan";
            this.Size = new System.Drawing.Size(831, 750);
            this.Load += new System.EventHandler(this.UC_QuanLyTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qltk_HeaderPanel)).EndInit();
            this.qltk_HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ql_KTX_DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBdS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qltk_GridCtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qltk_GridVw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maPQCbBoxCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phanQuyenBdS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl qltk_HeaderPanel;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel qltk_ActionBtnPanel2;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel qltk_ActionBtnPanel;
        private ql_KTXDataSet ql_KTX_DS;
        private System.Windows.Forms.BindingSource taiKhoanBdS;
        private ql_KTXDataSetTableAdapters.TAIKHOANTableAdapter taiKhoanTableAdapter;
        private ql_KTXDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl qltk_GridCtl;
        private DevExpress.XtraGrid.Views.Grid.GridView qltk_GridVw;
        private DevExpress.XtraGrid.Columns.GridColumn colUSERNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colPASSWORD;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPQ;
        private DevExpress.XtraGrid.Columns.GridColumn colTINHTRANG;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox maPQCbBoxCol;
        private System.Windows.Forms.BindingSource phanQuyenBdS;
        private ql_KTXDataSetTableAdapters.PHANQUYENTableAdapter phanQuyenTableAdapter;
    }
}
