using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using NMCNPM_QuanLyKTX.Common.Service;
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
    public partial class UC_QuanLyPhong : XtraUserControl
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
            CommonService.InitDSLoaiPhongBox(QLP_LoaiPhongCb_RepoItem, QL_KTXDataSet.LOAIPHONG);
        }

        /// <summary>
        /// Lấy data từ CSDL về DataSet
        /// </summary>
        private void FillDataFromDatabase()
        {
            QL_KTXDataSet.EnforceConstraints = false;

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.PHONG]
            PhongTableAdapter.Fill(QL_KTXDataSet.PHONG);

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.LOAIPHONG]
            LoaiPhongTableAdapter.Fill(QL_KTXDataSet.LOAIPHONG); 
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Add] thông tin phòng mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLP_Add_Btn_Click(object sender, EventArgs e)
        {
            // Click btn [Add]
            // Thêm dòng dữ liệu trống mới
            PhongBdS.AddNew();
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Save] thông tin phòng vào DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLP_Save_Btn_Click(object sender, EventArgs e)
        {
            // Click btn [Save] (Update)
            // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
            this.Validate();
            PhongBdS.EndEdit();

            // Update dữ liệu vào CSDL
            try
            {
                PhongTableAdapter.Update(QL_KTXDataSet.PHONG);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Delete] thông tin phòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLP_Delete_Btn_Click(object sender, EventArgs e)
        {
            // Xóa dòng dữ liệu hiện tại
            PhongBdS.RemoveCurrent();
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Reload] thông tin phòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLP_Reload_Btn_Click(object sender, EventArgs e)
        {
            // Click btn [Reload]
            // Lấy data từ CSDL về DataTable ql_KTX_DS.PHONG
            FillDataFromDatabase();

            // Set data cho ComboBox column [LOAIPHONG] để sử dụng
            CommonService.InitDSLoaiPhongBox(QLP_LoaiPhongCb_RepoItem, QL_KTXDataSet.LOAIPHONG);
        }
    }
}
