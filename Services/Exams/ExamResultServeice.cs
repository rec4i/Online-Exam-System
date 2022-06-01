using System;
using System.Collections.Generic;
using System.Linq;
using Kaynak_Kod.Entities.Exams;
using Kaynak_Kod.Entities.ExamScreen;
using Kaynak_Kod.Entities.Questions;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Helpers;

namespace Kaynak_Kod.Services.Exams
{
    public interface IExamResultService
    {
        pagination_Request_Result<Exam_List> Get_All_Exam_List_With_Pagination(pagenation_request x);

        List<User_Answers_Sucsess_Rate> Get_By_Exam_Guid_Exam_Resutls(Exam x);

    }
    public class ExamResultService : IExamResultService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public ExamResultService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public pagination_Request_Result<Exam_List> Get_All_Exam_List_With_Pagination(pagenation_request y)
        {
            var temp_ = _context.exams;
            var temp = (from x in _context.exams
                        select new
                        {
                            x.Exam_Connection_Id,
                            x.Exam_End_Date,
                            x.Exam_Number_Of_Questions,
                            x.Exam_Question_Per_Second,
                            x.Exam_Strat_Date,
                            x.Id,
                        }
            ).Skip(Convert.ToInt32(y.offset)).Take(Convert.ToInt32(y.limit)).ToList();

            IEnumerable<Exam_List> rd = temp.Select(o => new Exam_List
            {
                Exam_Connection_Id = o.Exam_Connection_Id,
                Exam_End_Date = o.Exam_End_Date,
                Exam_Number_Of_Questions = o.Exam_Number_Of_Questions,
                Exam_Question_Per_Second = o.Exam_Question_Per_Second,
                Exam_Strat_Date = o.Exam_Strat_Date,
                Id = o.Id,
                Subs = Get_Subs_Number(o.Exam_Connection_Id)
            });

            var Result = new pagination_Request_Result<Exam_List>
            {
                rows = rd.ToList(),
                totalNotFiltered = temp_.Count(),
                total = temp.Count()
            };

            return Result;

        }
        public int Get_Subs_Number(string x)
        {
            int z = (from ü in _context.user_Informations
                     where ü.Exam_Guid == x
                     select ü
            ).Count();
            return z;
        }
        public List<User_Answers_Sucsess_Rate> Get_By_Exam_Guid_Exam_Resutls(Exam x)
        {

            var Exam_Informationm=(from y in _context.exams
                                   where y.Id==x.Id
                                   select y
            ).FirstOrDefault(); 


            var exam_Users = (from y in _context.user_Informations
                              where y.Exam_Guid == Exam_Informationm.Exam_Connection_Id
                              select new
                              {
                                  y.Exam_Guid,
                                  y.Id,
                                  y.Guid,
                                  y.User_Name
                              }
            );

            IEnumerable<User_Information> temp_rd= exam_Users.Select(o=> new User_Information{
                Exam_Guid=o.Exam_Guid,
                Id=o.Id,
                Guid = o.Guid,
                User_Name=o.User_Name
            });


            List<User_Answers_Sucsess_Rate> rd = new List<User_Answers_Sucsess_Rate>();

            foreach (var item in temp_rd)
            {
                User_Answers_Sucsess_Rate result = new User_Answers_Sucsess_Rate
                {
                    Answer_Rate = new Number_of_True_And_False_Answers
                    {
                        True_Answer = Answer_Is_True(item.Guid, item.Exam_Guid).True_Answer,
                        False_Answer = Answer_Is_False(item.Guid, item.Exam_Guid)
                    },
                    User_Name = item.User_Name,
                    User_Guid = item.Guid,
                    Succses_Rate = Calculate_Sucsess_rate(Answer_Is_True(item.Guid, item.Exam_Guid).True_Answer, Answer_Is_False(item.Guid, item.Exam_Guid), item.Exam_Guid)

                };

                rd.Add(result);
            }






            return rd.ToList();




        }

        public decimal Calculate_Sucsess_rate(int True_Answers_, int False_Answers, string Exam_Guid)
        {

            int Exam_Number_Of_Question = (from x in _context.exams
                                           where x.Exam_Connection_Id == Exam_Guid
                                           select x
            ).FirstOrDefault().Exam_Number_Of_Questions;

            decimal Result = 100*(Convert.ToDecimal(True_Answers_) /  Convert.ToDecimal(Exam_Number_Of_Question));

            return Result;

        }
        public Number_of_True_And_False_Answers Answer_Is_True(string User_Guid, string Exam_Guid)
        {
            var temp = (from x in _context.User_Answers
                        join Answer_ in _context.answers
                        on x.Answer_Id equals Answer_.Id
                        where x.User_Guid == User_Guid && x.Exam_Guid == Exam_Guid && Answer_.Is_True == 1
                        select
                        new
                        {
                            Answer_.Answer_Text,
                            Answer_.Is_True,
                        }
            );

            IEnumerable<User_Answers> rd = temp.Select(o => new User_Answers
            {
                Answer_Id = o.Is_True,
            });

            var rd_ = new Number_of_True_And_False_Answers
            {
                True_Answer = rd.ToList().Count()
            };

            return rd_;
        }
        public int Answer_Is_False(string User_Guid, string Exam_Guid)
        {
            var temp = (from x in _context.User_Answers
                        join Answer_ in _context.answers
                        on x.Answer_Id equals Answer_.Id
                        where x.User_Guid == User_Guid && x.Exam_Guid == Exam_Guid && Answer_.Is_True == 0
                        select
                        new
                        {
                            Answer_.Answer_Text,
                            Answer_.Is_True,
                        }
             );

            IEnumerable<User_Answers> rd = temp.Select(o => new User_Answers
            {
                Answer_Id = o.Is_True,
            });



            return rd.ToList().Count();

        }





    }
}