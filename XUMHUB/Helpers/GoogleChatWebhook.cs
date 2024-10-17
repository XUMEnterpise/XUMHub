using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XUMHUB.Helpers
{
    public static class ChatHook
    {
        public static string GPCWebhook { get { return "Hook here"; } }
        public static string LaptopWebhook { get { return "Hook here"; } }
    }
    internal class GoogleChatWebhook
    {
        public async void SendWebhook(string message, string chatHook)
        {
            // Your Google Chat webhook URL
            string webhookUrl =chatHook;
            // Convert the message to JSON
            var chatMessage = new { text = message };
            string jsonMessage = JsonConvert.SerializeObject(chatMessage);

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
