using Microsoft.EntityFrameworkCore;
using Test3.Data.Entities;

namespace Test3.Data
{
    public class DataContext:DbContext
    {
        /// <summary>
        ///     I have created some mock data to be used
        ///     No need to connect to any database but all the DB configs have been done
        ///     If you wanna use the DB, you just need to add the connection strings
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }

        /// <summary>
        ///     returns list of sudents
        /// </summary>
        public List<Student> students { get; set; } = new List<Student>
        {
            new Student{Id = 1, Age = 23, Course = "Computer Science", Name = "Clife", Surname = "Mhlongo"},
            new Student{Id = 2, Age = 25, Course = "Information Technology", Name = "Brian", Surname = "Doe"},
            new Student { Id = 3, Age = 23, Course = "Computer Engineering", Name = "Vladmir", Surname = "Kozlov" },
            new Student { Id = 4, Age = 26, Course = "Industrial Engineering", Name = "John", Surname = "Khan" },
        };
    }
}
