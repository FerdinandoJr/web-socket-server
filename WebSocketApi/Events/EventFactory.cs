using System.Text.Json;
using WebSocketApi.Events.Factories;
using WebSocketApi.Events.Interfaces;
using WebSocketApi.Events.Types;

namespace WebSocketApi.Events
{
    public class EventFactory
    {
        private readonly Dictionary<EventType, IEventFactory> factories;

        public EventFactory()
        {
            factories = new Dictionary<EventType, IEventFactory>
        {
            { EventType.login, new LoginFactory() },
            { EventType.logout, new LogoutFactory() }
            // Adicione outras fábricas conforme necessário
        };
        }

        public void Execute (string jsonString)
        {
            if (jsonString == "" || jsonString == null) return;

            try
            {

                Console.WriteLine(jsonString);
                EventJson? eventJson = JsonSerializer.Deserialize<EventJson>(jsonString);
                
                if (eventJson == null)
                {
                    throw new JsonException("JSON null");
                }

                bool isEventType = Enum.TryParse(eventJson.Event, ignoreCase: true, out EventType eventType);                
                if (isEventType) // A conversão foi bem-sucedida, pegando função
                {

                    IEventFactory factory = factories[eventType];

                    factory.Execute(jsonString);
                }
                else
                {
                    // A conversão falhou, faça algo apropriado, como lançar uma exceção ou registrar um erro
                    throw new Exception("Tipo de evento inválido");
                }

            }
            catch (JsonException e)
            {
                // A conversão falhou
                throw new InvalidOperationException("JSON inválido: ", e);
            }
        }

    }
}
