using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace InformaSpexBanner.Services
{
    public class IpRestrictionMiddleware
    {

        public readonly RequestDelegate Next;
        public readonly IpSecuritySettings IpSecuritySettings;

        public IpRestrictionMiddleware(RequestDelegate next, IOptions<IpSecuritySettings> ipSecuritySettings)
        {
            Next = next;
            IpSecuritySettings = ipSecuritySettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            //var ipAddress = (string)context.Connection.RemoteIpAddress?.ToString();
            var adminHash = (string)context.Request.Query["adminhash"].ToString();
            var requestURI = (string)context.Request.Path;
            var adminCookie = (string)context.Request.Cookies["adminhash"];

            if(requestURI.ToLower().Contains("admin"))
            {
                if (!string.IsNullOrEmpty(adminCookie))
                {
                    if (!IpSecuritySettings.AdminHash.Equals(adminCookie))
                    {
                        Console.WriteLine("Cookie does not match|{0}",adminCookie);
                        context.Response.StatusCode = 403;
                        return;
                    }
                }
                else if (!string.IsNullOrEmpty(adminHash) && IpSecuritySettings.AdminHash.Equals(adminHash))
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(1);

                    context.Response.OnStarting(state=>{
                        var httpcontext = (HttpContext)state;
                        httpcontext.Response.Cookies.Append("adminhash", adminHash);
                        return Task.FromResult(0);
                    }, context);

                }
                else{
                    Console.WriteLine("Hash is empty or does not match|{0}",adminHash);
                    context.Response.StatusCode = 403;
                    return;
                }

            }

            await Next(context);

        }
    }
}
