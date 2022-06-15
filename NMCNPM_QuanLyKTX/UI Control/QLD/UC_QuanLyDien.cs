using DevExpress.XtraBars.Docking2010;
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

namespace NMCNPM_QuanLyKTX.UI_Control.QLD
{
    public partial class UC_QuanLyDien : XtraUserControl
    {
        // Kiểm tra trạng thái đóng mở của CustomViewSetting SidePanel
        private bool isSidePaneCollapsed = true;

        public UC_QuanLyDien()
        {
            InitializeComponent();
        }

        private void UC_QuanLyPhong_Load(object sender, EventArgs e)
        {
            // Lấy data từ CSDL
            FillDataFromDatabase();

            // Set data cho ComboBox column [LOAIPHONG] để sử dụng
            //CommonService.InitDSLoaiPhongBox(QLD_LoaiPhongCb_RepoItem, QL_KTXDataSet.LOAIPHONG);
            // Kiểm tra chế độ sử dụng app là có/không Login
            if (!CommonService.CheckAccessMode())
                CommonService.InitAppNoLoginMode(QLD_View_GridView, QLD_ActionBtn_Panel);
        }

        /// <summary>
        /// Lấy data từ CSDL về DataSet
        /// </summary>
        private void FillDataFromDatabase()
        {
            QL_KTXDataSet.EnforceConstraints = false;

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.PHONG]
            HoaDonDienTableAdapter.Fill(QL_KTXDataSet.HOADONDIEN);

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.LOAIPHONG]
            //LoaiHoaDonDienTableAdapter.Fill(QL_KTXDataSet.LOAIPHONG); 
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Add] thông tin phòng mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLD_Add_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Click btn [Add]
                // Thêm dòng dữ liệu trống mới
                DataRowView newRow = (DataRowView)HoaDonDienBdS.AddNew();
                QL_KTXDataSet.HOADONDIEN.Rows.InsertAt(newRow.Row, 0);
                HoaDonDienBdS.Position = 0;

                CommonService.ApplyCurrentMaQL(newRow);
                QLD_View_GridView.ShowEditForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi");
            }
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Save] thông tin phòng vào DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLD_Save_Btn_Click(object sender, EventArgs e)
        {
            // Click btn [Save] (Update)
            // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
            this.Validate();
            HoaDonDienBdS.EndEdit();

            // Update dữ liệu vào CSDL
            try
            {
                HoaDonDienTableAdapter.Update(QL_KTXDataSet.HOADONDIEN);
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
        private void QLD_Delete_Btn_Click(object sender, EventArgs e)
        {
            // Xóa dòng dữ liệu hiện tại
            HoaDonDienBdS.RemoveCurrent();
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Reload] thông tin phòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLD_Reload_Btn_Click(object sender, EventArgs e)
        {
            // Click btn [Reload]
            // Lấy data từ CSDL về DataTable ql_KTX_DS.PHONG
            FillDataFromDatabase();

            // Set data cho ComboBox column [LOAIPHONG] để sử dụng
           // CommonService.InitDSLoaiPhongBox(QLD_LoaiPhongCb_RepoItem, QL_KTXDataSet.LOAIPHONG);
        }

        /// <summary>
        /// Toggle open/close custom DetailViewSetting side panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLD_CustomViewSettingBtn_Click(object sender, EventArgs e)
        {
            // Nếu SidePanel là đóng, mở ra và hiển thị các lựa chọn
            if (isSidePaneCollapsed)
            {
                QLD_CustomViewSettingSidePane.Width = 75;
                QLD_CVSControlsPanel.Visible = true;
                isSidePaneCollapsed = false;
            }
            // Nếu SidePanel là mở, đóng lại và ẩn các lựa chọn
            else
            {
                QLD_CustomViewSettingSidePane.Width = 30;
                QLD_CVSControlsPanel.Visible = false;
                // Chỉ ẩn các lựa chọn custom khi ToggleSwitch là [Off]
                if (!QLD_CVSToggleSwitch.IsOn)
                    QLD_CVSMainControlsPanel.Visible = false;
                isSidePaneCollapsed = true;
            }
        }

        /// <summary>
        /// Toggle áp dụng/không áp dụng tính năng phân chia [EvenRow/OddRow]
        /// Nếu có áp dụng, cung cấp thêm các lựa chọn cho việc custom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLD_CVSToggleSwitch_Toggled(object sender, EventArgs e)
        {
            /*
             * Nếu ToggleSwitch là [On] -> có áp dụng [EvenRow/OddRow]
             * Hiển thị các lựa chọn custom
             * Nếu ToggleSwitch là [Off] -> không áp dụng [EvenRow/OddRow]
             * Không hiển thị các lựa chọn custom
             */
            if (QLD_CVSToggleSwitch.IsOn)
            {
                QLD_CVSMainControlsPanel.Visible = true;

                // Áp dụng [AppearanceOddRow] (Mặc đinh)
                QLD_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                QLD_CVSMainControlsPanel.Visible = false;

                // Hủy áp dụng [AppearanceOddRow]
                if (QLD_View_GridView.OptionsView.EnableAppearanceOddRow)
                    QLD_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                // Hủy áp dụng [AppearanceEvenRow]
                if (QLD_View_GridView.OptionsView.EnableAppearanceEvenRow)
                    QLD_View_GridView.OptionsView.EnableAppearanceEvenRow = false; ;
            }
        }

        /// <summary>
        /// Nếu có áp dụng [EvenRow/OddRow]
        /// Cho phép lựa chọn [EvenRow] hoặc [OddRow]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLD_CVSRowStyleBtn_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e.Button == QLD_CVSRowStyleBtn.Buttons[0])
            {
                // Áp dụng [OddRow]
                QLD_View_GridView.OptionsView.EnableAppearanceEvenRow = false;
                QLD_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                // Áp dụng [EvenRow]
                QLD_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                QLD_View_GridView.OptionsView.EnableAppearanceEvenRow = true;
            }
        }

        /// <summary>
        /// Set màu được chọn cho [OddRow/EvenRow] nếu đang được áp dụng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLD_CVSColorPickEdit_EditValueChanged(object sender, EventArgs e)
        {
            ColorPickEdit cVSColorPickEdit = sender as ColorPickEdit;
            QLD_View_GridView.Appearance.OddRow.BackColor = cVSColorPickEdit.Color;
            QLD_View_GridView.Appearance.EvenRow.BackColor = cVSColorPickEdit.Color;
        }

        private void QLD_CancelEdit_Btn_Click(object sender, EventArgs e)
        {
            HoaDonDienBdS.CancelEdit();
            try
            {
                if (QL_KTXDataSet.HOADONDIEN.Rows[0].RowState == DataRowState.Added)
                    HoaDonDienBdS.RemoveAt(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo");
            }
        }
    }
}
