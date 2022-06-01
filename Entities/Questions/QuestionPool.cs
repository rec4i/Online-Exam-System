using System.ComponentModel.DataAnnotations;

namespace Kaynak_Kod.Controllers.QuestionsControllers
{
    public class QuestionPool
    {
        [Key]
        public int Id { get; set; }
        public string Pool_Name { get; set; }
        
    }
}