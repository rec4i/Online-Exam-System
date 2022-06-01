using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Services;


namespace Kaynak_Kod.Controllers.ExamScreenControllers
{
    [Route("/ExamScreen")]
    public class ExamScreenController : Controller
    {
        public IActionResult ExamScreen()
        {
            return View();
        }

    }
}