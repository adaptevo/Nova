
using System.Web.Mvc;
using Nova.Applications.Web.Mvc.Controllers;
using Nova.Framework.IoCContainer;

namespace Nova.Applications.Web.Mvc
{
    public class TypeInstaller : IInstaller
    {
        public void Install(IContainer container)
        {
            container.Register<IController, QuestionController>("Question", Lifetime.Transient);
        }
    }
}