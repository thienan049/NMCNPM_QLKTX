using DevExpress.XtraBars.Docking2010;
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

namespace NMCNPM_QuanLyKTX.UI_Control.QLCSVC
{
    public partial class UC_QuanLyCSVC : XtraUserControl
    {
        // Kiểm tra trạng thái đóng mở của CustomViewSetting SidePanel
        private bool isSidePaneCollapsed = true;

        public UC_QuanLyCSVC()
        {
            InitializeComponent();
        }

        private void UC_QuanLyCSVC_Load(object sender, EventArgs e)
        {
            // Lấy data từ CSDL
            FillDataFromDatabase();

            // Kiểm tra chế độ sử dụng app là có/không Login
            if (!CommonService.CheckAccessMode())
                CommonService.InitAppNoLoginMode(QLCSVC_View_GridView, QLCSVC_ActionBtn_Panel);
        }

        /// <summary>
        /// Lấy data từ CSDL về DataSet
        /// </summary>
        private void FillDataFromDatabase()
        {
            QL_KTXDataSet.EnforceConstraints = false;

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.PHONG]
            VatTuTableAdapter.Fill(QL_KTXDataSet.VATTU);
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Add] thông tin phòng mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLCSVC_Add_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Click btn [Add]
                // Thêm dòng dữ liệu trống mới
                DataRowView newRow = (DataRowView)VatTuBdS.AddNew();
                QL_KTXDataSet.VATTU.Rows.InsertAt(newRow.Row, 0);
                VatTuBdS.Position = 0;

                CommonService.ApplyCurrentMaQL(newRow);
                QLCSVC_View_GridView.ShowEditForm();
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
        private void QLCSVC_Save_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Lưu dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Save (Update)
                // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
                this.Validate();

                VatTuBdS.EndEdit();
                // Update dữ liệu vào CSDL
                this.VatTuTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    VatTuTableAdapter.Update(QL_KTXDataSet.VATTU);

