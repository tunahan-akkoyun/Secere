using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class User
    {
        [Display(Name = "Id ")]
        [Required]
        public string Id { get; set; }
        [Display(Name = "User Name")]
        public string? userName { get; set; }
        [Display(Name = "normalizedUserName")]
        public string? normalizedUserName { get; set; }
        [Display(Name = "E-Mail :")]
        public string? Email { get; set; }
        [Display(Name = "normalizedEmail ")]

        public string? normalizedEmail { get; set; }
        [Display(Name = "EmailConfirmed ")]
        [Required]
        public bool EmailConfirmed { get; set; }
        [Display(Name = "PasswordHash ")]

        public string? PasswordHash { get; set; }
        [Display(Name = "SecurityStamp ")]

        public string? SecurityStamp { get; set; }

        [Display(Name = "ConcurrencyStamp ")]
        public string? ConcurrencyStamp { get; set; }
        [Display(Name = "PhoneNumber ")]

        public string? PhoneNumber { get; set; }
        [Required]
        [Display(Name = "PhoneNumberConfirmed ")]
        public bool PhoneNumberConfirmed { get; set; }
        [Display(Name = "TwoFactorEnabled ")]
        [Required]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = "LockoutEnd ")]
        public DateTimeOffset? LockoutEnd { get; set; }

        [Display(Name = "LockoutEnabled ")]
        [Required]

        public bool LockoutEnabled { get; set; }
        [Display(Name = "AccessFailedCount ")]

        [Required]

        public int AccessFailedCount { get; set; }




        [Display(Name = "FirstName ")]

        public string? FirstName { get; set; }

        [Display(Name = "LasttName ")]

        public string? LasttName { get; set; }
        [Display(Name = "ProfileImage ")]

        public byte[] ProfileImage { get; set; }
        [Display(Name = "FullName ")]

        public string? FullName { get; set; }


        public IList<Hayvan> hayvans { get; set; }


    }
}
