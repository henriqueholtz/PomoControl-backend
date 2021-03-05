using PomoControl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomoControl.Infraestructure.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int code);

        Task<List<T>> GetAll();
        Task<T> GetByCode(int code);
    }
}
