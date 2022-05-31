using System.ComponentModel.DataAnnotations;

namespace SPVWeb.Models
{
    public class Mountain
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       

        public List<Rentable> Rentables { get; set; } = new List<Rentable>(); 

        public int TrackCount { get; set; }


        public string Description { get; set; } = "";

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
