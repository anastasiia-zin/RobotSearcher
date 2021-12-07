using System;
using System.Collections.Generic;

namespace Requests.Notification
{
    public class UpdateNotificationsRequest
    {
        public ICollection<UpdateNotificationRequest> UpdatedNotifications { get; set; }
    }

    public class UpdateNotificationRequest
    {
        public string NotificationId { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public DateTime Added { get; set; }
        public bool IsRead { get; set; }
    }
}