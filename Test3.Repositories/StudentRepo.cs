using Test3.Data;
using Test3.Data.Entities;
using Test3.Repositories.Interfaces;

namespace Test3.Repositories
{
    public class StudentRepo:IStudentRepo
    {
        public static DataContext dbContext;
        public StudentRepo(DataContext _context) 
        {
            dbContext = _context;
        }
        public List<Student> GetStudents()
        {
            var result = dbContext.students.ToList();
            return result;
        }
        public Student GetStudentById(int Id)
        {
            var result = dbContext.students.Where(st=>st.Id == Id).FirstOrDefault();
            return result;
        }
        public bool AddStudent(Student student)
        {
            dbContext.students.Add(student);
            return true;
        }
        public bool DeleteStudent(int Id)
        {
            var student = dbContext.students.Where(st => st.Id == Id).FirstOrDefault();
            if(student == null) 
                return false;
            dbContext.students.Remove(student);
            return true;
        }
    }
}
