using System;
using System.ComponentModel.DataAnnotations;

namespace Kaynak_Kod.Entities.Exams
{
    public class ExamResult
    {

    }
    public class Exam_List
    {
        public int Id { get; set; }
        public string Exam_Connection_Id { get; set; }
        public DateTime Exam_Strat_Date { get; set; }
        public DateTime Exam_End_Date { get; set; }
        public int Exam_Question_Per_Second { get; set; }
        public int Exam_Number_Of_Questions { get; set; }

        public int Subs { get; set; }

    }

    public class Answer_Is_true_or_false
    {
        public int Answer_Id { get; set; }
        public int Answer_Is_True_OR_false { get; set; }
    }

    public class True_Answers
    {
        public int Answer_Id { get; set; }
    }
    public class False_Answers
    {
        public int Answer_Id { get; set; }
    }



    public class User_Answers_Sucsess_Rate
    {
        public string User_Guid { get; set; }
        public string User_Name { get; set; }
        public Number_of_True_And_False_Answers Answer_Rate { get; set; }
        public decimal Succses_Rate { get; set; }

    }

    public class Number_of_True_And_False_Answers
    {
        public int True_Answer { get; set; }
        public int False_Answer { get; set; }
    }

    public class Foo
    {
        public string exam { get; set; }
         public string user { get; set; }
       
    }


}