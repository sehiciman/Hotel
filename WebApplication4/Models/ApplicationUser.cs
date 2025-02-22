using Microsoft.AspNetCore.Identity;

namespace WebApplication4.Models
{
        public class ApplicationUser : IdentityUser
        {
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string KorisnickoIme { get; set; }
        }
    }


