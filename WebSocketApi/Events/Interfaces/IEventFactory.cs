using WebSocketApi.Events.Interfaces;

namespace WebSocketApi.Events.Interfaces
{
    public interface IEventFactory
    {
        void Execute(string jsonString);
    }
}