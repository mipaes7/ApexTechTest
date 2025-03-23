using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAPI.Models
{
    public class Answers
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid QuestionId { get; set; }
        public List<string>? Selection { get; set;} = new List<string>();
        public int? Rating  { get; set; }
    }
}