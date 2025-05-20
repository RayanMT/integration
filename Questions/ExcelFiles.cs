using System;
using System.IO;
using System.Windows.Forms;

namespace ExamSystemApp
{
    public static class ExcelFiles
    {
        // Folder under your exe where .xlsx lives
        private static string Folder => AppDomain.CurrentDomain.BaseDirectory;
        public static string Results => Path.Combine(Folder, "Results.xlsx");
    }
}
