using System.ComponentModel.DataAnnotations;

namespace AdminPanel.Models
{
    public class RoleFormViewModel
    {
        [Required(ErrorMessage ="Role Name is Required")]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
