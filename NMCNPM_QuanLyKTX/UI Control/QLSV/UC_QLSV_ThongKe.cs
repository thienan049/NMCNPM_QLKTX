using DevExpress.XtraEditors;
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

namespace NMCNPM_QuanLyKTX.UI_Control.QLSV
{
    public partial class UC_QLSV_ThongKe : UserControl
    {
        DataView thongKeDataView = null;

        public UC_QLSV_ThongKe()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load form thống kê của QLSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_QLSV_ThongKe_Load(object sender, EventArgs e)
        {
            QLSV_TKSV_GridControl.Dock = DockStyle.Fill;
            QLSV_TKSV_GridControl.BringToFront();
            CommonService.InitLoaiTKBox(QLSV_LoaiThongKeCb);
        }

        /// <summary>
        /// Xử lý khi nhấn search theo filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLSV_btnSearchTK_Click(object sender, EventArgs e)
        {
            // Nếu đã chọn loại thống kê
            if(QLSV_LoaiThongKeCb.SelectedItem != null)
            {
                // Lấy data từ CSDL
                FillDataFromDatabase();

                // Nếu chọn thống kê [Sinh viên vi phạm]
                if (QLSV_LoaiThongKeCb.SelectedItem.Equals("Sinh viên vi phạm"))
                {
                    // Điều kiện lọc ra DataView của DataTable [SINHVIEN] để hiển thị
                    // (Lọc ra những SV vi phạm nội quy/DataView chứa các sinh viên vi phạm nội quy)
                    String condition = "VIPHAMNOIQUY <> '' OR VIPHAMNOIQUY <> NULL";
                    thongKeDataView = new DataView(QL_KTXDataSet.SINHVIEN);
                    thongKeDataView.RowFilter = condition;
                    // Setting DataSource của BindingSource là DataView đã lọc
                    SinhVienBdS.DataSource = thongKeDataView;

                    // Hiển thị GridView chứa danh sách sinh viên
                    QLSV_TKSV_GridControl.Dock = DockStyle.Fill;
                    QLSV_TKSV_GridControl.BringToFront();
                }
                // Nếu chọn thống kê [Sinh viên theo phòng]
                else if (QLSV_LoaiThongKeCb.SelectedItem.Equals("Sinh viên theo phòng"))
                {
                    // Lấy data sinh viên theo phòng từ DB
                    SP_SinhVienTheoPhongTableAdapter.Fill(QL_KTXDataSet.SP_SINHVIENTHEOPHONG, QLSV_TenPhongCb.Text.Trim());
                    
                    // Hiển thị GridView chứa danh sách sinh viên
                    QLSV_TKSV_SVTP_GridControl.Dock = DockStyle.Fill;
                    QLSV_TKSV_SVTP_GridControl.BringToFront();
                }
            }           
        }

        /// <summary>
        /// Lấy data từ CSDL về DataSet
        /// </summary>
        private void FillDataFromDatabase()
        {
            QL_KTXDataSet.EnforceConstraints = false;

            // Lấy data từ CSDL về DataTable [QL_KTXDataSet.SINHVIEN]
            SinhVienTableAdapter.Fill(QL_KTXDataSet.SINHVIEN);
            //HopDongTableAdapter.Fill(QL_KTXDataSet.HOPDONG);
        }

        private void QLSV_TKSV_View_GridView_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {

        }

        private void QLSV_LoaiThongKeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (QLSV_LoaiThongKeCb.SelectedItem.Equals("Sinh viên vi phạm"))
            {
                QLSV_TenPhongCb.Enabled = false;
            }
            else if (QLSV_LoaiThongKeCb.SelectedItem.Equals("Sinh viên theo phòng"))
            {
                QL_KTXDataSet.EnforceConstraints = false;
                PhongTableAdapter.Fill(QL_KTXDataSet.PHONG);
                CommonService.InitDSPhongBox(QLSV_TenPhongCb, QL_KTXDataSet.PHONG);
                QLSV_TenPhongCb.Enabled = true;
            }
        }
    }
}
