using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace NMCNPM_QuanLyKTX
{
    static class Program
    {

        // SQL connection
        // Đối tượng connect DB
        public static SqlConnection DBConnection = new SqlConnection();

        /* Link dùng kết nối DB
         *  Template: Data Source=ANTHIEN049;Initial Catalog=TESTDB;User ID=sa;Password=asd"
        */
        public static string ConnStr = "";

        // Các đối tượng trong connection string
        public static string Servername = "ANTHIEN049";
        public static string Database = "ql_KTX";
        public static string Login = "sa";
        public static string Password = "asd";

        /// <summary>
        /// Mở kết nối đến DB
        /// </summary>
        public static int ConnectDB()
        {
            // Đóng kết nối nếu đang tồn tại một kết nối
            if (Program.DBConnection != null && Program.DBConnection.State == ConnectionState.Open)
                Program.DBConnection.Close();

            // Mở lại một kết nối mới
            try
            {
                Program.ConnStr = "Data Source=" + Program.Servername + ";Initial Catalog=" + Program.Database 
                                + ";User ID=" + Program.Login + ";password=" + Program.Password;

                Program.DBConnection.ConnectionString = Program.ConnStr;
                Program.DBConnection.Open();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nXem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}