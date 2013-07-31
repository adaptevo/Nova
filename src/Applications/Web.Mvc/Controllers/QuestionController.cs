using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Nova.Core.Application;
using Nova.Core.Domain;
using Nova.Applications.Web.Mvc.Model;
using Nova.Core.Services.Persistence;
using Nova.Core.Services.Context;
using Nova.Core;

namespace Nova.Applications.Web.Mvc.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IQuestionRepository _questionRepository;
        private readonly ICommandHandler<PostQuestionCommand> _postQuestion;

        public QuestionController()
        {
            _questionRepository = new InMemoryQuestionRepository();
            _questionService = new QuestionService(_questionRepository, new TagService(new MockUserContext()), new MockUserContext());
            _postQuestion = new PostQuestionCommandHandler(_questionRepository, new TagService(new MockUserContext()), new MockUserContext());
        }

        //
        // GET: /Question/

        public ActionResult Index()
        {
            return View("Index", _questionRepository.GetAll());
        }

        public ActionResult Create()
        {
            return View("CreateQuestionView");
        }

        public ActionResult SaveNew(string questionText)
        {
            var command = new PostQuestionCommand()
            {
                Question = questionText,
                Keywords = questionText
            };

            _postQuestion.Handle(command);
            return Overview(command.QuestionId);
        }

        public ActionResult Update(int questionId, string questionText)
        {
            return Index();
        }

        public ActionResult Overview(int questionId)
        {
            Question question = _questionRepository.Get(questionId);
            if (question != default(Question))
            {
                return View("OverviewView", question);
            }
            else
            {
                return View("OverviewView");
            }
        }

        public ActionResult Edit(int questionId)
        {
            Question question = _questionRepository.Get(questionId);
            if (question != default(Question))
            {
                return View("EditQuestionView", question);
            }
            else
            {
                return View("OverviewView");
            }
        }
    }
}
