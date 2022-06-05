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
    public partial class UC_QuanLyPhong : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_QuanLyPhong()
        {
            InitializeComponent();
        }

        private void UC_QuanLyPhong_Load(object sender, EventArgs e)
        {
            // Lấy data từ CSDL
            FillDataFromDatabase();

            // Set data cho ComboBox column [LOAIPHONG] để sử dụng
            ApplyPredefinedDataToControl();
        }

        /// <summary>
        /// Xử lý khi nhấn các buttons trong [qlp_ActionBtnPanel]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qlp_ActionBtnPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            // Click btn [Add]
            if (e.Button == qlp_ActionBtnPanel.Buttons[0])
            {
                // Thêm dòng dữ liệu trống mới
                phongBdS.AddNew();
            }
            // Click btn [Save] (Update)
            else if (e.Button == qlp_ActionBtnPanel.Buttons[1])
            {
                // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
                this.Validate();
                phongBdS.EndEdit();

                // Update dữ liệu vào CSDL
                try
                {
                    phongTableAdapter.Update(ql_KTX_DS.PHONG);
                }
                catch (System.Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
            // Click btn [Delete]
            else
            {
                // Xóa dòng dữ liệu hiện tại
                phongBdS.RemoveCurrent();

                // Update dữ liệu vào CSDL
                try
                {
                    phongTableAdapter.Update(ql_KTX_DS.PHONG);
                }
                catch (System.Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Xử lý khi nhấn các button trong [qlp_ActionBtnPanel2]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qlp_ActionBtnPanel2_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            // Click btn [Reload]
            if (e.Button == qlp_ActionBtnPanel2.Buttons[0])
            {
                // Lấy data từ CSDL về DataTable ql_KTX_DS.PHONG
                FillDataFromDatabase();

                // Set data cho ComboBox column [LOAIPHONG] để sử dụng
                ApplyPredefinedDataToControl();
            }
        }

        /// <summary>
        /// Get danh sách các loại phòng hiện có
        /// </summary>
        private List<string> GetListLoaiPhong()
        {
            DataRowCollection tableRows = ql_KTX_DS.LOAIPHONG.Rows;

            List<string> listLP = new List<string>(tableRows.Count);

            foreach (DataRow row in tableRows)
                listLP.Add((string)row[0]);

            return listLP;
        }

        /// <summary>
        /// Lấy data từ CSDL về DataSet
        /// </summary>
        private void FillDataFromDatabase()
        {
            ql_KTX_DS.EnforceConstraints = false;

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.PHONG]
            phongTableAdapter.Fill(ql_KTX_DS.PHONG);

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.LOAIPHONG]
            loaiPhongTableAdapter.Fill(ql_KTX_DS.LOAIPHONG);
        }

        /// <summary>
        /// Thực hiện thêm các data có sẵn vào control cần sử dụng
        /// </summary>
        private void ApplyPredefinedDataToControl()
        {
            // Thêm data cho control [ComboBox] cột [LOAIPHONG]
            List<string> listLP = GetListLoaiPhong();
            loaiPhongCbBoxCol.Items.Clear();
            foreach (string item in listLP)
            {               
                loaiPhongCbBoxCol.Items.Add(item);
            }

            loaiPhongCbBoxCol.TextEditStyle = TextEditStyles.DisableTextEditor;
        }
    }
}
