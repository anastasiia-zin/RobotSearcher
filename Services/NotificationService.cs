using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using DbContext = Infrastructure.DbContext;

namespace Services
{
    public class NotificationService : INotificationService
    {
        private readonly DbContext _context;

        public NotificationService(DbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Notification>> GetAllAsync(string userId)
        {
            return await _context.Notifications
                .Include(x => x.AppUserNotifications)
               // .Where(x => x.AppUserNotifications.Any(y => y.UserId == userId))
                .OrderBy(x => x.Added)
                .ToListAsync();
        }

        public async Task<Notification> AddAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
            return notification;
        }
    }
}