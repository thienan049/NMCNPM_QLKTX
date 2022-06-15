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

namespace NMCNPM_QuanLyKTX.UI_Control.QLCSVC
{
    public partial class UC_QuanLyVT_Phong: XtraUserControl
    {
        // Kiểm tra trạng thái đóng mở của CustomViewSetting SidePanel
        private bool isSidePaneCollapsed = true;

        public UC_QuanLyVT_Phong()
        {
            InitializeComponent();
        }

        private void UC_QuanLyPhong_Load(object sender, EventArgs e)
        {
            // Lấy data từ CSDL
            FillDataFromDatabase();

            // Kiểm tra chế độ sử dụng app là có/không Login
            if (!CommonService.CheckAccessMode())
                CommonService.InitAppNoLoginMode(QLVT_P_View_GridView, QLVT_P_ActionBtn_Panel);
        }

        /// <summary>
        /// Lấy data từ CSDL về DataSet
        /// </summary>
        private void FillDataFromDatabase()
        {
            QL_KTXDataSet.EnforceConstraints = false;

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.PHONG]
            VatTu_PhongTableAdapter.Fill(QL_KTXDataSet.VT_PHONG);

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.LOAIPHONG]
            //LoaiVatTu_PhongTableAdapter.Fill(QL_KTXDataSet.LOAIPHONG); 
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Add] thông tin phòng mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLVT_P_Add_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Click btn [Add]
                // Thêm dòng dữ liệu trống mới
                DataRowView newRow = (DataRowView)VatTu_PhongBdS.AddNew();
                QL_KTXDataSet.VT_PHONG.Rows.InsertAt(newRow.Row, 0);
                VatTu_PhongBdS.Position = 0;

                newRow["TIENNO"] = false;
                QLVT_P_View_GridView.ShowEditForm();
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
        private void QLVT_P_Save_Btn_Click(object sender, EventArgs e)
        {
            // Click btn [Save] (Update)
            // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
            this.Validate();
            VatTu_PhongBdS.EndEdit();

            // Update dữ liệu vào CSDL
            try
            {
                VatTu_PhongTableAdapter.Update(QL_KTXDataSet.VT_PHONG);
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
        private void QLVT_P_Delete_Btn_Click(object sender, EventArgs e)
        {
            // Xóa dòng dữ liệu hiện tại
            VatTu_PhongBdS.RemoveCurrent();
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Reload] thông tin phòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLVT_P_Reload_Btn_Click(object sender, EventArgs e)
        {
            // Click btn [Reload]
            // Lấy data từ CSDL về DataTable ql_KTX_DS.PHONG
            FillDataFromDatabase();

            // Set data cho ComboBox column [LOAIPHONG] để sử dụng
           // CommonService.InitDSLoaiPhongBox(QLVT_P_LoaiPhongCb_RepoItem, QL_KTXDataSet.LOAIPHONG);
        }

        /// <summary>
        /// Toggle open/close custom DetailViewSetting side panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLVT_P_CustomViewSettingBtn_Click(object sender, EventArgs e)
        {
            // Nếu SidePanel là đóng, mở ra và hiển thị các lựa chọn
            if (isSidePaneCollapsed)
            {
                QLVT_P_CustomViewSettingSidePane.Width = 75;
                QLVT_P_CVSControlsPanel.Visible = true;
                isSidePaneCollapsed = false;
            }
            // Nếu SidePanel là mở, đóng lại và ẩn các lựa chọn
            else
            {
                QLVT_P_CustomViewSettingSidePane.Width = 30;
                QLVT_P_CVSControlsPanel.Visible = false;
                // Chỉ ẩn các lựa chọn custom khi ToggleSwitch là [Off]
                if (!QLVT_P_CVSToggleSwitch.IsOn)
                    QLVT_P_CVSMainControlsPanel.Visible = false;
                isSidePaneCollapsed = true;
            }
        }

        /// <summary>
        /// Toggle áp dụng/không áp dụng tính năng phân chia [EvenRow/OddRow]
        /// Nếu có áp dụng, cung cấp thêm các lựa chọn cho việc custom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLVT_P_CVSToggleSwitch_Toggled(object sender, EventArgs e)
        {
            /*
             * Nếu ToggleSwitch là [On] -> có áp dụng [EvenRow/OddRow]
             * Hiển thị các lựa chọn custom
             * Nếu ToggleSwitch là [Off] -> không áp dụng [EvenRow/OddRow]
             * Không hiển thị các lựa chọn custom
             */
            if (QLVT_P_CVSToggleSwitch.IsOn)
            {
                QLVT_P_CVSMainControlsPanel.Visible = true;

                // Áp dụng [AppearanceOddRow] (Mặc đinh)
                QLVT_P_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                QLVT_P_CVSMainControlsPanel.Visible = false;

                // Hủy áp dụng [AppearanceOddRow]
                if (QLVT_P_View_GridView.OptionsView.EnableAppearanceOddRow)
                    QLVT_P_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                // Hủy áp dụng [AppearanceEvenRow]
                if (QLVT_P_View_GridView.OptionsView.EnableAppearanceEvenRow)
                    QLVT_P_View_GridView.OptionsView.EnableAppearanceEvenRow = false; ;
            }
        }

        /// <summary>
        /// Nếu có áp dụng [EvenRow/OddRow]
        /// Cho phép lựa chọn [EvenRow] hoặc [OddRow]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLVT_P_CVSRowStyleBtn_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e.Button == QLVT_P_CVSRowStyleBtn.Buttons[0])
            {
                // Áp dụng [OddRow]
                QLVT_P_View_GridView.OptionsView.EnableAppearanceEvenRow = false;
                QLVT_P_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                // Áp dụng [EvenRow]
                QLVT_P_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                QLVT_P_View_GridView.OptionsView.EnableAppearanceEvenRow = true;
            }
        }

        /// <summary>
        /// Set màu được chọn cho [OddRow/EvenRow] nếu đang được áp dụng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLVT_P_CVSColorPickEdit_EditValueChanged(object sender, EventArgs e)
        {
            ColorPickEdit cVSColorPickEdit = sender as ColorPickEdit;
            QLVT_P_View_GridView.Appearance.OddRow.BackColor = cVSColorPickEdit.Color;
            QLVT_P_View_GridView.Appearance.EvenRow.BackColor = cVSColorPickEdit.Color;
        }

        /// <summary>
        /// Lấy data cho sub-gridcontrol [QLVT_P_SubVatTu_GridControl] ở detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLVT_P_MaVTPopupEd_RepoItem_BeforePopup(object sender, EventArgs e)
        {
            QL_KTXDataSet.EnforceConstraints = false;
            // Lấy data từ CSDL về DataTable [ql_KTX_DS.HOPDONG]
            VatTuTableAdapter.Fill(QL_KTXDataSet.VATTU);
          
        }

        /// <summary>
        /// Trả về mã phòng khi chọn phòng ở detail sub-gridcontrol [QLVT_P_SubVatTu_GridControl]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLVT_P_MaVTPopupEd_RepoItem_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = ((DataRowView)VatTuBdS[VatTuBdS.Position])["MAVT"].ToString();
        }

        /// <summary>
        /// Lấy data cho sub-gridcontrol [QLVT_P_SubPhong_GridControl] ở detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLVT_P_MaPhongPopupEd_RepoItem_BeforePopup(object sender, EventArgs e)
        {
            QL_KTXDataSet.EnforceConstraints = false;
            // Lấy data từ CSDL về DataTable [ql_KTX_DS.HOPDONG]
            PhongTableAdapter.Fill(QL_KTXDataSet.PHONG);
        }

        /// <summary>
        /// Trả về mã phòng khi chọn phòng ở detail sub-gridcontrol [QLVT_P_SubPhong_GridControl]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLVT_P_MaPhongPopupEd_RepoItem_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = ((DataRowView)PhongBdS[PhongBdS.Position])["MAPHONG"].ToString();
        }

        private void QLVT_P_CancelEdit_Btn_Click(object sender, EventArgs e)
        {
            VatTu_PhongBdS.CancelEdit();
            try
            {
                if (QL_KTXDataSet.VT_PHONG.Rows[0].RowState == DataRowState.Added)
                    VatTu_PhongBdS.RemoveAt(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo");
            }
        }
    }
}
