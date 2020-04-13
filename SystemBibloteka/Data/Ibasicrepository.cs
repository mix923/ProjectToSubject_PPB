using System.Collections.Generic;
using System.Threading.Tasks;

namespace SystemBibloteka.Data
{
    public interface Ibasicrepository<T> where T : class, Ibasicentity
    {
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
    }
}
