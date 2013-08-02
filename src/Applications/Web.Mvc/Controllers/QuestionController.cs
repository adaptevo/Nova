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
        private readonly ICommandHandler<PostQuestionCommand> _postQuestion;
        private readonly IQueryHandler<GetQuestionByIdQuery, Question> _getQuestionById;
        private readonly IQueryHandler<GetAllQuestionsQuery, IEnumerable<Question>> _getAllQuestions;

        public QuestionController(ICommandHandler<PostQuestionCommand> postQuestion, 
            IQueryHandler<GetQuestionByIdQuery, Question> getQuestionById,
            IQueryHandler<GetAllQuestionsQuery, IEnumerable<Question>> getAllQuestions)
        {
            var questionRepository = new InMemoryQuestionRepository();
            _postQuestion = new PostQuestionCommandHandler(questionRepository, new TagService());
            _getQuestionById = new GetQuestionByIdQueryHandler(questionRepository);
            _getAllQuestions = new GetAllQuestionsQueryHandler(questionRepository);
        }

        public ActionResult Index()
        {
            return View("Index", _getAllQuestions.Handle(new GetAllQuestionsQuery()));
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
            Question question = _getQuestionById.Handle(new GetQuestionByIdQuery() { QuestionId = questionId });

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
            Question question = _getQuestionById.Handle(new GetQuestionByIdQuery() { QuestionId = questionId });

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
