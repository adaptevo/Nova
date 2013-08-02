
namespace Nova.Framework.IoCContainer
{
    public interface IResolve
    {
        T Resolve<T>();
        T Resolve<T>(string key);
        bool CanResolve<T>();
        bool CanResolve<T>(string key);
        void Release(object instance);
    }
}
