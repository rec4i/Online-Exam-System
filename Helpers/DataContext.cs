using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

using Kaynak_Kod.Entities.Questions;
using Kaynak_Kod.Entities.Exams;
using Kaynak_Kod.Entities.ExamScreen;
using Kaynak_Kod.Controllers.QuestionsControllers;

namespace WebApi.Helpers
{

    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Eczane> eczanes { get; set; }
        public DbSet<City> cityies { get; set; }
        public DbSet<Town> towns { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Answer> answers { get; set; }

        public DbSet<User_Information> user_Informations { get; set; }

        public DbSet<Exam_Questions> exam_Questions { get; set; }

        public DbSet<Exam> exams { get; set; }
        public DbSet<User_Answers> User_Answers { get; set; }

        public DbSet<QuestionPool> questionPools { get; set; }
        //



        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public void Context(DbContext context_)
        {
            context_.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("ConnString"));


            // in memory database used for simplicity, change to a real db for production applications
            // options.UseInMemoryDatabase("TestDb");

        }

    }
}