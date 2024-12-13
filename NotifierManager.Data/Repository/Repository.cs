using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NotifierManager.Data.Context;

namespace NotifierManager.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly NotifierDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(NotifierDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
