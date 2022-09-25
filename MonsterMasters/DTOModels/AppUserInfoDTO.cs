using Microsoft.AspNetCore.Identity;
using RegisterAndLoginApp.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace MonsterMasters.Api.DTOModels
{
    public class AppUserInfoDTO
    {
        [Required(ErrorMessage = "The ID is required")]
        public string ID { get; set; }
        [Required(ErrorMessage = "The user name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public static AppUserInfoDTO MakeDTO(IdentityUser user)
        {
            return new AppUserInfoDTO
            {
                ID = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
        }
        public static List<AppUserInfoDTO> MakeFromList(List<IdentityUser> users)
        {
            List<AppUserInfoDTO> dtos = new();
            foreach (var item in users)
            {
                dtos.Add(MakeDTO(item));
            }
            return dtos;
        }
    }
}