                    XtraMessageBox.Show("Lưu dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                        XtraMessageBox.Show("Lỗi: Không thể trùng lặp mã!", "Thông báo");
                    VatTuBdS.CancelEdit();
                }
            }
            else if (confirm == DialogResult.No)
            {
                VatTuBdS.CancelEdit();
            }
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Delete] thông tin phòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLCSVC_Delete_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Xóa dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Delete
                // Xóa dòng dữ liệu hiện tại
                VatTuBdS.RemoveCurrent();
                VatTuBdS.EndEdit();
                try
                {
                    VatTuTableAdapter.Update(QL_KTXDataSet.VATTU);

                    XtraMessageBox.Show("Xóa dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        XtraMessageBox.Show("Lỗi: Không thể xóa vì phòng còn được sử dụng!", "Thông báo");
                    VatTuBdS.CancelEdit();
                    QL_KTXDataSet.VATTU.RejectChanges();
                    VatTuBdS.MovePrevious();
                }
            }
            else if (confirm == DialogResult.No)
            {
                VatTuBdS.CancelEdit();
            }
        }

        /// <summary>
        /// Xử lý khi nhấn nút [Reload] thông tin phòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLCSVC_Reload_Btn_Click(object sender, EventArgs e)
        {
            // Click btn [Reload]
            // Lấy data từ CSDL về DataTable ql_KTX_DS.PHONG
            FillDataFromDatabase();

            // Set data cho ComboBox column [LOAIPHONG] để sử dụng
            //CommonService.InitDSLoaiPhongBox(QLCSVC_LoaiPhongCb_RepoItem, QL_KTXDataSet.LOAIPHONG);
        }

        /// <summary>
        /// Toggle open/close custom DetailViewSetting side panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLCSVC_CustomViewSettingBtn_Click(object sender, EventArgs e)
        {
            // Nếu SidePanel là đóng, mở ra và hiển thị các lựa chọn
            if (isSidePaneCollapsed)
            {
                QLCSVC_CustomViewSettingSidePane.Width = 75;
                QLCSVC_CVSControlsPanel.Visible = true;
                isSidePaneCollapsed = false;
            }
            // Nếu SidePanel là mở, đóng lại và ẩn các lựa chọn
            else
            {
                QLCSVC_CustomViewSettingSidePane.Width = 30;
                QLCSVC_CVSControlsPanel.Visible = false;
                // Chỉ ẩn các lựa chọn custom khi ToggleSwitch là [Off]
                if (!QLCSVC_CVSToggleSwitch.IsOn)
                    QLCSVC_CVSMainControlsPanel.Visible = false;
                isSidePaneCollapsed = true;
            }
        }

        /// <summary>
        /// Toggle áp dụng/không áp dụng tính năng phân chia [EvenRow/OddRow]
        /// Nếu có áp dụng, cung cấp thêm các lựa chọn cho việc custom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLCSVC_CVSToggleSwitch_Toggled(object sender, EventArgs e)
        {
            /*
             * Nếu ToggleSwitch là [On] -> có áp dụng [EvenRow/OddRow]
             * Hiển thị các lựa chọn custom
             * Nếu ToggleSwitch là [Off] -> không áp dụng [EvenRow/OddRow]
             * Không hiển thị các lựa chọn custom
             */
            if (QLCSVC_CVSToggleSwitch.IsOn)
            {
                QLCSVC_CVSMainControlsPanel.Visible = true;

                // Áp dụng [AppearanceOddRow] (Mặc đinh)
                QLCSVC_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                QLCSVC_CVSMainControlsPanel.Visible = false;

                // Hủy áp dụng [AppearanceOddRow]
                if (QLCSVC_View_GridView.OptionsView.EnableAppearanceOddRow)
                    QLCSVC_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                // Hủy áp dụng [AppearanceEvenRow]
                if (QLCSVC_View_GridView.OptionsView.EnableAppearanceEvenRow)
                    QLCSVC_View_GridView.OptionsView.EnableAppearanceEvenRow = false; ;
            }
        }

        /// <summary>
        /// Nếu có áp dụng [EvenRow/OddRow]
        /// Cho phép lựa chọn [EvenRow] hoặc [OddRow]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLCSVC_CVSRowStyleBtn_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e.Button == QLCSVC_CVSRowStyleBtn.Buttons[0])
            {
                // Áp dụng [OddRow]
                QLCSVC_View_GridView.OptionsView.EnableAppearanceEvenRow = false;
                QLCSVC_View_GridView.OptionsView.EnableAppearanceOddRow = true;
            }
            else
            {
                // Áp dụng [EvenRow]
                QLCSVC_View_GridView.OptionsView.EnableAppearanceOddRow = false;
                QLCSVC_View_GridView.OptionsView.EnableAppearanceEvenRow = true;
            }
        }

        /// <summary>
        /// Set màu được chọn cho [OddRow/EvenRow] nếu đang được áp dụng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLCSVC_CVSColorPickEdit_EditValueChanged(object sender, EventArgs e)
        {
            ColorPickEdit cVSColorPickEdit = sender as ColorPickEdit;
            QLCSVC_View_GridView.Appearance.OddRow.BackColor = cVSColorPickEdit.Color;
            QLCSVC_View_GridView.Appearance.EvenRow.BackColor = cVSColorPickEdit.Color;
        }

        private void InitDetailEditFormComponent(Control control)
        {
            if (control.Tag.Equals("EditValue/GIATIEN"))
            {
                (control as TextEdit).Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                (control as TextEdit).Properties.Mask.EditMask = "n0";
                (control as TextEdit).Properties.Mask.UseMaskAsDisplayFormat = true;
            }
        }

        private void QLCSVC_View_GridView_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
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

        private void QLCSVC_CancelEdit_Btn_Click(object sender, EventArgs e)
        {
            VatTuBdS.CancelEdit();
            try
            {
                if (QL_KTXDataSet.VATTU.Rows[0].RowState == DataRowState.Added)
                    VatTuBdS.RemoveAt(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo");
            }
        }
    }
}
