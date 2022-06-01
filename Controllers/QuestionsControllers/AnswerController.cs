using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using Kaynak_Kod.Services;
using System.Threading.Tasks;
using Kaynak_Kod.Models.Users;
using System.Collections.Generic;
using Kaynak_Kod.Services.Questions;
using Kaynak_Kod.Entities.Questions;

namespace Kaynak_Kod.Controllers.QuestionsControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerController : ControllerBase
    {
        private IAnswerService _AnswerService;
        public AnswerController(IAnswerService AnswerService)
        {
            _AnswerService = AnswerService;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Answer_Add")]
        public IActionResult Answer_Add(Answer x)
        {
            var rd = _AnswerService.Answer_Add(x);
            return Ok(rd);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Answer_Delete")]
        public IActionResult Answer_Delete(Answer x)
        {
            var rd = _AnswerService.Answer_Delete(x);
            return Ok(rd);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Answer_Edit")]
        public IActionResult Answer_Edit(Answer x)
        {
            var rd = _AnswerService.Answer_Edit(x);
            return Ok(rd);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Answer_Get_All")]
        public IActionResult Answer_Get_All()
        {
            var rd = _AnswerService.Answer_Get_All();
            return Ok(rd);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Answer_Get_By_Id")]
        public IActionResult Answer_Get_By_Id(Answer x)
        {
            var rd = _AnswerService.Answer_Get_By_Id(x);
            return Ok(rd);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Answer_Get_By_Question_Id")]
        public IActionResult Answer_Get_By_Question_Id(Question x)
        {
            var rd = _AnswerService.Answer_Get_By_Question_Id(x);
            return Ok(rd);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Answer_Delete_By_Question_Id")]
        public IActionResult Answer_Delete_By_Question_Id(Answer x)
        {
            _AnswerService.Answer_Delete_By_Question_Id(x);
            return Ok();
        }






    }
}