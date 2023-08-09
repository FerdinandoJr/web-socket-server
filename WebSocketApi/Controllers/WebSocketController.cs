using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace WebSocketsSample.Controllers;

#region snippet_Controller_Connect
public class WebSocketController : ControllerBase
{



    [Route("/ws")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

            Console.WriteLine("New connection: " + HttpContext.Connection.RemoteIpAddress);
            await Echo(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
    #endregion

    private static async Task Echo(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];
        var receiveResult = await webSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!receiveResult.CloseStatus.HasValue)
        {

            await webSocket.SendAsync(
                new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                WebSocketMessageType.Text,
                receiveResult.EndOfMessage,
                CancellationToken.None
            );

            receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None
            );

            Console.WriteLine("Send: " + webSocket);

        }

        await webSocket.CloseAsync(
            receiveResult.CloseStatus.Value,
            receiveResult.CloseStatusDescription,
            CancellationToken.None
        );
    }

    //private async Task SendMessageToSockets(string message)
    //{
    //    IEnumerable<SocketConnection> toSentTo;

    //    lock (websocketConnections)
    //    {
    //        toSentTo = websocketConnections.ToList();
    //    }

    //    var tasks = toSentTo.Select(async websocketConnection =>
    //    {
    //        var bytes = Encoding.Default.GetBytes(message);
    //        var arraySegment = new ArraySegment<byte>(bytes);
    //        await websocketConnection.WebSocket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
    //    });
    //    await Task.WhenAll(tasks);
    //}
}
