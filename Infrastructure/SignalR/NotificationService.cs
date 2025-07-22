using Application.Dto;
using Application.Interfaces.NotificationInterface;
using Domain.Model;
using Infrastructure.SignalR;
using Microsoft.AspNetCore.SignalR;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _repository;
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationService(INotificationRepository repository, IHubContext<NotificationHub> hubContext)
    {
        _repository = repository;
        _hubContext = hubContext;
    }

    // ✅ Send notification to a specific user
    public async Task SendNotification(int recipientId, string title, string message)
    {
        var notification = new Notification
        {
            RecipientId = recipientId,
            Title = title,
            Message = message
        };

        await _repository.Add(notification);
        await _repository.SaveChanges();

        await _hubContext.Clients.User(recipientId.ToString())
            .SendAsync("ReceiveNotification", title, message);
    }

    // ✅ Send notification to all connected users
    public async Task SendNotificationToAll(string title, string message)
    {
        var notification = new Notification
        {
            RecipientId = 0, // Or -1 or NULL if not for a specific user
            Title = title,
            Message = message
        };

        await _repository.Add(notification);
        await _repository.SaveChanges();

        await _hubContext.Clients.All
            .SendAsync("ReceiveNotification", title, message);
    }

    public async Task<ICollection<NotificationDto>> GetUserNotifications(int userId)
    {
        var list = await _repository.GetByUserId(userId);

        return list.Select(n => new NotificationDto
        {
            Id = n.Id,
            RecipientId = n.RecipientId,
            Title = n.Title,
            Message = n.Message,
            CreatedAt = n.CreatedAt,

        }).ToList();
    }
}
