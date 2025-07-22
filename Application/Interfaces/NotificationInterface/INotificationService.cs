using Application.Dto;

public interface INotificationService
{
    Task SendNotification(int recipientId, string title, string message);
    Task SendNotificationToAll(string title, string message);
    Task<ICollection<NotificationDto>> GetUserNotifications(int userId);
}
