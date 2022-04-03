using DevExpress.XtraEditors;
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
    public partial class UC_QuanLySinhVien : DevExpress.XtraEditors.XtraUserControl
    {
        public UC_QuanLySinhVien()
        {
            InitializeComponent();
        }

        // 
        private void UC_QuanLySinhVien_Load(object sender, EventArgs e)
        {
            ql_KTX_DS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'qLVTDataSet.Kho' table. You can move, or remove it, as needed.
            sinhVienTableAdapter.Connection.ConnectionString = Program.ConnStr;
            sinhVienTableAdapter.Fill(ql_KTX_DS.SINHVIEN);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {          
            //this.userTableAdapter.Connection.ConnectionString = Program.ConnStr;
            sinhVienTableAdapter.Update(ql_KTX_DS.SINHVIEN);
        }

        private void qlsv_ActionBtnPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {          
            // Click btn Add
            if (e.Button == qlsv_ActionBtnPanel.Buttons[0])
            {
                sinhVienBdS.AddNew();
                
            }
            // Click btn Save (Update)
            else if (e.Button == qlsv_ActionBtnPanel.Buttons[1])
            {
                sinhVienBdS.EndEdit();

                //this.userTableAdapter.Connection.ConnectionString = Program.ConnStr;
                sinhVienTableAdapter.Update(ql_KTX_DS.SINHVIEN);
            }
            // Click btn Delete
            else
            {
                sinhVienBdS.RemoveCurrent();
                //sinhVienTableAdapter.Connection.ConnectionString = Program.ConnStr;
                sinhVienTableAdapter.Update(this.ql_KTX_DS.SINHVIEN);
            }
        }
    }
}
