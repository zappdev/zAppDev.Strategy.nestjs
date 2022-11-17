using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer;
using zAppDev.Strategy.Transpiler.Base.Core;
using System;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer
{
    public class GTFSRenderer : IGTFSRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;
        public GTFSRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> FeedParse()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FeedParseFromRemoteZip()
            => null;

        public string GetFeedInstanceMember(TypeClass owner, Identifier identifier, string parsed, bool isAssignment)
            => throw new NotImplementedException();

        public string GetInstanceMember(TypeClass owner, Identifier identifier, string parsed, bool isAssignment)
            => throw new NotImplementedException();

        public string GTFSAccessibilityType()
        {
            throw new NotImplementedException();
        }

        public string GTFSAgency()
        {
            throw new NotImplementedException();
        }

        public string GTFSCalendar()
        {
            throw new NotImplementedException();
        }

        public string GTFSCalendarDate()
        {
            throw new NotImplementedException();
        }

        public string GTFSDirectionType()
        {
            throw new NotImplementedException();
        }

        public string GTFSDropOffType()
        {
            throw new NotImplementedException();
        }

        public string GTFSExceptionType()
        {
            throw new NotImplementedException();
        }

        public string GTFSFeed()
        {
            throw new NotImplementedException();
        }

        public string GTFSLocationType()
        {
            throw new NotImplementedException();
        }

        public string GTFSPickupType()
        {
            throw new NotImplementedException();
        }

        public string GTFSRoute()
        {
            throw new NotImplementedException();
        }

        public string GTFSRouteType()
        {
            throw new NotImplementedException();
        }

        public string GTFSShape()
        {   
            throw new NotImplementedException();
        }

        public string GTFSStop()
        {
            throw new NotImplementedException();
        }

        public string GTFSStopTime()
        {
            throw new NotImplementedException();
        }

        public string GTFSTimeOfDay()
        {
            throw new NotImplementedException();
        }

        public string GTFSTrip()
        {
            throw new NotImplementedException();
        }
    }
}
