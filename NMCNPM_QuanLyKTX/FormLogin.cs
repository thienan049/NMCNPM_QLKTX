using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Internal;
using System;
using System.Data.SqlClient;
using System.Drawing;

using System.Windows.Forms;

namespace NMCNPM_QuanLyKTX
{
    public partial class FormLogin : XtraForm
    {
        public FormLogin()
        {
            InitializeComponent();
            DevExpress.Skins.SkinManager.EnableFormSkins();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Mở kết nối đến DB
            Program.ConnectDB();   
            
        }

        /// <summary>
        /// Thực hiện login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doLoginBtnPanel_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e.Button == doLoginBtnPanel.Buttons[0])
            {
                /* Thực hiện login: chạy stored procedure login SP_DOLOGIN
                 * trả về 1 -> login hợp lệ -> thành công
                 * trả về 0 -> login ko hợp lệ -> thất bại
                 */
                string sqlCmdString = "exec SP_DOLOGIN '" + usernameTxtEd.Text.Trim() + "', '" + passwordTxtEd.Text.Trim() + "'";
                SqlCommand sqlCmd = new SqlCommand(sqlCmdString, Program.DBConnection);
                int result = (int)sqlCmd.ExecuteScalar();

                if(result == 1)
                {
                    ShowMessageBox(MessageBoxIcon.Information, "Login message", "Đăng nhập thành công");
                    Program.Username = usernameTxtEd.Text.Trim();
                    this.DialogResult = DialogResult.OK;
                    
                    this.Close();
                }
                else // == 0
                {
                    ShowMessageBox(MessageBoxIcon.Information, "Login message", "Đăng nhập thất bại");
                }
            }
        }

        /// <summary>
        /// Thoát chương trình nếu user chọn exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitLoginBtnPanel_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e.Button == exitLoginBtnPanel.Buttons[0])
            {
                // Thực hiện thoát
                Application.Exit();
            }
        }

        /// <summary>
        /// Custom MessageBox
        /// </summary>
        /// <param name="icon"></param>
        /// <param name="caption"></param>
        /// <param name="messageText"></param>
        void ShowMessageBox(MessageBoxIcon icon, string caption, string messageText)
        {
            
            XtraMessageBox.AllowHtmlText = true;

            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.Caption = "<size=10>" + caption + "</size>";
            args.Text = messageText ;
            args.Icon = XtraMessageHelper.MessageBoxIconToIcon(icon);
            args.Showing += delegate (object sender, XtraMessageShowingArgs e) {
                e.Form.Font = new Font("Tahoma", 10, FontStyle.Regular);
                e.Form.ForeColor = Color.White;
                e.Form.FormBorderStyle = FormBorderStyle.None;
                e.Form.BackColor = Color.FromArgb(65, 65, 68); //icon == MessageBoxIcon.Error ? Color.Red : Color.Yellow;
                //e.Form.BackColor = icon == MessageBoxIcon.Error ? CommonColors.GetCriticalColor(GetActiveLookAndFeel()) : CommonColors.GetWarningColor(GetActiveLookAndFeel());
            };
            XtraMessageBox.Show(args);
        }

        /// <summary>
        /// Override hàm ProcessCmdKey để xử lý KeyDown
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Trigger onClick event cho btn Login khi nhấn phím Enter
            if (keyData == Keys.Enter)
            {
                ButtonEventArgs e = new ButtonEventArgs((IButton)doLoginBtnPanel.Buttons[0]);
                doLoginBtnPanel_ButtonClick(null, e);

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}