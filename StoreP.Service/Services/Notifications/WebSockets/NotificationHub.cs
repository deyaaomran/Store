using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using StoreP.Core.Entities;
using Newtonsoft.Json;


namespace StoreP.Service.Services.Notifications.WebSockets
{
    public class NotificationHub : Hub
    {
     
        public async Task SendNotification(string message)
        {
            
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
