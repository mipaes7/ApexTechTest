using Microsoft.AspNetCore.Mvc;
using QuestionsAPI.Data;
using QuestionsAPI.Models;
using QuestionsAPI.Enums;
using System;

namespace QuestionsAPI.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        [HttpPut("{id:int}")]
        public IActionResult CreateOrUpdateQuestion(int id, [FromBody] Questions question)
        {
            if (question == null || string.IsNullOrEmpty(question.Title))
            {
                return BadRequest("Invalid question data.");
            }

            switch (question.Type)
            {
                case QuestionType.FiveStarRating:
                if(question.MinRating < 1 || question.MaxRating > 10 || question.MinRating >= question.MaxRating)
                {
                    return BadRequest("Invalid ratings range");
                }
                break;

                case QuestionType.MultipleOption:
                if(question.Options.Count < 2)
                {
                    return BadRequest("Must have at least 2 options");
                }
                break;

                case QuestionType.SingleOption:
                if(question.Options.Count < 2)
                {
                    return BadRequest("Must have at least 2 options");
                }
                break;

                default:
                    return BadRequest("Invalid question type");
            }

            var existingQuestion = Repository.GetById(id);
            if (existingQuestion != null)
            {
                question.Id = id;
                Repository.Update(question);
                return Ok(question);
            }
            else
            {
                question.Id = id;
                Repository.Add(question);
                return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, question);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetQuestion(int id)
        {
            var question = Repository.GetById(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            return Ok(Repository.GetAll());
        }

        [HttpPost("{id:int}")]
        public IActionResult SubmitAnswer(int questionId, [FromBody] Answers answer)
        {
            var question = Repository.GetById(questionId);
            
            if (question == null)
            {
                return NotFound();
            }

            return Ok("Answer submitted");
        }
    }
}

// {
//   "title": "title",
//   "Type": 0,
//   "options": ["option", "option"],
//   "minRating": 0,
//   "maxRating": 5
// }
// {
//   "title": "title",
//   "Type": 1,
//   "options": ["option", "option"],
//   "minRating": 0,
//   "maxRating": 5
// }
// {
//   "title": "title",
//   "Type": 2,
//   "options": ["option", "option"],
//   "minRating": 0,
//   "maxRating": 5
// }
