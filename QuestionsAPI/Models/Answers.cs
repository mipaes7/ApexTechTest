using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAPI.Models
{
    public class Answers
    {
        public Guid Id { get; set; }
        public List<string> AnswersValues { get; set;} = new List<string>();
    }
}