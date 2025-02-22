using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication4.Models

{
    public class Rezervacija
    {
        
        [Key]
        public int ID { get; set; }

       

        [ForeignKey("Soba")]
        public int SobaId { get; set; }
        public Soba Soba { get; set; }

        public DateTime VrijemeDolaska { get; set; }
        public DateTime VrijemeOdlaska { get; set; }

    }

}

