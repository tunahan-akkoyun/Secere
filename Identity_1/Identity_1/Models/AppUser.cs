using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Identity_1.Models
{
    public class AppUser:IdentityUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LasttName { get; set; }
        public string FullName { get; set; }

        public byte[] ? ProfileImage { get; set; }
    }
}
