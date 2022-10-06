using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonsterMasters.Api.DTOModels;
using MonsterMasters.Data.Contracts.Monsters;
using MonsterMasters.Data.Contracts.Orbs;
using MonsterMasters.Data.Orbs;
using RegisterAndLoginApp.Api.Models;

namespace MonsterMasters.Api.Controllers
{
    [Route("[controller]")]
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
        public async Task<List<OrbDTO>> GetOrbs()
        {
            return OrbDTO.MakeFromList(_dbContext.Orb.Include(x=>x.Rates).ToList());
        }

        //[HttpPost]
        //public async Task SeedOrbs()
        //{
        //    if ((await _dbContext.Orb.ToListAsync()).Count == 0)
        //    {
        //        await _dbContext.AddRangeAsync(new Orb[]
        //        {
        //              new BasicOrb(),
        //              new RareOrb(),
        //              new LuckyOrb()
        //        });
        //        await _dbContext.SaveChangesAsync();
        //    }
        //}

    }
}
