using System.ComponentModel.DataAnnotations;

namespace SPVWeb.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range (1, 100,ErrorMessage ="Lūdzu ievadiet braucēju skaitu no 1 līdz 100")]
        public int Brauceji { get; set; }
        [Required(ErrorMessage ="Lūdzu ievadiet savu vārdu")]
        public string Vards { get; set; }
        [Required(ErrorMessage = "Lūdzu ievadiet savu uzvārdu")]
        public string Uzvards { get; set; }
      
        [Required]
        public int MountainId { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.Date)]

        public DateTime ReservationDay { get; set; }

        public bool NeedHelmetRent  { get; set; }
        public bool NeedSkiiRent { get; set; }

    }
}
