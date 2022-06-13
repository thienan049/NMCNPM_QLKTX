using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using NMCNPM_QuanLyKTX.Common.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NMCNPM_QuanLyKTX.UI_Control.QLHD
{
    public partial class UC_QuanLyHopDong
    {

        /// <summary>
        /// Validate input trong EditForm
        /// Sử dụng RegEx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLHD_View_GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridColumn editedColumn = (e as EditFormValidateEditorEventArgs)?.Column ?? QLHD_View_GridView.FocusedColumn;

            string fieldName = editedColumn.FieldName;

            if (fieldName.Equals("SOTIEN") || fieldName.Equals("TIENNO"))
            {
                if (!Regex.IsMatch(e.Value.ToString(), CommonConstant.RegEx.NumeicInputPattern))
                {
                    e.Valid = false;
                    e.ErrorText = "Số tiền không hợp lệ!";
                }
            }
            else if (fieldName.Equals("NAMHOC"))
            {              
                if (!Regex.IsMatch(e.Value as string, CommonConstant.RegEx.NamHocPattern))
                {
                    e.Valid = false;
                    e.ErrorText = "Năm học không hợp lệ!\nNhập xxxx-yyyy!";
                    return;
                }

                int namTuInt, namDenInt;
                Int32.TryParse((e.Value as string).Split("-".ToCharArray())[0], out namTuInt);
                Int32.TryParse((e.Value as string).Split("-".ToCharArray())[1], out namDenInt);

                if (namTuInt > namDenInt)
                {
                    e.Valid = false;
                    e.ErrorText = "Năm học không hợp lệ!\nNhập xxxx <= yyyy!";
                }
            }
        }

        private void QLHD_View_GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
        }
    }
}
