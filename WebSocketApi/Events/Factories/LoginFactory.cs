using WebSocketApi.Events.Factories.DTOs;
using WebSocketApi.Events.Interfaces;

namespace WebSocketApi.Events.Factories
{
    public class LoginFactory : EventFactoryBase<LoginInputDTO>
    {
        public override void Execute(LoginInputDTO input)
        {
            Console.WriteLine("FAZENDO O LOGIN DO MALUKO!");
        }
    }
}
