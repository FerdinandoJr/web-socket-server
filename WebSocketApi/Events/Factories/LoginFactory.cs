using WebSocketApi.Events.Interfaces;

namespace WebSocketApi.Events.Factories
{
    public class LoginFactory : IEventFactory
    {
        public void Execute(string jsonString)
        {
            Console.WriteLine("FAZENDO LOGIN DO MALUKO");
        }
    }
}
