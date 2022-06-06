using System.ComponentModel.DataAnnotations;

namespace SPVWeb.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Atcerēties mani")]
        public bool RememberMe { get; set; }
    }
}
