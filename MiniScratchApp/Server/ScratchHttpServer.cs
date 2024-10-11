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

        public void Start(string url)
        {
            _listener.Prefixes.Add(url);  
            _listener.Start();
            Console.WriteLine("Server started. Listening for requests...");
            Task.Run(() => ListenLoop());
        }

        private async Task ListenLoop()
        {
            while (_listener.IsListening)
            {
                try
                {
                    var context = await _listener.GetContextAsync();
                    Console.WriteLine("Received request...");

                    // Process the request (e.g., read incoming body)
                    using (var reader = new StreamReader(context.Request.InputStream))
                    {
                        string body = reader.ReadToEnd();
                        Console.WriteLine($"Received body: {body}");
                    }

                    // Send response
                    var response = context.Response;
                    var responseString = "Hello from server!";
                    var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    response.OutputStream.Close();
                }
                catch (HttpListenerException)
                {
                    // Listener was stopped, gracefully exit the loop
                    break;
                }
            }
        }

        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
            Console.WriteLine("Server stopped.");
        }
    }
}
