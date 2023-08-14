using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Application.Use_Cases
{
    public class GetConnectionsUseCase
    {
        private ConnectionWSService ConnectionWSService;

        public GetConnectionsUseCase(ConnectionWSService connectionWSService)
        {
            ConnectionWSService = connectionWSService;
        }

        public IEnumerable<ConnectionWS> Execute()
        {
            return ConnectionWSService.GetAllConnections();
        }
    }
}
