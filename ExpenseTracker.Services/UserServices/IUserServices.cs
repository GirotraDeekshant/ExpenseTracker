
using ExpenseTracker.Business.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Services.UserServices
{
    public interface IUserServices
    {
        LoginDetails CheckLogin(string username, string password);
    }
}
