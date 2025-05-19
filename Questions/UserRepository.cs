using ClosedXML.Excel;
using System;
using System.IO;
using System.Linq;

namespace PROJECT
{
    public static class UserRepository
    {
        private static readonly string FilePath = "Users.xlsx";

        public static void EnsureFileExists()
        {
            if (!File.Exists(FilePath))
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("Users");

                ws.Cell(1, 1).Value = "Username";
                ws.Cell(1, 2).Value = "ID";
                ws.Cell(1, 3).Value = "Email";
                ws.Cell(1, 4).Value = "Password";
                ws.Cell(1, 5).Value = "UserType";

                wb.SaveAs(FilePath);
            }
        }

        public static bool IsUserExists(string username, string id, string email)
        {
            var wb = new XLWorkbook(FilePath);
            var ws = wb.Worksheet("Users");

            return ws.RowsUsed().Skip(1).Any(row =>
                row.Cell(1).GetString() == username ||
                row.Cell(2).GetString() == id ||
                row.Cell(3).GetString() == email);
        }

        public static void AddUser(string username, string id, string email, string password, string userType)
        {
            var wb = new XLWorkbook(FilePath);
            var ws = wb.Worksheet("Users");
            int lastRow = ws.LastRowUsed().RowNumber();

            ws.Cell(lastRow + 1, 1).Value = username;
            ws.Cell(lastRow + 1, 2).Value = id;
            ws.Cell(lastRow + 1, 3).Value = email;
            ws.Cell(lastRow + 1, 4).Value = password;
            ws.Cell(lastRow + 1, 5).Value = userType;

            wb.Save();
        }

        public static bool ValidateLogin(string username, string password, string userType)
        {
            if (!File.Exists(FilePath)) return false;

            var wb = new XLWorkbook(FilePath);
            var ws = wb.Worksheet("Users");

            return ws.RowsUsed().Skip(1).Any(row =>
                row.Cell(1).GetString() == username &&
                row.Cell(4).GetString() == password &&
                row.Cell(5).GetString() == userType);
        }
    }
}
