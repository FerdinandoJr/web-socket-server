using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class ConnectionWSRepository : IConnectionWSRepository
    {
        private List<ConnectionWS> listaDeConexoes = new List<ConnectionWS>();

        public List<ConnectionWS> GetAllConnections()
        {
            return listaDeConexoes;
        }

        public void AddConnection(ConnectionWS connection)
        {
            listaDeConexoes.Add(connection);
        }

        // Implemente outros métodos conforme necessário
    }
}
