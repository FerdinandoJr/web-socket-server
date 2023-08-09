using System.Net.WebSockets;
using System.Text;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebSocketsSample.Controllers;

#region snippet_Controller_Connect
public class WebSocketController : ControllerBase
{

    protected readonly ConnectionWSManager _connectionManager;

    public WebSocketController(ConnectionWSManager connectionManager)
    {
        this._connectionManager = connectionManager;
    }


    [Route("/connections")]
    public IActionResult GetConnections()
    {
        var connections = _connectionManager.GetAllConnections(); // Obter conexões usando sua lógica de gerenciamento
        return Ok(connections);
    }


    [Route("/ws")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

            string ipRemote = HttpContext.Connection.RemoteIpAddress != null ? HttpContext.Connection.RemoteIpAddress.ToString() : "0.0.0.0";

            var connectionWS = new ConnectionWS(webSocket, ipRemote);
            _connectionManager.AddConnection(connectionWS);

            Console.WriteLine("New connection: " + ipRemote);
            await Echo(webSocket);

            _connectionManager.RemoveConnection(connectionWS);
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
        var receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!receiveResult.CloseStatus.HasValue)
        {
            receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None
            );

            Console.WriteLine(Encoding.UTF8.GetString(buffer));

            var message = "{\"name\":\"Servidor\",\"text\":\"Recebido\"}";

            Console.WriteLine("Send: " + message);

            var bytes = Encoding.Default.GetBytes(message);
            var arraySegment = new ArraySegment<byte>(bytes);
            await webSocket.SendAsync(
                arraySegment,
                WebSocketMessageType.Text,
                true,
                CancellationToken.None
            );

        }

        await webSocket.CloseAsync(
            receiveResult.CloseStatus.Value,
            receiveResult.CloseStatusDescription,
            CancellationToken.None
        );
    }
}
