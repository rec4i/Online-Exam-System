using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kaynak_Kod.Entities.Exams
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        public string Exam_Connection_Id { get; set; }
        public DateTime Exam_Strat_Date { get; set; }
        public DateTime Exam_End_Date { get; set; }
        public int Exam_Question_Per_Second { get; set; }
        public int Exam_Number_Of_Questions { get; set; }

        public int Question_Pool_Id { get; set; }


    }
}