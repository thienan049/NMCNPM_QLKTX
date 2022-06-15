using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using NMCNPM_QuanLyKTX.Common.Const;
using System;
using System.Data;
using System.Windows.Forms;

namespace NMCNPM_QuanLyKTX.Common.Service
{
    class CommonService
    {

        /// <summary>
        /// Kiểm tra chế độ sử dụng app là có/không Login
        /// </summary>
        /// <returns></returns>
        public static bool CheckAccessMode()
        {
            return Program.AccessMode == CommonConstant.LoginMode.Login;
        }

        /// <summary>
        /// Lưu lại trạng thái LookAndFeel mặc định vào Program.cs
        /// </summary>
        public static void SaveDefaultApplicationStyle()
        {
            Program.DefaultSkin = UserLookAndFeel.Default.ActiveSkinName;
            Program.DefaultPalette = UserLookAndFeel.Default.ActiveSvgPaletteName;
        }

        /// <summary>
        /// Set LookAndFeel mặc định (đã được lưu trong Program.cs)
        /// </summary>
        public static void SetDefaultApplicationStyle()
        {            
            UserLookAndFeel.Default.SetSkinStyle(Program.DefaultSkin, Program.DefaultPalette);
        }

        /// <summary>
        /// Gán mã quản lý của tài khoản hiện tại
        /// </summary>
        /// <param name="row"></param>
        public static void ApplyCurrentMaQL(DataRowView row)
        {
            row["MAQL"] = Program.MaQL;
        }

        /// <summary>
        /// Tính toán thời điểm [Năm học] và [Học kỳ] hiện tại
        /// </summary>
        /// <returns></returns>
        public static String[] CalculateNamHocHocKy()
        {
            String[] result = new String[3];

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            if (month >= 8 && month <= 12)
            {
                // [0] = NamHocTu
                result[0] = year.ToString();
                // [1] = NamHocDen
                result[1] = (year + 1).ToString();
                // [2] = HocKy
                result[2] = "1";
            }
            else if (month >= 1 && month <= 5)
            {
                // [0] = NamHoc
                result[0] = (year - 1).ToString();
                // [1] = NamHocDen
                result[1] = year.ToString();
                // [2] = HocKy
                result[1] = "2";
            }
            else
            {
                // [0] = NamHoc
                result[0] = (year - 1).ToString();
                // [1] = NamHocDen
                result[1] = year.ToString();
                // [1] = HocKy
                result[2] = "3";
            }

            return result;
        }

        /// <summary>
        /// Hiển thị màn hình ở chế độ readonly/ không login
        /// </summary>
        /// <param name="userCtl"></param>
        /// <param name="isMainScreen"></param>
        public static void InitAppNoLoginMode(GridView mainView, PanelControl actionBtnPanel)
        {  
            // Disable các buttons cần thiết
            if(actionBtnPanel != null)
            {
                foreach (Control ctl in actionBtnPanel.Controls)
                {
                    if (ctl is SimpleButton)
                    {
                        if (!(ctl as SimpleButton).Name.Contains("Reload"))
                            (ctl as SimpleButton).Enabled = false;
                    }
                }
            }
            
            // Set readonly cho EditForm
            if(mainView != null)
            {
                mainView.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;
                foreach (GridColumn col in mainView.Columns)
                {
                    col.OptionsColumn.ReadOnly = true;
                }
            }           
        }

        /// <summary>
        /// Thêm giá trị cho ComboBox [Giới tính] trong EditView
        /// </summary>
        /// <param name="comboBox"></param>
        public static void InitGenderBoxRepoItem(RepositoryItemComboBox comboBox)
        {
            foreach (string gender in CommonConstant.GioiTinh)
            {
                comboBox.Items.Add(gender);
            }
        }

        /// <summary>
        /// Thêm giá trị cho ComboBox [Giới tính] 
        /// </summary>
        /// <param name="comboBox"></param>
        public static void InitGenderBox(ComboBoxEdit comboBox, bool isUnspecified)
        {
            if (isUnspecified)
            {
                comboBox.Properties.Items.Add("--");
                foreach (string gender in CommonConstant.GioiTinh)
                {
                    comboBox.Properties.Items.Add(gender);
                }
            }
            else
            {
                foreach (string gender in CommonConstant.GioiTinh)
                {
                    comboBox.Properties.Items.Add(gender);
                }
            }         
        }

