
    using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication4.Models
{
    public class Gost
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Korisnik")]
        public int KorisnikId { get; set; }  
        public Korisnik Korisnik { get; set; }

    }

}