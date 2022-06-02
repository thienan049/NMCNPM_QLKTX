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

namespace NMCNPM_QuanLyKTX.UI_Control
{
    partial class UC_QuanLySinhVien
    {
        /// <summary>
        /// Validate input trong EditForm
        /// Sử dụng RegEx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLSV_View_GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridColumn editedColumn = (e as EditFormValidateEditorEventArgs)?.Column ?? QLSV_View_GridView.FocusedColumn;

            string fieldName = editedColumn.FieldName;

            if (fieldName.Equals("HO") || fieldName.Equals("TEN"))
            {
                if (!Regex.IsMatch(e.Value as string, CommonConstant.RegEx.NamePattern))
                {
                    e.Valid = false;
                    e.ErrorText = "Họ/Tên không hợp lệ!";
                }
            }
            else if (fieldName.Equals("SDT"))
            {
                if (!Regex.IsMatch(e.Value as string, CommonConstant.RegEx.PhoneNumberPattern))
                {
                    e.Valid = false;
                    e.ErrorText = "SĐT không hợp lệ!\nNhập SĐT từ [9-10] chữ số!";
                }
            }
        }

        private void QLSV_View_GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
        }
    }
}
