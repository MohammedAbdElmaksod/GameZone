using GameZone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
    public interface ICategoryServices
    {
        Task AddCategory(Category category);
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task DeleteCategory(int id);
        List<SelectListItem> CategorySelectList();
        Task EditCategory(Category category);

    }
}
