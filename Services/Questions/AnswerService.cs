using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaynak_Kod.Entities.Questions;
using Kaynak_Kod.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;


namespace Kaynak_Kod.Services.Questions
{
    public interface IAnswerService
    {
        Answer Answer_Add(Answer x);
        Answer Answer_Delete(Answer x);

        Answer Answer_Edit(Answer x);

        List<Answer_Return_Value> Answer_Get_All();

        Answer_Return_Value Answer_Get_By_Id(Answer x);

        List<Answer_Return_Value> Answer_Get_By_Question_Id(Question x);


        void Answer_Delete_By_Question_Id(Answer x);


    }
    public class AnswerService : IAnswerService
    {

        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public AnswerService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }
        public Answer Answer_Add(Answer x)
        {
            _context.answers.Add(x);
            _context.SaveChanges();
            return x;
        }

        public Answer Answer_Delete(Answer x)
        {
            var temp = _context.answers;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.answers.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Answer Answer_Edit(Answer x)
        {
            
            var temp = _context.answers;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Answer_Text = x.Answer_Text;
            Değer.Is_True = x.Is_True;
            _context.SaveChanges();

            return Değer;
        }

        public List<Answer_Return_Value> Answer_Get_All()
        {
            var temp = _context.answers;

            var Değer = (from x in temp
                         join Question_ in _context.questions
                         on x.Question_Id equals Question_.Id
                         select new
                         {
                             x.Answer_Text,
                             x.Id,
                             x.Is_True,
                             x.Question_Id,
                             Question_

                         }
            );

            IEnumerable<Answer_Return_Value> rd = Değer.Select(o => new Answer_Return_Value
            {
                Answer_Text = o.Answer_Text,
                Id = o.Id,
                Is_True = o.Is_True,
                Question_Id = o.Question_Id,
                Question = o.Question_
            });
            return rd.ToList();
        }

        public Answer_Return_Value Answer_Get_By_Id(Answer x)
        {
            var temp = _context.answers;

            var Değer = (from y in temp
                         join Question_ in _context.questions
                         on y.Question_Id equals Question_.Id
                         select new
                         {
                             y.Answer_Text,
                             y.Id,
                             y.Is_True,
                             y.Question_Id,
                             Question_

                         }
            ).FirstOrDefault(o => o.Id == x.Id);

            Answer_Return_Value rd = new Answer_Return_Value
            {
                Answer_Text = Değer.Answer_Text,
                Id = Değer.Id,
                Is_True = Değer.Is_True,
                Question_Id = Değer.Question_Id,
                Question = Değer.Question_
            };
            return rd;
        }

        public List<Answer_Return_Value> Answer_Get_By_Question_Id(Question x)
        {
            var temp = _context.answers;

            var Değer = (from y in temp
                         join Question_ in _context.questions
                         on y.Question_Id equals Question_.Id
                         where y.Question_Id == x.Id
                         select new
                         {
                             y.Answer_Text,
                             y.Id,
                             y.Question_Id,
                             y.Is_True,
                             Question_

                         }
            );

            IEnumerable<Answer_Return_Value> rd = Değer.Select(o => new Answer_Return_Value
            {
                Answer_Text = o.Answer_Text,
                Id = o.Id,
                Is_True = o.Is_True,
                Question_Id = o.Question_Id,
                Question = o.Question_
            });
            return rd.ToList();

        }

        public void Answer_Delete_By_Question_Id(Answer x)
        {
            var temp = _context.answers;
            var Değer = temp.FirstOrDefault(o => o.Question_Id == x.Question_Id);
            _context.answers.Remove(Değer);
            _context.SaveChanges();
        }
    }
}