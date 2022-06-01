using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("/CreateExam")]
    public class AnasayfaController : Controller
    {



        [Route("/CreateExam")]
        public IActionResult CreateExam()
        {
            return View();
        }

        [Route("/CreateQuestion")]
        public IActionResult CreateQuestion()
        {
            return View();
        }

        [Route("/ExamResults")]
        public IActionResult ExamResults()
        {
            return View();
        }



    }
}
