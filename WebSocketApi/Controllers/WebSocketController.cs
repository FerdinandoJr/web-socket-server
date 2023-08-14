using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text;
using WebSocketApi.Events;

namespace WebSocketsSample.Controllers;

#region snippet_Controller_Connect
public class WebSocketController : ControllerBase
{

    //public WebSocketController(ConnectionWSManager connectionManager)
    //{
    //    this._connectionManager = connectionManager;
    //}

    [Route("/ws")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

            string ipRemote = HttpContext.Connection.RemoteIpAddress != null ? HttpContext.Connection.RemoteIpAddress.ToString() : "0.0.0.0";

            // _connectionManager.CreateConnection(webSocket, ipRemote);

            Console.WriteLine("Connected: " + ipRemote);

            // await Echo(webSocket);

            await ProcessarWebSocketAsync(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
    public async Task Echo(WebSocket webSocket)
    {
        byte[] buffer = new byte[1024 * 4];

        try
        {
            WebSocketReceiveResult receiveResult;
            do
            {
                var segment = new ArraySegment<byte>(buffer);
                receiveResult = await webSocket.ReceiveAsync(segment, CancellationToken.None);

                if (receiveResult != null)
                {
                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(receiveResult.CloseStatus.Value, receiveResult.CloseStatusDescription, CancellationToken.None);
                        return;
                    }

                    var messageReceived = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
                    Console.WriteLine(messageReceived);

                    var responseMessage = "{\"name\":\"Servidor\",\"text\":\"Recebido\"}";
                    Console.WriteLine("Send: " + responseMessage);

                    var responseBytes = Encoding.UTF8.GetBytes(responseMessage);
                    var responseSegment = new ArraySegment<byte>(responseBytes);
                    await webSocket.SendAsync(responseSegment, WebSocketMessageType.Text, true, CancellationToken.None);

                    Array.Clear(buffer, 0, buffer.Length); // Limpa o buffer
                }
                else
                {
                    return; // ACONTECEU ALGUM ERRO 
                }

            }
            while (!receiveResult.CloseStatus.HasValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error handling WebSocket communication: " + ex.Message);
            throw;
        }
    }
    #endregion

    public async Task ProcessarWebSocketAsync(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];
        WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        while (!result.CloseStatus.HasValue)
        {
            string jsonString = Encoding.UTF8.GetString(buffer, 0, result.Count);

            // Criar a fábrica principal
            EventFactory factory = new EventFactory();

            // Usar a fábrica para executar o comando correspondente
            factory.Execute(jsonString);
            
            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        }
        await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
    }
}



