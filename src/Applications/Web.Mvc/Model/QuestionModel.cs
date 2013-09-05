using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nova.Core.Domain;

namespace Nova.Applications.Web.Mvc.Model
{
    public class QuestionModel
    {
        public QuestionModel()
        {
            Questions = new Dictionary<string, Question>();
        }

        public Dictionary<string, Question> Questions { get; set; }

        public Question CurrentQuestion { get; set; }

        public Answer CurrentAnswer { get; set; }
    }
}