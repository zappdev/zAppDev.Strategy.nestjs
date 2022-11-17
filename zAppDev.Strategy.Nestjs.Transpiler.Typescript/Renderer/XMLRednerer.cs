using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer
{
    public class XMLRednerer : IXMLRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public XMLRednerer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> DocumentLoadFromString()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> DocumentSelectElement()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> DocumentSelectElements()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> DocumentToString()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, bool, string> ElementInnerText()
        {
            return (options, parsed, isAssignment) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> ElementSelectElements()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> ElementSelectElement()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> ElementGetAttribute()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> ElementSetAttribute()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> ElementToString()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public string XMLDocument()
        {
            throw new NotImplementedException();
        }

        public string XMLElement()
        {
            throw new NotImplementedException();
        }

        public string DefaultInstationCode()
        {
            throw new NotImplementedException();
        }

        public string XMLElementInstationCode(string typeClassName)
        {
            throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> DocumentEncrypt()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ElementEncrypt()
            => null;
    }
}
