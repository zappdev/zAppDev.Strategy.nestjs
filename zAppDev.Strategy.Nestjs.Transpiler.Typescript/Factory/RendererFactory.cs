using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Factory;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using System.Collections.Generic;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Factory
{
    public class RendererFactory : IRendererFactory
    {
        private static readonly Dictionary<Type, Type> _implementations
            = new Dictionary<Type, Type>();

        public RendererFactory AddRenderer<T, V>() where V : T
        {
            if (_implementations.ContainsKey(typeof(T)) == false)
            {
                _implementations.Add(typeof(T), typeof(V));
            }
            else
            {
                _implementations[typeof(T)] = typeof(V);
            }

            return this;
        }

        public T Build<T>(ILibraryHelper helper, IFunctionTransformer functionTransformer) where T : class
        {
            if (_implementations.ContainsKey(typeof(T)))
            {
                var renderedType = _implementations[typeof(T)];
                return Activator.CreateInstance(renderedType, helper, functionTransformer) as T;
            }
            return default;
        }
    }
}
