using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAPI.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        // public string Type { get; set; }
        public IList<string> Options { get; set; } = new List<string>();
        public int MinRating { get; set; } = 1;
        public int MaxRating { get; set; } = 5;

    }
}