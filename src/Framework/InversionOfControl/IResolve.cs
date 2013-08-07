
namespace Nova.Framework.InversionOfControl
{
    public interface IResolve
    {
        T Resolve<T>();
        T Resolve<T>(string name);
    }
}
