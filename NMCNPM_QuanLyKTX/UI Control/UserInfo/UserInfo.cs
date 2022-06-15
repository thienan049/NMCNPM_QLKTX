using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NMCNPM_QuanLyKTX.UI_Control.UserInfo
{
    public partial class UserInfo : Form
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            User_Ho_Val.Text = Program.HoUser;
            User_Ten_Val.Text = Program.TenUser;
            User_NgayNhanViec_Val.Text = DateTime.Parse(Program.NgayNhanViec).ToString("dd-MM-yyyy");
            User_MaQL_Val.Text = Program.MaQL;
            User_Username_Val.Text = Program.Username;

            foreach(String pms in GetUserPermissionList())
            {
                ShowPermissionDetail.ToolTip += pms + "\n";
            }
        }

        private void BtnOKCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<String> GetUserPermissionList()
        {
            List<String> Permissions = new List<string>();

            QL_KTXDataSet.EnforceConstraints = false;

            SP_GetUserPermissionTableAdapter.Fill(QL_KTXDataSet.SP_GETUSERPERMISSION, Program.Username);

            if(QL_KTXDataSet.SP_GETUSERPERMISSION.Rows.Count != 0)
            {
                foreach (DataRow row in QL_KTXDataSet.SP_GETUSERPERMISSION.Rows)
                {
                    Permissions.Add(row["VAITRO"] + ": " + row["CONGVIEC"]);
                }
            }          

            return Permissions;
        }
    }

}
