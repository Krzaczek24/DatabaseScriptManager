using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DatabaseScriptManager
{
    public static class TextLinesOperator
    {
        public static List<string> ExtractTableNames(string[] lines)
        {
            var regex = new Regex("^\\s*?CREATE\\s+?TABLE\\s+?(\"\\w+\")");
            return lines
                .Select(x => regex.Match(x))
                .Where(x => x.Success)
                .Select(x => x.Groups.Values.Last().Value)
                .ToList();
        }

        public static string[] AddLinesPrefixAndSuffix(string[] lines, string prefix, string suffix)
        {
            return AddLinesSuffix(AddLinesPrefix(lines, prefix), suffix);
        }

        public static string[] AddLinesPrefix(string[] lines, string prefix)
        {
            return lines.Select(x => $"{prefix}{x}").ToArray();
        }

        public static string[] AddLinesSuffix(string[] lines, string suffix)
        {
            return lines.Select(x => $"{x}{suffix}").ToArray();
        }
    }
}
