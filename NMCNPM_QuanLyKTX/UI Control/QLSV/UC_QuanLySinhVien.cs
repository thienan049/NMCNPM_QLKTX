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

namespace NMCNPM_QuanLyKTX.UI_Control.QLSV
{
    public partial class UC_QuanLySinhVien : XtraUserControl
    {
        DataView tblSinhVienDataView = null;

        // Kiểm tra trạng thái đóng mở của CustomViewSetting SidePanel
        private bool isSidePaneCollapsed = true;

        public UC_QuanLySinhVien()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý onLoad form QuanLySinhVien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_QuanLySinhVien_Load(object sender, EventArgs e)
        {
            // Lấy data từ CSDL về DataTable QL_KTXDataSet.SINHVIEN
            FillDataFromDatabase();

            // Khởi tạo giá trị cho các ComboBox
            CommonService.InitGenderBoxRepoItem(QLSV_GioiTinhCb_RepoItem);
            CommonService.InitGenderBox(QLSV_Filter_GioiTinhCb, true);
            //tblSinhVienDataView = new DataView(QL_KTXDataSet.SINHVIEN);
            //UC_QLSV_EditForm qlsvEditForm = new UC_QLSV_EditForm();
            //qlsvEditForm.InitDataBinding(this.SinhVienBdS);

            // QLSV_View_GridView.OptionsEditForm.CustomEditFormLayout = qlsvEditForm;
            // QLSV_View_GridView.OptionsEditForm.ActionOnModifiedRowChange = EditFormModifiedAction.Default;

            // Kiểm tra chế độ sử dụng app là có/không Login
            if(!CommonService.CheckAccessMode())
                CommonService.InitAppNoLoginMode(QLSV_View_GridView, QLSV_ActionBtn_Panel);
        }

