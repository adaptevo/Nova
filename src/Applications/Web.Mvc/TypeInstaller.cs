using System.Web.Mvc;
using Nova.Applications.Web.Mvc.Controllers;
using Nova.Framework.InversionOfControl;

namespace Nova.Applications.Web.Mvc
{
    public class TypeInstaller : IInstaller
    {
        public void Install(IRegister container)
        {
            container.Register<IController, QuestionController>("Question", Lifetime.Transient);
        }
    }
}