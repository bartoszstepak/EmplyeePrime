using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crud_2.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using crud_2.Services;
using crud_2.Controllers.BLL;

namespace crud_2.Controllers
{
    [Route("api/loginController")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ILoginBLL _loginBLL;
        private readonly IEmployeeBLL _employeeBLL;


        public LoginsController(ILoginBLL loginBLL, IEmployeeBLL employeeBLL)
        {
            _loginBLL = loginBLL;
            _employeeBLL = employeeBLL;
        }


        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]Login user)
        {
            if (user == null) {
                return BadRequest("Invalid client request");
            }

            if (_loginBLL.isValidUser(user))  {

                var employee = _employeeBLL.getEmplyeeByEmail(user.login);

                SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:49362",
                    audience: "http://localhost:4200",
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString, employee });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}