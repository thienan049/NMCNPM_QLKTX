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

        /// <summary>
        /// Xử lý khi nhấn các button trong qlhd_ActionBtnPanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qlhd_ActionBtnPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            // Click btn Add
            if (e.Button == qlhd_ActionBtnPanel.Buttons[0])
            {
                // Thêm dòng dữ liệu trống mới
                hopDongBdS.AddNew();
            }
            // Click btn Save (Update)
            else if (e.Button == qlhd_ActionBtnPanel.Buttons[1])
            {
                // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
                this.Validate();
                hopDongBdS.EndEdit();

                // Update dữ liệu vào CSDL
                //this.userTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    hopDongTableAdapter.Update(ql_KTX_DS.HOPDONG);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            // Click btn Delete
            else
            {
                // Xóa dòng dữ liệu hiện tại
                hopDongBdS.RemoveCurrent();

                // Update dữ liệu vào CSDL
                //sinhVienTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    hopDongTableAdapter.Update(ql_KTX_DS.HOPDONG);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Xử lý khi nhấn các button trong qlhd_ActionBtnPanel2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qlhd_ActionBtnPanel2_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            // Click btn Reload
            if (e.Button == qlhd_ActionBtnPanel2.Buttons[0])
            {
                // Lấy data từ CSDL về DataTable ql_KTX_DS.HOPDONG
                FillDataFromDatabase();
            }
        }
    }
}
