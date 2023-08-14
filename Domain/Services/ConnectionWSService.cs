using Domain.Entities;

namespace Domain.Services
{
    public class ConnectionWSService
    {
        private readonly List<ConnectionWS> _connections;

        public ConnectionWSService()
        {
            _connections = new List<ConnectionWS>();
        }

        public void AddConnection(ConnectionWS connection)
        {
            _connections.Add(connection);
        }

        public bool RemoveConnection(string id)
        {

           var connection = GetConnectionById(id);
            if (connection != null) {
                _connections.Remove(connection);

                return true;
            }

            return false;
            
        }

        public IEnumerable<ConnectionWS> GetAllConnections()
        {
            return _connections;
        }

        public ConnectionWS? GetConnectionById(string id)
        {
            var index = _connections.FindIndex(ws => ws.Id == id);
            
            if (index >= 0) {
                return _connections[index];
            }

            return null;    
        }
    }

}
