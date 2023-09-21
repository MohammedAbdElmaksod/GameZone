using GameZone.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
    public class GameFormVM
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "Please Enter Game Name")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        [Required(ErrorMessage = "Please Enter Game Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Devices")]
        public List<int> SelectedDevices { get; set; } = default!;

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
