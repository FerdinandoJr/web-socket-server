using System.Net.WebSockets;

namespace Domain.Entities
{
    public class ConnectionWS
    {
        public string Id { get; }
        public WebSocket WebSocket { get; }
        public string RemoteIpAddress { get; }

        public ConnectionWS(string id, WebSocket webSocket, string remoteIpAddress)
        {
            Id = id;
            WebSocket = webSocket;
            RemoteIpAddress = remoteIpAddress;
        }

        public ConnectionWS()
        {
        }
    }
}
