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
using static DevExpress.XtraEditors.BaseCheckedListBoxControl;

namespace NMCNPM_QuanLyKTX.UI_Control.QLTK
{
    public partial class UC_CapQuyenTaiKhoan : XtraUserControl
    {
        bool isVerifiedAdmin = false;
        bool isCapQuyenChanged = false;
        bool isCapChiTietCvPQ = false;

        public UC_CapQuyenTaiKhoan()
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
        }

        private void GetDataList()
        {
            CQTK_DanhSachQuyenListBox.Items.Clear();
            CQTK_DanhSachQuyenQLListBox.Items.Clear();
            CQTK_DanhSachTKListBox.Items.Clear();
            CQTK_DanhSachChiTietCVListBox.Items.Clear();

            foreach (String pq in GetListPhanQuyen())
            {
                CQTK_DanhSachQuyenListBox.Items.Add(pq.Trim());
                CQTK_DanhSachQuyenQLListBox.Items.Add(new ImageListBoxItem
                {
                    Image = User_Icon_SVGCol.GetImage(1),
                    Value = pq.Trim()
                });

            }

            foreach (String tk in GetListTaiKhoan())
            {
                CQTK_DanhSachTKListBox.Items.Add(new ImageListBoxItem
                {
                    Image = User_Icon_SVGCol.GetImage(0),
                    Value = tk.Trim()
                });
            }

            foreach (String cv in GetListChiTietCV())
            {
                CQTK_DanhSachChiTietCVListBox.Items.Add(cv.Trim());
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
            // Lấy data từ CSDL về DataTable [ql_KTX_DS.PHANQUYEN]
            QuyenTKTableAdapter.Fill(QL_KTXDataSet.QUYENTAIKHOAN);
            // Lấy data từ CSDL về DataTable [ql_KTX_DS.PHANQUYEN]
            PermissionTableAdapter.Fill(QL_KTXDataSet.PERMISSION);

            GetDataList();
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLTK_Reload_Btn_Click(object sender, EventArgs e)
        {
            FillDataFromDatabase();
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
                listPQ.Add((string)row["VAITRO"]);

            return listPQ;
        }

        /// <summary>
        /// Get danh sách các tài khoản hiện có
        /// </summary>
        private List<string> GetListTaiKhoan()
        {
            DataRowCollection tableRows = QL_KTXDataSet.TAIKHOAN.Rows;

            List<string> listTK = new List<string>(tableRows.Count);

            foreach (DataRow row in tableRows)
                listTK.Add((string)row["USERNAME"]);

            return listTK;
        }

        /// <summary>
        /// Get danh sách các công việc chi tiết hiện có
        /// </summary>
        /// <returns></returns>
        private List<string> GetListChiTietCV()
        {
            DataRowCollection tableRows = QL_KTXDataSet.PERMISSION.Rows;

            List<string> listCV = new List<string>(tableRows.Count);

            foreach (DataRow row in tableRows)
                listCV.Add((string)row["CONGVIEC"]);

            return listCV;
        }       

        private void CQTK_DanhSachTKListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (isCapQuyenChanged)
            {
                DialogResult rs = XtraMessageBox.Show("Đã có sự chỉnh sửa xảy ra, Bạn có muốn lưu thay đổi?", "Thông báo", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                    UpdateTK_QTKData();
                isCapQuyenChanged = false;
            }*/
            if(CQTK_DanhSachTKListBox.Items.Count != 0)
            {
                CQTK_DanhSachQuyenListBox.UnCheckAll();
                QL_KTXDataSet.EnforceConstraints = false;

                SP_GetUserPQTableAdapter.Fill(QL_KTXDataSet.SP_GETUSERPHANQUYEN, CQTK_DanhSachTKListBox.SelectedItem.ToString());

                foreach (DataRow row in QL_KTXDataSet.SP_GETUSERPHANQUYEN.Rows)
                {
                    int idx;
                    if ((idx = CQTK_DanhSachQuyenListBox.Items.IndexOf(row["VAITRO"])) != -1)
                    {
                        CQTK_DanhSachQuyenListBox.SetItemChecked(idx, true);
                    }
                }
            }                  
        }

        private void CQTK_SaveTK_QTK_Btn_Click(object sender, EventArgs e)
        {
            UpdateTK_QTKData();
            isCapQuyenChanged = false;
        }

        private void CQTK_DanhSachQuyenListBox_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            isCapQuyenChanged = true;
        }

        private void UpdateTK_QTKData()
        {
            if (isCapQuyenChanged)
            {
                DialogResult rs = XtraMessageBox.Show("Bạn có muốn lưu thay đổi cập nhật TK - PQTK?", "Thông báo", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    CheckedItemCollection list = CQTK_DanhSachQuyenListBox.CheckedItems;
                    SqlCommand sqlCmd = null;

                    String cmdINS, cmdDEL;
                    String editedTK = CQTK_DanhSachTKListBox.SelectedItem.ToString().Trim();
                    cmdDEL = "DELETE FROM " + CommonConstant.TableName.QTK + " WHERE USERNAME = '" + editedTK + "'";

                    if (list.Count != 0)
                    {
                        cmdINS = "INSERT INTO " + CommonConstant.TableName.QTK + " VALUES ";
                        for (int idx = 0; idx < list.Count; idx++)
                        {
                            if (idx != list.Count - 1)
                                cmdINS += "('" + editedTK + "', '" + QL_KTXDataSet.PHANQUYEN.Select("VAITRO = '" + list[idx] + "'")[0]["MAPQ"] + "', '" + DateTime.Today + "'), ";
                            else
                                cmdINS += "('" + editedTK + "', '" + QL_KTXDataSet.PHANQUYEN.Select("VAITRO = '" + list[idx] + "'")[0]["MAPQ"] + "', '" + DateTime.Today + "');";

                        }
                        try
                        {
                            sqlCmd = new SqlCommand(cmdDEL, Program.DBConnection);
                            sqlCmd.ExecuteNonQuery();
                            sqlCmd = new SqlCommand(cmdINS, Program.DBConnection);
                            sqlCmd.ExecuteNonQuery();
                            XtraMessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("Cập nhật thông tin thất bại!", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        try
                        {
                            sqlCmd = new SqlCommand(cmdDEL, Program.DBConnection);
                            sqlCmd.ExecuteNonQuery();
                            XtraMessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("Cập nhật thông tin thất bại!", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No changes were made!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void CQTK_DanhSachQuyenQLListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CQTK_DanhSachQuyenQLListBox.Items.Count != 0)
            {
                CQTK_DanhSachChiTietCVListBox.UnCheckAll();
                QL_KTXDataSet.EnforceConstraints = false;

                SP_GetPQPMSTableAdapter.Fill(QL_KTXDataSet.SP_GETPHANQUYENPERMISSION,
                    QL_KTXDataSet.PHANQUYEN.Select("VAITRO = '" + CQTK_DanhSachQuyenQLListBox.SelectedItem.ToString().Trim() + "'")[0]["MAPQ"].ToString().Trim());

                foreach (DataRow row in QL_KTXDataSet.SP_GETPHANQUYENPERMISSION.Rows)
                {
                    int idx;
                    if ((idx = CQTK_DanhSachChiTietCVListBox.Items.IndexOf(row["CONGVIEC"])) != -1)
                    {
                        CQTK_DanhSachChiTietCVListBox.SetItemChecked(idx, true);
                    }
                }
            }
           
        }

        private void CQTK_SavePQ_CVPQ_Btn_Click(object sender, EventArgs e)
        {
            UpdatePQ_CVPQData();
            isCapChiTietCvPQ = false;
        }

        private void UpdatePQ_CVPQData()
        {
            if (isCapChiTietCvPQ)
            {
                DialogResult rs = XtraMessageBox.Show("Bạn có muốn lưu thay đổi cập nhật PQ - Công việc PQ?", "Thông báo", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    CheckedItemCollection list = CQTK_DanhSachChiTietCVListBox.CheckedItems;
                    SqlCommand sqlCmd = null;

                    String cmdINS, cmdDEL;
                    String editedPQ = QL_KTXDataSet.PHANQUYEN.Select("VAITRO = '" + CQTK_DanhSachQuyenQLListBox.SelectedItem.ToString().Trim() + "'")[0]["MAPQ"].ToString();
                    cmdDEL = "DELETE FROM " + CommonConstant.TableName.PCV + " WHERE MAPQ= '" + editedPQ + "'";

                    if (list.Count != 0)
                    {
                        cmdINS = "INSERT INTO " + CommonConstant.TableName.PCV + " VALUES ";
                        for (int idx = 0; idx < list.Count; idx++)
                        {
                            if (idx != list.Count - 1)
                                cmdINS += "('" + editedPQ + "', '" + QL_KTXDataSet.PERMISSION.Select("CONGVIEC = '" + list[idx] + "'")[0]["MAPMS"] + "'), ";
                            else
                                cmdINS += "('" + editedPQ + "', '" + QL_KTXDataSet.PERMISSION.Select("CONGVIEC = '" + list[idx] + "'")[0]["MAPMS"] + "');";

                        }
                        try
                        {
                            sqlCmd = new SqlCommand(cmdDEL, Program.DBConnection);
                            sqlCmd.ExecuteNonQuery();
                            sqlCmd = new SqlCommand(cmdINS, Program.DBConnection);
                            sqlCmd.ExecuteNonQuery();
                            XtraMessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("Cập nhật thông tin thất bại!", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        try
                        {
                            sqlCmd = new SqlCommand(cmdDEL, Program.DBConnection);
                            sqlCmd.ExecuteNonQuery();
                            XtraMessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("Cập nhật thông tin thất bại!", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No changes were made!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void CQTK_DanhSachChiTietCVListBox_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            isCapChiTietCvPQ = true;
        }

        /// <summary>
        /// Xử lý khi nhấn Btn Add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CQTK_PQ_Add_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Click btn [Add]
                // Thêm dòng dữ liệu trống mới
                DataRowView newRow = (DataRowView)PhanQuyenBdS.AddNew();
                QL_KTXDataSet.PHANQUYEN.Rows.InsertAt(newRow.Row, 0);
                PhanQuyenBdS.Position = 0;

                CQTK_PhanQuyen_View_GridView.ShowEditForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void CQTK_PQ_Save_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Lưu dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Save (Update)
                // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
                this.Validate();

                PhanQuyenBdS.EndEdit();
                // Update dữ liệu vào CSDL
                this.PhanQuyenTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    PhanQuyenTableAdapter.Update(QL_KTXDataSet.PHANQUYEN);

                    XtraMessageBox.Show("Lưu dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                        XtraMessageBox.Show("Lỗi: Không thể trùng lặp mã PQ!", "Thông báo");
                    PhanQuyenBdS.CancelEdit();
                }
            }
            else if (confirm == DialogResult.No)
            {
                PhanQuyenBdS.CancelEdit();
            }
        }

        private void CQTK_PQ_Delete_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Xóa dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Delete
                // Xóa dòng dữ liệu hiện tại
                PhanQuyenBdS.RemoveCurrent();
                PhanQuyenBdS.EndEdit();
                // Update dữ liệu vào CSDL
                try
                {
                    PhanQuyenTableAdapter.Update(QL_KTXDataSet.PHANQUYEN);

                    XtraMessageBox.Show("Xóa dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        XtraMessageBox.Show("Lỗi: Không thể xóa vì dữ liệu hiện đang còn được sử dụng!", "Thông báo");
                    PhanQuyenBdS.CancelEdit();
                    QL_KTXDataSet.PHANQUYEN.RejectChanges();
                    PhanQuyenBdS.MovePrevious();
                }
            }
            else if (confirm == DialogResult.No)
            {
                PhanQuyenBdS.CancelEdit();
            }
        }

        private void CQTK_Reload_Btn3_Click(object sender, EventArgs e)
        {
            FillDataFromDatabase();
        }

        private void CQTK_PQ_Cancel_Btn_Click(object sender, EventArgs e)
        {
            PhanQuyenBdS.CancelEdit();
            try
            {
                if (QL_KTXDataSet.PHANQUYEN.Rows[0].RowState == DataRowState.Added)
                    PhanQuyenBdS.RemoveAt(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void CQTK_CTCV_Add_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Click btn [Add]
                // Thêm dòng dữ liệu trống mới
                DataRowView newRow = (DataRowView)PermissionBdS.AddNew();
                QL_KTXDataSet.PERMISSION.Rows.InsertAt(newRow.Row, 0);
                PermissionBdS.Position = 0;

                CQTK_Permission_View_GridView.ShowEditForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void CQTK_CTCV_Save_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Lưu dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Save (Update)
                // Apply data đã chỉnh sửa trên giao diện vào DataSet/DataTable
                this.Validate();

                PermissionBdS.EndEdit();
                // Update dữ liệu vào CSDL
                this.PermissionTableAdapter.Connection.ConnectionString = Program.ConnStr;
                try
                {
                    PermissionTableAdapter.Update(QL_KTXDataSet.PERMISSION);

                    XtraMessageBox.Show("Lưu dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                        XtraMessageBox.Show("Lỗi: Không thể trùng lặp mã!", "Thông báo");
                    PermissionBdS.CancelEdit();
                }
            }
            else if (confirm == DialogResult.No)
            {
                PermissionBdS.CancelEdit();
            }
        }

        private void CQTK_CTCV_Delete_Btn_Click(object sender, EventArgs e)
        {
            DialogResult confirm = XtraMessageBox.Show("Xóa dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Click btn Delete
                // Xóa dòng dữ liệu hiện tại
                PermissionBdS.RemoveCurrent();
                PermissionBdS.EndEdit();
                // Update dữ liệu vào CSDL
                try
                {
                    PermissionTableAdapter.Update(QL_KTXDataSet.PERMISSION);

                    XtraMessageBox.Show("Xóa dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        XtraMessageBox.Show("Lỗi: Không thể xóa vì dữ liệu hiện đang còn được sử dụng!", "Thông báo");
                    PermissionBdS.CancelEdit();
                    QL_KTXDataSet.PERMISSION.RejectChanges();
                    PermissionBdS.MovePrevious();
                }
            }
            else if (confirm == DialogResult.No)
            {
                PermissionBdS.CancelEdit();
            }
        }

        private void CQTK_Reload_Btn4_Click(object sender, EventArgs e)
        {
            FillDataFromDatabase();
        }

        private void CQTK_CTCV_Cancel_Btn_Click(object sender, EventArgs e)
        {
            PermissionBdS.CancelEdit();
            try
            {
                if (QL_KTXDataSet.PERMISSION.Rows[0].RowState == DataRowState.Added)
                    PermissionBdS.RemoveAt(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void CQTK_Reload_Btn2_Click(object sender, EventArgs e)
        {
            FillDataFromDatabase();
        }
    }
    
}
