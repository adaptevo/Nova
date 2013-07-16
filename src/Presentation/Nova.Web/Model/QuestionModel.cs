using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nova.Core.Model;

namespace Nova.Web.Model
{
    public class QuestionModel
    {
        public Dictionary<string, Question> Questions { get; set; }
    }
}