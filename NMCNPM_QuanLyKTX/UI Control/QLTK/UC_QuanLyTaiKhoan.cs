using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.EditForm.Helpers.Controls;
using DevExpress.XtraGrid.Views.Grid;
using NMCNPM_QuanLyKTX.Common.Const;
using NMCNPM_QuanLyKTX.Common.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace NMCNPM_QuanLyKTX.UI_Control.QLTK
{
    public partial class UC_QuanLyTaiKhoan : XtraUserControl
    {
        bool isVerifiedAdmin = false;

        // Kiểm tra trạng thái đóng mở của CustomViewSetting SidePanel
        private bool isSidePaneCollapsed = true;

        public UC_QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý onLoad form QuanLySinhVien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            // Lấy data từ CSDL
            FillDataFromDatabase();

            // Set column [PASSWORD] trong gridView thành dạng password display (*)          
            EnablePasswordDisplay(QLTK_View_GridView.Columns["PASSWORD"]);
            DisableEditing();
        }

        /// <summary>
        /// Thực hiện đổi loại giao diện (View) để thao tác dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLTK_ChangeViewBtnPanel_ButtonClick(object sender, ButtonEventArgs e)
        {
            // Change view to GridView
            if (e.Button == QLTK_ChangeViewBtnPanel.Buttons[0])
            {
                this.QLTK_GridControl.MainView = this.QLTK_View_GridView;
            }
            // Change view to CardView
            else if (e.Button == QLTK_ChangeViewBtnPanel.Buttons[1])
            {
                //this.QLTK_GridControl.MainView = this.QLTK_View_CardView;

            }
            // Change view to LayoutView
            else if (e.Button == QLTK_ChangeViewBtnPanel.Buttons[2])
            {
                //this.QLTK_GridControl.MainView = this.QLTK_View_LayoutView;
            }
            // Change view to TileView
            else
            {
                //this.QLTK_GridControl.MainView = this.QLTK_View_TileView;
            }
        }

        /// <summary>
        /// Lấy data từ CSDL về DataSet
        /// </summary>
        private void FillDataFromDatabase()
        {
            QL_KTXDataSet.EnforceConstraints = false;

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.TAIKHOAN]
            TaiKhoanTableAdapter.Fill(QL_KTXDataSet.TAIKHOAN);
            // Lấy data từ CSDL về DataTable [ql_KTX_DS.PHANQUYEN]
            PhanQuyenTableAdapter.Fill(QL_KTXDataSet.PHANQUYEN);
        }

        /// <summary>
        /// Toggle open/close custom DetailViewSetting side panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLTK_CustomViewSettingBtn_Click(object sender, EventArgs e)
        {
            // Nếu SidePanel là đóng, mở ra và hiển thị các lựa chọn
            if (isSidePaneCollapsed)
            {
                QLTK_CustomViewSettingSidePane.Width = 75;
                QLTK_CVSControlsPanel.Visible = true;
                isSidePaneCollapsed = false;
            }
            // Nếu SidePanel là mở, đóng lại và ẩn các lựa chọn
            else
            {
                QLTK_CustomViewSettingSidePane.Width = 30;
                QLTK_CVSControlsPanel.Visible = false;
                // Chỉ ẩn các lựa chọn custom khi ToggleSwitch là [Off]
                if (!QLTK_CVSToggleSwitch.IsOn)
                    QLTK_CVSMainControlsPanel.Visible = false;
                isSidePaneCollapsed = true;
            }
        }

        /// <summary>
        /// Toggle áp dụng/không áp dụng tính năng phân chia [EvenRow/OddRow]
        /// Nếu có áp dụng, cung cấp thêm các lựa chọn cho việc custom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLTK_CVSToggleSwitch_Toggled(object sender, EventArgs e)
        {
            /*
             * Nếu ToggleSwitch là [On] -> có áp dụng [EvenRow/OddRow]
             * Hiển thị các lựa chọn custom
             * Nếu ToggleSwitch là [Off] -> không áp dụng [EvenRow/OddRow]
             * Không hiển thị các lựa chọn custom
             */
            if (QLTK_CVSToggleSwitch.IsOn)
            {
                QLTK_CVSMainControlsPanel.Visible = true;

                // Áp dụng [AppearanceOddRow] (Mặc đinh)
                QLTK_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                QLTK_CVSMainControlsPanel.Visible = false;

                // Hủy áp dụng [AppearanceOddRow]
                if (QLTK_View_GridView.OptionsView.EnableAppearanceOddRow)
                    QLTK_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                // Hủy áp dụng [AppearanceEvenRow]
                if (QLTK_View_GridView.OptionsView.EnableAppearanceEvenRow)
                    QLTK_View_GridView.OptionsView.EnableAppearanceEvenRow = false; ;
            }
        }

        /// <summary>
        /// Nếu có áp dụng [EvenRow/OddRow]
        /// Cho phép lựa chọn [EvenRow] hoặc [OddRow]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLTK_CVSRowStyleBtn_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e.Button == QLTK_CVSRowStyleBtn.Buttons[0])
            {
                // Áp dụng [OddRow]
                QLTK_View_GridView.OptionsView.EnableAppearanceEvenRow = false;
                QLTK_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                // Áp dụng [EvenRow]
                QLTK_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                QLTK_View_GridView.OptionsView.EnableAppearanceEvenRow = true;
            }
        }

        /// <summary>
        /// Set màu được chọn cho [OddRow/EvenRow] nếu đang được áp dụng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLTK_CVSColorPickEdit_EditValueChanged(object sender, EventArgs e)
        {
            ColorPickEdit cVSColorPickEdit = sender as ColorPickEdit;
            QLTK_View_GridView.Appearance.OddRow.BackColor = cVSColorPickEdit.Color;
            QLTK_View_GridView.Appearance.EvenRow.BackColor = cVSColorPickEdit.Color;
        }

        /// <summary>
        /// Custom lại EditForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLTK_View_GridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {
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
        /// Xử lý khi nhấn Btn Add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLTK_Add_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Click btn [Add]
                // Thêm dòng dữ liệu trống mới
                DataRowView newRow = (DataRowView)TaiKhoanBdS.AddNew();
                QL_KTXDataSet.TAIKHOAN.Rows.InsertAt(newRow.Row, 0);
                TaiKhoanBdS.Position = 0;

                newRow["TINHTRANGSUDUNG"] = true; 
                QLTK_View_GridView.ShowEditForm();
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
        private void QLTK_Save_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Lưu dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Save (Update)
                // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
                this.Validate();

                TaiKhoanBdS.EndEdit();
                // Update dữ liệu vào CSDL
                this.TaiKhoanTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    TaiKhoanTableAdapter.Update(QL_KTXDataSet.TAIKHOAN);

                    XtraMessageBox.Show("Lưu dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {                  
                    if (ex.Message.Contains("Violation of PRIMARY KEY constraint 'PK_SINHVIEN'"))
                        XtraMessageBox.Show("Lỗi: Không thể trùng lặp mã sinh viên!", "Thông báo");
                    if (ex.Message.Contains("Cannot insert the value NULL into column"))
                        XtraMessageBox.Show("Lỗi: Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                    TaiKhoanBdS.CancelEdit();
                }
            }
            else if(confirm == DialogResult.No)
            {
                TaiKhoanBdS.CancelEdit();
            }
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLTK_Delete_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Xóa dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Delete
                // Xóa dòng dữ liệu hiện tại
                TaiKhoanBdS.RemoveCurrent();
                TaiKhoanBdS.EndEdit();
                // Update dữ liệu vào CSDL
                try
                {
                    TaiKhoanTableAdapter.Update(QL_KTXDataSet.TAIKHOAN);

                    XtraMessageBox.Show("Xóa dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint \"FK_TAIKHOAN_\""))
                        XtraMessageBox.Show("Lỗi: Không thể xóa vì tài khoản\nhiện đang còn được sử dụng!", "Thông báo");
                    TaiKhoanBdS.CancelEdit();
                    QL_KTXDataSet.TAIKHOAN.RejectChanges();
                    TaiKhoanBdS.MovePrevious();
                }
            }
            else if (confirm == DialogResult.No)
            {
                TaiKhoanBdS.CancelEdit();
            }
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLTK_Reload_Btn_Click(object sender, EventArgs e)
        {
            // Click btn Reload
            // Lấy data từ CSDL về DataTable QL_KTXDataSet.SINHVIEN
            TaiKhoanBdS.DataSource = QL_KTXDataSet;
            TaiKhoanBdS.DataMember = "TAIKHOAN";

            FillDataFromDatabase();
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Search Filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLTK_FilterSearchBtn_Click(object sender, EventArgs e)
        {
            String condition = MakeFilterCondition();

            FillDataFromDatabase();

            if (condition == null)
            {
                //SinhVienBdS.DataSource = QL_KTXDataSet;
                //SinhVienBdS.DataMember = "SINHVIEN";
            }
            else
            {
                //tblSinhVienDataView = new DataView(QL_KTXDataSet.SINHVIEN);
                //tblSinhVienDataView.RowFilter = condition;
                //SinhVienBdS.DataSource = tblSinhVienDataView;
            }          
        }

        /// <summary>
        /// Tạo câu điều kiện để search filter
        /// </summary>
        /// <returns></returns>
        private String MakeFilterCondition()
        {
            String filterExpression = null;

            if (!QLTK_Filter_MaSVTxt.Text.Equals(""))
            {
                filterExpression += "MASV LIKE '%" + QLTK_Filter_MaSVTxt.Text.Trim() + "%' "; 
            }

            if (!QLTK_Filter_HoTxt.Text.Equals(""))
            {
                filterExpression += "AND HO LIKE '%" + QLTK_Filter_HoTxt.Text.Trim() + "%' ";
            }

            if (!QLTK_Filter_TenTxt.Text.Equals(""))
            {
                filterExpression += "AND TEN LIKE '%" + QLTK_Filter_TenTxt.Text.Trim() + "%' ";
            }

            // Nếu [CheckState] = [Checked] thì chọn đủ dk
            if (QLTK_Filter_XetDKChk.CheckState == CheckState.Checked)
            {
                filterExpression += "AND XETDIEUKIEN = 'TRUE' ";
            }
            // Nếu [CheckState] = [Unchecked] thì chọn ko đủ dk
            else if (QLTK_Filter_XetDKChk.CheckState == CheckState.Unchecked)
            {
                filterExpression += "AND XETDIEUKIEN = 'FALSE' ";
            }
            // Trường hợp còn lại nếu [CheckState] = [Indeterminate] thì chọn tất cả
            //else if (QLTK_Filter_XetDKChk.CheckState == CheckState.Indeterminate)

            if (!QLTK_Filter_NgaySinhDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYSINH, 'System.String') LIKE '%/" + QLTK_Filter_NgaySinhDate.Text.TrimStart("0".ToCharArray()) + "/%' ";
            }

            if (!QLTK_Filter_ThangSinhDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYSINH, 'System.String') LIKE '" + QLTK_Filter_ThangSinhDate.Text.TrimStart("0".ToCharArray()) + "/%' ";
            }

            if (!QLTK_Filter_NamSinhDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYSINH, 'System.String') LIKE '%/" + QLTK_Filter_NamSinhDate.Text.TrimStart("0".ToCharArray()) + "%' ";
            }

            if (!QLTK_Filter_SDTTxt.Text.Equals(""))
            {
                filterExpression += "AND SDT LIKE '%" + QLTK_Filter_SDTTxt.Text.Trim() + "%' ";
            }

            if (!QLTK_Filter_GioiTinhCb.Text.Equals("") && !QLTK_Filter_GioiTinhCb.Text.Equals("--"))
            {
                filterExpression += "AND GIOITINH LIKE '%" + QLTK_Filter_GioiTinhCb.Text.Trim() + "%' ";
            }

            if (!QLTK_Filter_VPNQTxt.Text.Equals(""))
            {
                filterExpression += "AND VIPHAMNOIQUY LIKE '%" + QLTK_Filter_VPNQTxt.Text.Trim() + "%' ";
            }

            if (!QLTK_Filter_DiaChiTxt.Text.Equals(""))
            {
                filterExpression += "AND DIACHI LIKE '%" + QLTK_Filter_DiaChiTxt.Text.Trim() + "%' ";
            }

            if (!QLTK_Filter_MaQLTxt.Text.Equals(""))
            {
                filterExpression += "AND MAQL LIKE '%" + QLTK_Filter_MaQLTxt.Text.Trim() + "%' ";
            }
            return (filterExpression != null && filterExpression.StartsWith("AND ")) ? filterExpression.Remove(0, 4) : filterExpression;
        }

        /// <summary>
        /// Clear các điều kiện search filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLTK_FilterClearBtn_Click(object sender, EventArgs e)
        {
            QLTK_Filter_MaSVTxt.Text = String.Empty;
            QLTK_Filter_HoTxt.Text = String.Empty;
            QLTK_Filter_TenTxt.Text = String.Empty;
            QLTK_Filter_NgaySinhDate.Text = String.Empty;
            QLTK_Filter_NgaySinhDate.EditValue = null;
            QLTK_Filter_ThangSinhDate.Text = String.Empty;
            QLTK_Filter_ThangSinhDate.EditValue = null;
            QLTK_Filter_NamSinhDate.Text = String.Empty;
            QLTK_Filter_NamSinhDate.EditValue = null;
            QLTK_Filter_XetDKChk.CheckState = CheckState.Indeterminate;
            QLTK_Filter_SDTTxt.Text = String.Empty;
            QLTK_Filter_GioiTinhCb.SelectedItem = "--";
            QLTK_Filter_VPNQTxt.Text = String.Empty;
            QLTK_Filter_DiaChiTxt.Text = String.Empty;
            QLTK_Filter_MaQLTxt.Text = String.Empty;
        }

        private void InitDetailEditFormComponent(Control control)
        {
            if (control is TextEdit)
            {
                if (control.Tag.Equals("EditValue/PASSWORD"))
                {
                    if (isVerifiedAdmin)
                    {
                        (control as TextEdit).Properties.PasswordChar = '\0';
                    }
                    else
                    {
                        (control as TextEdit).Properties.PasswordChar = '*';
                    }
                }
            }                          
        }

        private void QLTK_CancleEdit_Btn_Click(object sender, EventArgs e)
        {
            TaiKhoanBdS.CancelEdit();
            try
            {
                if (QL_KTXDataSet.TAIKHOAN.Rows[0].RowState == DataRowState.Added)
                    TaiKhoanBdS.RemoveAt(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo");
            }           
        }

        private void QLTK_ShowPassword_Btn_Click(object sender, EventArgs e)
        {
            GridColumn column = QLTK_View_GridView.Columns["PASSWORD"];
            TogglePasswordDisplay(column);
        }

        /// <summary>
        /// Set một column trong gridView thành dạng password display (*)
        /// </summary>
        /// <param name="column"></param>
        private void EnablePasswordDisplay(GridColumn column)
        {
            QLTK_PasswordTxtEd_RepoItem.UseSystemPasswordChar = true;
            QLTK_View_GridView.OptionsBehavior.Editable = false;
        }

        /// <summary>
        /// Set một column trong gridView thành dạng normal display (*)
        /// </summary>
        /// <param name="column"></param>
        private void DisablePasswordDisplay(GridColumn column)
        {
            QLTK_PasswordTxtEd_RepoItem.UseSystemPasswordChar = false;
            QLTK_PasswordTxtEd_RepoItem.PasswordChar = '\0';
            QLTK_View_GridView.OptionsBehavior.Editable = true;
        }

        /// <summary>
        /// Toggle normal/password display
        /// </summary>
        /// <param name="column"></param>
        private void TogglePasswordDisplay(GridColumn column)
        {
            // Nếu đang [password display] -> [normal display]
            if (!QLTK_PasswordTxtEd_RepoItem.UseSystemPasswordChar)
            {
                EnablePasswordDisplay(column);
                QLTK_ShowPassword_Btn.ImageOptions.ImageIndex = 1;
                DisableEditing();
                isVerifiedAdmin = false;
            }              
            // Nếu đang [normal display] -> [password display]
            else
            {
                // InputDialog nhập mật khẩu xác thực Admin
                string adminPasswordInput = ShowInputBox("Xác thực quyền admin", "Nhập mật khẩu:");

                /*
                 * Thực hiện verify dựa trên username của TK đã login và mật khẩu xác thực
                 * Nếu thành công -> cho hiển thị password
                 * Nếu thất bại -> WARNING
                 */
                if (VerifyAdminAuthorization(Program.Username, adminPasswordInput))
                {
                    DisablePasswordDisplay(column);
                    QLTK_ShowPassword_Btn.ImageOptions.ImageIndex = 0;
                    EnableEditing();
                    isVerifiedAdmin = true;
                }                   
                else
                    XtraMessageBox.Show("Thông tin không chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Kiểm tra quyền admin hợp lệ
        /// </summary>
        /// <returns></returns>
        private bool VerifyAdminAuthorization(string username, string password)
        {
            /* Thực hiện verify admin: chạy stored procedure login SP_VERIFYADMINAUTHORIZATION
             * trả về [1] -> check hợp lệ -> thành công -> [return true]
             * trả về [0] -> check ko hợp lệ -> thất bại -. [return false]
             */
            string sqlCmdString = "exec SP_VERIFYADMINAUTHORIZATION '" + username + "', '" + password + "'";
            SqlCommand sqlCmd = new SqlCommand(sqlCmdString, Program.DBConnection);
            int result = (int)sqlCmd.ExecuteScalar();

            if (result == 1)
                return true;
            else // == 0
                return false;

        }

        /// <summary>
        /// Get danh sách các phân quyền hiện có
        /// </summary>
        private List<string> GetListPhanQuyen()
        {
            DataRowCollection tableRows = QL_KTXDataSet.PHANQUYEN.Rows;

            List<string> listPQ = new List<string>(tableRows.Count);

            foreach (DataRow row in tableRows)
                listPQ.Add((string)row[0]);

            return listPQ;
        }

        /// <summary>
        /// Custom InputBox
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="messageText"></param>
        /// <returns></returns>
        private string ShowInputBox(string caption, string messageText)
        {
            XtraInputBoxArgs args = new XtraInputBoxArgs();
            TextEdit input = new TextEdit();
            input.Properties.UseSystemPasswordChar = true;
            args.Editor = input;
            args.Caption = caption;
            args.Prompt = messageText;
            args.DefaultResponse = "";

            return (string)XtraInputBox.Show(args);
        }

        private void DisableEditing()
        {
            QLTK_Add_Btn.Enabled = false;
            QLTK_Save_Btn.Enabled = false;
            QLTK_Delete_Btn.Enabled = false;
        }

        private void EnableEditing()
        {
            QLTK_Add_Btn.Enabled = true;
            QLTK_Save_Btn.Enabled = true;
            QLTK_Delete_Btn.Enabled = true;
        }
    }
    
}
