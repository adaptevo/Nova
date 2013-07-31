using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Nova.Core.Application;
using Nova.Core.Domain;
using Nova.Applications.Web.Mvc.Model;
using Nova.Core.Services.Persistence;
using Nova.Core.Services.Context;

namespace Nova.Applications.Web.Mvc.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IQuestionRepository _questionRepository;

        public QuestionController()
        {
            _questionRepository = new InMemoryQuestionRepository();
            _questionService = new QuestionService(_questionRepository, new InMemoryTagRepository(), new TagService(new MockUserContext()), new MockUserContext());
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
            int questionId = _questionService.PostQuestion(questionText, questionText, null);
            return Overview(questionId);
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
