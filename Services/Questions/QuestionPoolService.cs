using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaynak_Kod.Controllers.QuestionsControllers;
using Kaynak_Kod.Entities.Questions;
using Kaynak_Kod.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
namespace Kaynak_Kod.Services.Questions
{
    public interface IQuestionPoolService
    {
        QuestionPool Question_Pool_Add(QuestionPool x);

        QuestionPool QuestionPool_Delete(QuestionPool x);

        QuestionPool QuestionPool_Edit(QuestionPool x);

        List<QuestionPool> QuestionPool_Get_All();

        QuestionPool QuestionPool_Get_By_Id(QuestionPool x);

    }
    public class QuestionPoolService : IQuestionPoolService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public QuestionPoolService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public QuestionPool Question_Pool_Add(QuestionPool x)
        {
            _context.questionPools.Add(x);
            _context.SaveChanges();
            return x;
        }

        public QuestionPool QuestionPool_Delete(QuestionPool x)
        {
            var temp = _context.questionPools;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.questionPools.Remove(Değer);
            _context.SaveChanges();

            return Değer;


        }

        public QuestionPool QuestionPool_Edit(QuestionPool x)
        {
            var temp = _context.questionPools;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Pool_Name = x.Pool_Name;
            _context.SaveChanges();

            return Değer;
        }

        public List<QuestionPool> QuestionPool_Get_All()
        {
           var temp= ( from x in _context.questionPools
                        select x
           );
            return temp.ToList();

        }

        public QuestionPool QuestionPool_Get_By_Id(QuestionPool x)
        {
            var temp = ( from y in _context.questionPools
                        where y.Id == x.Id
                        select y
            ).FirstOrDefault();
            return temp;
        }
    }
}