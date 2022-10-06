using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RegisterAndLoginApp.Api.DTO;
using RegisterAndLoginApp.Api.Models;
using System;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using MonsterMasters.Data.Contracts.Monsters;
using MonsterMasters.Data.Monsters.Orcs;

namespace RegisterAndLoginApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private AppSettings _appSettings;

        public AppUserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Register")]
        //POST AppUser/Register
        public async Task<object> PostAppUser(AppUserDTO model)
        {
            var role = model.UserName.ToLower().Contains("admin") ? "Admin" : "Customer";
            var appUser = new AppUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            try
            {
                var result = await _userManager.CreateAsync(appUser, model.Password);
                await _userManager.AddToRoleAsync(appUser, role);
                //
                var newUser =await _userManager.FindByNameAsync(model.UserName);
                string newUserId = newUser.Id;
                var Creatures = new List<Creature>
                {
                    new OrcArcher(newUserId),
                    new OrcSlasher(newUserId),
                    new OrcSpellcaster(newUserId),
                    new OrcWolfRider(newUserId)
                };
                newUser.Creatures = Creatures;
                await _userManager.UpdateAsync(newUser);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        //Post: AppUser/Login
        public async Task<IActionResult> Login(LoginDTO model)
        {
            //check if there is such user
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var key = Encoding.UTF8.GetBytes(_appSettings.JWTSecret);
                //Get role
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim(options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(45),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });

            }
            else
            {
                return BadRequest(new
                {
                    message = "Username or password is incorrect."
                });
            }
        }
    }
}
