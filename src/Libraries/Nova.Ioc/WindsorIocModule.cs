using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Nova.Libraries.Ioc
{
    public class WindsorIocModule : IocModule
    {
        private IWindsorContainer _windsorContainer;

        public WindsorIocModule(IWindsorContainer container)
        {
            _windsorContainer = container;
        }
        
        public override void Register<TInterface, TClass>() 
        {
            _windsorContainer.Register(Component.For<TInterface>().ImplementedBy<TClass>());
        }
    }
}
