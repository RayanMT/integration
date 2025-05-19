using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace PROJECT
{
    public static class QuestionRepository
    {
        public static List<Question> AllQuestions { get; set; } = new List<Question>();

        public static void SaveToExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Questions");
                ws.Cell(1, 1).InsertTable(new[] {
                    new { Type = "", Question = "", A = "", B = "", C = "", D = "", Correct = "", Category = "", Difficulty = "" }
                });

                for (int i = 0; i < AllQuestions.Count; i++)
                {
                    var q = AllQuestions[i];
                    ws.Cell(i + 2, 1).Value = q.Type;
                    ws.Cell(i + 2, 2).Value = q.Text;
                    ws.Cell(i + 2, 3).Value = q.AnswerA;
                    ws.Cell(i + 2, 4).Value = q.AnswerB;
                    ws.Cell(i + 2, 5).Value = q.AnswerC;
                    ws.Cell(i + 2, 6).Value = q.AnswerD;
                    ws.Cell(i + 2, 7).Value = q.CorrectAnswer;
                    ws.Cell(i + 2, 8).Value = q.Category;
                    ws.Cell(i + 2, 9).Value = q.Difficulty;
                }

                workbook.SaveAs("questions.xlsx");
            }
        }

        public static void LoadFromExcel()
        {
            AllQuestions.Clear();

            if (!File.Exists("questions.xlsx"))
                return;

            using (var workbook = new XLWorkbook("questions.xlsx"))
            {
                var ws = workbook.Worksheet("Questions");

                foreach (var row in ws.RowsUsed().Skip(1)) // Skip header row
                {
                    var q = new Question
                    {
                        Type = row.Cell(1).GetString(),
                        Text = row.Cell(2).GetString(),
                        AnswerA = row.Cell(3).GetString(),
                        AnswerB = row.Cell(4).GetString(),
                        AnswerC = row.Cell(5).GetString(),
                        AnswerD = row.Cell(6).GetString(),
                        CorrectAnswer = row.Cell(7).GetString(),
                        Category = row.Cell(8).GetString(),
                        Difficulty = row.Cell(9).GetString()
                    };

                    AllQuestions.Add(q);
                }
            }
        }
    }
}
