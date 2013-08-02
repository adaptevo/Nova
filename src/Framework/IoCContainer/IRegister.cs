
namespace Nova.Framework.IoCContainer
{
    public interface IRegister
    {
        IRegister Register<TInterface, TClass>(Lifetime lifetime)
            where TInterface : class
            where TClass : TInterface;

        IRegister Register<TInterface, TClass>(string key, Lifetime lifetime)
            where TInterface : class
            where TClass : TInterface;

        IRegister RegisterAllClassesBasedOn<TInterface>(Lifetime lifetime) where TInterface : class;
    }
}
