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

        public static List<Questions> GetAll() => questions;

        public static Questions GetById(int id) => questions.Find(q => q.Id == id);

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
    }
}