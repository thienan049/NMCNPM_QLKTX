using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using NMCNPM_QuanLyKTX.Common.Service;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NMCNPM_QuanLyKTX.UI_Control.Setting
{
    public partial class SettingDialog : XtraForm
    {
        /// <summary>
        /// Khởi tạo các Components
        /// </summary>
        public SettingDialog()
        {
            InitializeComponent();
            InitializeSkinListPanel();
        }

        /// <summary>
        /// Xử lý onLoad của form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingDialog_Load(object sender, EventArgs e)
        {
            // Loại bỏ VerticalScroll khỏi khung chứa list skin
            this.skinSectionListSkinStackPanel.VerticalScroll.Visible = false;
            this.skinSectionListSkinStackPanel.VerticalScroll.Maximum = 0;
        }

        /// <summary>
        /// Khởi tạo danh sách chứa các SkinItems đại diện cho các Skins
        /// để thực hiện setting Skin cho form.
        /// </summary>
        private void InitializeSkinListPanel()
        {
            // Lấy danh sách các skins hiện có
            SkinContainerCollection skins = SkinManager.Default.Skins;

            /*
             * Với mỗi skin, tạo một SkinItem gồm [SkinIcon, SkinName]
             * Sau vòng lặp này, StackPanel đã chứa đầy đủ các SkinItems.
             */
            foreach (SkinContainer skin in skins)
            {
                CreateNewSkinItem(skin);
            }

            /*
             * Set focus cho Icon của SkinItem trong StackPanel chứa các SkinItems
             * đại diện cho skin hiện tại đang được áp dụng.
             * 
             */
            skinSectionListSkinStackPanel.Controls.Find("The Bezier", true)[0].Select();
        }

        /// <summary>
        /// Khởi tạo một SkinItem gồm [SkinIcon, SkinName] 
        /// và add vào StackPanel chứa các SkinItem
        /// </summary>
        /// <param name="skin"></param>
        private void CreateNewSkinItem(SkinContainer skin)
        {
            // Tạo khung panel [SkinItem] chứa [SkinIcon, SkinName]
            FlowLayoutPanel skinItemPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown
            };

            // Tạo label chứa [SkinName]
            LabelControl skinNameLabel = new LabelControl
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Right),
                AutoSizeMode = LabelAutoSizeMode.None,
                Font = new Font("Tahoma", 8, FontStyle.Bold),
                Text = skin.SkinName
            };
            skinNameLabel.Appearance.Options.UseTextOptions = true;
            skinNameLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            skinNameLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            /*
             * Tạo khung picture chứa [SkinIcon]
             * Thêm xử lý onClick khi nhấn vào khung picture [SkinIcon]
             */
            PictureEdit skinPic = new PictureEdit
            {
                Image = SkinCollectionHelper.GetSkinIcon(skin.SkinName, SkinIconsSize.Large),
                Name = skin.SkinName
            };
            skinPic.Properties.AppearanceFocused.BorderColor = Color.AliceBlue;
            skinPic.Properties.AppearanceFocused.BackColor = Color.BlueViolet;
            skinPic.Click += new EventHandler(this.skinPictureSelect_Click);

            // Thêm [SkinIcon] và [SkinName] vào [SkinItem] để tạo thành một [SkinItem] hoàn chỉnh
            skinItemPanel.Controls.Add(skinPic);
            skinItemPanel.Controls.Add(skinNameLabel);

            // Thêm [SkinIcon] đã hoàn thiện vào StackPanel
            skinSectionListSkinStackPanel.Controls.Add(skinItemPanel);
        }

        /// <summary>
        /// Thay đổi skin/theme của ứng dụng khi nhấn vào Icon đại diện cho skin/theme đó
        /// trong danh sách các skins/themes được hiển thị để lựa chọn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinPictureSelect_Click(object sender, EventArgs e)
        {
            string text = ((PictureEdit)sender).Name;
            //WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle(text);
            UserLookAndFeel.Default.SetSkinStyle(text);
        }

        /// <summary>
        /// Set LookAndFeel mặc định [The Bezier]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinSectionSetDefaultBtn_Click(object sender, EventArgs e)
        {
            CommonService.SetDefaultApplicationStyle();

            /*
             * Set focus cho Icon của SkinItem trong StackPanel chứa các SkinItems
             * đại diện cho skin hiện tại đang được áp dụng.
             * 
             */
            skinSectionListSkinStackPanel.Controls.Find("The Bezier", true)[0].Select();
        }

        /// <summary>
        /// Lựa chọn Palette cho Skin bằng Swatch Picker UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinSectionChangePaletteBtn_Click(object sender, EventArgs e)
        {
            // Mở giao diện Swatch Picker UI để chọn Palette
            using (var dialog = new DevExpress.Customization.SvgSkinPaletteSelector(this))
            {
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }
        }
    }
}
