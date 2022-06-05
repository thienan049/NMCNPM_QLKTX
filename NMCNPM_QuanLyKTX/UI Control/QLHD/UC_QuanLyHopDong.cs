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

namespace NMCNPM_QuanLyKTX.UI_Control
{
    public partial class UC_QuanLyHopDong : DevExpress.XtraEditors.XtraUserControl
    {
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

        // <summary>
        /// Xử lý khi nhấn các button trong qlhd_ActionBtnPanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_ActionBtnPanel_ButtonClick_1(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            // Click btn Add
            if (e.Button == QLHD_ActionBtnPanel.Buttons[0])
            {
                // Thêm dòng dữ liệu trống mới
                HopDongBDS.AddNew();
            }
            // Click btn Save (Update)
            else if (e.Button == QLHD_ActionBtnPanel.Buttons[1])
            {
                // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
                this.Validate();
                HopDongBDS.EndEdit();

                // Update dữ liệu vào CSDL
                //this.userTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    HopDongTableAdapter.Update(QL_KTXDataSet.HOPDONG);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            // Click btn Delete
            else
            {
                // Xóa dòng dữ liệu hiện tại
                HopDongBDS.RemoveCurrent();

                // Update dữ liệu vào CSDL
                //sinhVienTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    HopDongTableAdapter.Update(QL_KTXDataSet.HOPDONG);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Xử lý khi nhấn các button trong qlhd_ActionBtnPanel2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_ActionBtnPanel2_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            // Click btn Reload
            if (e.Button == QLHD_ActionBtnPanel.Buttons[0])
            {
                // Lấy data từ CSDL về DataTable ql_KTX_DS.HOPDONG
                FillDataFromDatabase();
            }
        }

        private void QLHD_View_GridView_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
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
    }
}
