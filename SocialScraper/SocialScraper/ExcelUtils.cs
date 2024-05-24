using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SocialScraper
{
    public class ExcelUtils
    {
        public static void ExprotData(string path)
        {
            var spreadsheetDocument = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook);
            var workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();
            var worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());
            var sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
            var sheet = new Sheet()
            {
                Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "Sheet1"
            };
            sheets.Append(sheet);
            var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

            var nameList = typeof(SocialModel).GetProperties().ToList();
            var rowName = new Row();
            foreach (var p in nameList)
            {
                var cell = new Cell
                {
                    CellValue = new CellValue(p.Name),
                    DataType = CellValues.String
                };
                rowName.AppendChild(cell);
            }
            sheetData.Append(rowName);
            workbookpart.Workbook.Save();
            spreadsheetDocument.Close();
        }


       
    }
}
