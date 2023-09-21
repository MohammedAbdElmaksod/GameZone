using GameZone.Data;
using GameZone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ApplicationDbContext _context;

        public CategoryServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(Category category)
        {
            try
            {
                if (category == null) { throw new ArgumentNullException("category"); }
                await _context.AddAsync(category);
                _context.SaveChanges();
            }
            catch { }
        }

        public async Task DeleteCategory(int id)
        {
            try
            {
                var category = _context.TbCategory.Find(id);
                if (category != null)
                {
                    _context.TbCategory.Remove(category);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentNullException("category");
                }
            }
            catch { }
        }

        public List<SelectListItem> CategorySelectList()
        {
            try
            {
                var categories = _context.TbCategory
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .OrderBy(n=>n.Text)
                    .AsNoTracking()
                    .ToList();
                return categories;
            }
            catch { throw new InvalidOperationException(); }
        }

        public async Task<List<Category>> GetCategories()
        {
            try
            {
                var categories = new List<Category>();
                categories = await _context.TbCategory.ToListAsync();
                return categories;
            }
            catch { throw new InvalidOperationException(); }
        }

        public async Task<Category> GetCategoryById(int id)
        {
            try
            {
                var category = await _context.TbCategory.FindAsync(id);
                return category;
            }
            catch { throw new InvalidOperationException(); }
        }
        public async Task EditCategory(Category category)
        {
            try
            {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                await Task.FromResult(ex.Message);
            }
        }
    }
}
