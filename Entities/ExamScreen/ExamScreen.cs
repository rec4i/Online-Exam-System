using System.ComponentModel.DataAnnotations;

namespace Kaynak_Kod.Entities.ExamScreen
{
    public class ExamScreen
    {


    }
    public class Exam_Questions
    {
        [Key]
        public int Id { get; set; }
        public string User_Guid { get; set; }
        public int Question_Id { get; set; }
        public string Exam_Guid { get; set; }

    }

    public class User_Information
    {
        [Key]
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Exam_Guid { get; set; }
        public string User_Name { get; set; }
    }
    public class User_Answers
    {
        [Key]
        public int Id { get; set; }
        public string Exam_Guid { get; set; }
        public string User_Guid { get; set; }
        public int Question_Id { get; set; }
        public int Answer_Id { get; set; }
    }

}