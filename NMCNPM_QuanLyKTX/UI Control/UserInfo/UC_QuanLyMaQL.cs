using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
using DevExpress.XtraGrid.Views.Grid;
using NMCNPM_QuanLyKTX.Common.Const;
using NMCNPM_QuanLyKTX.Common.Service;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NMCNPM_QuanLyKTX.UI_Control.UserInfo
{
    public partial class UC_QuanLyMaQL : XtraUserControl
    {
        DataView tblMaQLDataView = null;

        // Kiểm tra trạng thái đóng mở của CustomViewSetting SidePanel
        private bool isSidePaneCollapsed = true;

        public UC_QuanLyMaQL()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý onLoad form QuanLyMaQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_QuanLyMaQL_Load(object sender, EventArgs e)
        {
            // Lấy data từ CSDL về DataTable QL_KTXDataSet.MaQL
            FillDataFromDatabase();

            // Kiểm tra chế độ sử dụng app là có/không Login
            if(!CommonService.CheckAccessMode())
                CommonService.InitAppNoLoginMode(QLMQL_View_GridView, QLMQL_ActionBtn_Panel);
        }

        /// <summary>
        /// Thực hiện đổi loại giao diện (View) để thao tác dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLMQL_ChangeViewBtnPanel_ButtonClick(object sender, ButtonEventArgs e)
        {
            // Change view to GridView
            if (e.Button == QLMQL_ChangeViewBtnPanel.Buttons[0])
            {
                //this.QLMQL_MainGridControl.MainView = this.QLMQL_View_GridView;
            }
            // Change view to CardView
            else if (e.Button == QLMQL_ChangeViewBtnPanel.Buttons[1])
            {
                //this.QLMQL_GridControl.MainView = this.QLMQL_View_CardView;

            }
            // Change view to LayoutView
            else if (e.Button == QLMQL_ChangeViewBtnPanel.Buttons[2])
            {
                //this.QLMQL_GridControl.MainView = this.QLMQL_View_LayoutView;
            }
            // Change view to TileView
            else
            {
                //this.QLMQL_GridControl.MainView = this.QLMQL_View_TileView;
            }
        }

        /// <summary>
        /// Lấy data từ CSDL về DataSet
        /// </summary>
        private void FillDataFromDatabase()
        {
            QL_KTXDataSet.EnforceConstraints = false;

            // Lấy data từ CSDL về DataTable [QL_KTXDataSet.MaQL]
            MaQLTableAdapter.Fill(QL_KTXDataSet.QUANLY);

            TaiKhoanTableAdapter.Fill(QL_KTXDataSet.TAIKHOAN);
        }

        /// <summary>
        /// Toggle open/close custom DetailViewSetting side panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLMQL_CustomViewSettingBtn_Click(object sender, EventArgs e)
        {
            // Nếu SidePanel là đóng, mở ra và hiển thị các lựa chọn
            if (isSidePaneCollapsed)
            {
                QLMQL_CustomViewSettingSidePane.Width = 75;
                QLMQL_CVSControlsPanel.Visible = true;
                isSidePaneCollapsed = false;
            }
            // Nếu SidePanel là mở, đóng lại và ẩn các lựa chọn
            else
            {
                QLMQL_CustomViewSettingSidePane.Width = 30;
                QLMQL_CVSControlsPanel.Visible = false;
                // Chỉ ẩn các lựa chọn custom khi ToggleSwitch là [Off]
                if (!QLMQL_CVSToggleSwitch.IsOn)
                    QLMQL_CVSMainControlsPanel.Visible = false;
                isSidePaneCollapsed = true;
            }
        }

        /// <summary>
        /// Toggle áp dụng/không áp dụng tính năng phân chia [EvenRow/OddRow]
        /// Nếu có áp dụng, cung cấp thêm các lựa chọn cho việc custom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLMQL_CVSToggleSwitch_Toggled(object sender, EventArgs e)
        {
            /*
             * Nếu ToggleSwitch là [On] -> có áp dụng [EvenRow/OddRow]
             * Hiển thị các lựa chọn custom
             * Nếu ToggleSwitch là [Off] -> không áp dụng [EvenRow/OddRow]
             * Không hiển thị các lựa chọn custom
             */
            if (QLMQL_CVSToggleSwitch.IsOn)
            {
                QLMQL_CVSMainControlsPanel.Visible = true;

                // Áp dụng [AppearanceOddRow] (Mặc đinh)
                QLMQL_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                QLMQL_CVSMainControlsPanel.Visible = false;

                // Hủy áp dụng [AppearanceOddRow]
                if (QLMQL_View_GridView.OptionsView.EnableAppearanceOddRow)
                    QLMQL_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                // Hủy áp dụng [AppearanceEvenRow]
                if (QLMQL_View_GridView.OptionsView.EnableAppearanceEvenRow)
                    QLMQL_View_GridView.OptionsView.EnableAppearanceEvenRow = false; ;
            }
        }

        /// <summary>
        /// Nếu có áp dụng [EvenRow/OddRow]
        /// Cho phép lựa chọn [EvenRow] hoặc [OddRow]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLMQL_CVSRowStyleBtn_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e.Button == QLMQL_CVSRowStyleBtn.Buttons[0])
            {
                // Áp dụng [OddRow]
                QLMQL_View_GridView.OptionsView.EnableAppearanceEvenRow = false;
                QLMQL_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                // Áp dụng [EvenRow]
                QLMQL_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                QLMQL_View_GridView.OptionsView.EnableAppearanceEvenRow = true;
            }
        }

        /// <summary>
        /// Set màu được chọn cho [OddRow/EvenRow] nếu đang được áp dụng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLMQL_CVSColorPickEdit_EditValueChanged(object sender, EventArgs e)
        {
            ColorPickEdit cVSColorPickEdit = sender as ColorPickEdit;
            QLMQL_View_GridView.Appearance.OddRow.BackColor = cVSColorPickEdit.Color;
            QLMQL_View_GridView.Appearance.EvenRow.BackColor = cVSColorPickEdit.Color;
        }

        /// <summary>
        /// Custom lại EditForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLMQL_View_GridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
            foreach (Control control in e.BindableControls)
            {
                if (control is TextEdit)
                {
                    //InitDetailEditFormComponent(control);
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
        /// Xử lý khi nhấn Btn Add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLMQL_Add_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Click btn [Add]
                // Thêm dòng dữ liệu trống mới
                DataRowView newRow = (DataRowView)MaQLBdS.AddNew();
                QL_KTXDataSet.QUANLY.Rows.InsertAt(newRow.Row, 0);
                MaQLBdS.Position = 0;

                QLMQL_View_GridView.ShowEditForm();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi");
            }                 
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLMQL_Save_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Lưu dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Save (Update)
                // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
                this.Validate();

                MaQLBdS.EndEdit();
                //tblMaQLDataView.RowStateFilter = DataViewRowState.OriginalRows;
                // Update dữ liệu vào CSDL
                this.MaQLTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                { 
                    MaQLTableAdapter.Update(QL_KTXDataSet.QUANLY);

                    XtraMessageBox.Show("Lưu dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if(ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                        XtraMessageBox.Show("Lỗi: Không thể trùng lặp mã!", "Thông báo");
                    MaQLBdS.CancelEdit();
                }
            }
            else if(confirm == DialogResult.No)
            {
                MaQLBdS.CancelEdit();
            }
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLMQL_Delete_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Xóa dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Delete
                // Xóa dòng dữ liệu hiện tại
                MaQLBdS.RemoveCurrent();
                MaQLBdS.EndEdit();
                //tblMaQLDataView.RowStateFilter = DataViewRowState.Deleted;
                // Update dữ liệu vào CSDL
                //MaQLTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    MaQLTableAdapter.Update(QL_KTXDataSet.QUANLY);

                    XtraMessageBox.Show("Xóa dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        XtraMessageBox.Show("Lỗi: Không thể xóa vì dữ liệu còn được sử dụng!", "Thông báo");
                    MaQLBdS.CancelEdit();
                    QL_KTXDataSet.QUANLY.RejectChanges();
                    MaQLBdS.MovePrevious();
                }
            }
            else if (confirm == DialogResult.No)
            {
                MaQLBdS.CancelEdit();
            }
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLMQL_Reload_Btn_Click(object sender, EventArgs e)
        {
            // Click btn Reload
            // Lấy data từ CSDL về DataTable QL_KTXDataSet.QUANLY
            FillDataFromDatabase();
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Search Filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLMQL_FilterSearchBtn_Click(object sender, EventArgs e)
        {
            String condition = MakeFilterCondition();

            FillDataFromDatabase();

            if (condition == null)
            {
                MaQLBdS.DataSource = QL_KTXDataSet;
                MaQLBdS.DataMember = "QUANLY";
            }
            else
            {
                tblMaQLDataView = new DataView(QL_KTXDataSet.QUANLY);
                tblMaQLDataView.RowFilter = condition;
                MaQLBdS.DataSource = tblMaQLDataView;
            }          
        }

        /// <summary>
        /// Tạo câu điều kiện để search filter
        /// </summary>
        /// <returns></returns>
        private String MakeFilterCondition()
        {
            String filterExpression = null;

            if (!QLMQL_Filter_MaSVTxt.Text.Equals(""))
            {
                filterExpression += "MASV LIKE '%" + QLMQL_Filter_MaSVTxt.Text.Trim() + "%' "; 
            }

            if (!QLMQL_Filter_HoTxt.Text.Equals(""))
            {
                filterExpression += "AND HO LIKE '%" + QLMQL_Filter_HoTxt.Text.Trim() + "%' ";
            }

            if (!QLMQL_Filter_TenTxt.Text.Equals(""))
            {
                filterExpression += "AND TEN LIKE '%" + QLMQL_Filter_TenTxt.Text.Trim() + "%' ";
            }

            // Nếu [CheckState] = [Checked] thì chọn đủ dk
            if (QLMQL_Filter_XetDKChk.CheckState == CheckState.Checked)
            {
                filterExpression += "AND XETDIEUKIEN = 'TRUE' ";
            }
            // Nếu [CheckState] = [Unchecked] thì chọn ko đủ dk
            else if (QLMQL_Filter_XetDKChk.CheckState == CheckState.Unchecked)
            {
                filterExpression += "AND XETDIEUKIEN = 'FALSE' ";
            }
            // Trường hợp còn lại nếu [CheckState] = [Indeterminate] thì chọn tất cả
            //else if (QLMQL_Filter_XetDKChk.CheckState == CheckState.Indeterminate)

            if (!QLMQL_Filter_NgaySinhDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYSINH, 'System.String') LIKE '%/" + QLMQL_Filter_NgaySinhDate.Text.TrimStart("0".ToCharArray()) + "/%' ";
            }

            if (!QLMQL_Filter_ThangSinhDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYSINH, 'System.String') LIKE '" + QLMQL_Filter_ThangSinhDate.Text.TrimStart("0".ToCharArray()) + "/%' ";
            }

            if (!QLMQL_Filter_NamSinhDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYSINH, 'System.String') LIKE '%/" + QLMQL_Filter_NamSinhDate.Text.TrimStart("0".ToCharArray()) + "%' ";
            }

            if (!QLMQL_Filter_SDTTxt.Text.Equals(""))
            {
                filterExpression += "AND SDT LIKE '%" + QLMQL_Filter_SDTTxt.Text.Trim() + "%' ";
            }

            if (!QLMQL_Filter_GioiTinhCb.Text.Equals("") && !QLMQL_Filter_GioiTinhCb.Text.Equals("--"))
            {
                filterExpression += "AND GIOITINH LIKE '%" + QLMQL_Filter_GioiTinhCb.Text.Trim() + "%' ";
            }

            if (!QLMQL_Filter_VPNQTxt.Text.Equals(""))
            {
                filterExpression += "AND VIPHAMNOIQUY LIKE '%" + QLMQL_Filter_VPNQTxt.Text.Trim() + "%' ";
            }

            if (!QLMQL_Filter_DiaChiTxt.Text.Equals(""))
            {
                filterExpression += "AND DIACHI LIKE '%" + QLMQL_Filter_DiaChiTxt.Text.Trim() + "%' ";
            }

            if (!QLMQL_Filter_MaQLTxt.Text.Equals(""))
            {
                filterExpression += "AND MAQL LIKE '%" + QLMQL_Filter_MaQLTxt.Text.Trim() + "%' ";
            }
            return (filterExpression != null && filterExpression.StartsWith("AND ")) ? filterExpression.Remove(0, 4) : filterExpression;
        }

        /// <summary>
        /// Clear các điều kiện search filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLMQL_FilterClearBtn_Click(object sender, EventArgs e)
        {
            QLMQL_Filter_MaSVTxt.Text = String.Empty;
            QLMQL_Filter_HoTxt.Text = String.Empty;
            QLMQL_Filter_TenTxt.Text = String.Empty;
            QLMQL_Filter_NgaySinhDate.Text = String.Empty;
            QLMQL_Filter_NgaySinhDate.EditValue = null;
            QLMQL_Filter_ThangSinhDate.Text = String.Empty;
            QLMQL_Filter_ThangSinhDate.EditValue = null;
            QLMQL_Filter_NamSinhDate.Text = String.Empty;
            QLMQL_Filter_NamSinhDate.EditValue = null;
            QLMQL_Filter_XetDKChk.CheckState = CheckState.Indeterminate;
            QLMQL_Filter_SDTTxt.Text = String.Empty;
            QLMQL_Filter_GioiTinhCb.SelectedItem = "--";
            QLMQL_Filter_VPNQTxt.Text = String.Empty;
            QLMQL_Filter_DiaChiTxt.Text = String.Empty;
            QLMQL_Filter_MaQLTxt.Text = String.Empty;
        }

        private void QLMQL_CancleEdit_Btn_Click(object sender, EventArgs e)
        {
            MaQLBdS.CancelEdit();
            try
            {
                if (QL_KTXDataSet.QUANLY.Rows[0].RowState == DataRowState.Added)
                    MaQLBdS.RemoveAt(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo");
            }           
        }

        private void QLMQL_UsernamePopupEd_RepoItem_BeforePopup(object sender, EventArgs e)
        {
            
        }

        private void QLMQL_UsernamePopupEd_RepoItem_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = ((DataRowView)TaiKhoanBdS[TaiKhoanBdS.Position])["USERNAME"].ToString();

        }
    }
    
}
