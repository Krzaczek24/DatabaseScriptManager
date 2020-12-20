using System;

namespace DatabaseScriptManager
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            args = new string[] { "script.sql" };
#endif

            if (!FileHelper.ParseFilePath(args, out string path, out string errorMsg))
            {
                Console.WriteLine("Wystąpił błąd!");
                Console.WriteLine(errorMsg);
                Environment.Exit(-1);
            }

            var text = FileHelper.GetFileLines(path);
            var tables = TextLinesOperator.ExtractTableNames(text);
            tables.Reverse();
            var deleteTables = TextLinesOperator.AddLinesPrefixAndSuffix(tables.ToArray(), "DROP TABLE ", ";");
            FileHelper.PrependLinesToFile(path, deleteTables);
        }
    }
}
