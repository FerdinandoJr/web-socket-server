using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ConnectionWSManager
    {
        private readonly List<ConnectionWS> _connections = new List<ConnectionWS>();

        public void AddConnection(ConnectionWS connection)
        {
            _connections.Add(connection);
        }

        public void RemoveConnection(ConnectionWS connection)
        {
            _connections.Remove(connection);
        }

        public List<ConnectionWS> GetAllConnections()
        {
            return _connections;
        }

        // Outros métodos conforme necessário
    }

}
