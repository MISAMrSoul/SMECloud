using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Misa.SmeNetCore.Models;
using Misa.SmeNetCore.Models.AccountViewModels;
using Misa.SmeNetCore.Results;
using Misa.SmeNetCore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Cors;
using System.Net.Mail;

namespace Misa.SmeNetcore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;

        public UserManager<ApplicationUser> UserManager { get; private set; }

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var claims = new[]
                    {
                       new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                       new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                   };

                    var token = new JwtSecurityToken
                    (
                        issuer: _configuration["Token:Issuer"],
                        audience: _configuration["Token:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])),
                                SecurityAlgorithms.HmacSha256)
                    );

                    return Ok(new ServiceResult { Code = 200, Data = new { token = new JwtSecurityTokenHandler().WriteToken(token) }, Success = true });
                }
                else
                {
                    return Ok(new ServiceResult { Code = 400, Data = "Đăng nhập không thành công!", Success = false });
                }
            }
            else
            {
                return Ok(new ServiceResult { Code = 400, Data = ModelState, Success = false });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, PhoneNumber = model.PhoneNumber, FullName = model.FullName };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var claims = new[]
                    {
                       new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                       new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                   };

                    var token = new JwtSecurityToken
                    (
                        issuer: _configuration["Token:Issuer"],
                        audience: _configuration["Token:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])),
                                SecurityAlgorithms.HmacSha256)
                    );
                    // var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user, model.PhoneNumber);

                    // SmtpClient client = new SmtpClient();
                    // client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    // client.EnableSsl = true;
                    // client.Host = "smtp.gmail.com";
                    // client.Port = 587;

                    // // setup Smtp authentication
                    // System.Net.NetworkCredential credentials =
                    //     new System.Net.NetworkCredential("smedotnetteam@gmail.com", "12345678@Abc");
                    // client.UseDefaultCredentials = false;
                    // client.Credentials = credentials;

                    // MailMessage msg = new MailMessage();
                    // msg.From = new MailAddress("smedotnetteam@gmail.com");
                    // msg.To.Add(new MailAddress(model.Email));

                    // msg.Subject = "Công ty cổ phần Misa gửi mã xác nhận tài khoản";
                    // msg.IsBodyHtml = true;
                    // msg.Body = "Mã xác nhận là " + code;
                    
                    // client.Send(msg);

                    return Ok(new ServiceResult { Code = 200, Data = new { token = new JwtSecurityTokenHandler().WriteToken(token),email = user.Email, UserId = user.Id }, Success = true });
                }
                else
                {
                    return Ok(new ServiceResult { Code = 400, Data = "Tạo tài khoản không thành công!", Success = false });
                }
            }
            else
            {
                return Ok(new ServiceResult { Code = 400, Data = ModelState, Success = false });
            }

        }
    }
}
