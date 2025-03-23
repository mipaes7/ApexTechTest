using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestionsAPI.Enums;

namespace QuestionsAPI.Models
{
    public class Questions
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public QuestionType Type { get; set; }
        public IList<string>? Options { get; set; } = new List<string>();
        public int? MinRating { get; set; } = 1;
        public int? MaxRating { get; set; } = 5;

    }
}