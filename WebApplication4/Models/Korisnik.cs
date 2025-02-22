using WebApplication4.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace WebApplication4.Models
{
public class Korisnik
    {

        [Key]
        public int Id { get; set; } // Promijenite naziv iz KKKorisnikId u KorisnikId kako biste bili konzistentni s vašom bazom podataka.
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; } // Javne properties umjesto privatnih za EF.
        public string BrojTelefona { get; set; }  // Javne properties umjesto privatnih za EF.
        public string Password  { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
     

  


    }
}
