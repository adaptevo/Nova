using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Nova.Web.Model;
using Nova.Core.Model;

namespace Nova.Web.Controllers
{
    public class QuestionController : Controller
    {
        private static readonly QuestionModel _questionModel = new QuestionModel();

        //
        // GET: /Question/

        public ActionResult Index(string QuestionId)
        {
            if (_questionModel.Questions == null)
            {
                _questionModel.Questions = new Dictionary<string, Question>();
            }

            return View("Index", _questionModel);
        }

        public ActionResult Create()
        {
            return View("CreateQuestionView");
        }

        public ActionResult SaveNew(string questionText)
        {
            string questionId = Guid.NewGuid().ToString();
            _questionModel.Questions.Add(questionId, new Question(questionText) { QuestionId = questionId});
            return Index(questionId);
        }

        public ActionResult Update(string questionId, string questionText)
        {
            if (_questionModel.Questions.ContainsKey(questionId))
            {
                _questionModel.Questions[questionId].QuestionText = questionText;
            }

            return View("Index", _questionModel);
        }

        public ActionResult Overview(string QuestionId)
        {
            if (!string.IsNullOrEmpty(QuestionId) && _questionModel.Questions.ContainsKey(QuestionId))
            {
                return View("OverviewView", _questionModel.Questions[QuestionId]);
            }
            else
            {
                return View("OverviewView");
            }
        }

        public ActionResult Edit(string QuestionId)
        {
            if (!string.IsNullOrEmpty(QuestionId) && _questionModel.Questions.ContainsKey(QuestionId))
            {
                return View("EditQuestionView", _questionModel.Questions[QuestionId]);
            }
            else
            {
                return View("OverviewView");
            }
        }
    }
}
