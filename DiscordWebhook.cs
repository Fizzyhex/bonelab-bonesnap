using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using Newtonsoft.Json;

using MelonLoader;

namespace BoneSnap
{
    internal static class DiscordWebhook
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task UploadText(string webhookUrl, string content)
        {
            // Create a new HttpClient instance
            using (HttpClient client = new HttpClient())
            {
                MultipartFormDataContent httpContent = new MultipartFormDataContent();

                // Create a JSON payload for the message
                var payload = new
                {
                    username = "Test",
                    content = content
                };
                var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
                var stringContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                httpContent.Add(stringContent, "payload_json");

                // Send the StringContent to the Discord webhook URL
                HttpResponseMessage response = await client.PostAsync(webhookUrl, httpContent);

                // Throw an exception if the response indicates an error
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
        }

        public static async void UploadImage(string webhookUrl, byte[] imageData)
        {
            // Set the content type header to multipart/form-data
            var multipartContent = new MultipartFormDataContent();
            multipartContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");

            // Add the image file to the multipart content
            var imageContent = new ByteArrayContent(imageData);
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");
            multipartContent.Add(imageContent, "file", "image.png");

            // Send the multipart content to the Discord webhook URL
            var response = await httpClient.PostAsync(webhookUrl, multipartContent);

            // Throw an exception if the response indicates an error
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to upload image to Discord webhook. Status code: {response.StatusCode}");
            }
        }
    }
}
