using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniScratchApp.Client
{
    public class ScratchHttpClient
    {
        private readonly HttpClient _client;

        public ScratchHttpClient()
        {
            _client = new HttpClient();
        }

        public async Task SendRequest(string url, string messageBody, string httpHeaders)
        {
            using (var client = new HttpClient())
            {
                // TODO: fix this
                var method = "POST";

                // Create a new HTTP request with the method you specified (GET, POST, PUT, DELETE)
                var request = new HttpRequestMessage(new HttpMethod(method), url);

                // Додај HTTP headers
                foreach (var header in httpHeaders.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var splitHeader = header.Split(':');
                    if (splitHeader.Length == 2)
                    {
                        var headerKey = splitHeader[0].Trim();
                        var headerValue = splitHeader[1].Trim();
                        request.Headers.Add(headerKey, headerValue);
                    }
                }

                // Add content if the method is POST or PUT
                if (method == "POST" || method == "PUT")
                {
                    request.Content = new StringContent(messageBody, Encoding.UTF8, "application/json");
                }

                try
                {
                    // Send the request and show the response
                    var response = await client.SendAsync(request);
                    var responseText = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Response: {responseText}");
                }
                catch (Exception ex)
                {
                    // Прикажи грешка доколку настане некој проблем при праќање на барањето
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
