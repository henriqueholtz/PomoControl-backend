using PomoControl.Core;
using PomoControl.Domain;
using System.Threading.Tasks;

namespace PomoControl.Infraestructure.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<ResponseDTO<User>> ChangeStatus(User user, bool active);
    }
}
