using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using Test3.Data.Entities;
using Test3.Repositories.Interfaces;
using Test3.WebService.Controllers;

namespace Test3.UnitTests
{
    public class StudentControllerTest
    {
        private readonly Mock<IStudentRepo> _repo;
        private readonly Mock<ILogger<StudentController>> _logger;
        private readonly StudentController _controller;

        public StudentControllerTest()
        {
            _repo = new Mock<IStudentRepo>();
            _logger = new Mock<ILogger<StudentController>>();
            _controller = new StudentController(_repo.Object, _logger.Object);

        }
        [Fact]
        public void GetStudents_ReturnList_WhenExist()
        {
            var students = new List<Student>
            {
                new Student{Id = 1, Age = 23, Course = "Computer Science", Name = "Clife", Surname = "Mhlongo"},
                new Student{Id = 2, Age = 25, Course = "Information Technology", Name = "Brian", Surname = "Doe"},
                new Student { Id = 3, Age = 23, Course = "Computer Engineering", Name = "Vladmir", Surname = "Kozlov" },
                new Student { Id = 4, Age = 26, Course = "Industrial Engineering", Name = "John", Surname = "Khan" },
            };

            _repo.Setup(x => x.GetStudents()).Returns(students);

            var response = _controller.GetAllStudents();

            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Result);
            Assert.Equal(4, response.Result.Count);
        }

        [Fact]
        public void GetAllstudents_ReturnsFalse_WhenNoStudent()
        {
            _repo.Setup(x => x.GetStudents()).Returns(new List<Student>());

            var response = _controller.GetAllStudents();

            Assert.False(response.IsSuccess); 
            Assert.Null(response.Result);
            Assert.Contains("No Student Found", response.Messages);
        }

        [Fact]
        public void DeleteStudent_ReturnTrue_WhenStudentDeleted()
        {
            _repo.Setup(x=>x.DeleteStudent(2)).Returns(true);

            var response = _controller.DeleteStudent(2);

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public void DeleteStudent_ReturnFalse_WhenStudentNotFound()
        {
            _repo.Setup(x => x.DeleteStudent(8)).Returns(false);

            var response = _controller.DeleteStudent(8);

            Assert.False(response.IsSuccess);
        }

        [Fact]
        public void AddStudent_ReturnFalse_WhenStudentIsNull()
        {
            _repo.Setup(x => x.AddStudent(null));

            var response = _controller.AddStudent(null);

            Assert.False(response.IsSuccess);
            Assert.Contains("Invalid student parameter provided.", response.Messages);
        }
    }
}