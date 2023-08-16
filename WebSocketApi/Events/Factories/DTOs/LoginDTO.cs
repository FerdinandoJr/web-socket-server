using System.Text.Json.Serialization;

namespace WebSocketApi.Events.Factories.DTOs
{

    public class LoginInputDTO
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public object Password { get; set; }
    }

    public class LogoutInputDTO {
        // QUALQUER COISA
    }

}
