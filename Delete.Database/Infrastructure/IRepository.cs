using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Delete.Database.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Add(List<T> entity);
        void Delete(T entity);
        void Update(T entity);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression);
        Task<T> GetDefault(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
    }
}
