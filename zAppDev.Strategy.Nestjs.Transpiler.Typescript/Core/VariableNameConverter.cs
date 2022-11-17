using System.Collections.Generic;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Core
{
    public class VariableNameConverter
    {
        public static readonly List<string> reserved = new List<string> {
            "import", "export", "eval", "enum", "interface", "static", "constructor", "let", "async", "debugger"
        };

        public static string Convert(string name)
        {
            if (reserved.Contains(name))
            {
                return $"__{name}";
            }

            return name;
        }
    }
}
