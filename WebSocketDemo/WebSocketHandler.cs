using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketDemo
{
    public class WebSocketHandler
    {
        public async Task Handlemessages(HttpContext context, WebSocket webSocket)
        {
            try
            {


                var buffer = new byte[1024 * 4];
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), System.Threading.CancellationToken.None);
                if (result != null)
                {
                    while (!result.CloseStatus.HasValue)
                    {
                        var msg = Encoding.UTF8.GetString(new ArraySegment<byte>(buffer, 0, result.Count));
                        FileLogger.SaveHl7ToFile("BloodGas", msg);
                        await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, System.Threading.CancellationToken.None);


                    }
                }
                await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, System.Threading.CancellationToken.None);

            }
            catch (Exception ex)
            {
                FileLogger.FileWorkerLogToFile("WebSocketLog", ex.Message + Environment.NewLine);
            }
        }

    }
}
