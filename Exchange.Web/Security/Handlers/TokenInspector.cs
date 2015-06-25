using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Exchange.Web.Helpers;
using Exchange.Core.Users;
using Castle.Windsor;
using System.Web.Http;
using System.Security.Principal;
using System.Security.Claims;

namespace Exchange.Web.Security
{
    public class TokenInspector : DelegatingHandler
    {
        private readonly UserManager _userManager;

        public TokenInspector(UserManager userManager)
        {
            _userManager = userManager;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            const string TOKEN_NAME = "X-Token";
            User user = null;

            if (request.Headers.Contains(TOKEN_NAME))
            {
                string encryptedToken = request.Headers.GetValues(TOKEN_NAME).First();
                try
                {
                    Token token = Token.Decrypt(encryptedToken);                                        
                    user = await _userManager.FindByNameOrEmailAsync(token.UserId);
                    bool isValidUserId = user != null && user.IsActive;                    
                    bool requestIPMatchesTokenIP = token.IP.Equals(request.GetClientIP());
                    

                    if (!isValidUserId || !requestIPMatchesTokenIP)
                    {
                        HttpResponseMessage reply = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid identity or client machine.");
                        return reply;
                    }
                }
                catch (Exception ex)
                {
                    HttpResponseMessage reply = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid token.");
                    return reply;
                }
            }
            else
            {
                HttpResponseMessage reply = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Request is missing authorization token.");
                return reply;
            }

            IIdentity identity = await _userManager.CreateIdentityAsync(user, "Windows");
            Thread.CurrentPrincipal = new ClaimsPrincipal(identity);            
            return await base.SendAsync(request, cancellationToken);
        }

    }
}