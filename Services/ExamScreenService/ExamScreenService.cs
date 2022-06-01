using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaynak_Kod.Entities.Exams;
using Kaynak_Kod.Entities.ExamScreen;
using Kaynak_Kod.Entities.Questions;
using Kaynak_Kod.Models.Users;
using Kaynak_Kod.Services.Exams;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;

namespace Kaynak_Kod.Services.ExamScreenService
{
    public interface IExamScreenService
    {
        User_Information Create_Exam_User_Informaiton(User_Information x);

        User_Information Get_User_Information_By_Id(User_Information x);


        List<Question_Return_Value> Create_Random_Exam_Questions(User_Information x);

        List<Question> Get_All_Questions_By_User_Id(User_Information x);

        Exam Exam_Get_By_Guid(Exam x);

        void Add_User_Answers(User_Answers x);





    }

    public class ExamScreenService : IExamScreenService
    {



        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public ExamScreenService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public User_Information Create_Exam_User_Informaiton(User_Information x)
        {
            var temp = new User_Information
            {
                Guid = Guid.NewGuid().ToString(),
                Exam_Guid = x.Exam_Guid,
                User_Name = x.User_Name
            };
            _context.user_Informations.Add(temp);
            _context.SaveChanges();
            return temp;
        }
        public User_Information Get_User_Information_By_Id(User_Information x)
        {
            return _context.user_Informations.FirstOrDefault(o => o.Id == x.Id);

        }


        public List<Question_Return_Value> Create_Random_Exam_Questions(User_Information x)
        {

            var temp = _context.questions;

            var Değer = (from y in temp
                        where y.Question_Pool_Id== _context.exams.FirstOrDefault(o=> o.Exam_Connection_Id==x.Exam_Guid).Question_Pool_Id
                         select new
                         {
                             y.Id,
                             y.Question_Text,
                             y.True_Answer_Id,
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


            List<Question_Return_Value> Random_questions = new List<Question_Return_Value>();

            Random rnd = new Random();

            var Exam_Information = _context.exams.FirstOrDefault(o => o.Exam_Connection_Id == x.Exam_Guid);

            int For_loop = Exam_Information.Exam_Number_Of_Questions;

            for (int i = 0; i < For_loop; i++)
            {
                var Rnd_ques = rd.Skip(rnd.Next(rd.Count())).Take(1).FirstOrDefault();

                if (Random_questions.FirstOrDefault(o => o.Id == Rnd_ques.Id) == null)
                {


                    var Rnd_Answers = Rnd_ques.Answers;
                    int ü = Rnd_Answers.Count();


                    List<Answer> Rnd_Answers_New = new List<Answer>();
                    for (int j = 0; j < Rnd_ques.Answers.Count(); j++)
                    {
                        var Rnd_Answer = Rnd_Answers.Skip(rnd.Next(Rnd_Answers.Count())).Take(1).FirstOrDefault();
                        if (Rnd_Answers_New.FirstOrDefault(o => o.Id == Rnd_Answer.Id) == null)
                        {
                            Rnd_Answers_New.Add(Rnd_Answer);
                        }
                        else
                        {
                            j--;
                        }

                    }
                    Random_questions.Add(new Question_Return_Value
                    {
                        Id = Rnd_ques.Id,
                        Question_Text = Rnd_ques.Question_Text,
                        Answers = Rnd_Answers_New
                    });

                }
                else
                {
                    i--;
                }

            }


            return Random_questions;



        }

        public List<Question> Get_All_Questions_By_User_Id(User_Information x)
        {
            throw new NotImplementedException();
        }

        public Exam Exam_Get_By_Guid(Exam x)
        {
            var Exam_Information = _context.exams.FirstOrDefault(o => o.Exam_Connection_Id == x.Exam_Connection_Id);
            return Exam_Information;
        }

        public void Add_User_Answers(User_Answers x)
        {
            _context.User_Answers.Add(x);
            _context.SaveChanges();

        }
    }
}