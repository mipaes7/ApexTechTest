using Microsoft.AspNetCore.Mvc;
using QuestionsAPI.Data;
using QuestionsAPI.Models;
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
    }
}
