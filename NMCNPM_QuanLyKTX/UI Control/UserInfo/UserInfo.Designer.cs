
namespace NMCNPM_QuanLyKTX.UI_Control.UserInfo
{
    partial class UserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfo));
            this.User_Ho_Lbl = new DevExpress.XtraEditors.LabelControl();
            this.User_Ho_Val = new DevExpress.XtraEditors.LabelControl();
            this.User_Ten_Val = new DevExpress.XtraEditors.LabelControl();
            this.User_Tên_Lbl = new DevExpress.XtraEditors.LabelControl();
            this.User_NgayNhanViec_Val = new DevExpress.XtraEditors.LabelControl();
            this.User_NgayNhanViec_Lbl = new DevExpress.XtraEditors.LabelControl();
            this.User_MaQL_Val = new DevExpress.XtraEditors.LabelControl();
            this.User_MaQL_Lbl = new DevExpress.XtraEditors.LabelControl();
            this.User_Username_Val = new DevExpress.XtraEditors.LabelControl();
            this.User_Username_Lbl = new DevExpress.XtraEditors.LabelControl();
            this.BtnOKCloseForm = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_styleCtl = new DevExpress.XtraEditors.StyleController(this.components);
            this.ThongTinUser_Header = new DevExpress.XtraEditors.LabelControl();
            this.ShowPermissionDetail = new DevExpress.XtraEditors.SimpleButton();
            this.QL_KTXDataSet = new NMCNPM_QuanLyKTX.ql_KTXDataSet();
            this.SP_GetUserPermissionTableAdapter = new NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.SP_GETUSERPERMISSIONTableAdapter();
            this.tableAdapterManager = new NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_styleCtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_KTXDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // User_Ho_Lbl
            // 
            this.User_Ho_Lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Ho_Lbl.Appearance.ForeColor = System.Drawing.Color.White;
            this.User_Ho_Lbl.Appearance.Options.UseFont = true;
            this.User_Ho_Lbl.Appearance.Options.UseForeColor = true;
            this.User_Ho_Lbl.Location = new System.Drawing.Point(155, 70);
            this.User_Ho_Lbl.Name = "User_Ho_Lbl";
            this.User_Ho_Lbl.Size = new System.Drawing.Size(23, 18);
            this.User_Ho_Lbl.TabIndex = 0;
            this.User_Ho_Lbl.Text = "Họ:";
            // 
            // User_Ho_Val
            // 
            this.User_Ho_Val.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Ho_Val.Appearance.ForeColor = System.Drawing.Color.White;
            this.User_Ho_Val.Appearance.Options.UseFont = true;
            this.User_Ho_Val.Appearance.Options.UseForeColor = true;
            this.User_Ho_Val.Location = new System.Drawing.Point(194, 72);
            this.User_Ho_Val.Name = "User_Ho_Val";
            this.User_Ho_Val.Size = new System.Drawing.Size(46, 16);
            this.User_Ho_Val.TabIndex = 1;
            this.User_Ho_Val.Text = "userHo";
            // 
            // User_Ten_Val
            // 
            this.User_Ten_Val.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Ten_Val.Appearance.ForeColor = System.Drawing.Color.White;
            this.User_Ten_Val.Appearance.Options.UseFont = true;
            this.User_Ten_Val.Appearance.Options.UseForeColor = true;
            this.User_Ten_Val.Location = new System.Drawing.Point(194, 112);
            this.User_Ten_Val.Name = "User_Ten_Val";
            this.User_Ten_Val.Size = new System.Drawing.Size(52, 16);
            this.User_Ten_Val.TabIndex = 3;
            this.User_Ten_Val.Text = "userTen";
            // 
            // User_Tên_Lbl
            // 
            this.User_Tên_Lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Tên_Lbl.Appearance.ForeColor = System.Drawing.Color.White;
            this.User_Tên_Lbl.Appearance.Options.UseFont = true;
            this.User_Tên_Lbl.Appearance.Options.UseForeColor = true;
            this.User_Tên_Lbl.Location = new System.Drawing.Point(147, 110);
            this.User_Tên_Lbl.Name = "User_Tên_Lbl";
            this.User_Tên_Lbl.Size = new System.Drawing.Size(31, 18);
            this.User_Tên_Lbl.TabIndex = 2;
            this.User_Tên_Lbl.Text = "Tên:";
            // 
            // User_NgayNhanViec_Val
            // 
            this.User_NgayNhanViec_Val.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_NgayNhanViec_Val.Appearance.ForeColor = System.Drawing.Color.White;
            this.User_NgayNhanViec_Val.Appearance.Options.UseFont = true;
            this.User_NgayNhanViec_Val.Appearance.Options.UseForeColor = true;
            this.User_NgayNhanViec_Val.Location = new System.Drawing.Point(194, 152);
            this.User_NgayNhanViec_Val.Name = "User_NgayNhanViec_Val";
            this.User_NgayNhanViec_Val.Size = new System.Drawing.Size(120, 16);
            this.User_NgayNhanViec_Val.TabIndex = 5;
            this.User_NgayNhanViec_Val.Text = "userNgayNhanViec";
            // 
            // User_NgayNhanViec_Lbl
            // 
            this.User_NgayNhanViec_Lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_NgayNhanViec_Lbl.Appearance.ForeColor = System.Drawing.Color.White;
            this.User_NgayNhanViec_Lbl.Appearance.Options.UseFont = true;
            this.User_NgayNhanViec_Lbl.Appearance.Options.UseForeColor = true;
            this.User_NgayNhanViec_Lbl.Location = new System.Drawing.Point(72, 150);
            this.User_NgayNhanViec_Lbl.Name = "User_NgayNhanViec_Lbl";
            this.User_NgayNhanViec_Lbl.Size = new System.Drawing.Size(106, 18);
            this.User_NgayNhanViec_Lbl.TabIndex = 4;
            this.User_NgayNhanViec_Lbl.Text = "Ngày nhận việc:";
            // 
            // User_MaQL_Val
            // 
            this.User_MaQL_Val.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_MaQL_Val.Appearance.ForeColor = System.Drawing.Color.White;
            this.User_MaQL_Val.Appearance.Options.UseFont = true;
            this.User_MaQL_Val.Appearance.Options.UseForeColor = true;
            this.User_MaQL_Val.Location = new System.Drawing.Point(194, 192);
            this.User_MaQL_Val.Name = "User_MaQL_Val";
            this.User_MaQL_Val.Size = new System.Drawing.Size(64, 16);
            this.User_MaQL_Val.TabIndex = 7;
            this.User_MaQL_Val.Text = "userMaQL";
            // 
            // User_MaQL_Lbl
            // 
            this.User_MaQL_Lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_MaQL_Lbl.Appearance.ForeColor = System.Drawing.Color.White;
            this.User_MaQL_Lbl.Appearance.Options.UseFont = true;
            this.User_MaQL_Lbl.Appearance.Options.UseForeColor = true;
            this.User_MaQL_Lbl.Location = new System.Drawing.Point(101, 190);
            this.User_MaQL_Lbl.Name = "User_MaQL_Lbl";
            this.User_MaQL_Lbl.Size = new System.Drawing.Size(77, 18);
            this.User_MaQL_Lbl.TabIndex = 6;
            this.User_MaQL_Lbl.Text = "Mã quản lý:";
            // 
            // User_Username_Val
            // 
            this.User_Username_Val.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Username_Val.Appearance.ForeColor = System.Drawing.Color.White;
            this.User_Username_Val.Appearance.Options.UseFont = true;
            this.User_Username_Val.Appearance.Options.UseForeColor = true;
            this.User_Username_Val.Location = new System.Drawing.Point(194, 232);
            this.User_Username_Val.Name = "User_Username_Val";
            this.User_Username_Val.Size = new System.Drawing.Size(93, 16);
            this.User_Username_Val.TabIndex = 9;
            this.User_Username_Val.Text = "userUsername";
            // 
            // User_Username_Lbl
            // 
            this.User_Username_Lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Username_Lbl.Appearance.ForeColor = System.Drawing.Color.White;
            this.User_Username_Lbl.Appearance.Options.UseFont = true;
            this.User_Username_Lbl.Appearance.Options.UseForeColor = true;
            this.User_Username_Lbl.Location = new System.Drawing.Point(106, 230);
            this.User_Username_Lbl.Name = "User_Username_Lbl";
            this.User_Username_Lbl.Size = new System.Drawing.Size(72, 18);
            this.User_Username_Lbl.TabIndex = 8;
            this.User_Username_Lbl.Text = "Username:";
            // 
            // BtnOKCloseForm
            // 
            this.BtnOKCloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOKCloseForm.Appearance.ForeColor = System.Drawing.Color.White;
            this.BtnOKCloseForm.Appearance.Options.UseFont = true;
            this.BtnOKCloseForm.Appearance.Options.UseForeColor = true;
            this.BtnOKCloseForm.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BtnOKCloseForm.Location = new System.Drawing.Point(165, 271);
            this.BtnOKCloseForm.Name = "BtnOKCloseForm";
            this.BtnOKCloseForm.Size = new System.Drawing.Size(75, 23);
            this.BtnOKCloseForm.StyleController = this.Btn_styleCtl;
            this.BtnOKCloseForm.TabIndex = 10;
            this.BtnOKCloseForm.Text = "OK";
            this.BtnOKCloseForm.Click += new System.EventHandler(this.BtnOKCloseForm_Click);
            // 
            // Btn_styleCtl
            // 
            this.Btn_styleCtl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            // 
            // ThongTinUser_Header
            // 
            this.ThongTinUser_Header.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThongTinUser_Header.Appearance.ForeColor = System.Drawing.Color.White;
            this.ThongTinUser_Header.Appearance.Options.UseFont = true;
            this.ThongTinUser_Header.Appearance.Options.UseForeColor = true;
            this.ThongTinUser_Header.Location = new System.Drawing.Point(101, 26);
            this.ThongTinUser_Header.Name = "ThongTinUser_Header";
            this.ThongTinUser_Header.Size = new System.Drawing.Size(207, 23);
            this.ThongTinUser_Header.TabIndex = 11;
            this.ThongTinUser_Header.Text = "Thông tin người dùng";
            // 
            // ShowPermissionDetail
            // 
            this.ShowPermissionDetail.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPermissionDetail.Appearance.ForeColor = System.Drawing.Color.White;
            this.ShowPermissionDetail.Appearance.Options.UseFont = true;
            this.ShowPermissionDetail.Appearance.Options.UseForeColor = true;
            this.ShowPermissionDetail.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ShowPermissionDetail.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.ShowPermissionDetail.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.ShowPermissionDetail.Location = new System.Drawing.Point(320, 229);
            this.ShowPermissionDetail.Name = "ShowPermissionDetail";
            this.ShowPermissionDetail.Size = new System.Drawing.Size(23, 23);
            this.ShowPermissionDetail.StyleController = this.Btn_styleCtl;
            this.ShowPermissionDetail.TabIndex = 12;
            this.ShowPermissionDetail.ToolTipTitle = "Quyền:";
            // 
            // QL_KTXDataSet
            // 
            this.QL_KTXDataSet.DataSetName = "ql_KTXDataSet";
            this.QL_KTXDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_GetUserPermissionTableAdapter
            // 
            this.SP_GetUserPermissionTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
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
            this.tableAdapterManager.TAIKHOANTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NMCNPM_QuanLyKTX.ql_KTXDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VATTUTableAdapter = null;
            this.tableAdapterManager.VT_PHONGTableAdapter = null;
            // 
            // UserInfo
            // 
            this.AcceptButton = this.BtnOKCloseForm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(413, 317);
            this.Controls.Add(this.ShowPermissionDetail);
            this.Controls.Add(this.ThongTinUser_Header);
            this.Controls.Add(this.BtnOKCloseForm);
            this.Controls.Add(this.User_Username_Val);
            this.Controls.Add(this.User_Username_Lbl);
            this.Controls.Add(this.User_MaQL_Val);
            this.Controls.Add(this.User_MaQL_Lbl);
            this.Controls.Add(this.User_NgayNhanViec_Val);
            this.Controls.Add(this.User_NgayNhanViec_Lbl);
            this.Controls.Add(this.User_Ten_Val);
            this.Controls.Add(this.User_Tên_Lbl);
            this.Controls.Add(this.User_Ho_Val);
            this.Controls.Add(this.User_Ho_Lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "UserInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UserInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Btn_styleCtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_KTXDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl User_Ho_Lbl;
        private DevExpress.XtraEditors.LabelControl User_Ho_Val;
        private DevExpress.XtraEditors.LabelControl User_Ten_Val;
        private DevExpress.XtraEditors.LabelControl User_Tên_Lbl;
        private DevExpress.XtraEditors.LabelControl User_NgayNhanViec_Val;
        private DevExpress.XtraEditors.LabelControl User_NgayNhanViec_Lbl;
        private DevExpress.XtraEditors.LabelControl User_MaQL_Val;
        private DevExpress.XtraEditors.LabelControl User_MaQL_Lbl;
        private DevExpress.XtraEditors.LabelControl User_Username_Val;
        private DevExpress.XtraEditors.LabelControl User_Username_Lbl;
        private DevExpress.XtraEditors.SimpleButton BtnOKCloseForm;
        private DevExpress.XtraEditors.StyleController Btn_styleCtl;
        private DevExpress.XtraEditors.LabelControl ThongTinUser_Header;
        private DevExpress.XtraEditors.SimpleButton ShowPermissionDetail;
        private ql_KTXDataSet QL_KTXDataSet;
        private ql_KTXDataSetTableAdapters.SP_GETUSERPERMISSIONTableAdapter SP_GetUserPermissionTableAdapter;
        private ql_KTXDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}