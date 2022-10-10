using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonsterMasters.Api.DTOModels;
using MonsterMasters.Core.Orbs;
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
        private readonly IOrbOpener _orbOpener;

        public OrbsController(UserManager<AppUser> userManager, AuthenticationContext context, IOrbOpener orbOpener)
        {
            _userManager = userManager;
            _dbContext = context;
            _orbOpener = orbOpener;
        }

        [HttpGet]
        [Authorize]
        public async Task<List<OrbDTO>> GetOrbs()
        {
            return OrbDTO.MakeFromList(_dbContext.Orb.Include(x=>x.Rates).ToList());
        }

        [HttpPost]
        [Authorize]
        [Route("BuyOrb")]
        public async Task<ActionResult<CreatureDTO>> BuyOrb(OrbDTO orbDTO)
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
            if(true)//check user money
            {
                //remove money

                var orb = _dbContext.Orb.Include(x=>x.Rates).ToListAsync().Result.Find(x => x.Name == orbDTO.Name);
                if(orb == null)
                {
                    return BadRequest(new
                    {
                        message = "Invalid orb pick."
                    });
                }
                var creatureDrop =await _orbOpener.GetCreatureFromOrb(orb);
                return Ok(CreatureDTO.MakeDTO(creatureDrop));

            }
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
