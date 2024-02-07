using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MOM.BasicAuthentication.Authentication.Basic;

namespace MOM.BasicAuthentication.Authentication.Basic.Attributes
{
    public class BasicAuthorizationAttribute : AuthorizeAttribute
    {
        public BasicAuthorizationAttribute()
        {
            AuthenticationSchemes = BasicAuthenticationDefaults.AuthenticationScheme;
        }
    }
}
