using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace JapanProga
{
    class ExportToExcel
    {
        private Form1 Form1 { get; set; }
        public ExportToExcel(Form1 f)
        {
            Form1 = f;
        }
        public void CreateFile(Excel.Application ex)
        {
            ex.Visible = false;
            Excel.Workbook workbook = ex.Workbooks.Add(Type.Missing);
            ex.SheetsInNewWorkbook = 1;
            ex.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);
            sheet.Name = "Словарь";
        }
        public void AddToCell(Excel.Worksheet _sheet, int row, string word, string reading, string translate)
        {
            _sheet.Cells[row, 1] = word;
            _sheet.Cells[row, 2] = reading;
            _sheet.Cells[row, 3] = translate;
        }
        public void AddToCell(Excel.Worksheet _sheet, int row, string word, string translate)
        {
            _sheet.Cells[row, 1] = word;
            _sheet.Cells[row, 3] = translate;
        }
        public void SaveExcelDoc(string path, Excel.Application _ex)
        {
            _ex.Application.ActiveWorkbook.SaveAs(path, Excel.XlFileFormat.xlExcel9795, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            _ex.Quit();
        }
    }
}
