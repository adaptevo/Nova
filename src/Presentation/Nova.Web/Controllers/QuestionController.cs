using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Nova.Web.Controllers
{
    public class QuestionController : Controller
    {
        private static readonly Dictionary<string, string> _questionRepository = new Dictionary<string, string>();

        //
        // GET: /Question/

        public ActionResult Index(string QuestionId)
        {
            return View("Index", _questionRepository);
        }

        public ActionResult Create()
        {
            return View("CreateQuestionView");
        }

        public ActionResult SaveNew(string questionText)
        {
            string questionId = Guid.NewGuid().ToString();
            _questionRepository.Add(questionId, questionText);
            return Index(questionId);
        }

        public ActionResult Overview(string QuestionId)
        {
            if(!string.IsNullOrEmpty(QuestionId) && _questionRepository.ContainsKey(QuestionId))
            {
                return View("OverviewView", (object)_questionRepository[QuestionId]);
            }
            else
            {
                return View("OverviewView");
            }
        }
    }
}
