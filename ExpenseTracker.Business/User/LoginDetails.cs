using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Business.User
{
    public class LoginDetails
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string RoleId { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
    }
}
