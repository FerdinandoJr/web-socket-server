using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using System.Net.WebSockets;

namespace Application.Use_Cases
{
    public class CreateConnectionUseCase
    {
        private ConnectionWSService ConnectionWSService;
        private IConnectionWSRepository ConnectionWSRepository;

        public CreateConnectionUseCase(ConnectionWSService connectionWSService, IConnectionWSRepository connectionWSRepository)
        {
            ConnectionWSService = connectionWSService;
            ConnectionWSRepository = connectionWSRepository;   
        }

        public async void Execute(WebSocket webSocket, string ipRemote)
        {
            try 
            {
                Random key = new Random(2023);

                ConnectionWS connectionWS = new ConnectionWS(key.Next().ToString(), webSocket, ipRemote);

                ConnectionWSService.AddConnection(connectionWS);

                await ConnectionWSRepository.Echo(connectionWS);

            } catch (Exception ex) 
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
