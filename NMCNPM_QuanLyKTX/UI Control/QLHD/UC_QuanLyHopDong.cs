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
        }

        /// <summary>
        /// Lấy data từ CSDL về DataSet
        /// </summary>
        private void FillDataFromDatabase()
        {
            QL_KTXDataSet.EnforceConstraints = false;

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.HOPDONG]
            HopDongTableAdapter.Fill(QL_KTXDataSet.HOPDONG);
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_Add_Btn_Click(object sender, EventArgs e)
        {
            // Click btn Add
            // Thêm dòng dữ liệu trống mới
            HopDongBdS.AddNew();

        }

        /// <summary>
        /// Xử lý khi nhấn Btn Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_Save_Btn_Click(object sender, EventArgs e)
        {
            // Click btn Save (Update)
            // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
            this.Validate();
            HopDongBdS.EndEdit();

            // Update dữ liệu vào CSDL
            try
            {
                HopDongTableAdapter.Update(QL_KTXDataSet.HOPDONG);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_Delete_Btn_Click(object sender, EventArgs e)
        {
            // Click btn Delete
            // Xóa dòng dữ liệu hiện tại
            HopDongBdS.RemoveCurrent();

            // Update dữ liệu vào CSDL
            try
            {
                HopDongTableAdapter.Update(QL_KTXDataSet.HOPDONG);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            FillDataFromDatabase();
        }

        private void QLHD_View_GridView_EditFormPrepared_1(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {
            TextEdit sampleControl = (TextEdit)e.BindableControls["MAHD"];

            foreach (Control control in e.BindableControls)
            {
                if (control is TextEdit)
                {
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
                filterExpression += "MAHD LIKE '%" + QLHD_Filter_MaSVTxt.Text.Trim() + "%' ";
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
                filterExpression += "AND Convert(NGAYSINH, 'System.String') LIKE '*/" + QLHD_Filter_NgayTaoDate.Text.TrimStart("0".ToCharArray()) + "/*' ";
            }

            if (!QLHD_Filter_ThangTaoDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYSINH, 'System.String') LIKE '" + QLHD_Filter_ThangTaoDate.Text.TrimStart("0".ToCharArray()) + "/*' ";
            }

            if (!QLHD_Filter_NamTaoDate.Text.Equals(""))
            {
                filterExpression += "AND Convert(NGAYSINH, 'System.String') LIKE '*/" + QLHD_Filter_NamTaoDate.Text.TrimStart("0".ToCharArray()) + "*' ";
            }

            if (!QLHD_Filter_NamHocTuTxt.Text.Equals(""))
            {
                filterExpression += "AND NAMHOC LIKE '" + QLHD_Filter_NamHocTuTxt.Text.Trim() + "-%' ";
            }

            if (!QLHD_Filter_NamHocDenTxt.Text.Equals(""))
            {
                filterExpression += "AND NAMHOC LIKE '%-" + QLHD_Filter_NamHocDenTxt.Text.Trim() + "' ";
            }

            if (!QLHD_Filter_HocKyCb.Text.Equals("") && !QLHD_Filter_HocKyCb.Text.Equals("--"))
            {
                filterExpression += "AND HOCKY = '" + QLHD_Filter_HocKyCb.Text.Trim() + "' ";
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

        private void QLHD_MaPhongPopupEd_RepoItem_BeforePopup(object sender, EventArgs e)
        {
            QL_KTXDataSet.EnforceConstraints = false;
            // Lấy data từ CSDL về DataTable [ql_KTX_DS.HOPDONG]
            PhongTableAdapter.Fill(QL_KTXDataSet.PHONG);

            QLHD_MaPhongPopupCtl_RepoItem.Size = new Size(549, 223);
        }

        private void QLHD_MaPhongPopupEd_RepoItem_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            e.Value = ((DataRowView)PhongBdS[PhongBdS.Position])["MAPHONG"].ToString();
        }
    }
}
