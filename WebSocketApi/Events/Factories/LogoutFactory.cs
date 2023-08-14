using WebSocketApi.Events.Interfaces;

namespace WebSocketApi.Events.Factories
{
    public class LogoutFactory : IEventFactory
    {
        public void Execute(string jsonString)
        {
            Console.WriteLine("SAINDO DA VIDA!");
        }
    }
}
