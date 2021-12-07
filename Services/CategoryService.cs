using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using DbContext = Infrastructure.DbContext;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DbContext _context;

        public CategoryService(DbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _context.Categories.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Category> AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}