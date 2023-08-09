using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ConnectionWSService : IConnectionWSService
    {
        private readonly IConnectionWSRepository _repository;

        public ConnectionWSService(IConnectionWSRepository repository)
        {
            _repository = repository;
        }

        public List<ConnectionWS> GetAllConnections()
        {
            return _repository.GetAllConnections();
        }

        public void AddConnection(ConnectionWS connection)
        {
            _repository.AddConnection(connection);
        }

        // Implemente outros métodos conforme necessário
    }

}