        /// <summary>
        /// Thêm giá trị cho ComboBox [Học Kỳ] trong EditView
        /// </summary>
        /// <param name="comboBox"></param>
        public static void InitHocKyBoxRepoItem(RepositoryItemComboBox comboBox)
        {
            foreach (string hk in CommonConstant.HocKy)
            {
                comboBox.Items.Add(hk);
            }
        }

        /// <summary>
        /// Thêm giá trị cho ComboBox [Học Kỳ] 
        /// </summary>
        /// <param name="comboBox"></param>
        public static void InitHocKyBox(ComboBoxEdit comboBox, bool isUnspecified)
        {
            if (isUnspecified)
            {
                comboBox.Properties.Items.Add("--");
                foreach (string hk in CommonConstant.HocKy)
                {
                    comboBox.Properties.Items.Add(hk);
                }
            }
            else
            {
                foreach (string hk in CommonConstant.HocKy)
                {
                    comboBox.Properties.Items.Add(hk);
                }
            }
        }

        /// <summary>
        /// Thêm giá trị cho ComboBox [Loại thống kê] trong EditView
        /// </summary>
        /// <param name="comboBox"></param>
        public static void InitLoaiTKBox(ComboBoxEdit comboBox)
        {
            foreach (string loaiTK in CommonConstant.LoaiThongKe)
            {
                comboBox.Properties.Items.Add(loaiTK);
            }
        }

        /// <summary>
        /// Thêm giá trị cho ComboBox [Danh sách phòng]
        /// </summary>
        /// <param name="comboBox"></param>
        public static void InitDSPhongBox(ComboBoxEdit comboBox, DataTable phongDataTable)
        {
            foreach (DataRow row in phongDataTable.Rows)
            {
                comboBox.Properties.Items.Add(row["MAPHONG"]);
            }
        }

        /// <summary>
        /// Thêm giá trị cho ComboBox [Danh sách loại phòng] trong EditView
        /// </summary>
        /// <param name="comboBox"></param>
        public static void InitDSLoaiPhongBox(RepositoryItemComboBox comboBox, DataTable loaiPhongDataTable)
        {
            foreach (DataRow row in loaiPhongDataTable.Rows)
            {
                comboBox.Items.Add(row["MALOAIPHONG"]);
            }
        }

        /// <summary>
        /// Trả về danh sách [MAPHONG] cho Autocomplete
        /// </summary>
        /// <param name="phongDataTable"></param>
        /// <returns></returns>
        public static AutoCompleteStringCollection AutoCompleteDSPhongCollection(ql_KTXDataSet.PHONGDataTable phongDataTable)
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            foreach (DataRow row in phongDataTable.Rows)
            {
                collection.Add(row["MAPHONG"] as String);
            }

            return collection;
        }

        /// <summary>
        /// Trả về danh sách [MAQL] cho Autocomplete
        /// </summary>
        /// <param name="quanLyTable"></param>
        /// <returns></returns>
        public static AutoCompleteStringCollection AutoCompleteDSQuanLyCollection(ql_KTXDataSet.QUANLYDataTable quanLyTable)
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            foreach (DataRow row in quanLyTable.Rows)
            {
                collection.Add(row["MAQL"] as String);
            }

            return collection;
        }

        /// <summary>
        /// Trả về danh sách [MAHD] cho Autocomplete
        /// </summary>
        /// <param name="hopDongTable"></param>
        /// <returns></returns>
        public static AutoCompleteStringCollection AutoCompleteDSMaHDCollection(ql_KTXDataSet.HOPDONGDataTable hopDongTable)
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            foreach (DataRow row in hopDongTable.Rows)
            {
                collection.Add(row["MAHD"] as String);
            }

            return collection;
        }

        /// <summary>
        /// Trả về danh sách [MASV] cho Autocomplete
        /// </summary>
        /// <param name="sinhVienTable"></param>
        /// <returns></returns>
        public static AutoCompleteStringCollection AutoCompleteDSMaSVCollection(ql_KTXDataSet.SINHVIENDataTable sinhVienTable)
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            foreach (DataRow row in sinhVienTable.Rows)
            {
                collection.Add(row["MASV"] as String);
            }

            return collection;
        }

        /// <summary>
        /// Trả về danh sách [NAMHOC] cho Autocomplete
        /// </summary>
        /// <returns></returns>
        public static AutoCompleteStringCollection AutoCompleteNamHocCollection()
        {
            int namHoc = 2010;

            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            while(namHoc <= 2025)
            {
                collection.Add(namHoc.ToString() + "-" + (++namHoc).ToString());
            }

            return collection;
        }       
    }
}
