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

namespace NMCNPM_QuanLyKTX.UI_Control.QLTK
{
    partial class UC_QuanLyTaiKhoan
    {
        /// <summary>
        /// Validate input trong EditForm
        /// Sử dụng RegEx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QLTK_View_GridView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridColumn editedColumn = (e as EditFormValidateEditorEventArgs)?.Column ?? QLTK_View_GridView.FocusedColumn;

            string fieldName = editedColumn.FieldName;

            if (fieldName.Equals("USERNAME") || fieldName.Equals("PASSWORD"))
            {
                if (e.Value.ToString().Trim().Equals(String.Empty) || e.Value == null)
                {
                    e.Valid = false;
                    e.ErrorText = "Không được để trống!";
                }
            }
        }

        private void QLTK_View_GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
        }
    }
}
