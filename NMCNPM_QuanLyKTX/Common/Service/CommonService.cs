using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using NMCNPM_QuanLyKTX.Common.Const;
using System;
using System.Collections.Generic;
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
    }
}
