using System.ComponentModel.DataAnnotations;

namespace BulkyBookModels.Models
{
    public class CoverType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cover Type")]
        public string Name { get; set; }
    }
}
