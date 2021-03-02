using PomoControl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomoControl.Infraestructure.Interfaces
{
    interface IBaseRepository<T> where T : Base
    {
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int code);

        Task<List<T>> GetAll(T entity);
        Task<T> GetByCode(int code);
    }
}
