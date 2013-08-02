using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Nova.Applications.Web.Mvc.Controllers;
using Nova.Core;
using Nova.Core.Application;
using Nova.Core.Services.Persistence;
using Nova.Framework.IoCContainer;

namespace Nova.Applications.Web.Mvc
{
    public class ControllerFactory : IControllerFactory
    {
        private readonly IResolve _container;
        private readonly IControllerFactory _defaultControllerFactory;

        public ControllerFactory(IResolve container)
            : this(container, new DefaultControllerFactory())
        { }

        public ControllerFactory(IResolve container, IControllerFactory defaultControllerFactory)
        {
            _container = container;
            _defaultControllerFactory = defaultControllerFactory;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            //if (_container.CanResolve<IController>(controllerName))
            //    return _container.Resolve<IController>(controllerName);

            if (controllerName == "Question")
            {
                var questionRepository = new InMemoryQuestionRepository();
                return new QuestionController(new PostQuestionCommandHandler(questionRepository, new TagService()),
                    new GetQuestionByIdQueryHandler(questionRepository),
                    new GetAllQuestionsQueryHandler(questionRepository));
            }

            return _defaultControllerFactory.CreateController(requestContext, controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return _defaultControllerFactory.GetControllerSessionBehavior(requestContext, controllerName);
        }

        public void ReleaseController(IController controller)
        {
            //_container.Release(controller);
            controller = null;
        }
    }
}