using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kaynak_Kod.Entities.Questions
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string Question_Text { get; set; }

        public int True_Answer_Id { get; set; }

        public int Question_Pool_Id { get; set; }
        

    }

    public class Question_Return_Value
    {
        [Key]
        public int Id { get; set; }

        public string Question_Text { get; set; }

        public int True_Answer_Id { get; set; }

        public List<Answer> Answers { get; set; }

    }
    public class Question_Return_Value_Witout_True_Answer
    {
        [Key]
        public int Id { get; set; }

        public string Question_Text { get; set; }

        public int True_Answer_Id { get; set; }

        public List<Answer_Return_Value_Witouth_True> Answers { get; set; }

    }
    public class pagenation_request
    {
        public string offset { get; set; }
        public string search { get; set; }
        public string sort { get; set; }
        public string order { get; set; }
        public string limit { get; set; }

    }
    public class pagination_Request_Result<T>
    {
        public List<T> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
       
    }
}