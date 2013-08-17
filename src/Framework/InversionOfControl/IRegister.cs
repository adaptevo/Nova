
using System;
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

        IRegister Register<TInterface>(Func<TInterface> factoryMethod, Lifetime lifetime)
            where TInterface : class;

        IRegister Register<TInterface, IFactory>(Func<IFactory, TInterface> factoryMethod, Lifetime lifetime)
            where TInterface : class
            where IFactory : class;
    }
}
