using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
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

namespace NMCNPM_QuanLyKTX.UI_Control.QLHD
{
    public partial class UC_QuanLyHopDong : XtraUserControl
    {
        DataView tblHopDongDataView = null;

        // Kiểm tra trạng thái đóng mở của CustomViewSetting SidePanel
        private bool isSidePaneCollapsed = true;

        public UC_QuanLyHopDong()
        {
            InitializeComponent();
        }
      
        private void UC_QuanLyHopDong_Load(object sender, EventArgs e)
        {
            // Lấy data từ CSDL
            FillDataFromDatabase();

            // Set data cho ComboBox column [HOCKY] để sử dụng
            CommonService.InitHocKyBoxRepoItem(QLHD_HocKyCb_RepoItem);

            // Kiểm tra chế độ sử dụng app là có/không Login
            if (!CommonService.CheckAccessMode())
                CommonService.InitAppNoLoginMode(QLHD_View_GridView, QLHD_ActionBtn_Panel);
        }

        /// <summary>
        /// Lấy data từ CSDL về DataSet
        /// </summary>
        private void FillDataFromDatabase()
        {
            QL_KTXDataSet.EnforceConstraints = false;

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.HOPDONG]
            HopDongTableAdapter.Fill(QL_KTXDataSet.HOPDONG);

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.PHONG]
            PhongTableAdapter.Fill(QL_KTXDataSet.PHONG);

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.SINHVIEN]
            SinhVienTableAdapter.Fill(QL_KTXDataSet.SINHVIEN);
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_Add_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                String maHDNew = Calculating_MaHD();

                // Click btn [Add]
                // Thêm dòng dữ liệu trống mới
                DataRowView newRow = (DataRowView)HopDongBdS.AddNew();
                QL_KTXDataSet.HOPDONG.Rows.InsertAt(newRow.Row, 0);
                HopDongBdS.Position = 0;

                newRow["MAHD"] = maHDNew;
                CommonService.ApplyCurrentMaQL(newRow);
                QLHD_View_GridView.ShowEditForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi");
            }
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_Save_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Lưu dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Save (Update)
                // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
                this.Validate();
                HopDongBdS.EndEdit();

                // Update dữ liệu vào CSDL
                this.HopDongTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    HopDongTableAdapter.Update(QL_KTXDataSet.HOPDONG);

                    XtraMessageBox.Show("Lưu dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Violation of PRIMARY KEY constraint 'PK_HOPDONG'"))
                        XtraMessageBox.Show("Lỗi: Không thể trùng lặp mã hợp đồng!", "Thông báo");
                    HopDongBdS.CancelEdit();
                }
            }
            else if (confirm == DialogResult.No)
            {
                HopDongBdS.CancelEdit();
            }
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_Delete_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Xóa dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Delete
                // Xóa dòng dữ liệu hiện tại
                HopDongBdS.RemoveCurrent();
                HopDongBdS.EndEdit();
                //tblSinhVienDataView.RowStateFilter = DataViewRowState.Deleted;
                // Update dữ liệu vào CSDL
                //SinhVienTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    HopDongTableAdapter.Update(QL_KTXDataSet.HOPDONG);

                    XtraMessageBox.Show("Xóa dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {                   
                    XtraMessageBox.Show(ex.Message, "Thông báo");
                    HopDongBdS.CancelEdit();
                    QL_KTXDataSet.HOPDONG.RejectChanges();
                    HopDongBdS.MovePrevious();
                }
            }
            else if (confirm == DialogResult.No)
            {
                HopDongBdS.CancelEdit();
            }
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_Reload_Btn_Click(object sender, EventArgs e)
        {
            // Click btn Reload
            // Lấy data từ CSDL về DataTable ql_KTX_DS.HOPDONG
            HopDongBdS.DataSource = QL_KTXDataSet;
            HopDongBdS.DataMember = "HOPDONG";

            FillDataFromDatabase();
        }

        private void QLHD_View_GridView_EditFormPrepared_1(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {
            //FillDataFromDatabase();

            foreach (Control control in e.BindableControls)
            {
                if (control is TextEdit)
                {
                    InitDetailEditFormComponent(control);
                    (control as TextEdit).AutoSize = true;
                    (control as TextEdit).Font = new Font((control as TextEdit).Font.FontFamily, 10);
                    //var x = (control as TextEdit).Size;
                    //var y = (control as TextEdit).CalcBestSize();
                    (control as TextEdit).Size = new Size((control as TextEdit).Size.Width, 22);
                }
            }

            EditFormContainer container = (e.Panel as EditFormContainer);
            TableLayoutPanel layoutPane = (container.Controls[0].Controls[0] as TableLayoutPanel);
            layoutPane.AutoSize = true;
            layoutPane.Size = new Size(container.Size.Width, 110);
        }

        /// <summary>
        /// Toggle open/close custom DetailViewSetting side panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_CustomViewSettingBtn_Click(object sender, EventArgs e)
        {
            // Nếu SidePanel là đóng, mở ra và hiển thị các lựa chọn
            if (isSidePaneCollapsed)
            {
                QLHD_CustomViewSettingSidePane.Width = 75;
                QLHD_CVSControlsPanel.Visible = true;
                isSidePaneCollapsed = false;
            }
            // Nếu SidePanel là mở, đóng lại và ẩn các lựa chọn
            else
            {
                QLHD_CustomViewSettingSidePane.Width = 30;
                QLHD_CVSControlsPanel.Visible = false;
                // Chỉ ẩn các lựa chọn custom khi ToggleSwitch là [Off]
                if (!QLHD_CVSToggleSwitch.IsOn)
                    QLHD_CVSMainControlsPanel.Visible = false;
                isSidePaneCollapsed = true;
            }
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Search Filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_FilterSearchBtn_Click(object sender, EventArgs e)
        {
            String condition = MakeFilterCondition();

            FillDataFromDatabase();

            if (condition == null)
            {
                HopDongBdS.DataSource = QL_KTXDataSet;
                HopDongBdS.DataMember = "HOPDONG";
            }
            else
            {
                tblHopDongDataView = new DataView(QL_KTXDataSet.HOPDONG);
                tblHopDongDataView.RowFilter = condition;
                HopDongBdS.DataSource = tblHopDongDataView;
            }
        }

        /// <summary>
        /// Tạo câu điều kiện để search filter
        /// </summary>
        /// <returns></returns>
        private String MakeFilterCondition()
        {
            String filterExpression = null;

            if (!QLHD_Filter_MaHDTxt.Text.Equals(""))
            {
                filterExpression += "MAHD LIKE '%" + QLHD_Filter_MaHDTxt.Text.Trim() + "%' ";
            }

            if (!QLHD_Filter_SoTienTxt.Text.Equals(""))
            {
                filterExpression += "AND SOTIEN = '" + QLHD_Filter_SoTienTxt.Text.Trim() + "' ";
            }

            if (!QLHD_Filter_TienNoTxt.Text.Equals(""))
            {
                filterExpression += "AND TIENNO = '" + QLHD_Filter_TienNoTxt.Text.Trim() + "' ";
            }

            if (!QLHD_Filter_NgayTaoDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYTAO, 'System.String') LIKE '*/" + QLHD_Filter_NgayTaoDate.Text.TrimStart("0".ToCharArray()) + "/*' ";
            }

            if (!QLHD_Filter_ThangTaoDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYTAO, 'System.String') LIKE '" + QLHD_Filter_ThangTaoDate.Text.TrimStart("0".ToCharArray()) + "/*' ";
            }

            if (!QLHD_Filter_NamTaoDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYTAO, 'System.String') LIKE '*/" + QLHD_Filter_NamTaoDate.Text.TrimStart("0".ToCharArray()) + "*' ";
            }

            if (!QLHD_Filter_HocKyCb.Text.Equals("") && !QLHD_Filter_HocKyCb.Text.Equals("--"))
            {
                filterExpression += "AND HOCKY = '" + QLHD_Filter_HocKyCb.Text.Trim() + "' ";
            }

            if (!QLHD_Filter_NamHocTuTxt.Text.Equals(""))
            {
                filterExpression += "AND SUBSTRING(NAMHOC, 1, 4) LIKE '%" + QLHD_Filter_NamHocTuTxt.Text.Trim() + "%' ";
            }

            if (!QLHD_Filter_NamHocDenTxt.Text.Equals(""))
            {
                filterExpression += "AND SUBSTRING(NAMHOC, 6, 4) LIKE '%" + QLHD_Filter_NamHocDenTxt.Text.Trim() + "%' ";
            }

            if (!QLHD_Filter_MaSVTxt.Text.Equals(""))
            {
                filterExpression += "AND MASV LIKE '%" + QLHD_Filter_MaSVTxt.Text.Trim() + "%' ";
            }

            if (!QLHD_Filter_MaPhongTxt.Text.Equals(""))
            {
                filterExpression += "AND MAPHONG LIKE '%" + QLHD_Filter_MaPhongTxt.Text.Trim() + "%' ";
            }

            if (!QLHD_Filter_MaQLTxt.Text.Equals(""))
            {
                filterExpression += "AND MAQL LIKE '%" + QLHD_Filter_MaQLTxt.Text.Trim() + "%' ";
            }
            return (filterExpression != null && filterExpression.StartsWith("AND ")) ? filterExpression.Remove(0, 4) : filterExpression;
        }

        /// <summary>
        /// Lấy data cho sub-gridcontrol [QLHD_SubPhong_GridControl] ở detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_MaPhongPopupEd_RepoItem_BeforePopup(object sender, EventArgs e)
        {
            QL_KTXDataSet.EnforceConstraints = false;
            // Lấy data từ CSDL về DataTable [ql_KTX_DS.HOPDONG]
            PhongTableAdapter.Fill(QL_KTXDataSet.PHONG);

            QLHD_MaPhongPopupCtl_RepoItem.Size = new Size(549, 223);
        }

        /// <summary>
        /// Trả về mã phòng khi chọn phòng ở detail sub-gridcontrol [QLHD_SubPhong_GridControl]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_MaPhongPopupEd_RepoItem_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = ((DataRowView)Sub_PhongBdS[Sub_PhongBdS.Position])["MAPHONG"].ToString();
        }

        /// <summary>
        /// Lấy data cho sub-gridcontrol [QLHD_SubSV_GridControl] ở detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_MaSVPopupEd_RepoItem_BeforePopup(object sender, EventArgs e)
        {
            QL_KTXDataSet.EnforceConstraints = false;
            // Lấy data từ CSDL về DataTable [ql_KTX_DS.HOPDONG]
            SinhVienTableAdapter.Fill(QL_KTXDataSet.SINHVIEN);

            String condition = "XETDIEUKIEN = 'true'";
            DataView svDuDKDataView = new DataView(QL_KTXDataSet.SINHVIEN);
            svDuDKDataView.RowFilter = condition;
            Sub_SinhVienBdS.DataSource = svDuDKDataView;
            QLHD_MaSVPopupCtl_RepoItem.Size = new Size(749, 223);
        }

        /// <summary>
        /// Trả về mã phòng khi chọn phòng ở detail sub-gridcontrol [QLHD_SubSV_GridControl]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_MaSVPopupEd_RepoItem_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = ((DataRowView)Sub_SinhVienBdS[Sub_SinhVienBdS.Position])["MASV"].ToString();
        }

        /// <summary>
        /// Clear các điều kiện search filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_FilterClearBtn_Click(object sender, EventArgs e)
        {
            QLHD_Filter_MaHDTxt.Text = String.Empty;
            QLHD_Filter_SoTienTxt.Text = String.Empty;
            QLHD_Filter_TienNoTxt.Text = String.Empty;
            QLHD_Filter_NgayTaoDate.Text = String.Empty;
            QLHD_Filter_NgayTaoDate.EditValue = null;
            QLHD_Filter_ThangTaoDate.Text = String.Empty;
            QLHD_Filter_ThangTaoDate.EditValue = null;
            QLHD_Filter_NamTaoDate.Text = String.Empty;
            QLHD_Filter_NamTaoDate.EditValue = null;
            QLHD_Filter_HocKyCb.SelectedItem = "--";
            QLHD_Filter_NamHocTuTxt.Text = String.Empty;
            QLHD_Filter_NamHocDenTxt.Text = String.Empty;
            QLHD_Filter_MaSVTxt.Text = String.Empty;
            QLHD_Filter_MaPhongTxt.Text = String.Empty;
            QLHD_Filter_MaQLTxt.Text = String.Empty;
        }

        private void InitFilterComponent()
        {
            // Set data cho ComboBox column [HOCKY_Filter] để sử dụng
            CommonService.InitHocKyBox(QLHD_Filter_HocKyCb, true);

            FillDataFromDatabase();

            QLHD_Filter_MaPhongTxt.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            QLHD_Filter_MaPhongTxt.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            QLHD_Filter_MaPhongTxt.MaskBox.AutoCompleteCustomSource = CommonService.AutoCompleteDSPhongCollection(QL_KTXDataSet.PHONG);

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.QUANLY]
            QuanLyTableAdapter.Fill(QL_KTXDataSet.QUANLY);
            QLHD_Filter_MaQLTxt.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            QLHD_Filter_MaQLTxt.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            QLHD_Filter_MaQLTxt.MaskBox.AutoCompleteCustomSource = CommonService.AutoCompleteDSQuanLyCollection(QL_KTXDataSet.QUANLY);
        }

        private void QLHD_HeaderNavigationTab_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            if((sender as TabPane).SelectedPageIndex == 1)
            {
                InitFilterComponent();
            }
        }

        private void InitDetailEditFormComponent(Control control)
        {
            if (control.Tag.Equals("EditValue/MAHD"))
            {
                (control as TextEdit).MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                (control as TextEdit).MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                (control as TextEdit).MaskBox.AutoCompleteCustomSource = CommonService.AutoCompleteDSMaHDCollection(QL_KTXDataSet.HOPDONG);
            }
            else if (control.Tag.Equals("EditValue/SOTIEN") || control.Tag.Equals("EditValue/TIENNO"))
            {
                (control as TextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                (control as TextEdit).Properties.Mask.EditMask = "n0";
                (control as TextEdit).Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            else if (control.Tag.Equals("EditValue/NAMHOC"))
            {
                (control as TextEdit).MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                (control as TextEdit).MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                (control as TextEdit).MaskBox.AutoCompleteCustomSource = CommonService.AutoCompleteNamHocCollection();
            }
        }

        /// <summary>
        /// Toggle áp dụng/không áp dụng tính năng phân chia [EvenRow/OddRow]
        /// Nếu có áp dụng, cung cấp thêm các lựa chọn cho việc custom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_CVSToggleSwitch_Toggled(object sender, EventArgs e)
        {
            /*
             * Nếu ToggleSwitch là [On] -> có áp dụng [EvenRow/OddRow]
             * Hiển thị các lựa chọn custom
             * Nếu ToggleSwitch là [Off] -> không áp dụng [EvenRow/OddRow]
             * Không hiển thị các lựa chọn custom
             */
            if (QLHD_CVSToggleSwitch.IsOn)
            {
                QLHD_CVSMainControlsPanel.Visible = true;

                // Áp dụng [AppearanceOddRow] (Mặc đinh)
                QLHD_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                QLHD_CVSMainControlsPanel.Visible = false;

                // Hủy áp dụng [AppearanceOddRow]
                if (QLHD_View_GridView.OptionsView.EnableAppearanceOddRow)
                    QLHD_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                // Hủy áp dụng [AppearanceEvenRow]
                if (QLHD_View_GridView.OptionsView.EnableAppearanceEvenRow)
                    QLHD_View_GridView.OptionsView.EnableAppearanceEvenRow = false; ;
            }
        }

        /// <summary>
        /// Nếu có áp dụng [EvenRow/OddRow]
        /// Cho phép lựa chọn [EvenRow] hoặc [OddRow]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_CVSRowStyleBtn_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button == QLHD_CVSRowStyleBtn.Buttons[0])
            {
                // Áp dụng [OddRow]
                QLHD_View_GridView.OptionsView.EnableAppearanceEvenRow = false;
                QLHD_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                // Áp dụng [EvenRow]
                QLHD_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                QLHD_View_GridView.OptionsView.EnableAppearanceEvenRow = true;
            }
        }

        /// <summary>
        /// Set màu được chọn cho [OddRow/EvenRow] nếu đang được áp dụng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_CVSColorPickEdit_EditValueChanged(object sender, EventArgs e)
        {
            ColorPickEdit cVSColorPickEdit = sender as ColorPickEdit;
            QLHD_View_GridView.Appearance.OddRow.BackColor = cVSColorPickEdit.Color;
            QLHD_View_GridView.Appearance.EvenRow.BackColor = cVSColorPickEdit.Color;
        }

        /// <summary>
        /// Tính toán mã HD khi tạo mới
        /// </summary>
        /// <returns></returns>
        private String Calculating_MaHD()
        {
            DataView dw = new DataView(QL_KTXDataSet.HOPDONG);
            String condition = "MAHD ASC";
            dw.Sort = condition;
            DataTable dt = dw.ToTable();
            String maHDLast = (dt.Rows[dt.Rows.Count - 1]["MAHD"]).ToString();

            String newMaHD = "HD";
            
            try
            {
                int newID = Int32.Parse(maHDLast.Substring(2, 8)) + 1;
                int zeroChars = 8 - newID.ToString().Length;

                for (int i = 0; i < zeroChars; i++)
                {
                    newMaHD += "0";
                }
                newMaHD += newID;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo");
            }

            return newMaHD;
        }
    }
}
