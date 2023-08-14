using WebSocketsSample.Controllers;

namespace WebSocketApi.Controllers
{
    public class EventoCadastrarComando
    {
        private readonly EventoCadastrar _evento;

        public EventoCadastrarComando(EventoCadastrar evento)
        {
            _evento = evento;
        }

        public async Task ExecutarAsync()
        {
            // Lógica de cadastro
            // Você pode usar _evento.Nome, _evento.Email, etc., para acessar os dados do evento
        }
    }
}
