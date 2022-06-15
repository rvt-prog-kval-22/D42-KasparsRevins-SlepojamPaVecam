using System.ComponentModel.DataAnnotations;

namespace SPVWeb.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Brauceji { get; set; }
      
        public string UserId { get; set; } = "";
        [Required]
        public int MountainId { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.Date)]

        public DateTime ReservationDay { get; set; }
    }
}
