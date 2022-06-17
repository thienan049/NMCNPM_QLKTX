using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using NMCNPM_QuanLyKTX.Common.Const;
using System;
using System.Collections.Generic;
using System.Data;
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
                    return;
                }

                GridColumn soTienCol = QLHD_View_GridView.Columns["SOTIEN"];
                GridColumn tienNoCol = QLHD_View_GridView.Columns["TIENNO"];               

                if (fieldName.Equals("SOTIEN"))
                {
                    Double.TryParse(e.Value.ToString(), out double soTien);
                    Double.TryParse(QLHD_View_GridView.GetFocusedRowCellValue(tienNoCol).ToString(), out double tienNo);
                    
                    if (soTien < tienNo)
                    {
                        e.Valid = false;
                        e.ErrorText = "Số tiền không hợp lệ!\nSOTIEN >= TIENNO";
                        return;
                    }
                }
                else if (fieldName.Equals("TIENNO"))
                {
                    Double.TryParse(QLHD_View_GridView.GetFocusedRowCellValue(soTienCol).ToString(), out double soTien);
                    Double.TryParse(e.Value.ToString(), out double tienNo);

                    if (soTien < tienNo)
                    {
                        e.Valid = false;
                        e.ErrorText = "Số tiền không hợp lệ!\nSOTIEN >= TIENNO";
                        return;
                    }
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

                Int32.TryParse((e.Value as string).Split("-".ToCharArray())[0], out int namTuInt);
                Int32.TryParse((e.Value as string).Split("-".ToCharArray())[1], out int namDenInt);

                if (namTuInt > namDenInt)
                {
                    e.Valid = false;
                    e.ErrorText = "Năm học không hợp lệ!\nNhập xxxx <= yyyy!";
                }
            }
            else if (fieldName.Equals("HOCKY"))
            {
                // Lấy giá trị [MAPHONG] để lấy số tiền tương ứng rồi tính tổng tiền cho vào số tiền [SOTIEN]
                String maPhong = QLHD_View_GridView.GetFocusedRowCellValue(QLHD_View_GridView.Columns["MAPHONG"]).ToString();
                if (!maPhong.Equals("") && maPhong != null)
                {
                    QLHD_View_GridView.SetFocusedRowCellValue(QLHD_View_GridView.Columns["SOTIEN"], CalSoTienHopDong(maPhong, e.Value.ToString()));
                    QLHD_View_GridView.SetFocusedRowCellValue(QLHD_View_GridView.Columns["TIENNO"], 0);
                }               
            }
            else if (fieldName.Equals("MAPHONG"))
            {
                if (((DataRowView)SP_GetTTPhongConChoTrongBdS.Current)["CONTRONG"].Equals(0) && !e.Value.Equals(maPhongHetCho))
                {
                    e.Valid = false;
                    e.ErrorText = "Phòng này đã hết chỗ trống!";
                }

                // Lấy giá trị [HOCKY] rồi tính tổng tiền cho vào số tiền [SOTIEN]
                String hk = QLHD_View_GridView.GetFocusedRowCellValue(QLHD_View_GridView.Columns["HOCKY"]).ToString();
                if (!hk.Equals("") && hk != null)
                {
                    QLHD_View_GridView.SetFocusedRowCellValue(QLHD_View_GridView.Columns["SOTIEN"], CalSoTienHopDong(e.Value.ToString(), hk));
                    QLHD_View_GridView.SetFocusedRowCellValue(QLHD_View_GridView.Columns["TIENNO"], 0);
                }

                // Lấy data từ CSDL về DataTable [ql_KTX_DS.HOPDONG]
                SP_GetTTPhongConChoTrongTableAdapter.Fill(QL_KTXDataSet.SP_GETTHONGTINPHONGCONCHOTRONG, namHocHK[0] + "-" + namHocHK[1], namHocHK[2]);
            }
            else if (fieldName.Equals("MASV"))
            {
                String maPhong = QLHD_View_GridView.GetFocusedRowCellValue(QLHD_View_GridView.Columns["MAPHONG"]).ToString();
                String namHoc = QLHD_View_GridView.GetFocusedRowCellValue(QLHD_View_GridView.Columns["NAMHOC"]).ToString();
                String hk = QLHD_View_GridView.GetFocusedRowCellValue(QLHD_View_GridView.Columns["HOCKY"]).ToString();

                if(SinhVienContractExist(maPhong, namHoc, hk, e.Value.ToString()))
                {
                    e.Valid = false;
                    e.ErrorText = "Sinh viên này đã có 1 hợp đồng!";
                }
            }
        }

        private void QLHD_View_GridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
        }
    }
}
