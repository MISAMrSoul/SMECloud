using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace Misa.SmeNetCore.Handlers
{
    public class AuthorizeJWT : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var jwt = context.HttpContext.Request.Headers["Authorization"];
            if(string.IsNullOrEmpty(jwt)) {
                context.Result = new OkObjectResult(new { Code = 401, Message = "Khong co token"});
                return;
            }
            var token = jwt.ToString().Split(" ")[1];
            
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] tokenByte = Convert.FromBase64String("");
            try
            {
                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MPtiXjyEYKZGrZlStGikGTPoHmSrlbmmcGHYVrbOcFxtXGtXjoVfSluDzEIsKkSxSUGRoxbNSuoUXLWBdtZqLEVqxBfBvRGqEeFs")),
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
            }
            catch (Exception ex)
            {
                context.Result = new OkObjectResult(new { Code = 401, Message = "Token loi ---" + ex.Message});
            }
        }
    }
}