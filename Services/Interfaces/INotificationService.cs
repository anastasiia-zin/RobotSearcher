using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Services.Interfaces
{
    public interface INotificationService
    {
        public Task<ICollection<Notification>> GetAllAsync(string userId);
        public Task<Notification> AddAsync(Notification notification);
    }
}