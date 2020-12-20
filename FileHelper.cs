using System.IO;
using System.Linq;

namespace DatabaseScriptManager
{
    public static class FileHelper
    {
        public static bool ParseFilePath(string[] args, out string parsedPath, out string errorMsg)
        {
            errorMsg = string.Empty;
            parsedPath = string.Empty;

            if (args == null)
            {
                errorMsg = "Nieprawidłowy argument! Podaj ścieżkę do pliku";
                return false;
            }

            string path = string.Join("", args);

            if (!File.Exists(path))
            {
                errorMsg = "Nie znaleziono pliku [{path}]";
                return false;
            }

            parsedPath = path;
            return true;
        }

        public static string[] GetFileLines(string path)
        {
            return File.ReadAllLines(path);
        }

        public static void PrependLinesToFile(string path, string[] lines, bool ignoreExistingDrops = true, bool emptyLine = true)
        {
            var existingText = File.ReadAllLines(path).ToList();
            if (ignoreExistingDrops)
                existingText = existingText.Where(x => !x.StartsWith("DROP TABLE ")).ToList();
            while (existingText.Count() >= 0 && string.IsNullOrEmpty(existingText.First()))
                existingText.RemoveAt(0);
            File.WriteAllLines(path, lines);
            if (emptyLine)
                File.AppendAllLines(path, new string[] { string.Empty });
            File.AppendAllLines(path, existingText);
        }
    }
}
