
namespace NMCNPM_QuanLyKTX
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.contentContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accCtlSidebar = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.acCtlQuanLySinhVien = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acCtlQuanLyPhong = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.accCtlSidebar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // contentContainer
            // 
            this.contentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentContainer.Location = new System.Drawing.Point(257, 30);
            this.contentContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contentContainer.Name = "contentContainer";
            this.contentContainer.Size = new System.Drawing.Size(843, 670);
            this.contentContainer.TabIndex = 0;
            // 
            // accCtlSidebar
            // 
            this.accCtlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.accCtlSidebar.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.acCtlQuanLySinhVien,
            this.acCtlQuanLyPhong});
            this.accCtlSidebar.Location = new System.Drawing.Point(0, 30);
            this.accCtlSidebar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.accCtlSidebar.Name = "accCtlSidebar";
            this.accCtlSidebar.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accCtlSidebar.Size = new System.Drawing.Size(257, 670);
            this.accCtlSidebar.TabIndex = 1;
            this.accCtlSidebar.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // acCtlQuanLySinhVien
            // 
            this.acCtlQuanLySinhVien.Appearance.Hovered.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acCtlQuanLySinhVien.Appearance.Hovered.Options.UseFont = true;
            this.acCtlQuanLySinhVien.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acCtlQuanLySinhVien.Appearance.Normal.Options.UseFont = true;
            this.acCtlQuanLySinhVien.Appearance.Pressed.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acCtlQuanLySinhVien.Appearance.Pressed.Options.UseFont = true;
            this.acCtlQuanLySinhVien.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement3});
            this.acCtlQuanLySinhVien.Expanded = true;
            this.acCtlQuanLySinhVien.Hint = "Quản lý sinh viên";
            this.acCtlQuanLySinhVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElement1.ImageOptions.SvgImage")));
            this.acCtlQuanLySinhVien.Name = "acCtlQuanLySinhVien";
            this.acCtlQuanLySinhVien.Text = "Quản lý sinh viên";
            this.acCtlQuanLySinhVien.Click += new System.EventHandler(this.acCtlQuanLySinhVien_Click);
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement3.Text = "Element3";
            // 
            // acCtlQuanLyPhong
            // 
            this.acCtlQuanLyPhong.Appearance.Hovered.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acCtlQuanLyPhong.Appearance.Hovered.Options.UseFont = true;
            this.acCtlQuanLyPhong.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acCtlQuanLyPhong.Appearance.Normal.Options.UseFont = true;
            this.acCtlQuanLyPhong.Appearance.Pressed.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acCtlQuanLyPhong.Appearance.Pressed.Options.UseFont = true;
            this.acCtlQuanLyPhong.Expanded = true;
            this.acCtlQuanLyPhong.Hint = "Quản lý phòng";
            this.acCtlQuanLyPhong.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElement2.ImageOptions.SvgImage")));
            this.acCtlQuanLyPhong.Name = "acCtlQuanLyPhong";
            this.acCtlQuanLyPhong.Text = "Quản lý phòng";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1100, 30);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.DockingEnabled = false;
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.fluentFormDefaultManager1.MaxItemId = 1;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // FormMain
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.ControlContainer = this.contentContainer;
            this.Controls.Add(this.contentContainer);
            this.Controls.Add(this.accCtlSidebar);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.NavigationControl = this.accCtlSidebar;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý ký túc xá";
            ((System.ComponentModel.ISupportInitialize)(this.accCtlSidebar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer contentContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accCtlSidebar;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acCtlQuanLySinhVien;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acCtlQuanLyPhong;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}

