using System.ComponentModel.DataAnnotations;

namespace SPVWeb.ViewModel
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        [Required(ErrorMessage = "Lomas vārds ir nepieciešams")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
