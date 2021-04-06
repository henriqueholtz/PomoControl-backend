using Microsoft.EntityFrameworkCore;
using PomoControl.Core;
using PomoControl.Core.Exceptions;
using PomoControl.Domain;
using PomoControl.Infraestructure.Context;
using PomoControl.Infraestructure.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PomoControl.Infraestructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly PomoContext _context;
        public UserRepository(PomoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ResponseDTO<User>> ChangeStatus(User user, bool active)
        {
            try
            {
                user.ChangeStatus(active);
                _context.Attach(user);
                _context.Entry(user).Property(x => x.Active).IsModified = true;
                await _context.SaveChangesAsync();
                return new ResponseDTO<User>(user, "The status is updated with success.", true); //Add record time here
            }
            catch(Exception ex)
            {
                throw new RepositoryException(ex.Message, ex);
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.Where(x => x.Email.ToLower().Equals(email.ToLower())).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
