using Application.Use_Cases;
using Domain.Entities;
using System.Net.WebSockets;

namespace Infrastructure
{
    public class ConnectionWSManager
    {
        CreateConnectionUseCase CreateConnectionUseCase;
        GetConnectionsUseCase GetConnectionsUseCase;

        public ConnectionWSManager(CreateConnectionUseCase createConnectionUseCase, GetConnectionsUseCase getConnectionsUseCase)
        {
            CreateConnectionUseCase = createConnectionUseCase;  
            GetConnectionsUseCase = getConnectionsUseCase; 
        }
        
        public void CreateConnection(WebSocket webSocket, String ipRemote)
        {
            CreateConnectionUseCase.Execute(webSocket, ipRemote);
        }

        public IEnumerable<ConnectionWS> GetConnections()
        {
            return GetConnectionsUseCase.Execute();
        }

    }

}