        /// <summary>
        /// Thực hiện đổi loại giao diện (View) để thao tác dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLSV_ChangeViewBtnPanel_ButtonClick(object sender, ButtonEventArgs e)
        {
            // Change view to GridView
            if (e.Button == QLSV_ChangeViewBtnPanel.Buttons[0])
            {
                this.QLSV_MainGridControl.MainView = this.QLSV_View_GridView;
            }
            // Change view to CardView
            else if (e.Button == QLSV_ChangeViewBtnPanel.Buttons[1])
            {
                //this.QLSV_GridControl.MainView = this.QLSV_View_CardView;

            }
            // Change view to LayoutView
            else if (e.Button == QLSV_ChangeViewBtnPanel.Buttons[2])
            {
                //this.QLSV_GridControl.MainView = this.QLSV_View_LayoutView;
            }
            // Change view to TileView
            else
            {
                //this.QLSV_GridControl.MainView = this.QLSV_View_TileView;
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
            // Lấy data từ CSDL về DataTable [QL_KTXDataSet.HOPDONG]
            HopDongTableAdapter.Fill(QL_KTXDataSet.HOPDONG);
        }

        public bool HasChanges()
        {
            bool Result = false;
            //QL_KTXDataSet.SINHVIEN.g
            DataTable x = ((ql_KTXDataSet)SinhVienBdS.DataSource).SINHVIEN.GetChanges(DataRowState.Modified | DataRowState.Added);
            DataRow[] y = ((ql_KTXDataSet)SinhVienBdS.DataSource).SINHVIEN.Select(null, null, DataViewRowState.ModifiedCurrent);
            Result = (((ql_KTXDataSet)SinhVienBdS.DataSource).SINHVIEN).GetChanges(DataRowState.Modified) != null;
            //this.QLSVViewType_gridView.rows

            return Result;
        }

        /// <summary>
        /// Toggle open/close custom DetailViewSetting side panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLSV_CustomViewSettingBtn_Click(object sender, EventArgs e)
        {
            // Nếu SidePanel là đóng, mở ra và hiển thị các lựa chọn
            if (isSidePaneCollapsed)
            {
                QLSV_CustomViewSettingSidePane.Width = 75;
                QLSV_CVSControlsPanel.Visible = true;
                isSidePaneCollapsed = false;
            }
            // Nếu SidePanel là mở, đóng lại và ẩn các lựa chọn
            else
            {
                QLSV_CustomViewSettingSidePane.Width = 30;
                QLSV_CVSControlsPanel.Visible = false;
                // Chỉ ẩn các lựa chọn custom khi ToggleSwitch là [Off]
                if (!QLSV_CVSToggleSwitch.IsOn)
                    QLSV_CVSMainControlsPanel.Visible = false;
                isSidePaneCollapsed = true;
            }
        }

        /// <summary>
        /// Toggle áp dụng/không áp dụng tính năng phân chia [EvenRow/OddRow]
        /// Nếu có áp dụng, cung cấp thêm các lựa chọn cho việc custom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLSV_CVSToggleSwitch_Toggled(object sender, EventArgs e)
        {
            /*
             * Nếu ToggleSwitch là [On] -> có áp dụng [EvenRow/OddRow]
             * Hiển thị các lựa chọn custom
             * Nếu ToggleSwitch là [Off] -> không áp dụng [EvenRow/OddRow]
             * Không hiển thị các lựa chọn custom
             */
            if (QLSV_CVSToggleSwitch.IsOn)
            {
                QLSV_CVSMainControlsPanel.Visible = true;

                // Áp dụng [AppearanceOddRow] (Mặc đinh)
                QLSV_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                QLSV_CVSMainControlsPanel.Visible = false;

                // Hủy áp dụng [AppearanceOddRow]
                if (QLSV_View_GridView.OptionsView.EnableAppearanceOddRow)
                    QLSV_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                // Hủy áp dụng [AppearanceEvenRow]
                if (QLSV_View_GridView.OptionsView.EnableAppearanceEvenRow)
                    QLSV_View_GridView.OptionsView.EnableAppearanceEvenRow = false; ;
            }
        }

        /// <summary>
        /// Nếu có áp dụng [EvenRow/OddRow]
        /// Cho phép lựa chọn [EvenRow] hoặc [OddRow]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLSV_CVSRowStyleBtn_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e.Button == QLSV_CVSRowStyleBtn.Buttons[0])
            {
                // Áp dụng [OddRow]
                QLSV_View_GridView.OptionsView.EnableAppearanceEvenRow = false;
                QLSV_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                // Áp dụng [EvenRow]
                QLSV_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                QLSV_View_GridView.OptionsView.EnableAppearanceEvenRow = true;
            }
        }

        /// <summary>
        /// Set màu được chọn cho [OddRow/EvenRow] nếu đang được áp dụng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLSV_CVSColorPickEdit_EditValueChanged(object sender, EventArgs e)
        {
            ColorPickEdit cVSColorPickEdit = sender as ColorPickEdit;
            QLSV_View_GridView.Appearance.OddRow.BackColor = cVSColorPickEdit.Color;
            QLSV_View_GridView.Appearance.EvenRow.BackColor = cVSColorPickEdit.Color;
        }

        /// <summary>
        /// Custom lại EditForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLSV_View_GridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
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
        private void QLSV_Add_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Click btn [Add]
                // Thêm dòng dữ liệu trống mới
                DataRowView newRow = (DataRowView)SinhVienBdS.AddNew();
                QL_KTXDataSet.SINHVIEN.Rows.InsertAt(newRow.Row, 0);
                SinhVienBdS.Position = 0;

                newRow["XETDIEUKIEN"] = true;
                CommonService.ApplyCurrentMaQL(newRow);
                QLSV_View_GridView.ShowEditForm();
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
        private void QLSV_Save_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Lưu dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Save (Update)
                // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
                this.Validate();

