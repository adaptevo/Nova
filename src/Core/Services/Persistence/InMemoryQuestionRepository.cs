﻿using System;
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
            var tag = new Tag("Science Fiction");
            SetId(tag, 1);

            Question question = new Question("Who is your favorite character from any of the Star Trek series", "favorite star trek series character", tag);
            SetId(question, (IntIdentifier)1);

            Answer answer;

            answer = new Answer(question, "Data");
            SetId(answer, 1);
            question.Answers.Add(answer);

            answer = new Answer(question, "Data");
            SetId(answer, 2);
            question.Answers.Add(answer);

            answer = new Answer(question, "Data");
            SetId(answer, 3);
            question.Answers.Add(answer);

            answer = new Answer(question, "Jean Luc Picard");
            SetId(answer, 4);
            question.Answers.Add(answer);

            Questions.Add(question);
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
            int currentMaxAnswerId = Questions.SelectMany(question => question.Answers).Max(answer => answer.Id);

            foreach (Question question in TransientQuestions)
            {
                SetId(question, (IntIdentifier)(++currentMaxQuestionId));

                foreach (Answer answer in question.Answers)
                {
                    SetId(answer, ++currentMaxAnswerId);
                }

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
