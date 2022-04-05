
namespace NMCNPM_QuanLyKTX.UI_Control
{
    partial class UC_QuanLyHopDong
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions5 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QuanLyHopDong));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions6 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions7 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions8 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.qlsv_HeaderPanel = new DevExpress.XtraEditors.PanelControl();
            this.qlsv_ActionBtnPanel2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.qlsv_ActionBtnPanel = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.ql_KTX_DS = new NMCNPM_QuanLyKTX.ql_KTXDataSet();
            this.hopDongBdS = new System.Windows.Forms.BindingSource(this.components);
            this.hopDongTableAdapter = new NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.HOPDONGTableAdapter();
            this.tableAdapterManager = new NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.TableAdapterManager();
            this.hOPDONGGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYTAO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNAMHOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOCKY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMASV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAQL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTIENNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hocKyCbBoxCol = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.qlsv_HeaderPanel)).BeginInit();
            this.qlsv_HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ql_KTX_DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hopDongBdS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOPDONGGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hocKyCbBoxCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // qlsv_HeaderPanel
            // 
            this.qlsv_HeaderPanel.Controls.Add(this.qlsv_ActionBtnPanel2);
            this.qlsv_HeaderPanel.Controls.Add(this.qlsv_ActionBtnPanel);
            this.qlsv_HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.qlsv_HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.qlsv_HeaderPanel.Name = "qlsv_HeaderPanel";
            this.qlsv_HeaderPanel.Size = new System.Drawing.Size(858, 100);
            this.qlsv_HeaderPanel.TabIndex = 3;
            // 
            // qlsv_ActionBtnPanel2
            // 
            this.qlsv_ActionBtnPanel2.ButtonInterval = 50;
            windowsUIButtonImageOptions5.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions5.Image")));
            this.qlsv_ActionBtnPanel2.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Reload", true, windowsUIButtonImageOptions5, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.qlsv_ActionBtnPanel2.Location = new System.Drawing.Point(448, 23);
            this.qlsv_ActionBtnPanel2.Name = "qlsv_ActionBtnPanel2";
            this.qlsv_ActionBtnPanel2.Size = new System.Drawing.Size(361, 72);
            this.qlsv_ActionBtnPanel2.TabIndex = 2;
            this.qlsv_ActionBtnPanel2.Text = "windowsUIButtonPanel1";
            // 
            // qlsv_ActionBtnPanel
            // 
            this.qlsv_ActionBtnPanel.ButtonInterval = 50;
            windowsUIButtonImageOptions6.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions6.Image")));
            windowsUIButtonImageOptions7.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions7.Image")));
            windowsUIButtonImageOptions8.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions8.Image")));
            this.qlsv_ActionBtnPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Add", true, windowsUIButtonImageOptions6, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save", true, windowsUIButtonImageOptions7, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Delete", true, windowsUIButtonImageOptions8, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.qlsv_ActionBtnPanel.Location = new System.Drawing.Point(48, 23);
            this.qlsv_ActionBtnPanel.Name = "qlsv_ActionBtnPanel";
            this.qlsv_ActionBtnPanel.Size = new System.Drawing.Size(361, 72);
            this.qlsv_ActionBtnPanel.TabIndex = 1;
            this.qlsv_ActionBtnPanel.Text = "windowsUIButtonPanel1";
            // 
            // ql_KTX_DS
            // 
            this.ql_KTX_DS.DataSetName = "ql_KTXDataSet";
            this.ql_KTX_DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hopDongBdS
            // 
            this.hopDongBdS.DataMember = "HOPDONG";
            this.hopDongBdS.DataSource = this.ql_KTX_DS;
            // 
            // hopDongTableAdapter
            // 
            this.hopDongTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.HOADONDIENTableAdapter = null;
            this.tableAdapterManager.HOPDONGTableAdapter = this.hopDongTableAdapter;
            this.tableAdapterManager.LOAIPHONGTableAdapter = null;
            this.tableAdapterManager.PHANQUYENTableAdapter = null;
            this.tableAdapterManager.PHONGTableAdapter = null;
            this.tableAdapterManager.QUANLYTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.TAIKHOANTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VATTUTableAdapter = null;
            this.tableAdapterManager.VT_PHONGTableAdapter = null;
            // 
            // hOPDONGGridControl
            // 
            this.hOPDONGGridControl.DataSource = this.hopDongBdS;
            this.hOPDONGGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hOPDONGGridControl.Location = new System.Drawing.Point(0, 100);
            this.hOPDONGGridControl.MainView = this.gridView1;
            this.hOPDONGGridControl.Name = "hOPDONGGridControl";
            this.hOPDONGGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.hocKyCbBoxCol});
            this.hOPDONGGridControl.Size = new System.Drawing.Size(858, 386);
            this.hOPDONGGridControl.TabIndex = 4;
            this.hOPDONGGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAHD,
            this.colNGAYTAO,
            this.colSOTIEN,
            this.colNAMHOC,
            this.colHOCKY,
            this.colMAPHONG,
            this.colMASV,
            this.colMAQL,
            this.colTIENNO});
            this.gridView1.GridControl = this.hOPDONGGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colMAHD
            // 
            this.colMAHD.FieldName = "MAHD";
            this.colMAHD.Name = "colMAHD";
            this.colMAHD.Visible = true;
            this.colMAHD.VisibleIndex = 0;
            // 
            // colNGAYTAO
            // 
            this.colNGAYTAO.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNGAYTAO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNGAYTAO.FieldName = "NGAYTAO";
            this.colNGAYTAO.Name = "colNGAYTAO";
            this.colNGAYTAO.Visible = true;
            this.colNGAYTAO.VisibleIndex = 1;
            // 
            // colSOTIEN
            // 
            this.colSOTIEN.FieldName = "SOTIEN";
            this.colSOTIEN.Name = "colSOTIEN";
            this.colSOTIEN.Visible = true;
            this.colSOTIEN.VisibleIndex = 2;
            // 
            // colNAMHOC
            // 
            this.colNAMHOC.FieldName = "NAMHOC";
            this.colNAMHOC.Name = "colNAMHOC";
            this.colNAMHOC.Visible = true;
            this.colNAMHOC.VisibleIndex = 3;
            // 
            // colHOCKY
            // 
            this.colHOCKY.ColumnEdit = this.hocKyCbBoxCol;
            this.colHOCKY.FieldName = "HOCKY";
            this.colHOCKY.Name = "colHOCKY";
            this.colHOCKY.Visible = true;
            this.colHOCKY.VisibleIndex = 4;
            // 
            // colMAPHONG
            // 
            this.colMAPHONG.FieldName = "MAPHONG";
            this.colMAPHONG.Name = "colMAPHONG";
            this.colMAPHONG.Visible = true;
            this.colMAPHONG.VisibleIndex = 5;
            // 
            // colMASV
            // 
            this.colMASV.FieldName = "MASV";
            this.colMASV.Name = "colMASV";
            this.colMASV.Visible = true;
            this.colMASV.VisibleIndex = 6;
            // 
            // colMAQL
            // 
            this.colMAQL.FieldName = "MAQL";
            this.colMAQL.Name = "colMAQL";
            this.colMAQL.Visible = true;
            this.colMAQL.VisibleIndex = 7;
            // 
            // colTIENNO
            // 
            this.colTIENNO.FieldName = "TIENNO";
            this.colTIENNO.Name = "colTIENNO";
            this.colTIENNO.Visible = true;
            this.colTIENNO.VisibleIndex = 8;
            // 
            // hocKyCbBoxCol
            // 
            this.hocKyCbBoxCol.AutoHeight = false;
            this.hocKyCbBoxCol.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.hocKyCbBoxCol.Name = "hocKyCbBoxCol";
            // 
            // UC_QuanLyHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hOPDONGGridControl);
            this.Controls.Add(this.qlsv_HeaderPanel);
            this.Name = "UC_QuanLyHopDong";
            this.Size = new System.Drawing.Size(858, 486);
            this.Load += new System.EventHandler(this.UC_QuanLyHopDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qlsv_HeaderPanel)).EndInit();
            this.qlsv_HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ql_KTX_DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hopDongBdS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOPDONGGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hocKyCbBoxCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl qlsv_HeaderPanel;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel qlsv_ActionBtnPanel2;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel qlsv_ActionBtnPanel;
        private ql_KTXDataSet ql_KTX_DS;
        private System.Windows.Forms.BindingSource hopDongBdS;
        private ql_KTXDataSetTableAdapters.HOPDONGTableAdapter hopDongTableAdapter;
        private ql_KTXDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl hOPDONGGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAHD;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYTAO;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTIEN;
        private DevExpress.XtraGrid.Columns.GridColumn colNAMHOC;
        private DevExpress.XtraGrid.Columns.GridColumn colHOCKY;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn colMASV;
        private DevExpress.XtraGrid.Columns.GridColumn colMAQL;
        private DevExpress.XtraGrid.Columns.GridColumn colTIENNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox hocKyCbBoxCol;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}
