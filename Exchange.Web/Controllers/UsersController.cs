using Abp.Authorization.Users;
using Abp.Runtime.Session;
using Exchange.Core.Users;
using Exchange.Web.Models;
using Exchange.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Exchange.Web.Controllers
{
    public class UsersController : ApiController
    {
        private readonly UserManager _userManager;

        public UsersController(UserManager userManager)
        {
            _userManager = userManager;            
        }

        [HttpPost]
        public async Task<UserAuthenticationResponse> Post(UserModel userModel)
        {
            var user = await _userManager.FindByNameOrEmailAsync(userModel.UserName);
            if (user == null)
            {
                return new UserAuthenticationResponse
                {
                    Succeded = false,
                    Message = AbpLoginResultType.InvalidUserNameOrEmailAddress.ToString()
                };
            }

            if (!user.IsEmailConfirmed)
            {
                return new UserAuthenticationResponse
                {
                    Succeded = false,
                    Message = AbpLoginResultType.UserEmailIsNotConfirmed.ToString()
                };
            }

            if (!user.IsActive)
            {
                return new UserAuthenticationResponse
                {
                    Succeded = false,
                    Message = AbpLoginResultType.UserIsNotActive.ToString()
                };
            }

            var authenticated = await _userManager.CheckPasswordAsync(user, userModel.Password);
            if (!authenticated)
            {
                return new UserAuthenticationResponse
                {
                    Succeded = false,
                    Message = AbpLoginResultType.InvalidPassword.ToString()
                };
            }



            var token = new Token(userModel.UserName, HttpContext.Current.Request.UserHostAddress);
            return new UserAuthenticationResponse
            {
                Succeded = true,
                Message = AbpLoginResultType.Success.ToString(),
                Token = token.Encrypt()
            };
        }
    }
}