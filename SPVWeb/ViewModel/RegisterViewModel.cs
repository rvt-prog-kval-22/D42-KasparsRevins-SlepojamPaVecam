using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SPVWeb.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Paroles nesakrīt.")]
        public string ConfirmPassword { get; set; }
    }
}
