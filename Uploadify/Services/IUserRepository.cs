using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uploadify.Models;

namespace Uploadify.Services
{
    public interface IUserRepository
    {
        User CreateUser(User user);
    }
}
