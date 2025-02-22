using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace WebApplication4.Models
{
    public class Ponuda
    {
        [Key]
        public int ID{ get; set; }
        public  string nazivPonude { get; set; }
        [ForeignKey ("Soba")] // obavijest
        public int sobaId { get; set; }
        public  Soba soba { get; set; }
        public  double novaCijena { get; set; }



       
    }
}
