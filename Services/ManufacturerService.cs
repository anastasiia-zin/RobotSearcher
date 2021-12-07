using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using DbContext = Infrastructure.DbContext;

namespace Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly DbContext _context;

        public ManufacturerService(DbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Manufacturer>> GetAllAsync()
        {
            return await _context.Manufacturers.OrderBy(x => x.Name).ToListAsync();
        }

        public Task<Manufacturer> AddAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Manufacturer> AddAsync(Manufacturer category)
        {
            await _context.Manufacturers.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}