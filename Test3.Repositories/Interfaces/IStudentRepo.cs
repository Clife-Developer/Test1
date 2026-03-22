using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DE = Test3.Data.Entities;


namespace Test3.Repositories.Interfaces
{
    public interface IStudentRepo
    {
        List<DE.Student> GetStudents();
        bool AddStudent(DE.Student student);
        bool DeleteStudent(int Id);
    }
}
