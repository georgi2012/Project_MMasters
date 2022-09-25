using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonsterMasters.Api.DTOModels;
using MonsterMasters.Data.Contracts.Monsters;
using RegisterAndLoginApp.Api.Models;

namespace RegisterAndLoginApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AuthenticationContext _dbContext;

        public UserProfileController(UserManager<AppUser> userManager, AuthenticationContext context)
        {
            _userManager = userManager;
            _dbContext = context;
        }

        [HttpGet]
        [Authorize]
        //get : /UserProfile
        public async Task<object> GetUserProfile()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest(new
                {
                    message = "Invalid user token."
                });
            }
            return new
            {
                // FullName = user.FullName,
                Email = user.Email,
                user.UserName
            };
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("GetUsers")]
        public List<AppUserInfoDTO> GetUsers()
        {
            return AppUserInfoDTO.MakeFromList(_dbContext.Users.ToList());

        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("RemoveUser")]
        public async Task<IActionResult> RemoveUser([FromBody]string ID)
        {
            var user = await _userManager.FindByIdAsync(ID);
            if (user == null)
            {
                return BadRequest(new
                {
                    message = "Could not find user with such ID."
                });
            }
            var res = await _userManager.DeleteAsync(user);
            if (!res.Succeeded)
            {
                string errors="";
                foreach(var error in res.Errors)
                {
                    errors += error.Description+";";
                }
                return BadRequest(new
                {
                    message = "Could not remove user:" + errors
                });
            }
            return Ok(res);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("EditUser")]
        public async Task<IActionResult> EditUser([FromBody] AppUserInfoDTO dto)
        {
            var user = await _userManager.FindByIdAsync(dto.ID);
            if (user == null)
            {
                return BadRequest(new
                {
                    message = "Could not find user with such ID."
                });
            }

            user.Email = dto.Email;
            user.UserName = dto.UserName;
            var res = await _userManager.UpdateAsync(user);
            //var res = await _userManager.DeleteAsync(user);
            if (!res.Succeeded)
            {
                string errors = "";
                foreach (var error in res.Errors)
                {
                    errors += error.Description + ";";
                }
                return BadRequest(new
                {
                    message = "Could not change user:" + errors
                });
            }
            return Ok(res);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Customer")]
        [Route("GetCreatures")]
        public async Task<object> GetCreatures()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest(new
                {
                    message = "Invalid user token."
                });
            }
            var userCreatures = _dbContext.Creatures.ToList().FindAll(x => x.userId == userId);
            return CreatureDTO.MakeFromList(userCreatures);
        }
    }
}
