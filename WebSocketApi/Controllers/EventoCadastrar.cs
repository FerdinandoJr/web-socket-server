using System.Text.Json.Serialization;

namespace WebSocketApi.Controllers
{
    public class EventoCadastrar
    {
        [JsonPropertyName("eventType")]
        public EventType EventType { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("senha")]
        public string Senha { get; set; }
    }
}
