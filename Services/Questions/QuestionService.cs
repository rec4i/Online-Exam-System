using System;
using System.Collections.Generic;
using System.Linq;
using Kaynak_Kod.Entities.Questions;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Helpers;


namespace Kaynak_Kod.Services.Questions
{

    public interface IQuestionService
    {
        Question Question_Add(Question x);

        Question Question_Delete(Question x);

        Question Question_Edit(Question x);

        List<Question_Return_Value> Question_Get_All();

        Question_Return_Value Question_Get_By_Id(Question x);

        pagination_Request_Result<Question_Return_Value> Question_Get_With_Pagenation(pagenation_request x);
    }

    public class QuestionService : IQuestionService
    {

        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;
        public QuestionService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }
        public Question Question_Add(Question x)
        {
            _context.questions.Add(x);
            _context.SaveChanges();

            return x;
        }

        public Question Question_Delete(Question x)
        {
            var temp = _context.questions;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.questions.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Question Question_Edit(Question x)
        {
            var temp = _context.questions;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);

            Değer.Question_Text = x.Question_Text;
            Değer.True_Answer_Id = x.True_Answer_Id;
            Değer.Question_Pool_Id=x.Question_Pool_Id;
            _context.SaveChanges();

            return Değer;
        }

        public List<Question_Return_Value> Question_Get_All()
        {
            var temp = _context.questions;

            var Değer = (from x in temp

                         select new
                         {
                             x.Id,
                             x.Question_Text,
                             x.True_Answer_Id,
                         }
            );

            IEnumerable<Question_Return_Value> rd = Değer.Select(o => new Question_Return_Value
            {
                Id = o.Id,
                Question_Text = o.Question_Text,
                True_Answer_Id = o.True_Answer_Id,
                Answers = (from z in _context.answers
                           where z.Question_Id == o.Id
                           select z
                ).ToList()

            });

            return rd.ToList();
        }

        public Question_Return_Value Question_Get_By_Id(Question x)
        {
            var temp = _context.questions;

            var Değer = (from y in temp
                         select new
                         {
                             x.Id,
                             x.Question_Text,
                             x.True_Answer_Id,
                         }
            ).FirstOrDefault(o => o.Id == x.Id);

            Question_Return_Value rd = new Question_Return_Value
            {
                Id = Değer.Id,
                Question_Text = Değer.Question_Text,
                True_Answer_Id = Değer.True_Answer_Id,
                Answers = (from z in _context.answers
                           where z.Question_Id == Değer.Id
                           select z
              ).ToList()
            };

            return rd;
        }

        public pagination_Request_Result<Question_Return_Value> Question_Get_With_Pagenation(pagenation_request x)
        {

            var temp = _context.questions;

            var Değer = (from y in temp
                        where y.Question_Text.StartsWith(x.search)
                         select new
                         {
                             y.Id,
                             y.Question_Text,
                             y.True_Answer_Id,
                         }
            ).Skip(Convert.ToInt32(x.offset)).Take(Convert.ToInt32(x.limit)).ToList();

            IEnumerable<Question_Return_Value> rd = Değer.Select(o => new Question_Return_Value
            {
                Id = o.Id,
                Question_Text = o.Question_Text,
                True_Answer_Id = o.True_Answer_Id,
                Answers = (from z in _context.answers
                           where z.Question_Id == o.Id
                           select z
                ).ToList()

            });

            var Result = new pagination_Request_Result<Question_Return_Value>
            {
                rows = rd.ToList(),
                totalNotFiltered = temp.Count(),
                total = Değer.Count()
            };

            return Result;




        }
    }
}