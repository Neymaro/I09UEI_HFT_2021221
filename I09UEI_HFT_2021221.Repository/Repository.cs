using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace I09UEI_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public abstract T Get(int id);
        public abstract void Insert(T entity);
        public abstract void Delete(int id);
        public IQueryable<T> GetAll() => _context.Set<T>();
    }
}
