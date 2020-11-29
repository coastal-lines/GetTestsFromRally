using ClosedXML.Excel;
using SaveTestCasesFromRallyToJson.TestCaseClasses;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SaveTestCasesFromRallyToJson.ExcelClasses
{
    public class ExcelCommonClass
    {
        private XLWorkbook workbook;
        private IXLWorksheet worksheet;

        public void MakeTemplateTable()
        {
            workbook = new XLWorkbook();
            worksheet = workbook.Worksheets.Add("Tests cases");

            worksheet.Cell("A1").SetValue("Number").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("B1").SetValue("Name").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);

            worksheet.Cell("C1").SetValue("Steps").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("C2").SetValue("Input").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("D2").SetValue("Expected Result").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);

            worksheet.Cell("E1").SetValue("Details").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("E2").SetValue("Description").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("F2").SetValue("Notes").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("G2").SetValue("Objective").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("H2").SetValue("PreConditions").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("I2").SetValue("PostConditions").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("J2").SetValue("ValidationInput").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("K2").SetValue("ValidationExpectedResult").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("L2").SetValue("Project").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("M2").SetValue("TestFolderName").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("N2").SetValue("Risk").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("O2").SetValue("Type").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("P2").SetValue("Method").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("Q2").SetValue("Priority").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);
            worksheet.Cell("R2").SetValue("ProductArea").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetBold(true);

            worksheet.Range("A1:A2").Merge();
            worksheet.Range("B1:B2").Merge();
            worksheet.Range("C1:D1").Merge();
            worksheet.Range("C1:D1").Merge();
            worksheet.Range("E1:R1").Merge();

            worksheet.Column(2).Width = 50;
            worksheet.Column(3).Width = 100;
            worksheet.Column(4).Width = 50;
            worksheet.Column(5).Width = 50;
            worksheet.Column(6).Width = 50;
            worksheet.Column(7).Width = 50;
            worksheet.Column(8).Width = 50;
            worksheet.Column(9).Width = 50;
            worksheet.Column(10).Width = 50;
            worksheet.Column(11).Width = 50;
            worksheet.Column(12).Width = 50;
            worksheet.Column(13).Width = 20;
            worksheet.Column(14).Width = 20;
            worksheet.Column(15).Width = 20;
            worksheet.Column(16).Width = 20;
            worksheet.Column(17).Width = 20;
            worksheet.Column(18).Width = 20;

            worksheet.RowHeight = 60;
            worksheet.Style.Alignment.SetWrapText(true);
        }

        public void FillCells(List<TestCase> tcList)
        {
            int startIndex = 3;
            int tempIndex = -1;

            foreach (var tc in tcList)
            {
                tempIndex = startIndex;
                worksheet.Cell("A" + startIndex).SetValue(tc.TestCaseNumber).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("B" + startIndex).SetValue(tc.TestCaseName).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("E" + startIndex).SetValue(FormatText(tc.Details.Description)).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("F" + startIndex).SetValue(tc.Details.Notes).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("G" + startIndex).SetValue(tc.Details.Objective).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("H" + startIndex).SetValue(tc.Details.PreConditions).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("I" + startIndex).SetValue(tc.Details.PostConditions).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("J" + startIndex).SetValue(tc.Details.ValidationInput).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("K" + startIndex).SetValue(tc.Details.ValidationExpectedResult).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("L" + startIndex).SetValue(tc.Details.Project).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("M" + startIndex).SetValue(tc.Details.TestFolderName).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("N" + startIndex).SetValue(tc.Details.Risk).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("O" + startIndex).SetValue(tc.Details.Type).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("P" + startIndex).SetValue(tc.Details.Method).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("Q" + startIndex).SetValue(tc.Details.Priority).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                worksheet.Cell("R" + startIndex).SetValue(tc.Details.ProductArea).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                
                for (int i = 0; i < tc.Steps.Count; i++)
                {
                    worksheet.Cell("C" + startIndex).SetValue(FormatText(tc.Steps[i].InputText)).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                    worksheet.Cell("D" + startIndex).SetValue(FormatText(tc.Steps[i].ExpectedText)).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                    startIndex += 1;
                }

                worksheet.Range($"A{tempIndex}:A{startIndex - 1}").Merge();
                worksheet.Range($"B{tempIndex}:B{startIndex - 1}").Merge();
                worksheet.Range($"E{tempIndex}:E{startIndex - 1}").Merge();
                worksheet.Range($"F{tempIndex}:F{startIndex - 1}").Merge();
                worksheet.Range($"G{tempIndex}:G{startIndex - 1}").Merge();
                worksheet.Range($"H{tempIndex}:H{startIndex - 1}").Merge();
                worksheet.Range($"I{tempIndex}:I{startIndex - 1}").Merge();
                worksheet.Range($"J{tempIndex}:J{startIndex - 1}").Merge();
                worksheet.Range($"K{tempIndex}:K{startIndex - 1}").Merge();
                worksheet.Range($"L{tempIndex}:L{startIndex - 1}").Merge();
                worksheet.Range($"M{tempIndex}:M{startIndex - 1}").Merge();
                worksheet.Range($"N{tempIndex}:N{startIndex - 1}").Merge();
                worksheet.Range($"O{tempIndex}:O{startIndex - 1}").Merge();
                worksheet.Range($"P{tempIndex}:P{startIndex - 1}").Merge();
                worksheet.Range($"Q{tempIndex}:Q{startIndex - 1}").Merge();
                worksheet.Range($"R{tempIndex}:R{startIndex - 1}").Merge();
            }
        }

        public void SaveExcelFile()
        {
            workbook.SaveAs("file.xlsx");
        }

        public string FormatText(string text)
        {
            text = text.Trim();
            text = text.Replace("&nbsp;", "");
            return Regex.Replace(text, "<.*?>", "");
        }
    }
}