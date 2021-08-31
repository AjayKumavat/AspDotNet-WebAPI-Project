using Delete.Database;
using Delete.Database.Repository;
using Delete.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delete.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Student GetStudentById(int id);
        bool DeleteStudent(int id);
        Student UpdateStudent(Student student);
        Student AddStudent(Student student);
    }
    public class StudentService : IStudentService
    {
        private readonly DeleteContext _context;

        public StudentService(DeleteContext context)
        {
            _context = context;
        }

        public Student AddStudent(Student student)
        {
            _context.Students.FromSqlRaw("exec sp_InsertStudent @Name, @Age", student.Name, student.Age);
            _context.Add(student);
            _context.SaveChanges();
            return student;
        }

        public bool DeleteStudent(int id)
        {
            var student = GetStudentById(id);

            if (student != null)
            {
                _context
                    .Students
                    .FromSqlRaw("exec sp_DeleteStudent @Id", id)
                    .FirstOrDefault();
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public Student GetStudentById(int id)
        {
            SqlParameter studentId = new SqlParameter("@Id", id);

            return _context
                    .Students
                    .FromSqlRaw<Student>("exec sp_GetStudentById @Id", studentId)
                    .ToList()
                    .FirstOrDefault();
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _context.Students.FromSqlRaw("exec sp_GetStudents").ToListAsync();
        }

        public Student UpdateStudent(Student student)
        {
            _context.Students.FromSqlRaw("exec sp_UpdateStudent @Name, @Age", student.Name, student.Age);

            _context.SaveChanges();

            return student;
        }
    }
}
