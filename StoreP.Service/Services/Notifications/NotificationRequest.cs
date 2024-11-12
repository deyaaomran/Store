using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreP.Service.Services.Notifications
{
    public class NotificationRequest
    {
        public string DeviceToken { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
