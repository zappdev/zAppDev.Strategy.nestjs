namespace zAppDev.Strategy.Utilities.Transformer
{
    public abstract class TypescriptGenerator<T> : IDisposable, IGenerator<T>
    {
        protected T _model;

        protected TypescriptGenerator()
        {
        }

        public abstract string GetFilename(T model);

        protected abstract string RenderImports(T model);

        protected abstract string RenderClass(T model);

        public virtual string Render(T model)
        {
            return $@"{RenderImports(model)}

{RenderClass(model)}
";
        }

        public virtual string Render(IEnumerable<T> models)
        {
            return "";
        }

        public (string, string) RenderFile(T model)
        {
            return (GetFilename(model), Render(model));
        }

        public void Dispose()
        {
        }

    }
}
