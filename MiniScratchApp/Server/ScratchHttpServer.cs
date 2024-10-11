using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniScratchApp.Server
{
    public class ScratchHttpServer
    {

        private HttpListener _listener;

        public ScratchHttpServer()
        {
            _listener = new HttpListener();
        }

        public async void Start(string url, TextBox textBoxIncomingRequests)
        {
            _listener.Prefixes.Add(url);  
            _listener.Start();
            Console.WriteLine("Server started. Listening for requests...");
            string result = await Task.Run(async () => await ListenLoop());
            textBoxIncomingRequests.Text += result;
            MessageBox.Show("Server is listening on port: " + url);
        }

        private async Task<string> ListenLoop()
        {
            while (_listener.IsListening)
            {
                try
                {
                    await Task.Delay(1000);

                    var context = await _listener.GetContextAsync();
                    Console.WriteLine("Received request...");
                    var request = context.Request;

                    // Extracting details from the request
                    string method = request.HttpMethod;
                    string url = request.Url.ToString();
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    // Send response
                    var response = context.Response;
                    var responseString = "Request received!";
                    var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    response.OutputStream.Close();

                    // Logging the incoming request with timestamp
                    string logEntry = $"{timestamp}: {method} request received at {url}" + Environment.NewLine;
                    return logEntry;
                }
                catch (HttpListenerException)
                {
                    // Listener was stopped, gracefully exit the loop
                    break;
                }
            }
            return "";
        }

        public void Stop()
        {
            _listener.Stop();
            Console.WriteLine("Server stopped.");
        }

        public void Close()
        {
            _listener.Close();
            Console.WriteLine("Server closed.");
        }
    }
}
