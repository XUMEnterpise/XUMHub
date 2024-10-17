using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XUMHUB.Helpers
{
    internal class GoogleChatWebhook
    {
        private async void SendWebhook(string message)
        {
            // Your Google Chat webhook URL
            string webhookUrl = "https://chat.googleapis.com/v1/spaces/AAAAR68v7q0/messages?key=AIzaSyDdI0hCZtE6vySjMm-WEfRq3CPzqKqqsHI&token=We8ujTSOnWwTFhxjvLZLkbuvJtxwebxmz7Z837jQRek";
            // Convert the message to JSON
            string jsonMessage = JsonConvert.SerializeObject(message);

            using (HttpClient client = new HttpClient())
            {
                // Set up the request content
                var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

                // Send the message via POST request
                HttpResponseMessage response = await client.PostAsync(webhookUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Message sent successfully!");
                }
                else
                {
                    Console.WriteLine($"Error sending message: {response.StatusCode}");
                }

            }
        }
    }
}
