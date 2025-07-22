using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        /// <summary>
        /// Send notification to a specific user.
        /// </summary>
        [Authorize(Roles = "Admin,Coordinator")]

        [HttpPost("send-to-user")]
        public async Task<IActionResult> SendToUser([FromQuery] int userId, [FromQuery] string title, [FromQuery] string message)
        {
            await _notificationService.SendNotification(userId, title, message);
            return Ok($"Notification sent to user {userId}");
        }

        /// <summary>
        /// Broadcast notification to all connected users.
        /// </summary>
        [Authorize(Roles = "Admin,Coordinator")]

        [HttpPost("send-to-all")]
        public async Task<IActionResult> SendToAll([FromQuery] string title, [FromQuery] string message)
        {
            await _notificationService.SendNotificationToAll(title, message);
            return Ok("Notification sent to all users.");
        }

        /// <summary>
        /// Get all notifications for a specific user.
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserNotifications(int userId)
        {
            var notifications = await _notificationService.GetUserNotifications(userId);
            return Ok(notifications);
        }
    }
}
