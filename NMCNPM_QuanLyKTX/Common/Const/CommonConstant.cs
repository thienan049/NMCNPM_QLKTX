using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMCNPM_QuanLyKTX.Common.Const
{
    /// <summary>
    /// Chứa các consts thường được sử dụng
    /// </summary>
    public class CommonConstant
    {
        public static string[] GioiTinh = { "Nam", "Nữ" };

        public static string[] HocKy = { "1", "2", "3" };

        public static string[] LoaiThongKe = 
        {
            "Sinh viên vi phạm", 
            "Sinh viên theo phòng" 
        };

        /// <summary>
        /// Chứa các RegEx Patterns được sử dụng 
        /// </summary>
        public class RegEx
        {
            // RegEx cho [Họ/Tên]
            public const string NamePattern = "^([aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ']+\\s?)+$";

            // RegEx cho họ tên
            public const string PhoneNumberPattern = "^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$";

            // RegEx cho input số
            public const string NumeicInputPattern = "^\\d$";

            // RegEx cho năm học
            public const string NamHocPattern = "^(\\d){4}-(\\d){4}$";
        }
       
    }
}
