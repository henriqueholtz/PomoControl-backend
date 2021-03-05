using Microsoft.EntityFrameworkCore;
using PomoControl.Domain;
using PomoControl.Infraestructure.Context;
using PomoControl.Infraestructure.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PomoControl.Infraestructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly PomoContext _context;
        public UserRepository(PomoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.Where(x => x.Email.ToLower().Equals(email.ToLower())).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
