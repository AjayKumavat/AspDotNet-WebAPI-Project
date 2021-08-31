using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Delete.Database.Infrastructure
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DeleteContext Context { get; set; }
        public Repository(DeleteContext context)
        {
            Context = context;
        }


        #region CRUD Implementation
        public virtual void Add(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public virtual void Add(List<T> entity)
        {
            Context.AddRange(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public virtual async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetDefault(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.Set<T>().Update(entity);
            Context.SaveChanges();

        }
        #endregion
    }
}
