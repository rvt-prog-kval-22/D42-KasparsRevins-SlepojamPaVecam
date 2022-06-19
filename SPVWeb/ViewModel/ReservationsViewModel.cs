using SPVWeb.Models;

namespace SPVWeb.ViewModel
{
    public class ReservationsViewModel
    {
        public string Name { get; set; }
        public int Brauceji { get; set; }

        public DateTime ReservationDay { get; set; }

        public decimal TotalCost { get; set; }
    }
}
