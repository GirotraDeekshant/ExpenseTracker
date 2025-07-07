using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Business.APIResponse
{
    public class APIResponse
    {
        public object Data { get; set; }
        public string Response { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public string jwt_token { get; set; }
    }
}
