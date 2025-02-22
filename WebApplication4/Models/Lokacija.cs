using System.ComponentModel.DataAnnotations;
using System.Data;
namespace WebApplication4.Models
{
    public class Lokacija
    {
        [Key] //da li ide i ovdje
        public int ID { get; set; }
        public string nazivLokacije { get; set; }
        public  string adresa { get; set; }
        public string  Koordinate { get; set; } //treba ovdje string pa se u indexl razdvojiti na long i magn

        
    }
}