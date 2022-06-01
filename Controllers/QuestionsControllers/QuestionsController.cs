using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using Kaynak_Kod.Services.Questions;
using Kaynak_Kod.Entities.Questions;

namespace Kaynak_Kod.Controllers.QuestionsControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private IQuestionService _QuestionService;
        public QuestionsController(IQuestionService QuestionService)
        {
            _QuestionService = QuestionService;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Question_Add")]
        public IActionResult Question_Add(Question x)
        {
            var rd = _QuestionService.Question_Add(x);
            return Ok(rd);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Question_Delete")]
        public IActionResult Question_Delete(Question x)
        {
            var rd = _QuestionService.Question_Delete(x);
            return Ok(rd);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Question_Edit")]
        public IActionResult Question_Edit(Question x)
        {
            var rd = _QuestionService.Question_Edit(x);
            return Ok(rd);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Question_Get_All")]
        public IActionResult Question_Get_All()
        {
            var rd = _QuestionService.Question_Get_All();
            return Ok(rd);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Question_Get_By_Id")]
        public IActionResult Question_Get_By_Id(Question x)
        {
            var rd = _QuestionService.Question_Get_By_Id(x);
            return Ok(rd);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Question_Get_With_Pagenation")]
        public IActionResult Question_Get_With_Pagenation(pagenation_request x)
        {
            var rd = _QuestionService.Question_Get_With_Pagenation(x);
            return Ok(rd);
        }








    }
}