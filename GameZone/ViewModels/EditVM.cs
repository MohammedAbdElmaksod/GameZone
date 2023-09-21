using GameZone.Validation;

namespace GameZone.ViewModels
{
    public class EditVM : GameFormVM
    {
       
        [ValidateExtension(AllowedExtensionsAndMaxSize.allowedExtensions),
           ValidateFileMaxSize(AllowedExtensionsAndMaxSize.allowedSizeByByte)]
        public IFormFile? Cover { get; set; } 
        public string? CurrentCover { get; set; } = string.Empty;
    }
}
