using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.ApplicationCore.RepositoryInterface
{
    public interface IRepository<T> where T:class
    {
        int Insert(T entity);
        int Update(T entity);
        int Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
