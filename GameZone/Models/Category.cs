namespace GameZone.Models
{
    public class Category : BaseModel
    {
        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
