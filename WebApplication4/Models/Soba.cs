using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace WebApplication4.Models
{
    public class Soba
    {
        [Key]
        public  int ID { get; set; }
        public string nazivSobe { get; set; }
        public double cijenaSobe { get; set; }

        public int brojOsoba { get; set; }
        public bool Rezervisana { get; set; } = false;


        
    }
}
