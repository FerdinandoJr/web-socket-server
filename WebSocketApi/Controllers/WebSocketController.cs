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
        var connections = _connectionManager.GetConnections(); // Obter conexões usando sua lógica de gerenciamento
        return Ok(connections);
    }


    [Route("/ws")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

            string ipRemote = HttpContext.Connection.RemoteIpAddress != null ? HttpContext.Connection.RemoteIpAddress.ToString() : "0.0.0.0";
            
            _connectionManager.CreateConnection(webSocket, ipRemote);
        
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
    #endregion
}
