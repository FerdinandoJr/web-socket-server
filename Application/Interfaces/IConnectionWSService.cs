using Domain.Entities;

namespace Application.Interfaces
{
    public interface IConnectionWSService
    {
        List<ConnectionWS> GetAllConnections();
        void AddConnection(ConnectionWS connection);
        // Outros métodos conforme necessário
    }
}
