using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YEB.Data;
using YEB.Entity;

namespace YEB.Repository.Impl
{
    public class UserRepositoryImpl : BaseRepositoryImpl, IUserRepository
    {
        private readonly Context _context;
        public UserRepositoryImpl(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<int> CheckUsername(User user)
        {
            try
            {
                return await _context.User
                    .Where(u => u.Username == user.Username)
                    .CountAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Login(User user)
        {
            try
            {
                return await _context.User
                    .Where(u => u.Username == user.Username && u.Password == user.Password)
                    .CountAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
