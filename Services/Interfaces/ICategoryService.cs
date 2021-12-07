using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<ICollection<Category>> GetAllAsync();
        
        public Task<Category> AddAsync(Category category);
        public Task<Category> UpdateAsync(Category category);
    }
}