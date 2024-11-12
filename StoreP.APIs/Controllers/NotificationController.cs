using Microsoft.AspNetCore.Mvc;
using StoreP.Service.Services.Notifications;

namespace StoreP.APIs.Controllers
{
    public class NotificationController : BaseApiController
    {
        private readonly FcmService _fcmService;

        public NotificationController( FcmService fcmService)
        {
            _fcmService = fcmService;
        }

        [HttpPost("send")]

        public async Task<IActionResult> SendNotification([FromBody] NotificationRequest request)
        {
            try
            {
                await _fcmService.SendNotificationAsync(request.DeviceToken, request.Title, request.Body);
                return Ok("Notification sent successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error: {ex.Message}");
            }

        }
    }
}
