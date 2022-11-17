using zAppDev.Strategy.Transpiler.Base.Common;
using zAppDev.Strategy.Transpiler.Base.Core;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Statement;
using System.Linq;
using System;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Core
{
    public class NullSafeTransformer : INullSafeTransformer
    {
        private readonly IDataTypeTransformer _dataTypeTransformer;

        public bool DontUseSafeNumbers => false;

        public NullSafeTransformer(IDataTypeTransformer dataTypeTransformer)
        {
            _dataTypeTransformer = dataTypeTransformer;
        }

        public string ConcatMembers(FunctionOptions options, params string[] members)
        {
            //if (string.IsNullOrEmpty(left)) return right;
            return string.Join(".", members);
        }

        public string NullSafeMemberWrapping(FunctionOptions options, Member member, Func<FunctionOptions, Member, string> func)
        {
            var code = func.Invoke(options, member);
            if (OmitNullSafeMemberWrapping(member))
            {
                return code;
            }

            return code;
        }

        public bool OmitNullSafe(Expression currentExpDataType)
        {
            return false;
        }

        public bool OmitNullSafeMemberWrapping(Member member)
        {
            var library = member.Members.First();

            if (member.ParentStatement is Assign parentStatement)
            {
                if (parentStatement.LeftHandPart.Equals(member))
                {
                    return true;
                }
            }

            if (member.Members.Last() is EnumerationIdentifier)
            {
                return true;
            }

            return library.DataType.Name.Equals(ModuleNames.ServiceLib);
        }

        public string SafeNumberTransform(string parsed)
        {
            return parsed;
        }
    }
}
