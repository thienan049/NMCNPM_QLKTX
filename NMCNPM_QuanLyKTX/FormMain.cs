using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using NMCNPM_QuanLyKTX.Common.Service;
using NMCNPM_QuanLyKTX.UI_Control.QLCSVC;
using NMCNPM_QuanLyKTX.UI_Control.QLD;
using NMCNPM_QuanLyKTX.UI_Control.QLHD;
using NMCNPM_QuanLyKTX.UI_Control.QLP;
using NMCNPM_QuanLyKTX.UI_Control.QLSV;
using NMCNPM_QuanLyKTX.UI_Control.QLTK;
using NMCNPM_QuanLyKTX.UI_Control.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NMCNPM_QuanLyKTX
{
    public partial class FormMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        // QuanLySinhVien user control
        UC_QuanLySinhVien UC_QLSV = null;

        // QuanLySinhVien_ThongKe user control
        UC_QLSV_ThongKe UC_QLSV_TK = null;

        // QuanLyHopDong user control
        UC_QuanLyHopDong UC_QLHD = null;

        // QuanLyPhong user control
        UC_QuanLyPhong UC_QLP = null;

        // QuanLyTaiKhoan user control
        UC_QuanLyTaiKhoan UC_QLTK = null;

        // QuanLyTaiKhoan user control
        UC_QuanLyCSVC UC_QLCSVC = null;

        // QuanLyTaiKhoan user control
        UC_QuanLyDien UC_QLD = null;

        // Khởi tạo form
        public FormMain()
        {
            InitializeComponent();

            Program.ConnectDB();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Lưu lại trạng thái tyle mặc định của chương trình
            CommonService.SaveDefaultApplicationStyle();

            // Hiển thị thông tin user
            if(CommonService.CheckAccessMode())
                InitUserInfo();
        }

        // Hiển thị QLSV user control
        private void acCtlEle_ThongTinSV_Click(object sender, EventArgs e)
        {
            // Nếu chưa tồn tại, tạo đối tượng mới
            if (this.UC_QLSV == null)
            {
                this.UC_QLSV = new UC_QuanLySinhVien
                {
                    Dock = DockStyle.Fill
                };

                // Thêm đối tượng vừa tạo vào khu vực content container
                this.contentContainer.Controls.Add(this.UC_QLSV);
                this.UC_QLSV.BringToFront();
            }
            // Nếu đã tồn tại, đưa lên front để hiển thị
            else
            {
                this.UC_QLSV.BringToFront();
            }
        }

        private void acCtlEle_ThongTinPhong_Click(object sender, EventArgs e)
        {
            // Nếu chưa tồn tại, tạo đối tượng mới
            if (this.UC_QLP == null)
            {
                this.UC_QLP = new UC_QuanLyPhong
                {
                    Dock = DockStyle.Fill
                };

                // Thêm đối tượng vừa tạo vào khu vực content container
                this.contentContainer.Controls.Add(this.UC_QLP);
                this.UC_QLP.BringToFront();
            }
            // Nếu đã tồn tại, đưa lên front để hiển thị
            else
            {
                this.UC_QLP.BringToFront();
            }
        }

        private void acCtlEle_TaiKhoan_Click(object sender, EventArgs e)
        {
            // Nếu chưa tồn tại, tạo đối tượng mới
            if (this.UC_QLTK == null)
            {
                this.UC_QLTK = new UC_QuanLyTaiKhoan
                {
                    Dock = DockStyle.Fill
                };

                // Thêm đối tượng vừa tạo vào khu vực content container
                this.contentContainer.Controls.Add(this.UC_QLTK);
                this.UC_QLTK.BringToFront();
            }
            // Nếu đã tồn tại, đưa lên front để hiển thị
            else
            {
                this.UC_QLTK.BringToFront();
            }
        }

        private void acCtlEle_ThongTinHD_Click(object sender, EventArgs e)
        {
            // Nếu chưa tồn tại, tạo đối tượng mới
            if (this.UC_QLHD == null)
            {
                this.UC_QLHD = new UC_QuanLyHopDong
                {
                    Dock = DockStyle.Fill
                };

                // Thêm đối tượng vừa tạo vào khu vực content container
                this.contentContainer.Controls.Add(this.UC_QLHD);
                this.UC_QLHD.BringToFront();
            }
            // Nếu đã tồn tại, đưa lên front để hiển thị
            else
            {
                this.UC_QLHD.BringToFront();
            }
        }
        /// <summary>
        /// Display setting windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ProgramSetting_ItemClick(object sender, ItemClickEventArgs e)
        {

            new SettingDialog().ShowDialog();
            WindowsFormsSettings.PopupAnimation = PopupAnimation.System;
            //WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle(new DevExpress.LookAndFeel.SkinStyle("ads"));
        }

        private void acCtlEle_ThongKeSV_Click(object sender, EventArgs e)
        {
            // Nếu chưa tồn tại, tạo đối tượng mới
            if (this.UC_QLSV_TK == null)
            {
                this.UC_QLSV_TK = new UC_QLSV_ThongKe
                {
                    Dock = DockStyle.Fill
                };

                // Thêm đối tượng vừa tạo vào khu vực content container
                this.contentContainer.Controls.Add(this.UC_QLSV_TK);
                this.UC_QLSV_TK.BringToFront();
            }
            // Nếu đã tồn tại, đưa lên front để hiển thị
            else
            {
                this.UC_QLSV_TK.BringToFront();
            }
        }

        /// <summary>
        /// Lấy thông tin user và hiển thị
        /// </summary>
        private void InitUserInfo()
        {
            QL_KTXDataSet.EnforceConstraints = false;
            // Lấy data user từ [SP_GETUSERINFO]
            SP_GetUserInfoTableAdapter.Fill(QL_KTXDataSet.SP_GETUSERINFO, Program.Username);

            if(QL_KTXDataSet.SP_GETUSERINFO.Rows.Count != 0)
            {
                DataRow row = QL_KTXDataSet.SP_GETUSERINFO.Rows[0];
  
                Program.HoUser = row["HO"] as String;
                Program.TenUser = row["TEN"] as String;
                Program.MaQL = row["MAQL"] as String;
                Program.NgayNhanViec = row["NGAYNHANVIEC"].ToString();
            }

            HoTenUserLbl.Caption = Program.HoUser + " " + Program.TenUser;
            MaQLUserLbl.Caption = "     " + Program.MaQL;
        }

        private void HoTenUserLbl_ItemClick(object sender, ItemClickEventArgs e)
        {
            new UI_Control.UserInfo.UserInfo().ShowDialog();
        }

        private void acCtlEle_ThongTinVatTu_Click(object sender, EventArgs e)
        {
            // Nếu chưa tồn tại, tạo đối tượng mới
            if (this.UC_QLCSVC == null)
            {
                this.UC_QLCSVC = new UC_QuanLyCSVC
                {
                    Dock = DockStyle.Fill
                };

                // Thêm đối tượng vừa tạo vào khu vực content container
                this.contentContainer.Controls.Add(this.UC_QLCSVC);
                this.UC_QLCSVC.BringToFront();
            }
            // Nếu đã tồn tại, đưa lên front để hiển thị
            else
            {
                this.UC_QLCSVC.BringToFront();
            }
        }

        private void acCtlEle_ThongTinDien_Click(object sender, EventArgs e)
        {
            // Nếu chưa tồn tại, tạo đối tượng mới
            if (this.UC_QLD == null)
            {
                this.UC_QLD = new UC_QuanLyDien
                {
                    Dock = DockStyle.Fill
                };

                // Thêm đối tượng vừa tạo vào khu vực content container
                this.contentContainer.Controls.Add(this.UC_QLD);
                this.UC_QLD.BringToFront();
            }
            // Nếu đã tồn tại, đưa lên front để hiển thị
            else
            {
                this.UC_QLD.BringToFront();
            }
        }
    }
}
