using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using NMCNPM_QuanLyKTX.Common.Const;
using NMCNPM_QuanLyKTX.Common.Service;
using NMCNPM_QuanLyKTX.UI_Control.QLCSVC;
using NMCNPM_QuanLyKTX.UI_Control.QLD;
using NMCNPM_QuanLyKTX.UI_Control.QLHD;
using NMCNPM_QuanLyKTX.UI_Control.QLP;
using NMCNPM_QuanLyKTX.UI_Control.QLSV;
using NMCNPM_QuanLyKTX.UI_Control.QLTK;
using NMCNPM_QuanLyKTX.UI_Control.Setting;
using NMCNPM_QuanLyKTX.UI_Control.UserInfo;
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

        bool controlElementDisabled = false;

        // QuanLySinhVien user control
        UC_QuanLySinhVien UC_QLSV = null;

        // QuanLySinhVien_ThongKe user control
        UC_QLSV_ThongKe UC_QLSV_TK = null;

        // QuanLyHopDong user control
        UC_QuanLyHopDong UC_QLHD = null;

        // QuanLyPhong user control
        UC_QuanLyPhong UC_QLP = null;

        // QuanLyLoaiPhong user control
        UC_QuanLyLoaiPhong UC_QLLP = null;

        // QuanLyTaiKhoan user control
        UC_QuanLyTaiKhoan UC_QLTK = null;

        // QuanLyTaiKhoan user control
        UC_CapQuyenTaiKhoan UC_CQTK = null;

        // QuanLyCSVC user control
        UC_QuanLyCSVC UC_QLCSVC = null;

        // QuanLyVT_Phong user control
        UC_QuanLyVT_Phong UC_QLVT_P = null;

        // QuanLyDien user control
        UC_QuanLyDien UC_QLD = null;

        // QuanLyMaQL user control
        UC_QuanLyMaQL UC_QLMQL = null;

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

            if (CommonService.CheckAccessMode())
            {
                InitUserInfo(false);
                InitUserPrivilege(false);
            }
            else
            {
                InitUserPrivilege(true);
                InitUserInfo(true);
            }
            
            InitCurrentWorkingTime();          
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

        private void acCtlEle_ThongTinVatTu_Phong_Click(object sender, EventArgs e)
        {
            // Nếu chưa tồn tại, tạo đối tượng mới
            if (this.UC_QLVT_P == null)
            {
                this.UC_QLVT_P = new UC_QuanLyVT_Phong
                {
                    Dock = DockStyle.Fill
                };

                // Thêm đối tượng vừa tạo vào khu vực content container
                this.contentContainer.Controls.Add(this.UC_QLVT_P);
                this.UC_QLVT_P.BringToFront();
            }
            // Nếu đã tồn tại, đưa lên front để hiển thị
            else
            {
                this.UC_QLVT_P.BringToFront();
            }
        }

        private List<String> GetUserPermissionList()
        {

            List<String> Permissions = new List<string>();

            QL_KTXDataSet.EnforceConstraints = false;

            SP_GetUserPermissionTableAdapter.Fill(QL_KTXDataSet.SP_GETUSERPERMISSION, Program.Username);

            if (QL_KTXDataSet.SP_GETUSERPERMISSION.Rows.Count != 0)
            {
                foreach (DataRow row in QL_KTXDataSet.SP_GETUSERPERMISSION.Rows)
                {
                    Permissions.Add(row["MAPMS"].ToString().Trim());
                }
            }

            return Permissions;
        }

        /// <summary>
        /// Lấy thông tin user và hiển thị
        /// </summary>
        private void InitUserInfo(bool noLogin)
        {
            if (!noLogin)
            {
                QL_KTXDataSet.EnforceConstraints = false;
                // Lấy data user từ [SP_GETUSERINFO]
                SP_GetUserInfoTableAdapter.Fill(QL_KTXDataSet.SP_GETUSERINFO, Program.Username);

                if (QL_KTXDataSet.SP_GETUSERINFO.Rows.Count != 0)
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
            else
            {
                HoTenUserLbl.Caption = "No user";
                MaQLUserLbl.Caption = String.Empty;
            }

        }

        /// <summary>
        /// Hiển thị thông tin năm học - học kỳ
        /// </summary>
        private void InitCurrentWorkingTime()
        {
            // Lấy thông tin năm học và học kỳ
            String[] namHocHK = CommonService.CalNamHocHocKy();

            if (namHocHK.Length != 0)
            {
                NamHocVal.Caption = namHocHK[0] + " - " + namHocHK[1];
                HocKyVal.Caption = namHocHK[2];
            }
        }

        /// <summary>
        /// Hiển thị theo phân quyền
        /// </summary>
        private void InitUserPrivilege(bool noLogin)
        {
            if (!noLogin)
            {
                List<String> pms = GetUserPermissionList();
                foreach (String detailPMS in pms)
                {
                    if (!detailPMS.Equals(CommonConstant.MaPMS.A))
                    {
                        if (!controlElementDisabled)
                            DisableAllOptions();
                        if (detailPMS.Equals(CommonConstant.MaPMS.VTP))
                        {
                            acCtlQuanLyCSVC.Enabled = true;
                            acCtlEle_ThongTinVatTu_Phong.Enabled = true;
                        }
                        else if (detailPMS.Equals(CommonConstant.MaPMS.P))
                        {
                            acCtlQuanLyPhong.Enabled = true;
                            acCtlEle_ThongTinPhong.Enabled = true;
                        }
                        else if (detailPMS.Equals(CommonConstant.MaPMS.HDD))
                        {
                            acCtlQuanLyDien.Enabled = true;
                            acCtlEle_ThongTinDien.Enabled = true;
                        }
                        else if (detailPMS.Equals(CommonConstant.MaPMS.HD))
                        {
                            acCtlQuanLyHopDong.Enabled = true;
                            acCtlEle_ThongTinHD.Enabled = true;
                        }
                        else if (detailPMS.Equals(CommonConstant.MaPMS.SV))
                        {
                            acCtlQuanLySinhVien.Enabled = true;
                            acCtlEle_ThongTinSV.Enabled = true;
                            acCtlEle_ThongKeSV.Enabled = true;
                        }
                        else if (detailPMS.Equals(CommonConstant.MaPMS.VT))
                        {
                            acCtlQuanLyCSVC.Enabled = true;
                            acCtlEle_ThongTinVatTu.Enabled = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                acCtlQuanLyTaiKhoan.Enabled = false;
            }                                 
        }

        /// <summary>
        /// Hiển thị chi tiết thông tin user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HoTenUserLbl_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CommonService.CheckAccessMode())
                new UI_Control.UserInfo.UserInfo().ShowDialog();
        }

        private void DisableAllOptions()
        {
            foreach(AccordionControlElement ctl in accCtlSidebar.GetElements())
            {
                ctl.Enabled = false;
            }
            controlElementDisabled = true;
        }

        private void acCtlEle_CapQuyenTaiKhoan_Click(object sender, EventArgs e)
        {
            // Nếu chưa tồn tại, tạo đối tượng mới
            if (this.UC_CQTK == null)
            {
                this.UC_CQTK = new UC_CapQuyenTaiKhoan
                {
                    Dock = DockStyle.Fill
                };

                // Thêm đối tượng vừa tạo vào khu vực content container
                this.contentContainer.Controls.Add(this.UC_CQTK);
                this.UC_CQTK.BringToFront();
            }
            // Nếu đã tồn tại, đưa lên front để hiển thị
            else
            {
                this.UC_CQTK.BringToFront();
            }
        }

        private void acCtlEle_ThongTinLoaiPhong_Click(object sender, EventArgs e)
        {
            // Nếu chưa tồn tại, tạo đối tượng mới
            if (this.UC_QLLP == null)
            {
                this.UC_QLLP = new UC_QuanLyLoaiPhong
                {
                    Dock = DockStyle.Fill
                };

                // Thêm đối tượng vừa tạo vào khu vực content container
                this.contentContainer.Controls.Add(this.UC_QLLP);
                this.UC_QLLP.BringToFront();
            }
            // Nếu đã tồn tại, đưa lên front để hiển thị
            else
            {
                this.UC_QLLP.BringToFront();
            }
        }

        private void acCtlEle_MaQuanly_Click(object sender, EventArgs e)
        {
            // Nếu chưa tồn tại, tạo đối tượng mới
            if (this.UC_QLMQL == null)
            {
                this.UC_QLMQL = new UC_QuanLyMaQL
                {
                    Dock = DockStyle.Fill
                };

                // Thêm đối tượng vừa tạo vào khu vực content container
                this.contentContainer.Controls.Add(this.UC_QLMQL);
                this.UC_QLMQL.BringToFront();
            }
            // Nếu đã tồn tại, đưa lên front để hiển thị
            else
            {
                this.UC_QLMQL.BringToFront();
            }
        }

        private void Logout_Btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Restart();
        }
    }
}
