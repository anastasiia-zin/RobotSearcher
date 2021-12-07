using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Services.Interfaces
{
    public interface IManufacturerService
    {
        public Task<ICollection<Manufacturer>> GetAllAsync();
        public Task<Manufacturer> AddAsync(Manufacturer manufacturer);
    }
}