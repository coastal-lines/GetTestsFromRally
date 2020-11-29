using ClosedXML.Excel;
using SaveTestCasesFromRallyToJson.TestCaseClasses;
using System.Collections.Generic;

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
            worksheet.Cell("A1").SetValue("Number");
            worksheet.Cell("B1").Value = "Name";
            worksheet.Cell("C1").SetValue("Steps");
            worksheet.Cell("C2").Value = "Input";
            worksheet.Cell("D2").Value = "Expected Result";
            worksheet.Cell("E1").Value = "Details";
            worksheet.Cell("E2").Value = "Description";
            worksheet.Cell("F2").Value = "Notes";
            worksheet.Cell("G2").Value = "Objective";
            worksheet.Cell("H2").Value = "PreConditions";
            worksheet.Cell("I2").Value = "PostConditions";
            worksheet.Cell("J2").Value = "ValidationInput";
            worksheet.Cell("K2").Value = "ValidationExpectedResult";
            worksheet.Cell("L2").Value = "Project";
            worksheet.Cell("M2").Value = "TestFolderName";
            worksheet.Cell("N2").Value = "Tags";
            worksheet.Cell("O2").Value = "Risk";
            worksheet.Cell("P2").Value = "Type";
            worksheet.Cell("Q2").Value = "Method";
            worksheet.Cell("R2").Value = "Priority";
            worksheet.Cell("S2").Value = "ProductArea";
            worksheet.Range("A1:A2").Merge();
            worksheet.Range("B1:B2").Merge();
            worksheet.Range("C1:D1").Merge();
            worksheet.Range("C1:D1").Merge();
            worksheet.Range("E1:S1").Merge();
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
                worksheet.Cell("E" + startIndex).SetValue(tc.Details.Description).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
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
                    worksheet.Cell("C" + startIndex).Value = tc.Steps[i].InputText;
                    startIndex += 1;
                }

                worksheet.Range($"A{tempIndex}:A{startIndex - 1}").Merge();
                worksheet.Range($"B{tempIndex}:B{startIndex - 1}").Merge();
            }
        }

        public void SaveExcelFile()
        {
            workbook.SaveAs("file.xlsx");
        }
    }
}