                SinhVienBdS.EndEdit();
                //tblSinhVienDataView.RowStateFilter = DataViewRowState.OriginalRows;
                // Update dữ liệu vào CSDL
                this.SinhVienTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    /*if (HasChanges())
                    {
                        XtraMessageBox.Show("u have hanges");
                    }*/
                    //tblSinhVienDataView.Table

                    SinhVienTableAdapter.Update(QL_KTXDataSet.SINHVIEN);

                    XtraMessageBox.Show("Lưu dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if(ex.Message.Contains("Violation of PRIMARY KEY constraint 'PK_SINHVIEN'"))
                        XtraMessageBox.Show("Lỗi: Không thể trùng lặp mã sinh viên!", "Thông báo");
                    SinhVienBdS.CancelEdit();
                }
            }
            else if(confirm == DialogResult.No)
            {
                SinhVienBdS.CancelEdit();
            }
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLSV_Delete_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Xóa dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Delete
                // Xóa dòng dữ liệu hiện tại
                SinhVienBdS.RemoveCurrent();
                SinhVienBdS.EndEdit();
                //tblSinhVienDataView.RowStateFilter = DataViewRowState.Deleted;
                // Update dữ liệu vào CSDL
                //SinhVienTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    SinhVienTableAdapter.Update(QL_KTXDataSet.SINHVIEN);

