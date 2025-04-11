using ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;
        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public ResponseDTO SendCF(RequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
