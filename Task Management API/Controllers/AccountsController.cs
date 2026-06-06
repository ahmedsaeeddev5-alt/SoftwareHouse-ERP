using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Task_Management_API.Data.Dtos;
using Task_Management_API.Data.Models;

namespace Task_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountsController : ControllerBase
    {
        public AccountsController(UserManager<AppUser> userManager, IConfiguration configuration)
        {

            _userManager = userManager;
            this.configuration = configuration;
        }

        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration configuration;

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterNewUser([FromBody] dtoNewUser user)
        {
            if (ModelState.IsValid)
            {
                AppUser appuser = new()
                {
                    UserName = user.userName,
                    Email = user.email,

                };
                IdentityResult result = await _userManager.CreateAsync(appuser, user.password);
                if (result.Succeeded)
                {
                    return Ok("success");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(dtoLogin Login)
        {
            if (ModelState.IsValid)
            {
                AppUser? user = await _userManager.FindByNameAsync(Login.userName);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, Login.password))
                    {
                        // Add Custom Claims first (create payload) and add Roles If you're using Identity roles
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        var roles = await _userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                        }


                        //(SigningCredentials)
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
                        var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        //Generate the JWT Token that contains (claims , SigningCredentials)
                        var token = new JwtSecurityToken(
                            claims: claims,
                            issuer: configuration["JWT:Issuer"],
                            audience: configuration["JWT:Audience"],
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: sc
                            );
                        var _token = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,

                        };
                        return Ok(_token);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "UserName is invalid");
                }

            }
            return BadRequest(ModelState);
        }

    }
}
