using Delete.Database.Infrastructure;
using Delete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delete.Database.Repository
{
    public interface IStudentRepository
    {

    }
    public class StudentRepository : IStudentRepository
    {
        private readonly DeleteContext _context;

        public StudentRepository(DeleteContext context)
        {
            _context = context;
        }
    }
}
