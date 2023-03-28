using CRUD_With_Angular.Database;
using CRUD_With_Angular.Interface;
using CRUD_With_Angular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace CRUD_With_Angular.Repo
{
    public class LoginService : ILogin
    {
        private readonly AppDbContext _context;

        private readonly IConfiguration _configuration;
        public LoginService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration; 
        }

        public async Task<Login> LoginAsync(Login loginDetail)
        {
            if (loginDetail != null)
            {
                var data = _context.tblLogin.Where(x => x.Email.Equals(loginDetail.Email) && x.Password.Equals(loginDetail.Password)).FirstOrDefault();

                if (data != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("EmpId", loginDetail.EmpId.ToString()),
                       // new Claim("DisplayName", loginDetail.FullName),
                        new Claim("FullName", loginDetail.FullName),
                        new Claim("Email", loginDetail.Email)
                    };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);


                    loginDetail.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return loginDetail;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
       
        }


    }
}
