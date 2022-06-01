using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

namespace WebApi.Models.Users
{
    public class RegisterRequest
    {
        [Key]
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }


        public string Password { get; set; }

        public string PasswordRety { get; set; }

        public string UserPhoto { get; set; }

        public Role Role { get; set; }
    }
}