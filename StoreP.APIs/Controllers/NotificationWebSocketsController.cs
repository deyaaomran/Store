using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StoreP.Service.Services.Notifications.WebSockets;


namespace StoreP.APIs.Controllers
{
    public class NotificationWebSocketsController : BaseApiController
    {
        
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationWebSocketsController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] NotificationRequestHub request)
        {
            if (string.IsNullOrEmpty(request.Message))
            {
                return BadRequest("The message field is required.");
            }

            await _hubContext.Clients.All.SendAsync("ReceiveNotification", request.Message);
             return Ok("Notification sent to all connected clients");
        }
    }
}
