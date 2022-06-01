using Kaynak_Kod.Entities.Exams;
using Kaynak_Kod.Entities.ExamScreen;
using Kaynak_Kod.Services.ExamScreenService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Services;
namespace Kaynak_Kod.Controllers.ExamScreenControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamScrennApiController : ControllerBase
    {
        private IExamScreenService _ExamScreenService;
        public ExamScrennApiController(IExamScreenService ExamScreenService)
        {
            _ExamScreenService = ExamScreenService;
        }

        [AllowAnonymous]
        [HttpPost("Create_Exam_User_Informaiton")]
        public IActionResult Create_Exam_User_Informaiton(User_Information x)
        {
            var rd = _ExamScreenService.Create_Exam_User_Informaiton(x);
            return Ok(rd);
        }

        [AllowAnonymous]
        [HttpPost("Get_User_Information_By_Id")]
        public IActionResult Get_User_Information_By_Id(User_Information x)
        {
            var rd = _ExamScreenService.Get_User_Information_By_Id(x);
            return Ok(rd);
        }


        [AllowAnonymous]
        [HttpPost("Create_Random_Exam_Questions")]
        public IActionResult Create_Random_Exam_Questions(User_Information x)
        {
            var rd = _ExamScreenService.Create_Random_Exam_Questions(x);
            return Ok(rd);
        }

        [AllowAnonymous]
        [HttpPost("Get_All_Questions_By_User_Id")]
        public IActionResult Get_All_Questions_By_User_Id(User_Information x)
        {
            var rd = _ExamScreenService.Get_All_Questions_By_User_Id(x);
            return Ok(rd);
        }

        [AllowAnonymous]
        [HttpPost("Exam_Get_By_Guid")]
        public IActionResult Exam_Get_By_Guid(Exam x)
        {
            var rd = _ExamScreenService.Exam_Get_By_Guid(x);
            return Ok(rd);
        }

        [AllowAnonymous]
        [HttpPost("Add_User_Answers")]
        public IActionResult Add_User_Answers(User_Answers x)
        {
            _ExamScreenService.Add_User_Answers(x);
            return Ok();
           
        }





    }
}