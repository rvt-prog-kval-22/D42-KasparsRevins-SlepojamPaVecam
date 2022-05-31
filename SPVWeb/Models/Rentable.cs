using System.ComponentModel.DataAnnotations;

namespace SPVWeb.Models
{
    public class Rentable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
    }
}
