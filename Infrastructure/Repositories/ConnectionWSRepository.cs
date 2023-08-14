using Domain.Entities;
using Domain.Interfaces;
using System.Net.WebSockets;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ConnectionWSRepository : IConnectionWSRepository
    {
        public async Task Echo(ConnectionWS connection)
        {
            byte[] buffer = new byte[1024 * 4];

            WebSocket webSocket = connection.WebSocket;

            try
            {
                WebSocketReceiveResult receiveResult;
                do
                {
                    var segment = new ArraySegment<byte>(buffer);
                    receiveResult = await webSocket.ReceiveAsync(segment, CancellationToken.None);

                    if (receiveResult != null) {
                        if (receiveResult.MessageType == WebSocketMessageType.Close)
                        {
                            await webSocket.CloseAsync(receiveResult.CloseStatus.Value, receiveResult.CloseStatusDescription, CancellationToken.None);
                            return;
                        }

                        var messageReceived = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count);
                        Console.WriteLine(messageReceived);

                        var responseMessage = "{\"name\":\"Servidor\",\"text\":\"Recebido\"}";
                        Console.WriteLine("Send: " + responseMessage);

                        var responseBytes = Encoding.UTF8.GetBytes(responseMessage);
                        var responseSegment = new ArraySegment<byte>(responseBytes);
                        await webSocket.SendAsync(responseSegment, WebSocketMessageType.Text, true, CancellationToken.None);

                        Array.Clear(buffer, 0, buffer.Length); // Limpa o buffer
                    } else
                    {
                        return; // ACONTECEU ALGUM ERRO 
                    }
                
                }
                while (!receiveResult.CloseStatus.HasValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error handling WebSocket communication: " + ex.Message);
                throw;
            }
        }

        // Implemente outros métodos conforme necessário
    }
}
