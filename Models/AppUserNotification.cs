namespace Models
{
    public class AppUserNotification : BaseEntity
    {
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public Notification Notification { get; set; }
        public string NotificationId { get; set; }
    }
}