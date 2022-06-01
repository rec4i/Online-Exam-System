using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using Kaynak_Kod.Entities.Questions;
using Kaynak_Kod.Services.Exams;
using Kaynak_Kod.Entities.Exams;
namespace Kaynak_Kod.Controllers.ExamControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamResultController : ControllerBase
    {
        private IExamResultService _ExamResultService;
        public ExamResultController(IExamResultService ExamService)
        {
            _ExamResultService = ExamService;
        }



        [Authorize(Role.Admin)]
        [HttpPost("Get_All_Exam_List_With_Pagination")]
        public IActionResult Get_All_Exam_List_With_Pagination(pagenation_request x)
        {
            var rd = _ExamResultService.Get_All_Exam_List_With_Pagination(x);
            return Ok(rd);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Get_By_Exam_Guid_Exam_Resutls")]
        public IActionResult Get_By_Exam_Guid_Exam_Resutls(Exam x)
        {
            var rd = _ExamResultService.Get_By_Exam_Guid_Exam_Resutls(x);
            return Ok(rd);
        }

        


    }
}