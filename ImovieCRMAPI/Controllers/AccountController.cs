using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IMovieCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountServiceAsync accountServiceAsync;
        private readonly IConfiguration configuration;

        public AccountController(IAccountServiceAsync accountServiceAsync, IConfiguration cb)
        {
            this.accountServiceAsync = accountServiceAsync;
            this.configuration = cb;

        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUpAsync(SignUpModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await accountServiceAsync.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Usre has been created successfully " });
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in result.Errors)
            {
                sb.Append(item.Description);
            }
            return BadRequest(sb.ToString());
        }
        [HttpPost("login")]


  //           "email": "MMuser@example.com",
  //"password": "MMstring123."
   
        public async Task<IActionResult> Login(SignInModel model)
        {
            var result = await accountServiceAsync.LoginAsync(model);
            if (!result.Succeeded)
            {
                return Unauthorized(new { Message = "Invalid Username and password" });
            }
            //list of claims
            var authCalims = new List<Claim> {
                new Claim(ClaimTypes.Name,model.Email),
                 new Claim(ClaimTypes.Country,"USA"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
            //key

            var authKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudiene"],
                expires:DateTime.Now.AddDays(1),
                claims:authCalims,
                signingCredentials: new SigningCredentials(authKey,SecurityAlgorithms.HmacSha256Signature)
                );
            var t = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new {  t});
        }
    }
}
