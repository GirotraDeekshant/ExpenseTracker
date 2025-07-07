
using ExpenseTracker.Business.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Repository.UserRepository
{
    public interface IUserRepository
    {
        LoginDetails CheckLogin(string username, string password);
    }
}
