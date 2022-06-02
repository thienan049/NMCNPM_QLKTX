
namespace NMCNPM_QuanLyKTX
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.loginTitleLbl = new DevExpress.XtraEditors.LabelControl();
            this.usernameTxtEd = new DevExpress.XtraEditors.TextEdit();
            this.usernameStPanel = new DevExpress.Utils.Layout.StackPanel();
            this.usernameLbl = new DevExpress.XtraEditors.LabelControl();
            this.passwordStPanel = new DevExpress.Utils.Layout.StackPanel();
            this.passwordLbl = new DevExpress.XtraEditors.LabelControl();
            this.passwordTxtEd = new DevExpress.XtraEditors.TextEdit();
            this.doLoginBtnPanel = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.usernameUnderline = new DevExpress.XtraEditors.SeparatorControl();
            this.passwordUnderline = new DevExpress.XtraEditors.SeparatorControl();
            this.exitLoginBtnPanel = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.usernameTxtEd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernameStPanel)).BeginInit();
            this.usernameStPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordStPanel)).BeginInit();
            this.passwordStPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTxtEd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernameUnderline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordUnderline)).BeginInit();
            this.SuspendLayout();
            // 
            // loginTitleLbl
            // 
            this.loginTitleLbl.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginTitleLbl.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.loginTitleLbl.Appearance.Options.UseFont = true;
            this.loginTitleLbl.Appearance.Options.UseForeColor = true;
            this.loginTitleLbl.Location = new System.Drawing.Point(162, 106);
            this.loginTitleLbl.Name = "loginTitleLbl";
            this.loginTitleLbl.Size = new System.Drawing.Size(74, 33);
            this.loginTitleLbl.TabIndex = 3;
            this.loginTitleLbl.Text = "Login";
            // 
            // usernameTxtEd
            // 
            this.usernameTxtEd.EditValue = "admin";
            this.usernameTxtEd.Location = new System.Drawing.Point(89, 6);
            this.usernameTxtEd.Name = "usernameTxtEd";
            this.usernameTxtEd.Properties.AllowFocused = false;
            this.usernameTxtEd.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.usernameTxtEd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTxtEd.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.usernameTxtEd.Properties.Appearance.Options.UseBackColor = true;
            this.usernameTxtEd.Properties.Appearance.Options.UseFont = true;
            this.usernameTxtEd.Properties.Appearance.Options.UseForeColor = true;
            this.usernameTxtEd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.usernameTxtEd.Size = new System.Drawing.Size(155, 22);
            this.usernameTxtEd.TabIndex = 4;
            // 
            // usernameStPanel
            // 
            this.usernameStPanel.Controls.Add(this.usernameLbl);
            this.usernameStPanel.Controls.Add(this.usernameTxtEd);
            this.usernameStPanel.Location = new System.Drawing.Point(69, 217);
            this.usernameStPanel.Name = "usernameStPanel";
            this.usernameStPanel.Size = new System.Drawing.Size(265, 34);
            this.usernameStPanel.TabIndex = 5;
            // 
            // usernameLbl
            // 
            this.usernameLbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLbl.Appearance.ForeColor = System.Drawing.Color.White;
            this.usernameLbl.Appearance.Options.UseFont = true;
            this.usernameLbl.Appearance.Options.UseForeColor = true;
            this.usernameLbl.Location = new System.Drawing.Point(3, 8);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(80, 18);
            this.usernameLbl.TabIndex = 5;
            this.usernameLbl.Text = "Username:";
            // 
            // passwordStPanel
            // 
            this.passwordStPanel.Controls.Add(this.passwordLbl);
            this.passwordStPanel.Controls.Add(this.passwordTxtEd);
            this.passwordStPanel.Location = new System.Drawing.Point(69, 281);
            this.passwordStPanel.Name = "passwordStPanel";
            this.passwordStPanel.Size = new System.Drawing.Size(265, 29);
            this.passwordStPanel.TabIndex = 6;
            // 
            // passwordLbl
            // 
            this.passwordLbl.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.Appearance.ForeColor = System.Drawing.Color.White;
            this.passwordLbl.Appearance.Options.UseFont = true;
            this.passwordLbl.Appearance.Options.UseForeColor = true;
            this.passwordLbl.Location = new System.Drawing.Point(3, 5);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(78, 18);
            this.passwordLbl.TabIndex = 5;
            this.passwordLbl.Text = "Password:";
            // 
            // passwordTxtEd
            // 
            this.passwordTxtEd.EditValue = "asd";
            this.passwordTxtEd.Location = new System.Drawing.Point(87, 3);
            this.passwordTxtEd.Name = "passwordTxtEd";
            this.passwordTxtEd.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.passwordTxtEd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTxtEd.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.passwordTxtEd.Properties.Appearance.Options.UseBackColor = true;
            this.passwordTxtEd.Properties.Appearance.Options.UseFont = true;
            this.passwordTxtEd.Properties.Appearance.Options.UseForeColor = true;
            this.passwordTxtEd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.passwordTxtEd.Properties.PasswordChar = '*';
            this.passwordTxtEd.Properties.UseSystemPasswordChar = true;
            this.passwordTxtEd.Size = new System.Drawing.Size(157, 22);
            this.passwordTxtEd.TabIndex = 4;
            // 
            // doLoginBtnPanel
            // 
            this.doLoginBtnPanel.AppearanceButton.Hovered.BackColor = System.Drawing.Color.Silver;
            this.doLoginBtnPanel.AppearanceButton.Hovered.Options.UseBackColor = true;
            this.doLoginBtnPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("LoginBtn", false, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.doLoginBtnPanel.Location = new System.Drawing.Point(153, 357);
            this.doLoginBtnPanel.Name = "doLoginBtnPanel";
            this.doLoginBtnPanel.Size = new System.Drawing.Size(100, 80);
            this.doLoginBtnPanel.TabIndex = 7;
            this.doLoginBtnPanel.Text = "windowsUIButtonPanel1";
            this.doLoginBtnPanel.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.doLoginBtnPanel_ButtonClick);
            // 
            // usernameUnderline
            // 
            this.usernameUnderline.Location = new System.Drawing.Point(63, 247);
            this.usernameUnderline.Name = "usernameUnderline";
            this.usernameUnderline.Size = new System.Drawing.Size(275, 18);
            this.usernameUnderline.TabIndex = 8;
            // 
            // passwordUnderline
            // 
            this.passwordUnderline.Location = new System.Drawing.Point(63, 310);
            this.passwordUnderline.Name = "passwordUnderline";
            this.passwordUnderline.Size = new System.Drawing.Size(275, 18);
            this.passwordUnderline.TabIndex = 9;
            // 
            // exitLoginBtnPanel
            // 
            windowsUIButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions2.SvgImage")));
            this.exitLoginBtnPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("ExitBtn", false, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.exitLoginBtnPanel.Location = new System.Drawing.Point(354, 3);
            this.exitLoginBtnPanel.Name = "exitLoginBtnPanel";
            this.exitLoginBtnPanel.Size = new System.Drawing.Size(43, 34);
            this.exitLoginBtnPanel.TabIndex = 8;
            this.exitLoginBtnPanel.Text = "windowsUIButtonPanel2";
            this.exitLoginBtnPanel.UseButtonBackgroundImages = false;
            this.exitLoginBtnPanel.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.exitLoginBtnPanel_ButtonClick);
            // 
            // FormLogin
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.exitLoginBtnPanel);
            this.Controls.Add(this.passwordUnderline);
            this.Controls.Add(this.doLoginBtnPanel);
            this.Controls.Add(this.usernameUnderline);
            this.Controls.Add(this.usernameStPanel);
            this.Controls.Add(this.loginTitleLbl);
            this.Controls.Add(this.passwordStPanel);
            this.EnableAcrylicAccent = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usernameTxtEd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernameStPanel)).EndInit();
            this.usernameStPanel.ResumeLayout(false);
            this.usernameStPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordStPanel)).EndInit();
            this.passwordStPanel.ResumeLayout(false);
            this.passwordStPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTxtEd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernameUnderline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordUnderline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl loginTitleLbl;
        private DevExpress.XtraEditors.TextEdit usernameTxtEd;
        private DevExpress.Utils.Layout.StackPanel usernameStPanel;
        private DevExpress.XtraEditors.LabelControl usernameLbl;
        private DevExpress.Utils.Layout.StackPanel passwordStPanel;
        private DevExpress.XtraEditors.LabelControl passwordLbl;
        private DevExpress.XtraEditors.TextEdit passwordTxtEd;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel doLoginBtnPanel;
        private DevExpress.XtraEditors.SeparatorControl usernameUnderline;
        private DevExpress.XtraEditors.SeparatorControl passwordUnderline;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel exitLoginBtnPanel;
    }
}