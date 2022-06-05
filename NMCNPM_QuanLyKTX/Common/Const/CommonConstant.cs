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
        public static string[] GioiTinh = { "Nam", "Nữ", "Khác"};

        public static string[] HocKy = { "1", "2", "3" };

        /// <summary>
        /// Chứa các RegEx Patterns được sử dụng 
        /// </summary>
        public class RegEx
        {
            // RegEx cho [Họ/Tên]
            public const string NamePattern = "^([aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ']+\\s?)+$";

            // RegEx cho họ tên
            public const string PhoneNumberPattern = "^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$";
        }
       
    }
}
