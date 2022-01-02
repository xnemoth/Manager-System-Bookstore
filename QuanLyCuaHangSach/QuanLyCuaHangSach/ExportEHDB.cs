using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace QuanLyCuaHangSach
{
    class ExportEHDB
    {
        public void ExportHDB(DataTable dt, string sheetName, string mhd, string nvl, string nl, int tt, int[,] intt)
        {
            Microsoft.Office.Interop.Excel.Application FE = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 
            FE.Visible = true;
            FE.DisplayAlerts = false;
            FE.Application.SheetsInNewWorkbook = 1;
            oBooks = FE.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(FE.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;
            // Tạo phần đầu và đuôi
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "E1");
            head.MergeCells = true;
            head.Value2 = "CỬA HÀNG SÁCH NEMO";
            head.Font.Italic = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "12";
            head.Font.ColorIndex = 16;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range head2 = oSheet.get_Range("A2", "E2");
            head2.MergeCells = true;
            head2.Value2 = "GMAIL: nemo.tronghieu@gmail.com";
            head2.Font.Italic = true;
            head2.Font.Name = "Times New Roman";
            head2.Font.Size = "12";
            head2.Font.ColorIndex = 16;
            head2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range head3 = oSheet.get_Range("A3", "E3");
            head3.MergeCells = true;
            head3.Value2 = "CONTACT: 0948399769";
            head3.Font.Italic = true;
            head3.Font.Name = "Times New Roman";
            head3.Font.Size = "12";
            head3.Font.ColorIndex = 16;
            head3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range head4 = oSheet.get_Range("A5", "E5");
            head4.MergeCells = true;
            head4.Value2 = "HÓA ĐƠN BÁN SÁCH";
            head4.Font.Bold = true;
            head4.Font.Name = "Times New Roman";
            head4.Font.Size = "18";
            head4.Font.ColorIndex = 10;
            head4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range leftnav1 = oSheet.get_Range("A7", "B7");
            leftnav1.MergeCells = true;
            leftnav1.Value2 = "Mã hóa đơn";
            leftnav1.Font.Bold = true;
            leftnav1.Font.Name = "Times New Roman";
            leftnav1.Font.Size = "12";
            leftnav1.Font.ColorIndex = 10;
            leftnav1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range leftnav2 = oSheet.get_Range("A8", "B8");
            leftnav2.MergeCells = true;
            leftnav2.Value2 = "Nhân viên lập";
            leftnav2.Font.Bold = true;
            leftnav2.Font.Name = "Times New Roman";
            leftnav2.Font.Size = "12";
            leftnav2.Font.ColorIndex = 10;
            leftnav2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range leftnav3 = oSheet.get_Range("A9", "B9");
            leftnav3.MergeCells = true;
            leftnav3.Value2 = "Ngày lập";
            leftnav3.Font.Bold = true;
            leftnav3.Font.Name = "Times New Roman";
            leftnav3.Font.Size = "12";
            leftnav3.Font.ColorIndex = 10;
            leftnav3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rightnav = oSheet.get_Range("D7", "E7");
            rightnav.MergeCells = true;
            rightnav.Value2 = mhd;
            rightnav.Font.Italic = true;
            rightnav.Font.Name = "Times New Roman";
            rightnav.Font.Size = "12";
            rightnav.Font.ColorIndex = 10;
            rightnav.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rightnav2 = oSheet.get_Range("D8", "E8");
            rightnav2.MergeCells = true;
            rightnav2.Value2 = nvl;
            rightnav2.Font.Italic = true;
            rightnav2.Font.Name = "Times New Roman";
            rightnav2.Font.Size = "12";
            rightnav2.Font.ColorIndex = 10;
            rightnav2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rightnav3 = oSheet.get_Range("D9", "E9");
            rightnav3.MergeCells = true;
            rightnav3.Value2 = nl;
            rightnav3.Font.Italic = true;
            rightnav3.Font.Name = "Times New Roman";
            rightnav3.Font.Size = "12";
            rightnav3.Font.ColorIndex = 10;
            rightnav3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A11", "A11");
            cl1.Value2 = "Mã sách bán";
            cl1.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B11", "B11");
            cl2.Value2 = "Tên sách";
            cl2.ColumnWidth = 30.0;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C11", "C11");
            cl3.Value2 = "Số lượng";
            cl3.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D11", "D11");
            cl4.Value2 = "Đơn giá";
            cl4.ColumnWidth = 30.0;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E11", "E11");
            cl5.Value2 = "Thành tiền";
            cl5.ColumnWidth = 30.0;
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A11", "E11");
            rowHead.Font.Bold = true;
            rowHead.Font.Name = "Times New Roman";
            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            int x = dt.Rows.Count;
            int y = dt.Columns.Count;
            object[,] arr = new object[x, y];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < x; r++)
            {
                DataRow dr = dt.Rows[r];
                for (int c = 0; c < y; c++)
                {
                    arr[r, c] = dr[c];
                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 12;
            int columnStart = 1;
            int rowEnd = rowStart + x - 1;
            int columnEnd = y;
            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            // Điền tổng tiền
            Microsoft.Office.Interop.Excel.Range c7 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart + 4];
            Microsoft.Office.Interop.Excel.Range c8 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd + 1];
            Microsoft.Office.Interop.Excel.Range rangett = oSheet.get_Range(c7, c8);
            rangett.Value2 = intt;
            // Ô tổng tiền hóa đơn
            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, columnStart];
            Microsoft.Office.Interop.Excel.Range c4 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, columnStart + 3];
            Microsoft.Office.Interop.Excel.Range c5 = oSheet.get_Range(c3, c4);
            c5.MergeCells = true;
            c5.Value2 = "Tổng tiền";
            c5.Font.Bold = true;
            c5.Font.Name = "Times New Roman";
            c5.Font.Size = "12";
            c5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range c6 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, columnStart + 4];
            c6.Value2 = tt;
            // Kẻ viền
            Microsoft.Office.Interop.Excel.Range range2 = oSheet.get_Range(c1, c6);
            range2.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // footer
            Microsoft.Office.Interop.Excel.Range f1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 3, columnStart];
            Microsoft.Office.Interop.Excel.Range f2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 3, columnEnd + 1];
            Microsoft.Office.Interop.Excel.Range footer = oSheet.get_Range(f1, f2); ;
            footer.MergeCells = true;
            footer.Value2 = "Xin cảm ơn quý khách";
            footer.Font.Italic = true;
            footer.Font.Name = "Times New Roman";
            footer.Font.Size = "12";
            footer.Font.ColorIndex = 16;
            footer.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        public void ExportRP1(DataTable dt, string sheetName, string nvl, string nbfrom, string nbto, string ls, int tt)
        {
            Microsoft.Office.Interop.Excel.Application FE = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 
            FE.Visible = true;
            FE.DisplayAlerts = false;
            FE.Application.SheetsInNewWorkbook = 1;
            oBooks = FE.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(FE.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;
            // Tạo phần đầu và đuôi
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "E1");
            head.MergeCells = true;
            head.Value2 = "CỬA HÀNG SÁCH NEMO";
            head.Font.Italic = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "12";
            head.Font.ColorIndex = 16;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range head2 = oSheet.get_Range("A2", "E2");
            head2.MergeCells = true;
            head2.Value2 = "GMAIL: nemo.tronghieu@gmail.com";
            head2.Font.Italic = true;
            head2.Font.Name = "Times New Roman";
            head2.Font.Size = "12";
            head2.Font.ColorIndex = 16;
            head2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range head3 = oSheet.get_Range("A3", "E3");
            head3.MergeCells = true;
            head3.Value2 = "CONTACT: 0948399769";
            head3.Font.Italic = true;
            head3.Font.Name = "Times New Roman";
            head3.Font.Size = "12";
            head3.Font.ColorIndex = 16;
            head3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range head4 = oSheet.get_Range("A5", "E5");
            head4.MergeCells = true;
            head4.Value2 = "BÁO CÁO DOANH THU";
            head4.Font.Bold = true;
            head4.Font.Name = "Times New Roman";
            head4.Font.Size = "18";
            head4.Font.ColorIndex = 10;
            head4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range leftnav1 = oSheet.get_Range("A7", "B7");
            leftnav1.MergeCells = true;
            leftnav1.Value2 = "Nhân viên lập";
            leftnav1.Font.Bold = true;
            leftnav1.Font.Name = "Times New Roman";
            leftnav1.Font.Size = "12";
            leftnav1.Font.ColorIndex = 10;
            leftnav1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range leftnav2 = oSheet.get_Range("A8", "B8");
            leftnav2.MergeCells = true;
            leftnav2.Value2 = "Ngày thông kê";
            leftnav2.Font.Bold = true;
            leftnav2.Font.Name = "Times New Roman";
            leftnav2.Font.Size = "12";
            leftnav2.Font.ColorIndex = 10;
            leftnav2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range leftnav3 = oSheet.get_Range("A10", "B10");
            leftnav3.MergeCells = true;
            leftnav3.Value2 = "Loại hàng";
            leftnav3.Font.Bold = true;
            leftnav3.Font.Name = "Times New Roman";
            leftnav3.Font.Size = "12";
            leftnav3.Font.ColorIndex = 10;
            leftnav3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rightnav = oSheet.get_Range("D7", "E7");
            rightnav.MergeCells = true;
            rightnav.Value2 = nvl;
            rightnav.Font.Italic = true;
            rightnav.Font.Name = "Times New Roman";
            rightnav.Font.Size = "12";
            rightnav.Font.ColorIndex = 10;
            rightnav.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rightnav2 = oSheet.get_Range("D8", "E8");
            rightnav2.MergeCells = true;
            rightnav2.Value2 = "từ " + nbfrom;
            rightnav2.Font.Italic = true;
            rightnav2.Font.Name = "Times New Roman";
            rightnav2.Font.Size = "12";
            rightnav2.Font.ColorIndex = 10;
            rightnav2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rightnav3 = oSheet.get_Range("D9", "E9");
            rightnav3.MergeCells = true;
            rightnav3.Value2 = "đến " + nbto;
            rightnav3.Font.Italic = true;
            rightnav3.Font.Name = "Times New Roman";
            rightnav3.Font.Size = "12";
            rightnav3.Font.ColorIndex = 10;
            rightnav3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rightnav4 = oSheet.get_Range("D10", "E10");
            rightnav4.MergeCells = true;
            rightnav4.Value2 = ls;
            rightnav4.Font.Italic = true;
            rightnav4.Font.Name = "Times New Roman";
            rightnav4.Font.Size = "12";
            rightnav4.Font.ColorIndex = 10;
            rightnav4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A12", "A12");
            cl1.Value2 = "Mã hóa đơn";
            cl1.ColumnWidth = 20.0;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B12", "B12");
            cl2.Value2 = "Nhân viên bán";
            cl2.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C12", "C12");
            cl3.Value2 = "Khách hàng mua";
            cl3.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D12", "D12");
            cl4.Value2 = "Ngày bán";
            cl4.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E12", "E12");
            cl5.Value2 = "Thành tiền";
            cl5.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A12", "E12");
            rowHead.Font.Bold = true;
            rowHead.Font.Name = "Times New Roman";
            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            int x = dt.Rows.Count;
            int y = dt.Columns.Count;
            object[,] arr = new object[x, y];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < x; r++)
            {
                DataRow dr = dt.Rows[r];
                for (int c = 0; c < y; c++)
                {
                    arr[r, c] = dr[c].ToString();
                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 13;
            int columnStart = 1;
            int rowEnd = rowStart + x - 1;
            int columnEnd = y;
            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            // Ô tổng tiền hóa đơn
            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, columnStart];
            Microsoft.Office.Interop.Excel.Range c4 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, columnStart + 3];
            Microsoft.Office.Interop.Excel.Range c5 = oSheet.get_Range(c3, c4);
            c5.MergeCells = true;
            c5.Value2 = "Tổng tiền";
            c5.Font.Bold = true;
            c5.Font.Name = "Times New Roman";
            c5.Font.Size = "12";
            c5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range c6 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, columnStart + 4];
            c6.Value2 = tt;
            // Kẻ viền
            Microsoft.Office.Interop.Excel.Range range2 = oSheet.get_Range(c1, c6);
            range2.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
        }

        public void ExportRP2(DataTable dt, string sheetName, string nvl,string nvx, string nbfrom, string nbto, string ls, int tt)
        {
            Microsoft.Office.Interop.Excel.Application FE = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 
            FE.Visible = true;
            FE.DisplayAlerts = false;
            FE.Application.SheetsInNewWorkbook = 1;
            oBooks = FE.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(FE.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetName;
            // Tạo phần đầu và đuôi
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "E1");
            head.MergeCells = true;
            head.Value2 = "CỬA HÀNG SÁCH NEMO";
            head.Font.Italic = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "12";
            head.Font.ColorIndex = 16;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range head2 = oSheet.get_Range("A2", "E2");
            head2.MergeCells = true;
            head2.Value2 = "GMAIL: nemo.tronghieu@gmail.com";
            head2.Font.Italic = true;
            head2.Font.Name = "Times New Roman";
            head2.Font.Size = "12";
            head2.Font.ColorIndex = 16;
            head2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range head3 = oSheet.get_Range("A3", "E3");
            head3.MergeCells = true;
            head3.Value2 = "CONTACT: 0948399769";
            head3.Font.Italic = true;
            head3.Font.Name = "Times New Roman";
            head3.Font.Size = "12";
            head3.Font.ColorIndex = 16;
            head3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range head4 = oSheet.get_Range("A5", "E5");
            head4.MergeCells = true;
            head4.Value2 = "BÁO CÁO XUẤT KHO";
            head4.Font.Bold = true;
            head4.Font.Name = "Times New Roman";
            head4.Font.Size = "18";
            head4.Font.ColorIndex = 10;
            head4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range leftnav1 = oSheet.get_Range("A7", "B7");
            leftnav1.MergeCells = true;
            leftnav1.Value2 = "Nhân viên lập";
            leftnav1.Font.Bold = true;
            leftnav1.Font.Name = "Times New Roman";
            leftnav1.Font.Size = "12";
            leftnav1.Font.ColorIndex = 10;
            leftnav1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range leftnav2 = oSheet.get_Range("A8", "B8");
            leftnav2.MergeCells = true;
            leftnav2.Value2 = "Ngày thông kê";
            leftnav2.Font.Bold = true;
            leftnav2.Font.Name = "Times New Roman";
            leftnav2.Font.Size = "12";
            leftnav2.Font.ColorIndex = 10;
            leftnav2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range leftnav3 = oSheet.get_Range("A10", "B10");
            leftnav3.MergeCells = true;
            leftnav3.Value2 = "Loại hàng";
            leftnav3.Font.Bold = true;
            leftnav3.Font.Name = "Times New Roman";
            leftnav3.Font.Size = "12";
            leftnav3.Font.ColorIndex = 10;
            leftnav3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range leftnav4 = oSheet.get_Range("A11", "B11");
            leftnav4.MergeCells = true;
            leftnav4.Value2 = "Nhân viên xuất";
            leftnav4.Font.Bold = true;
            leftnav4.Font.Name = "Times New Roman";
            leftnav4.Font.Size = "12";
            leftnav4.Font.ColorIndex = 10;
            leftnav4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rightnav = oSheet.get_Range("D7", "E7");
            rightnav.MergeCells = true;
            rightnav.Value2 = nvl;
            rightnav.Font.Italic = true;
            rightnav.Font.Name = "Times New Roman";
            rightnav.Font.Size = "12";
            rightnav.Font.ColorIndex = 10;
            rightnav.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rightnav2 = oSheet.get_Range("D8", "E8");
            rightnav2.MergeCells = true;
            rightnav2.Value2 = "từ " + nbfrom;
            rightnav2.Font.Italic = true;
            rightnav2.Font.Name = "Times New Roman";
            rightnav2.Font.Size = "12";
            rightnav2.Font.ColorIndex = 10;
            rightnav2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rightnav3 = oSheet.get_Range("D9", "E9");
            rightnav3.MergeCells = true;
            rightnav3.Value2 = "đến " + nbto;
            rightnav3.Font.Italic = true;
            rightnav3.Font.Name = "Times New Roman";
            rightnav3.Font.Size = "12";
            rightnav3.Font.ColorIndex = 10;
            rightnav3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rightnav4 = oSheet.get_Range("D10", "E10");
            rightnav4.MergeCells = true;
            rightnav4.Value2 = ls;
            rightnav4.Font.Italic = true;
            rightnav4.Font.Name = "Times New Roman";
            rightnav4.Font.Size = "12";
            rightnav4.Font.ColorIndex = 10;
            rightnav4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range rightnav5 = oSheet.get_Range("D11", "E11");
            rightnav5.MergeCells = true;
            rightnav5.Value2 = nvx;
            rightnav5.Font.Italic = true;
            rightnav5.Font.Name = "Times New Roman";
            rightnav5.Font.Size = "12";
            rightnav5.Font.ColorIndex = 10;
            rightnav5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A13", "A13");
            cl1.Value2 = "Mã sách xuất";
            cl1.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B13", "B13");
            cl2.Value2 = "Hóa đơn xuất";
            cl2.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C13", "C13");
            cl3.Value2 = "Ngày xuất";
            cl3.ColumnWidth = 20.0;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D13", "D13");
            cl4.Value2 = "Số lượng";
            cl4.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E13", "E13");
            cl5.Value2 = "Giá bán";
            cl5.ColumnWidth = 20.0;
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A13", "E13");
            rowHead.Font.Bold = true;
            rowHead.Font.Name = "Times New Roman";
            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            int x = dt.Rows.Count;
            int y = dt.Columns.Count;
            object[,] arr = new object[x, y];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < x; r++)
            {
                DataRow dr = dt.Rows[r];
                for (int c = 0; c < y; c++)
                {
                    arr[r, c] = dr[c].ToString();
                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 14;
            int columnStart = 1;
            int rowEnd = rowStart + x - 1;
            int columnEnd = y;
            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            // Ô tổng tiền hóa đơn
            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, columnStart];
            Microsoft.Office.Interop.Excel.Range c4 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, columnStart + 3];
            Microsoft.Office.Interop.Excel.Range c5 = oSheet.get_Range(c3, c4);
            c5.MergeCells = true;
            c5.Value2 = "Tổng tiền";
            c5.Font.Bold = true;
            c5.Font.Name = "Times New Roman";
            c5.Font.Size = "12";
            c5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            Microsoft.Office.Interop.Excel.Range c6 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, columnStart + 4];
            c6.Value2 = tt;
            // Kẻ viền
            Microsoft.Office.Interop.Excel.Range range2 = oSheet.get_Range(c1, c6);
            range2.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
        }
    }
}
