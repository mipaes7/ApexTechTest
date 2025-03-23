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
        [HttpPut("{id:guid}")]
        public IActionResult CreateOrUpdateQuestion(Guid id, [FromBody] Questions question)
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

        [HttpGet("{id:guid}")]
        public IActionResult GetQuestion(Guid id)
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

        [HttpPost("{id:guid}")]
        public IActionResult SubmitAnswer(Guid questionId, [FromBody] Answers answer)
        {
            var question = Repository.GetById(questionId);
            
            if (question == null)
            {
                return BadRequest("test"); 
            }

            switch (question.Type)
            {
                case QuestionType.FiveStarRating:
                if(answer.Rating == null || answer.Rating < question.MinRating || answer.Rating > question.MaxRating)
                {
                    return BadRequest("Invalid rating");
                }
                break;

                case QuestionType.MultipleOption:
                if(answer.Selection.Count < 1 ||answer.Selection.All(selectedOption => question.Options.Contains(selectedOption)))
                {
                    return BadRequest("Invalid selection");
                }
                break;

                case QuestionType.SingleOption:
                if(answer.Selection.Count != 1 || question.Options.Contains(answer.Selection[0]))
                {
                    return BadRequest("Invalid selection");
                }
                break;

                default:
                    return BadRequest("Invalid question type");
            }

            return Ok("Answer submitted");
        }
    }
}

//*REQUEST POST 
// {
//   "title": "fiveStarQuestionStandard",
//   "Type": 0,
//   "minRating": 1,
//   "maxRating": 10
// }
//*RESPONSE
// {
//     "id": 7,
//     "title": "fiveStarQuestionStandard",
//     "type": 0,
//     "options": [],
//     "minRating": 1,
//     "maxRating": 10
// }
//*REQUEST POST
// {
//   "title": "multipleOptionStandard",
//   "Type": 1,
//   "options": ["option1", "option2"]
// }
//*RESPONSE
// {
//     "id": 8,
//     "title": "multipleOptionStandard",
//     "type": 1,
//     "options": [
//         "option1",
//         "option2"
//     ],
//     "minRating": 1,
//     "maxRating": 5
// }
//*REQUEST POST
// {
//   "title": "singleOptionStandard",
//   "Type": 2,
//   "options": ["option1", "option2"]
// }
//*RESPONSE
// {
//     "id": 9,
//     "title": "singleOptionStandard",
//     "type": 2,
//     "options": [
//         "option1",
//         "option2"
//     ],
//     "minRating": 1,
//     "maxRating": 5
// }
