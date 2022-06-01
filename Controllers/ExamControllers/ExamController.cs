using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using Kaynak_Kod.Services;
using System.Threading.Tasks;
using Kaynak_Kod.Models.Users;
using System.Collections.Generic;
using Kaynak_Kod.Services.Questions;
using Kaynak_Kod.Entities.Questions;
using Kaynak_Kod.Services.Exams;
using Kaynak_Kod.Entities.Exams;

namespace Kaynak_Kod.Controllers.ExamControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : ControllerBase
    {
        private IExamService _ExamService;
        public ExamController(IExamService ExamService)
        {
            _ExamService = ExamService;
        }


        [Authorize(Role.Admin)]
        [HttpPost("Exam_Add")]
        public IActionResult Exam_Add(Exam x)
        {
            if (x.Exam_End_Date > x.Exam_Strat_Date)
            {
                var rd = _ExamService.Exam_Add(x);
                return Ok(rd);
            }
            else
            {
                return StatusCode(500, "Please Check Dates!");
            }


        }

        [Authorize(Role.Admin)]
        [HttpPost("Exam_Delete")]
        public IActionResult Exam_Delete(Exam x)
        {
            var rd = _ExamService.Exam_Delete(x);
            return Ok(rd);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Exam_Edit")]
        public IActionResult Exam_Edit(Exam x)
        {
            var rd = _ExamService.Exam_Edit(x);
            return Ok(rd);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Exam_Get_All")]
        public IActionResult Exam_Get_All()
        {
            var rd = _ExamService.Exam_Get_All();
            return Ok(rd);
        }



        [Authorize(Role.Admin)]
        [HttpPost("Exam_Gey_By_Id")]
        public IActionResult Exam_Gey_By_Id(Exam x)
        {
            var rd = _ExamService.Exam_Gey_By_Id(x);
            return Ok(rd);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Exam_Get_All_With_Pagination")]
        public IActionResult Exam_Get_All_With_Pagination(pagenation_request x)
        {
            var rd = _ExamService.Exam_Get_All_With_Pagination(x);
            return Ok(rd);
        }



    }
}