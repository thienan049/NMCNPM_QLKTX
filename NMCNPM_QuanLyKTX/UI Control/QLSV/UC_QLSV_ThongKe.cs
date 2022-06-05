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

namespace NMCNPM_QuanLyKTX.UI_Control.QLSV
{
    public partial class UC_QLSV_ThongKe : UserControl
    {
        DataView thongKeDataView = null;

        public UC_QLSV_ThongKe()
        {
            InitializeComponent();
            InitComponent();
        }

        private void QLSV_btnSearchTK_Click(object sender, EventArgs e)
        {
            if (QLSV_LoaiThongKeCb.SelectedItem.Equals("Sinh viên vi phạm"))
            {
                QL_KTXDataSet.EnforceConstraints = false;
                SinhVienTableAdapter.Fill(QL_KTXDataSet.SINHVIEN);

                String condition = "VIPHAMNOIQUY <> '' OR VIPHAMNOIQUY <> NULL";
                thongKeDataView = new DataView(QL_KTXDataSet.SINHVIEN);
                thongKeDataView.RowFilter = condition;
                SinhVienBdS.DataSource = thongKeDataView;
            }
        }
        
        private void InitComponent()
        {
            this.QLSV_LoaiThongKeCb.Properties.Items.Add("Sinh viên vi phạm");
        }

        private void QLSV_TKSV_View_GridView_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {

        }

        private void sINHVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.SinhVienBdS.EndEdit();
            this.tableAdapterManager.UpdateAll(this.QL_KTXDataSet);

        }
    }
}
