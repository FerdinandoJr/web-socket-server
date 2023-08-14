using System.Text.Json;
using WebSocketsSample.Controllers;

namespace WebSocketApi.Controllers
{
    public class EventoComandoFactory
    {
        public IEventoComando CriarComando(string jsonString)
        {
            var eventoBase = JsonSerializer.Deserialize<EventoBase>(jsonString);
            switch (eventoBase.EventType)
            {
                case "login":
                    var eventoLogin = JsonSerializer.Deserialize<EventoLogin>(jsonString);
                    return new EventoLoginComando(eventoLogin);
                case "cadastrar":
                    var eventoCadastrar = JsonSerializer.Deserialize<EventoCadastrar>(jsonString);
                    return new EventoCadastrarComando(eventoCadastrar);
                // Outros casos para diferentes tipos de eventos
                default:
                    throw new InvalidOperationException("Tipo de evento desconhecido");
            }
        }
    }
}
