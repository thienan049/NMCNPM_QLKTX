using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NMCNPM_QuanLyKTX.UI_Control.Custom_EditForm
{
    public partial class UC_QLSV_EditForm : UserControl
    {
        public UC_QLSV_EditForm()
        {
            InitializeComponent();
        }

        public void InitDataBinding(BindingSource dataSource)
        {
            this.QLSV_EditForm_MaSV.DataBindings.Add(new Binding("EditValue", dataSource, "MASV", true));
            this.QLSV_EditForm_XetDK.DataBindings.Add(new Binding("EditValue", dataSource, "XETDIEUKIEN", true));
            this.QLSV_EditForm_Ho.DataBindings.Add(new Binding("EditValue", dataSource, "HO", true));
            this.QLSV_EditForm_Ten.DataBindings.Add(new Binding("EditValue", dataSource, "TEN", true));
        }
    }
}
