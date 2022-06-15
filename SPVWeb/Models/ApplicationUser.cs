using Microsoft.AspNetCore.Identity;

namespace SPVWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List <Reservation> Reservations { get; set; } = new ();
    }
}
