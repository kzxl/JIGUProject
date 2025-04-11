using ModelDTO;
using Newtonsoft.Json;
using Shared.Models;
using Shared.Services.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
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

        public async Task<string> CheckAPI(string url)
        {
            var respone = await $"http://{url}/api/check".GetAsync(_httpClient);
            return respone;
        }

        public async Task<ResponseDTO> DeleteCF(string url, int id)
        {
            var respone = await $"http://{url}/api/delete".PostAsync(_httpClient, new { id = id });
            if (respone == null) { return new ResponseDTO { IsSuccess = false, Message = "Xảy ra lỗi" }; }
            var result = JsonConvert.DeserializeObject<ResponseDTO>(respone);
            return result;
        }

        public async Task<List<LineInfo>> GetLineInfo(string url)
        {
            var respone = await $"http://{url}/api/getinfo".GetAsync(_httpClient);
            if (respone == null) { return null; }
            var result = JsonConvert.DeserializeObject<List<LineInfo>>(respone);
            return result;
        }

        public async Task<ResponseDTO> SendCF(string url, RequestDTO request)
        {
            var respone = await $"http://{url}/api/sendcf".PostAsync(_httpClient, request);
            if (respone == null) { return new ResponseDTO { IsSuccess = false, Message = "Xảy ra lỗi" }; }
            var result = JsonConvert.DeserializeObject<ResponseDTO>(respone);
            return result;
        }

    }
}
