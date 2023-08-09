using System.Net.WebSockets;

namespace Domain.Entities
{
    public class ConnectionWS
    {
        public WebSocket WebSocket { get; }
        public string RemoteIpAddress { get; }

        public ConnectionWS(WebSocket webSocket, string remoteIpAddress)
        {
            WebSocket = webSocket;
            RemoteIpAddress = remoteIpAddress;
        }
    }
}
