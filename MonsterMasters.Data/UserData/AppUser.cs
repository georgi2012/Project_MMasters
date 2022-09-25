using Microsoft.AspNetCore.Identity;
using MonsterMasters.Data.Contracts.Monsters;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterAndLoginApp.Api.Models
{
    public class AppUser: IdentityUser
    {
        public List<Creature> Creatures { get; set; }
    }
}
