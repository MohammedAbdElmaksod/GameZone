using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter The Name")]
        public string Name { get; set; } = string.Empty;
    }
}
