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

namespace NMCNPM_QuanLyKTX.UI_Control.QLP
{
    public partial class UC_QuanLyLoaiPhong : XtraUserControl
    {
        // Kiểm tra trạng thái đóng mở của CustomViewSetting SidePanel
        private bool isSidePaneCollapsed = true;

        public UC_QuanLyLoaiPhong()
        {
            InitializeComponent();
        }

        private void UC_QuanLyPhong_Load(object sender, EventArgs e)
        {
            // Lấy data từ CSDL
            FillDataFromDatabase();           

            // Kiểm tra chế độ sử dụng app là có/không Login
            if (!CommonService.CheckAccessMode())
                CommonService.InitAppNoLoginMode(QLLP_View_GridView, QLLP_ActionBtn_Panel);
        }

        /// <summary>
        /// Lấy data từ CSDL về DataSet
        /// </summary>
        private void FillDataFromDatabase()
        {
            QL_KTXDataSet.EnforceConstraints = false;

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.LOAIPHONG]
            LoaiPhongTableAdapter.Fill(QL_KTXDataSet.LOAIPHONG);
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Add] thông tin phòng mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLLP_Add_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Click btn [Add]
                // Thêm dòng dữ liệu trống mới
                DataRowView newRow = (DataRowView)LoaiPhongBdS.AddNew();
                QL_KTXDataSet.LOAIPHONG.Rows.InsertAt(newRow.Row, 0);
                LoaiPhongBdS.Position = 0;

                QLLP_View_GridView.ShowEditForm();
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
        private void QLLP_Save_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Lưu dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Save (Update)
                // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
                this.Validate();

                LoaiPhongBdS.EndEdit();
                // Update dữ liệu vào CSDL
                this.LoaiPhongTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    LoaiPhongTableAdapter.Update(QL_KTXDataSet.LOAIPHONG);

                    XtraMessageBox.Show("Lưu dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                        XtraMessageBox.Show("Lỗi: Không thể trùng lặp mã!", "Thông báo");
                    LoaiPhongBdS.CancelEdit();
                }
            }
            else if (confirm == DialogResult.No)
            {
                LoaiPhongBdS.CancelEdit();
            }
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Delete] thông tin phòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLLP_Delete_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Xóa dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Delete
                // Xóa dòng dữ liệu hiện tại
                LoaiPhongBdS.RemoveCurrent();
                LoaiPhongBdS.EndEdit();
                try
                {
                    LoaiPhongTableAdapter.Update(QL_KTXDataSet.LOAIPHONG);

                    XtraMessageBox.Show("Xóa dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        XtraMessageBox.Show("Lỗi: Không thể xóa vì phòng còn được sử dụng!", "Thông báo");
                    LoaiPhongBdS.CancelEdit();
                    QL_KTXDataSet.LOAIPHONG.RejectChanges();
                    LoaiPhongBdS.MovePrevious();
                }
            }
            else if (confirm == DialogResult.No)
            {
                LoaiPhongBdS.CancelEdit();
            }
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Reload] thông tin phòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLLP_Reload_Btn_Click(object sender, EventArgs e)
        {
            // Click btn [Reload]
            // Lấy data từ CSDL về DataTable ql_KTX_DS.LOAIPHONG
            FillDataFromDatabase();
        }

        /// <summary>
        /// Toggle open/close custom DetailViewSetting side panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLLP_CustomViewSettingBtn_Click(object sender, EventArgs e)
        {
            // Nếu SidePanel là đóng, mở ra và hiển thị các lựa chọn
            if (isSidePaneCollapsed)
            {
                QLLP_CustomViewSettingSidePane.Width = 75;
                QLLP_CVSControlsPanel.Visible = true;
                isSidePaneCollapsed = false;
            }
            // Nếu SidePanel là mở, đóng lại và ẩn các lựa chọn
            else
            {
                QLLP_CustomViewSettingSidePane.Width = 30;
                QLLP_CVSControlsPanel.Visible = false;
                // Chỉ ẩn các lựa chọn custom khi ToggleSwitch là [Off]
                if (!QLLP_CVSToggleSwitch.IsOn)
                    QLLP_CVSMainControlsPanel.Visible = false;
                isSidePaneCollapsed = true;
            }
        }

        /// <summary>
        /// Toggle áp dụng/không áp dụng tính năng phân chia [EvenRow/OddRow]
        /// Nếu có áp dụng, cung cấp thêm các lựa chọn cho việc custom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLLP_CVSToggleSwitch_Toggled(object sender, EventArgs e)
        {
            /*
             * Nếu ToggleSwitch là [On] -> có áp dụng [EvenRow/OddRow]
             * Hiển thị các lựa chọn custom
             * Nếu ToggleSwitch là [Off] -> không áp dụng [EvenRow/OddRow]
             * Không hiển thị các lựa chọn custom
             */
            if (QLLP_CVSToggleSwitch.IsOn)
            {
                QLLP_CVSMainControlsPanel.Visible = true;

                // Áp dụng [AppearanceOddRow] (Mặc đinh)
                QLLP_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                QLLP_CVSMainControlsPanel.Visible = false;

                // Hủy áp dụng [AppearanceOddRow]
                if (QLLP_View_GridView.OptionsView.EnableAppearanceOddRow)
                    QLLP_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                // Hủy áp dụng [AppearanceEvenRow]
                if (QLLP_View_GridView.OptionsView.EnableAppearanceEvenRow)
                    QLLP_View_GridView.OptionsView.EnableAppearanceEvenRow = false; ;
            }
        }

        /// <summary>
        /// Nếu có áp dụng [EvenRow/OddRow]
        /// Cho phép lựa chọn [EvenRow] hoặc [OddRow]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLLP_CVSRowStyleBtn_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e.Button == QLLP_CVSRowStyleBtn.Buttons[0])
            {
                // Áp dụng [OddRow]
                QLLP_View_GridView.OptionsView.EnableAppearanceEvenRow = false;
                QLLP_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                // Áp dụng [EvenRow]
                QLLP_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                QLLP_View_GridView.OptionsView.EnableAppearanceEvenRow = true;
            }
        }

        /// <summary>
        /// Set màu được chọn cho [OddRow/EvenRow] nếu đang được áp dụng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLLP_CVSColorPickEdit_EditValueChanged(object sender, EventArgs e)
        {
            ColorPickEdit cVSColorPickEdit = sender as ColorPickEdit;
            QLLP_View_GridView.Appearance.OddRow.BackColor = cVSColorPickEdit.Color;
            QLLP_View_GridView.Appearance.EvenRow.BackColor = cVSColorPickEdit.Color;
        }

        private void QLLP_CancelEdit_Btn_Click(object sender, EventArgs e)
        {
            LoaiPhongBdS.CancelEdit();
            try
            {
                if (QL_KTXDataSet.LOAIPHONG.Rows[0].RowState == DataRowState.Added)
                    LoaiPhongBdS.RemoveAt(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo");
            }
        }
    }
}
