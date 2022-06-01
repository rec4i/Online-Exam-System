using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using Kaynak_Kod.Services.Questions;
namespace Kaynak_Kod.Controllers.QuestionsControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionPoolController : ControllerBase
    {

        private IQuestionPoolService _QuestionPoolService;
        public QuestionPoolController(IQuestionPoolService QuestionPoolService)
        {
            _QuestionPoolService = QuestionPoolService;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Question_Pool_Add")]
        public IActionResult Question_Pool_Add(QuestionPool x)
        {
            var rd = _QuestionPoolService.Question_Pool_Add(x);
            return Ok(rd);
        }

        [Authorize(Role.Admin)]
        [HttpPost("QuestionPool_Delete")]
        public IActionResult QuestionPool_Delete(QuestionPool x)
        {
            var rd = _QuestionPoolService.QuestionPool_Delete(x);
            return Ok(rd);
        }


        [Authorize(Role.Admin)]
        [HttpPost("QuestionPool_Edit")]
        public IActionResult QuestionPool_Edit(QuestionPool x)
        {
            var rd = _QuestionPoolService.QuestionPool_Edit(x);
            return Ok(rd);
        }

        [Authorize(Role.Admin)]
        [HttpPost("QuestionPool_Get_All")]
        public IActionResult QuestionPool_Get_All()
        {
            var rd = _QuestionPoolService.QuestionPool_Get_All();
            return Ok(rd);
        }


        [Authorize(Role.Admin)]
        [HttpPost("QuestionPool_Get_By_Id")]
        public IActionResult QuestionPool_Get_By_Id(QuestionPool x)
        {
            var rd = _QuestionPoolService.QuestionPool_Get_By_Id(x);
            return Ok(rd);
        }

    }
}