using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MOM.BasicAuthentication.DTOs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MOM.BasicAuthentication.Authentication.Basic.Attributes
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missng Authorization Key"));

            }

            var authorizationHeader = Request.Headers["Authorization"].ToString();
            if (!authorizationHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            {
                if (!Request.Headers.ContainsKey("Authorization"))
                {
                    return Task.FromResult(AuthenticateResult.Fail("Authorization Header does not start whit 'Basic '"));

                }

            }
            var authBase64Decoded = Encoding.UTF8.GetString(
                Convert.FromBase64String(
                    authorizationHeader.Replace("Basic ", "",
                    StringComparison.OrdinalIgnoreCase
                ))
               );

            var authSplit = authBase64Decoded.Split(new[] { ':' }, 2);

            if (authSplit.Length != 2)
            {
                return Task.FromResult(AuthenticateResult.Fail("invalid Authorization header format"));
            }


            var clientId = authSplit[0];
            var clientSecret = authSplit[1];

            // --- START Using Soheil Api in order to validate users 
            //var restClient = new RestClient("http://sapwebservice.sapco.ir/validateuser/api/login");
            //var request = new RestRequest();
            //var AuthenticationInfo = new AuthenticationRequestDto()
            //{
            //    userName = clientId,
            //    password = clientSecret
            //};
            //request.AddJsonBody(AuthenticationInfo);
            //var response = restClient.Post(request);
            //var responseStatus = response.StatusCode;
            //var responseStatusCode = (int)responseStatus;
            // --- END Using Soheil Api in order to validate users
            
            if (!(clientId == "mom_ws" && clientSecret == "mom_ws")) //&& responseStatusCode == 200
            {

                return Task.FromResult(AuthenticateResult.Fail("UserName Or Password is incorrect"));

            }
            



            var client = new BasicAuthenticationClient
            {
                AuthenticationType = BasicAuthenticationDefaults.AuthenticationScheme,
                IsAuthenticated = true,
                Name = clientId
            };


            var ClaimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(client, new[]
            {
                new Claim(ClaimTypes.Name, clientId)
            }));

            return Task.FromResult(
                AuthenticateResult.Success(
                    new AuthenticationTicket(ClaimsPrincipal, Scheme.Name
                    )));


        }
    }
}
