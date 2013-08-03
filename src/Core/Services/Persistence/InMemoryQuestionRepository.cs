using System;
using System.Linq;
using Nova.Core.Domain;
using System.Collections.Generic;

namespace Nova.Core.Services.Persistence
{
    public class InMemoryQuestionRepository : IQuestionRepository
    {
        private static readonly ICollection<Question> Questions = new List<Question>();
        private static readonly ICollection<Question> TransientQuestions = new List<Question>();

        static InMemoryQuestionRepository()
        {
            var sciFiTag = new Tag("Science Fiction");
            SetId(sciFiTag, 1);

            Question question1 = new Question("Who is your favorite character from any of the Star Trek series", "favorite star trek series character", sciFiTag);
            SetId(question1, (IntIdentifier)1);
            question1.Answer("Data");
            question1.Answer("Data");
            question1.Answer("Data");
            question1.Answer("Jean Luc Picard");

            var mobileTag = new Tag("Mobile");
            SetId(mobileTag, 2);

            Question question2 = new Question("Which mobile operating system do you prefer?", "preferred mobile operating system", mobileTag);
            SetId(question2, (IntIdentifier)2);
            question2.Answer("Android");
            question2.Answer("Android");
            question2.Answer("IOS");
            question2.Answer("Windows");

            Questions.Add(question1);
            Questions.Add(question2);
        }

        public IEnumerable<Question> GetAll()
        {
            return Questions;
        }

        public Question Get(int id)
        {
            return Questions.SingleOrDefault(question => question.Id == id);
        }

        public void Add(Question question)
        {
            TransientQuestions.Add(question);
        }

        public void PersistChanges()
        {
            int currentMaxQuestionId = Questions.Max(question => question.Id);

            foreach (Question question in TransientQuestions)
            {
                SetId(question, (IntIdentifier)(++currentMaxQuestionId));              
                Questions.Add(question);
            }

            TransientQuestions.Clear();
        }

        private static void SetId<T>(T entity, IntIdentifier id)
        {
            typeof(T).GetProperty("Id").SetValue(entity, id, null); 
        }

        private static void SetId<T>(T entity, int id)
        {
            typeof(T).GetProperty("Id").SetValue(entity, id, null);
        }
    }
}
