using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonsterMasters.Api.DTOModels;
using MonsterMasters.Data.Contracts.Monsters;
using RegisterAndLoginApp.Api.Models;

namespace MonsterMasters.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrbsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AuthenticationContext _dbContext;

        public OrbsController(UserManager<AppUser> userManager, AuthenticationContext context)
        {
            _userManager = userManager;
            _dbContext = context;
        }

        [HttpGet]
        [Authorize]
        public Task GetOrbs()
        {

        }

    }
}
