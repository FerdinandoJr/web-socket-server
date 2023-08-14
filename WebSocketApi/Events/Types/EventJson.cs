using System.Text.Json.Serialization;

namespace WebSocketApi.Events.Types
{
    public class EventJson
    {
        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("payload")]
        public object Payload { get; set; }
    }
}
