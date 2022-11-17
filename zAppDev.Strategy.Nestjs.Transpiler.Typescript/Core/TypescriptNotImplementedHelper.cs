using System.Text.RegularExpressions;
using System.Linq;
using CLMS.Lang.Model.Expressions;
using zAppDev.Strategy.Transpiler.Base.Helpers;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Core
{
    public class TypescriptNotImplementedHelper : INotImplementedHelper
    {
        private static readonly Regex DoubleQuoteRegex = new Regex("[\"]");

        private static readonly Regex SemicolonRegex = new Regex("[;]");

        public string GetNotImplementedCode(string parsed, string parameters = null, FunctionCall fcall = null)
        {
            var msg = string.IsNullOrEmpty(parameters) ? parsed : $"{parsed}({parameters})";
            if (fcall != null)
            {
                msg = $"{fcall.Function.GetParent()?.GetParent()?.FullName}({string.Join(",", fcall.Function.Parameters.Select(c => c.Name))})";
            }

            return $"throw \"{Sanitize(parsed)}({Sanitize(parameters)})\"";
        }

        private string Sanitize(string param)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                return "";
            }

            param = DoubleQuoteRegex.Replace(param, "'");
            return SemicolonRegex.Replace(param, "");
        }
    }
}