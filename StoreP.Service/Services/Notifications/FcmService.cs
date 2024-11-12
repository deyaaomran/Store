using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class FcmService
{
    private readonly string _serverKey = "BHFYLGJotLFWEGJiXrs5H7_ih-_RGrUsT1vxR-JsY5LDvEyQP83OkBU9UZcouPZeS9zRkUL_CdJCi9DV_FLj2Z0"; 
    private readonly string _fcmUrl = "https://fcm.googleapis.com/fcm/send";

    public async Task SendNotificationAsync(string deviceToken, string title, string body)
    {
        using var client = new HttpClient();

        client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"key={_serverKey}");

        var message = new
        {
            to = deviceToken,
            notification = new
            {
                title,
                body
            }
        };

        var jsonMessage = JsonConvert.SerializeObject(message);
        var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(_fcmUrl, content);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error sending notification");
        }
    }
}
