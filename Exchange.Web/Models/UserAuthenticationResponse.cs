using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exchange.Web.Models
{
    public class UserAuthenticationResponse
    {
        public bool Succeded { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}