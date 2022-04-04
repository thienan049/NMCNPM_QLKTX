using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NMCNPM_QuanLyKTX.UI_Control
{
    public partial class UC_QuanLyTaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Các xử lý khi form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UC_QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            // Lấy data từ CSDL
            FillDataFromDatabase();

            // Set column [PASSWORD] trong gridView thành dạng password display (*)          
            EnablePasswordDisplay(qltk_GridVw.Columns["PASSWORD"]);

            // Set data cho ComboBox column [PHANQUYEN] để sử dụng
            ApplyPredefinedDataToControl();
        }

        /// <summary>
        /// Xử lý khi nhấn các buttons trong [qltk_ActionBtnPanel]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qltk_ActionBtnPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            // Click btn [Add]
            if (e.Button == qltk_ActionBtnPanel.Buttons[0])
            {
                // Thêm dòng dữ liệu trống mới
                taiKhoanBdS.AddNew();
            }
            // Click btn [Save] (Update)
            else if (e.Button == qltk_ActionBtnPanel.Buttons[1])
            {
                // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
                this.Validate();
                taiKhoanBdS.EndEdit();

                // Update dữ liệu vào CSDL
                try
                {
                    taiKhoanTableAdapter.Update(ql_KTX_DS.TAIKHOAN);
                }
                catch (System.Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
            // Click btn [Delete]
            else
            {
                // Xóa dòng dữ liệu hiện tại
                taiKhoanBdS.RemoveCurrent();

                // Update dữ liệu vào CSDL
                try
                {
                    taiKhoanTableAdapter.Update(ql_KTX_DS.TAIKHOAN);
                }
                catch (System.Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Xử lý khi nhấn các button trong [qltk_ActionBtnPanel2]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qltk_ActionBtnPanel2_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            // Click btn [Reload]
            if (e.Button == qltk_ActionBtnPanel2.Buttons[0])
            {
                // Lấy data từ CSDL về DataTable ql_KTX_DS.TAIKHOAN
                FillDataFromDatabase();
            }
            // Click btn [ShowPassword]
            else if(e.Button == qltk_ActionBtnPanel2.Buttons[1])
            {
                GridColumn column = qltk_GridVw.Columns["PASSWORD"];
                TogglePasswordDisplay(column);
            }
        }

        /// <summary>
        /// Set một column trong gridView thành dạng password display (*)
        /// </summary>
        /// <param name="column"></param>
        private void EnablePasswordDisplay(GridColumn column)
        {
            RepositoryItemTextEdit passEdit = new RepositoryItemTextEdit();
            passEdit.PasswordChar = '*';

            if (column.ColumnEdit != null)
            {
                if (column.ColumnEdit is RepositoryItemTextEdit tEdit)
                    tEdit.PasswordChar = '*';
            }
            else
                column.ColumnEdit = passEdit;
        }

        /// <summary>
        /// Set một column trong gridView thành dạng normal display (*)
        /// </summary>
        /// <param name="column"></param>
        private void DisablePasswordDisplay(GridColumn column)
        {
            column.ColumnEdit = null;
        }

        /// <summary>
        /// Toggle normal/password display
        /// </summary>
        /// <param name="column"></param>
        private void TogglePasswordDisplay(GridColumn column)
        {
            // Nếu đang [password display] -> [normal display]
            if (column.ColumnEdit == null)
                EnablePasswordDisplay(column);
            // Nếu đang [normal display] -> [password display]
            else
            {
                // InputDialog nhập mật khẩu xác thực Admin
                string adminPasswordInput = XtraInputBox.Show("Nhập mật khẩu: ", "Xác thực quyền Admin", "Default");

                /*
                 * Thực hiện verify dựa trên username của TK đã login và mật khẩu xác thực
                 * Nếu thành công -> cho hiển thị password
                 * Nếu thất bại -> WARNING
                 */
                if (VerifyAdminAuthorization(Program.Username, adminPasswordInput))
                    DisablePasswordDisplay(column);
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
            DataRowCollection tableRows = ql_KTX_DS.PHANQUYEN.Rows;

            List<string> listPQ = new List<string>(tableRows.Count);

            foreach (DataRow row in tableRows)
                listPQ.Add((string)row[0]);

            return listPQ;
        }

        /// <summary>
        /// Lấy data từ CSDL về DataSet
        /// </summary>
        private void FillDataFromDatabase()
        {
            ql_KTX_DS.EnforceConstraints = false;

            // Lấy data từ CSDL về DataTable [ql_KTX_DS.TAIKHOAN]
            taiKhoanTableAdapter.Fill(ql_KTX_DS.TAIKHOAN);
            // Lấy data từ CSDL về DataTable [ql_KTX_DS.PHANQUYEN]
            phanQuyenTableAdapter.Fill(ql_KTX_DS.PHANQUYEN);
        }

        /// <summary>
        /// Thực hiện thêm các data có sẵn vào control cần sử dụng
        /// </summary>
        private void ApplyPredefinedDataToControl()
        {
            // Thêm data cho control [ComboBox] cột [PHANQUYEN]
            List<string> listPQ = GetListPhanQuyen();
            foreach (string item in listPQ)
            {
                maPQComboBox.Items.Add(item); maPQComboBox.TextEditStyle = TextEditStyles.DisableTextEditor;
            }
        }
    }
}
