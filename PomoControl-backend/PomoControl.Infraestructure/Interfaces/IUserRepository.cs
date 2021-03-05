using PomoControl.Domain;
using System.Threading.Tasks;

namespace PomoControl.Infraestructure.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
