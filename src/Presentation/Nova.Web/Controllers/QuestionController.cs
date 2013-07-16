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
            return View();
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
    }
}
