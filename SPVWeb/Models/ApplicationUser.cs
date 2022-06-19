using Microsoft.AspNetCore.Identity;

namespace SPVWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Mountain> Mountains { get; set; } = new();
    }
}
