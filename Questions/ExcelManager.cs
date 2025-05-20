using ClosedXML.Excel;
using ExamSystemApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PROJECT
{
    public static class ExcelManager
    {
        // Load questions from the Excel file
       

        // Save a student's exam result
        public static void SaveExamResult(string filePath, string userId, string course, string difficulty, int score, int minutesTaken, int totalMinutes)
        {
            try
            {
                XLWorkbook workbook;
                IXLWorksheet worksheet;

                if (File.Exists(filePath))
                {
                    workbook = new XLWorkbook(filePath);
                    worksheet = workbook.Worksheet("Results");
                }
                else
                {
                    workbook = new XLWorkbook();
                    worksheet = workbook.Worksheets.Add("Results");

                    worksheet.Cell(1, 1).Value = "UserID";
                    worksheet.Cell(1, 2).Value = "Course";
                    worksheet.Cell(1, 3).Value = "Difficulty";
                    worksheet.Cell(1, 4).Value = "Score";
                    worksheet.Cell(1, 5).Value = "TimeTaken";
                    worksheet.Cell(1, 6).Value = "Date";
                }

                int newRow = worksheet.LastRowUsed()?.RowNumber() + 1 ?? 2;

                worksheet.Cell(newRow, 1).Value = userId;
                worksheet.Cell(newRow, 2).Value = course;
                worksheet.Cell(newRow, 3).Value = difficulty;
                worksheet.Cell(newRow, 4).Value = score;
                worksheet.Cell(newRow, 5).Value = $"{minutesTaken} min of {totalMinutes}";
                worksheet.Cell(newRow, 6).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                workbook.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Failed to save exam result:\n{ex.Message}");
            }
        }
    }
}
