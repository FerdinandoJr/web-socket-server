using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IConnectionWSRepository
    {
        List<ConnectionWS> GetAllConnections();
        void AddConnection(ConnectionWS connection);
        // Outros métodos conforme necessário
    }
}
