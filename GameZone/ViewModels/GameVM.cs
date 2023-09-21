using GameZone.Models;
using GameZone.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
    public class GameVM : GameFormVM
    {
        [Required(ErrorMessage = "Please Choose Cover")]
        [ValidateExtension(AllowedExtensionsAndMaxSize.allowedExtensions),
           ValidateFileMaxSize(AllowedExtensionsAndMaxSize.allowedSizeByByte)]
        public IFormFile Cover { get; set; } = default!;
    }
}
