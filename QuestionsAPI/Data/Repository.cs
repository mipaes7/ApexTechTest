using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestionsAPI.Models;

namespace QuestionsAPI.Data
{
    public static class Repository
    {
        private static readonly List<Questions> questions = new List<Questions>();
        private static readonly List<Answers> answers = new List<Answers>();

        public static List<Questions> GetAll() => questions;

        public static Questions GetById(Guid id) => questions.Find(q => q.Id == id);

        public static void Add(Questions question)
        {
            questions.Add(question);
        }

        public static void Update(Questions updatedQuestion)
        {
            var existingQuestion = questions.Find(q => q.Id == updatedQuestion.Id);
            if (existingQuestion != null)
            {
                questions.Remove(existingQuestion);
                questions.Add(updatedQuestion);
            }
        }

        public static void AddAnswer(Answers answer)
        {
            answers.Add(answer);
        }

        public static List<Answers> GetAnswersByQuestionId(Guid questionId)
        {
            return answers.Where(a => a.QuestionId == questionId).ToList();
        }
    }
}