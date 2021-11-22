using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I09UEI_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        T ListOne(int id);

        IQueryable<T> ListAll();

        void AddOne(T obj);

        void Delete(int id);

    }
}
