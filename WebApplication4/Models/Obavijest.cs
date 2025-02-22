using System.ComponentModel.DataAnnotations;
using System.Data;
namespace WebApplication4.Models
{
    public class Obavijest
    {
        [Key]
        public int ID { get; set; }
        public string poruka { get; set; }


}
}
