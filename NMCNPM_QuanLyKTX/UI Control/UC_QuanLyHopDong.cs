using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NMCNPM_QuanLyKTX.UI_Control
{
    public partial class UC_QuanLyHopDong : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_QuanLyHopDong()
        {
            InitializeComponent();
        }

        private void UC_QuanLyHopDong_Load(object sender, EventArgs e)
        {
            // Lấy data từ CSDL
            FillDataFromDatabase();

            // Set data cho ComboBox column [HOCKY] để sử dụng
            ApplyPredefinedDataToControl();
        }

        /// <summary>
        /// Lấy data từ CSDL về DataSet
        /// </summary>
        private void FillDataFromDatabase()
        {
            ql_KTX_DS.EnforceConstraints = false;

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.HOPDONG]
            hopDongTableAdapter.Fill(ql_KTX_DS.HOPDONG);
        }

        /// <summary>
        /// Thực hiện thêm các data có sẵn vào control cần sử dụng
        /// </summary>
        private void ApplyPredefinedDataToControl()
        {
            // Thêm data cho control [ComboBox] cột [HOCKY]
            hocKyCbBoxCol.Items.Add("1");
            hocKyCbBoxCol.Items.Add("2");
            hocKyCbBoxCol.Items.Add("3");


            hocKyCbBoxCol.TextEditStyle = TextEditStyles.DisableTextEditor;
        }
    }
}
