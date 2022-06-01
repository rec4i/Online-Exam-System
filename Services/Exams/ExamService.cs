using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaynak_Kod.Entities.Exams;
using Kaynak_Kod.Entities.Questions;
using Kaynak_Kod.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;

namespace Kaynak_Kod.Services.Exams
{
    public interface IExamService
    {
        Exam Exam_Add(Exam x);
        Exam Exam_Delete(Exam x);
        Exam Exam_Edit(Exam x);

        List<Exam> Exam_Get_All();

        Exam Exam_Gey_By_Id(Exam x);

        Exam Exam_Get_By_Guid(Exam x);

        pagination_Request_Result<Exam> Exam_Get_All_With_Pagination(pagenation_request x);

    }
    public class ExamService : IExamService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public ExamService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public Exam Exam_Add(Exam x)
        {
            Exam temp = new Exam
            {
                Exam_Connection_Id = Guid.NewGuid().ToString(),
                Exam_Strat_Date = x.Exam_Strat_Date,
                Exam_End_Date = x.Exam_End_Date,
                Exam_Question_Per_Second = x.Exam_Question_Per_Second,
                Exam_Number_Of_Questions = x.Exam_Number_Of_Questions,
                Question_Pool_Id=x.Question_Pool_Id
            };
            _context.exams.Add(temp);

            _context.SaveChanges();
            return temp;
        }

        public Exam Exam_Delete(Exam x)
        {
            var temp = _context.exams;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            _context.exams.Remove(Değer);
            _context.SaveChanges();

            return Değer;
        }

        public Exam Exam_Edit(Exam x)
        {
            var temp = _context.exams;
            var Değer = temp.FirstOrDefault(o => o.Id == x.Id);
            Değer.Exam_Connection_Id = x.Exam_Connection_Id;
            Değer.Exam_End_Date = x.Exam_End_Date;
            Değer.Exam_Number_Of_Questions = x.Exam_Number_Of_Questions;
            Değer.Exam_Question_Per_Second = x.Exam_Question_Per_Second;
            Değer.Exam_Strat_Date = x.Exam_Strat_Date;
            _context.SaveChanges();

            return Değer;
        }

        public List<Exam> Exam_Get_All()
        {
            return _context.exams.ToList();
        }

        public Exam Exam_Gey_By_Id(Exam x)
        {
            var temp = (from y in _context.exams
                        where y.Id == x.Id
                        select y
            ).First();
            return temp;
        }

        public Exam Exam_Get_By_Guid(Exam x)
        {
            var temp = (from y in _context.exams
                        where y.Exam_Connection_Id == x.Exam_Connection_Id
                        select y
           ).First();
            return temp;
        }

        public pagination_Request_Result<Exam> Exam_Get_All_With_Pagination(pagenation_request x)
        {
            var temp = _context.exams;

            var Değer = (from y in temp
                         //where y.Exam_Connection_Id.StartsWith(x.search)
                         select new
                         {
                             y.Id,
                             y.Exam_Connection_Id,
                             y.Exam_End_Date,
                             y.Exam_Number_Of_Questions,
                             y.Exam_Question_Per_Second,
                             y.Exam_Strat_Date,
                             
                         }
            ).Skip(Convert.ToInt32(x.offset)).Take(Convert.ToInt32(x.limit)).ToList();

            IEnumerable<Exam> rd = Değer.Select(o => new Exam
            {
                Id=o.Id,
                Exam_Connection_Id=o.Exam_Connection_Id,
                Exam_End_Date=o.Exam_End_Date,
                Exam_Number_Of_Questions=o.Exam_Number_Of_Questions,
                Exam_Question_Per_Second=o.Exam_Question_Per_Second,
                Exam_Strat_Date=o.Exam_Strat_Date
               
            });

            var Result = new pagination_Request_Result<Exam>
            {
                rows = rd.ToList(),
                totalNotFiltered = temp.Count(),
                total = Değer.Count()
            };

            return Result;




        }
    }
}