using System;
using System.Linq;
using System.Text;

namespace CodeGeneration
{
    public static class StringExtensions
    {
        public const int LevelSize = 4;

        /// <summary>
        /// Align code using spaces. Works correctly with StyleCop compliant code (alignment relies on brackets)
        /// </summary>
        /// <param name="code"></param>
        /// <param name="level">level = 4 spaces by default. example of levels: namespace = 0, class = 1, method = 2</param>
        /// <returns></returns>
        public static string Indent(this string code, int level = 0)
        {
            var lines = code.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None).Select(x => x.TrimStart());

            var result = new StringBuilder();
            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    result.AppendLine();
                }
                else
                {
                    if (line.StartsWith("}"))
                    {
                        level--;
                    }

                    result.Append(new string(' ', LevelSize * level));
                    result.AppendLine(line);

                    if (line.StartsWith("{"))
                    {
                        level++;
                    }
                }
            }

            return result.ToString();
        }
    }
}
