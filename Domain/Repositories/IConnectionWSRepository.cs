using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IConnectionWSRepository
    {
        public Task Echo(ConnectionWS connection);
    }
}
