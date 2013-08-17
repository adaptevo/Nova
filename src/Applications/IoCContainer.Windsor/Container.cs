using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Nova.Framework.InversionOfControl;

namespace Nova.Libraries.Ioc
{
    public class Container : IContainer, IDisposable
    {
        private readonly IWindsorContainer _windsorContainer;

        public Container()
        {
            _windsorContainer = new WindsorContainer();
        }

        public IRegister Register<TInterface, TClass>(Lifetime lifetime = Lifetime.Transient)
            where TInterface : class
            where TClass : TInterface
        {
            return Register<TInterface, TClass>(string.Empty, lifetime);
        }

        public IRegister Register<TInterface, TClass>(string name, Lifetime lifetime)
            where TInterface : class
            where TClass : TInterface
        {
            ComponentRegistration<TInterface> registration = Component.For<TInterface>().ImplementedBy<TClass>();
            return Register(registration, name, lifetime);
        }

        public IRegister Register<TInterface>(Func<TInterface> factoryMethod, Lifetime lifetime)
            where TInterface : class
        {
            ComponentRegistration<TInterface> registration = Component.For<TInterface>()
                .UsingFactoryMethod(factoryMethod);
            return Register(registration, string.Empty, lifetime);
        }

        public IRegister Register<TInterface, IFactory>(Func<IFactory, TInterface> factoryMethod, Lifetime lifetime)
            where TInterface : class
            where IFactory : class
        {
            ComponentRegistration<TInterface> registration = Component.For<TInterface>()
                .UsingFactoryMethod(k => factoryMethod(k.Resolve<IFactory>()));
            return Register(registration, string.Empty, lifetime);
        }

        public T Resolve<T>()
        {
            return _windsorContainer.Resolve<T>();
        }

        public T Resolve<T>(string name)
        {
            return _windsorContainer.Resolve<T>(name);
        }

        public void Dispose()
        {
            _windsorContainer.Dispose();
        }

        private IRegister Register<TInterface>(ComponentRegistration<TInterface> registration, string name, Lifetime lifetime)
            where TInterface : class
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                registration = registration.Named(name);
            }

            switch (lifetime)
            {
                case Lifetime.Singleton:
                    registration = registration.LifeStyle.Singleton;
                    break;
                case Lifetime.PerWebRequest:
                    registration = registration.LifeStyle.PerWebRequest;
                    break;
                default:
                    registration = registration.LifeStyle.Transient;
                    break;
            }

            _windsorContainer.Register(registration);
            return this;
        }
    }
}
