using System.ComponentModel.DataAnnotations;

namespace SPVWeb.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
