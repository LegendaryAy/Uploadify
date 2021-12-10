using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uploadify.Data;
using Uploadify.Models;

namespace Uploadify.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
