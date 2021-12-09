using System.Linq;

namespace I09UEI_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        IQueryable<T> GetAll();

        void Insert(T obj);

        void Delete(int id);
    }
}
