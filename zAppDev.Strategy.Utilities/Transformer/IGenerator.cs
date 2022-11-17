namespace zAppDev.Strategy.Utilities.Transformer
{
    public interface IGenerator<T>
    {
        void Dispose();
        string GetFilename(T cls);
        string Render(IEnumerable<T> cls);
        string Render(T cls);
    }
}