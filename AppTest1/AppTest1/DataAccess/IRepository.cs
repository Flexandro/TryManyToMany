using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTest1.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Get(int id);
        int Insert(T model);
        void Update(T model);
        void Delete(int id);
    }
}
