using Abp.Authorization.Users;
using Abp.Runtime.Session;
using Exchange.Core.Users;
using Exchange.Web.Models;
using Exchange.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Exchange.Web.Controllers
{
    public class UsersController : ApiController
    {
        private readonly UserManager _userManager;

        public UsersController(UserManager userManager, IAbpSession session)
        {            
            _userManager = userManager;
        }        

        [HttpPost]
        public async Task<string> Post(UserModel userModel)
        {           
            var loginResult = await _userManager.LoginAsync(userModel.UserName, userModel.Password);            

            if (loginResult.Result == AbpLoginResultType.Success)
            {
                var token = new Token(userModel.UserName, HttpContext.Current.Request.UserHostAddress);
                return token.Encrypt();
            }

            return loginResult.Result.ToString();
        }
    }
}