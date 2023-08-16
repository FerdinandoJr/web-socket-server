using WebSocketApi.Events.Factories.DTOs;
using WebSocketApi.Events.Interfaces;

namespace WebSocketApi.Events.Factories
{
    public class LogoutFactory : EventFactoryBase<LogoutInputDTO>
    {
        public override void Execute(LogoutInputDTO input)
        {
            Console.WriteLine("SAINDO DA VIDA!");
        }
    }
}