                    XtraMessageBox.Show("Xóa dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint \"FK_HOPDONG_SINHVIEN\""))
                        XtraMessageBox.Show("Lỗi: Không thể xóa vì còn tồn tại\nhợp đồng của sinh viên này!", "Thông báo");
                    SinhVienBdS.CancelEdit();
                    QL_KTXDataSet.SINHVIEN.RejectChanges();
                    SinhVienBdS.MovePrevious();
                }
            }
            else if (confirm == DialogResult.No)
            {
                SinhVienBdS.CancelEdit();
            }
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLSV_Reload_Btn_Click(object sender, EventArgs e)
        {
            // Click btn Reload
            // Lấy data từ CSDL về DataTable QL_KTXDataSet.SINHVIEN
            SinhVienBdS.DataSource = QL_KTXDataSet;
            SinhVienBdS.DataMember = "SINHVIEN";

            FillDataFromDatabase();
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Search Filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLSV_FilterSearchBtn_Click(object sender, EventArgs e)
        {
            String condition = MakeFilterCondition();

            FillDataFromDatabase();

            if (condition == null)
            {
                SinhVienBdS.DataSource = QL_KTXDataSet;
                SinhVienBdS.DataMember = "SINHVIEN";
            }
            else
            {
                tblSinhVienDataView = new DataView(QL_KTXDataSet.SINHVIEN);
                tblSinhVienDataView.RowFilter = condition;
                SinhVienBdS.DataSource = tblSinhVienDataView;
            }          
        }

        /// <summary>
        /// Tạo câu điều kiện để search filter
        /// </summary>
        /// <returns></returns>
        private String MakeFilterCondition()
        {
            String filterExpression = null;

            if (!QLSV_Filter_MaSVTxt.Text.Equals(""))
            {
                filterExpression += "MASV LIKE '%" + QLSV_Filter_MaSVTxt.Text.Trim() + "%' "; 
            }

            if (!QLSV_Filter_HoTxt.Text.Equals(""))
            {
                filterExpression += "AND HO LIKE '%" + QLSV_Filter_HoTxt.Text.Trim() + "%' ";
            }

            if (!QLSV_Filter_TenTxt.Text.Equals(""))
            {
                filterExpression += "AND TEN LIKE '%" + QLSV_Filter_TenTxt.Text.Trim() + "%' ";
            }

            // Nếu [CheckState] = [Checked] thì chọn đủ dk
            if (QLSV_Filter_XetDKChk.CheckState == CheckState.Checked)
            {
                filterExpression += "AND XETDIEUKIEN = 'TRUE' ";
            }
            // Nếu [CheckState] = [Unchecked] thì chọn ko đủ dk
            else if (QLSV_Filter_XetDKChk.CheckState == CheckState.Unchecked)
            {
                filterExpression += "AND XETDIEUKIEN = 'FALSE' ";
            }
            // Trường hợp còn lại nếu [CheckState] = [Indeterminate] thì chọn tất cả
            //else if (QLSV_Filter_XetDKChk.CheckState == CheckState.Indeterminate)

            if (!QLSV_Filter_NgaySinhDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYSINH, 'System.String') LIKE '%/" + QLSV_Filter_NgaySinhDate.Text.TrimStart("0".ToCharArray()) + "/%' ";
            }

            if (!QLSV_Filter_ThangSinhDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYSINH, 'System.String') LIKE '" + QLSV_Filter_ThangSinhDate.Text.TrimStart("0".ToCharArray()) + "/%' ";
            }

            if (!QLSV_Filter_NamSinhDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYSINH, 'System.String') LIKE '%/" + QLSV_Filter_NamSinhDate.Text.TrimStart("0".ToCharArray()) + "%' ";
            }

            if (!QLSV_Filter_SDTTxt.Text.Equals(""))
            {
                filterExpression += "AND SDT LIKE '%" + QLSV_Filter_SDTTxt.Text.Trim() + "%' ";
            }

            if (!QLSV_Filter_GioiTinhCb.Text.Equals("") && !QLSV_Filter_GioiTinhCb.Text.Equals("--"))
            {
                filterExpression += "AND GIOITINH LIKE '%" + QLSV_Filter_GioiTinhCb.Text.Trim() + "%' ";
            }

            if (!QLSV_Filter_VPNQTxt.Text.Equals(""))
            {
                filterExpression += "AND VIPHAMNOIQUY LIKE '%" + QLSV_Filter_VPNQTxt.Text.Trim() + "%' ";
            }

            if (!QLSV_Filter_DiaChiTxt.Text.Equals(""))
            {
                filterExpression += "AND DIACHI LIKE '%" + QLSV_Filter_DiaChiTxt.Text.Trim() + "%' ";
            }

            if (!QLSV_Filter_MaQLTxt.Text.Equals(""))
            {
                filterExpression += "AND MAQL LIKE '%" + QLSV_Filter_MaQLTxt.Text.Trim() + "%' ";
            }
            return (filterExpression != null && filterExpression.StartsWith("AND ")) ? filterExpression.Remove(0, 4) : filterExpression;
        }

        /// <summary>
        /// Clear các điều kiện search filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLSV_FilterClearBtn_Click(object sender, EventArgs e)
        {
            QLSV_Filter_MaSVTxt.Text = String.Empty;
            QLSV_Filter_HoTxt.Text = String.Empty;
            QLSV_Filter_TenTxt.Text = String.Empty;
            QLSV_Filter_NgaySinhDate.Text = String.Empty;
            QLSV_Filter_NgaySinhDate.EditValue = null;
            QLSV_Filter_ThangSinhDate.Text = String.Empty;
            QLSV_Filter_ThangSinhDate.EditValue = null;
            QLSV_Filter_NamSinhDate.Text = String.Empty;
            QLSV_Filter_NamSinhDate.EditValue = null;
            QLSV_Filter_XetDKChk.CheckState = CheckState.Indeterminate;
            QLSV_Filter_SDTTxt.Text = String.Empty;
            QLSV_Filter_GioiTinhCb.SelectedItem = "--";
            QLSV_Filter_VPNQTxt.Text = String.Empty;
            QLSV_Filter_DiaChiTxt.Text = String.Empty;
            QLSV_Filter_MaQLTxt.Text = String.Empty;
        }

        private void InitDetailEditFormComponent(Control control)
        {
            if (control.Tag.Equals("EditValue/MASV"))
            {
                (control as TextEdit).MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                (control as TextEdit).MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                (control as TextEdit).MaskBox.AutoCompleteCustomSource = CommonService.AutoCompleteDSMaSVCollection(QL_KTXDataSet.SINHVIEN);
            }
        }
    }
    
}
