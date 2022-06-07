using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using NMCNPM_QuanLyKTX.Common.Const;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMCNPM_QuanLyKTX.Common.Service
{
    class CommonService
    {
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
        /// Tạo câu query phục vụ tìm kiếm trong DataTable
        /// </summary>
        /// <param name="paramsMap"></param>
        /// <returns></returns>
        public String MakeFilterCondition(Dictionary<String, object> paramsMap)
        {
            String filterCondition = "";

            if(paramsMap != null && paramsMap.Count != 0)
            {
                foreach (KeyValuePair<String, object> cond in paramsMap)
                {
                    filterCondition += cond.Key + "LIKE %" + cond.Value + "%"; 
                }
            }

            return filterCondition;
        }
    }
}
