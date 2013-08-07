
namespace Nova.Framework.InversionOfControl
{
    public interface IRegister
    {
        IRegister Register<TInterface, TClass>(Lifetime lifetime)
            where TInterface : class
            where TClass : TInterface;

        IRegister Register<TInterface, TClass>(string name, Lifetime lifetime)
            where TInterface : class
            where TClass : TInterface;
    }
}
