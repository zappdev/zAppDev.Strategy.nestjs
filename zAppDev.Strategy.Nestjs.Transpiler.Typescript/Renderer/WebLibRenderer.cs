using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;
using System;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer
{
    public class WebLibRenderer : IWebLibRenderer
    {
        protected readonly ILibraryHelper _helper;
        protected readonly IFunctionTransformer _compiler;

        public WebLibRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public string DefaultInstatiationCode(TypeClass typeClass)
        {
            return _compiler.DataTypeTransformer.GetInstantiationCode(typeClass);
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> RequestRedirectToUrl()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params, null);

        public Func<FunctionOptions, string, bool, string> RequestApplicationPath()
            => (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public Func<FunctionOptions, string, string, FunctionCall, string> RequestGetClientIp()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params, null);

        public Func<FunctionOptions, string, string, FunctionCall, string> RequestGetQueryStringParameter()
        {
            return (options, parsed, @params, fcall) =>
            {
                throw new NotImplementedException();
            };
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> RequestGetServerVariable()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params, null);

        public Func<FunctionOptions, string, string, FunctionCall, string> RequestGetUrl()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params, null);

        public Func<FunctionOptions, string, string, FunctionCall, string> RequestIsAuthenticated()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params, null);

        public Func<FunctionOptions, string, string, FunctionCall, string> SocketCloseConnection()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params, null);

        public Func<FunctionOptions, string, string, FunctionCall, string> SocketCreateConnection()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params, null);

        public Func<FunctionOptions, string, string, FunctionCall, string> SocketSend()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params, null);

        public Func<FunctionOptions, string, string, FunctionCall, string> SocketStartReceiving()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params, null);

        public Func<FunctionOptions, string, bool, string> UriAuthority()
            => (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public Func<FunctionOptions, string, string, FunctionCall, string> UriCreateFromString()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params, null);

        public Func<FunctionOptions, string, bool, string> UriHost()
            => (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public string UriInstatiationCode()
            => throw new NotImplementedException();

        public string URIName()
            => _helper.NotImplementedHelper.GetNotImplementedCode("WebLib.Uri");

        public Func<FunctionOptions, string, bool, string> UriPort()
            => (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public Func<FunctionOptions, string, bool, string> UriScheme()
            => (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public Func<FunctionOptions, string, string, FunctionCall, string> RequestGetHeader()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params, null);

        public Func<FunctionOptions, string, string, FunctionCall, string> SocketGetConnection()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params, null);

        public Func<FunctionOptions, string, bool, string> SocketClientIsConnected()
            => (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public string SocketClientName()
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode("WebLig.SocketClient");
        }
    }
}
