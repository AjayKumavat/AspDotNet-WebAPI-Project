using Delete.Database.Infrastructure;
using Delete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delete.Database.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {

    }
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DeleteContext context) : base(context)
        {
        }
    }
}
