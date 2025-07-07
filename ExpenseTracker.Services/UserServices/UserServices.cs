
using ExpenseTracker.Business.User;
using ExpenseTracker.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExpenseTracker.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private IUserRepository _userRepository = null;
        public UserServices(IUserRepository userRepository)
        { 
            _userRepository = userRepository;
        }
        public LoginDetails CheckLogin(string username, string password)
        {
            return _userRepository.CheckLogin(username, password);
        }
    }
}
