using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Kaynak_Kod.Entities.Questions
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public int Question_Id { get; set; }
        [JsonIgnore]
        public int Is_True { get; set; }

        public string Answer_Text { get; set; }
    }

    public class Answer_Return_Value_Witouth_True
    {

        public int Id { get; set; }
        public int Question_Id { get; set; }

        public string Answer_Text { get; set; }

        [JsonIgnore]
        public int Is_True { get; set; }


        public Question Question { get; set; }
    }
    public class Answer_Return_Value
    {

        public int Id { get; set; }
        public int Question_Id { get; set; }

        public string Answer_Text { get; set; }

        [JsonIgnore]
        public int Is_True { get; set; }


        public Question Question { get; set; }
    }
}