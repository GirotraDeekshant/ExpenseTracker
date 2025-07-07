
using ExpenseTracker.Business.APIResponse;
using ExpenseTracker.Model;
using ExpenseTracker.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using static ExpenseTracker.Business.APIResponse.Utility;


namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserController> _log;
        private readonly JwtHelper _JwtHelper;
        private readonly IUserServices _UserService = null;
        APIResponse result = null;
        public UserController(IConfiguration configuration, ILogger<UserController> log, JwtHelper jwtHelper, IUserServices userService)
        {
            _configuration = configuration;
            log = _log;
            _JwtHelper = jwtHelper;
            _UserService = userService;
            this.result = result;
        }

        [HttpPost]
        public APIResponse Login(string username, string password)
        {
            try
            {
                var dt = _UserService.CheckLogin(username, password);
                if (dt != null)
                {
                    result = new APIResponse()
                    {
                        Data = dt,
                        Response = CommonActions.UserDoesNotExists.ToString(),
                        Message = Messages.UserDoesNotExists().ToString(),
                        Status = false,
                    };
                }
            }
            catch (Exception ex) { 
                //Common.Logger.InfoError(ex.Message);
            }
            return result;
        }
        public APIResponse Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                Response.Cookies.Delete("AccessToken");
                result = new APIResponse()
                {
                    Data = null,
                    Response = CommonActions.Successful.ToString(),
                    Message = Messages.Logout().ToString(),
                    Status = true,
                };
            }
            catch (Exception ex)
            {
                result = new APIResponse()
                {
                    Data = null,
                    Response = CommonActions.Error.ToString(),
                    Message = ex.InnerException.ToString(),
                    Status = false,
                };
            }
            return result;
        }
    }
}
