﻿using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using NMCNPM_QuanLyKTX.UI_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NMCNPM_QuanLyKTX
{
    public partial class FormMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        // QuanLySinhVien user control
        UC_QuanLySinhVien UC_QLSV = null;

        // QuanLyPhong user control
        UC_QuanLyPhong UC_QLP = null;

        // Khởi tạo form
        public FormMain()
        {
            InitializeComponent();

            Program.ConnectDB();
        }

        // Hiển thị QLSV user control
        private void acCtlEle_ThongTinSV_Click(object sender, EventArgs e)
        {
            // Nếu chưa tồn tại, tạo đối tượng mới
            if (this.UC_QLSV == null)
            {
                this.UC_QLSV = new UC_QuanLySinhVien
                {
                    Dock = DockStyle.Fill
                };

                // Thêm đối tượng vừa tạo vào khu vực content container
                this.contentContainer.Controls.Add(this.UC_QLSV);
                this.UC_QLSV.BringToFront();
            }
            // Nếu đã tồn tại, đưa lên front để hiển thị
            else
            {
                this.UC_QLSV.BringToFront();
            }
        }

        private void acCtlEle_ThongTinPhong_Click(object sender, EventArgs e)
        {
            // Nếu chưa tồn tại, tạo đối tượng mới
            if (this.UC_QLP == null)
            {
                this.UC_QLP = new UC_QuanLyPhong
                {
                    Dock = DockStyle.Fill
                };

                // Thêm đối tượng vừa tạo vào khu vực content container
                this.contentContainer.Controls.Add(this.UC_QLP);
                this.UC_QLP.BringToFront();
            }
            // Nếu đã tồn tại, đưa lên front để hiển thị
            else
            {
                this.UC_QLP.BringToFront();
            }
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {

        }
    }
}