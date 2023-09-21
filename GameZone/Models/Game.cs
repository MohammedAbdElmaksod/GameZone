using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Game : BaseModel
    {
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(100)]
        public string CoverName { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; } = default!;
        public virtual ICollection<GameDevice>? Devices { get; set; } = new List<GameDevice>();

    }
}
