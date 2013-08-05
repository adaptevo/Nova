
namespace Nova.Framework.IoCContainer
{
    public interface IResolve
    {
        T Resolve<T>();
        T Resolve<T>(string name);
    }
}
