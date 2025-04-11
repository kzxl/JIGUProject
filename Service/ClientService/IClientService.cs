using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ModelDTO;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.ClientService
{
    public interface IClientService
    {
        Task<ResponseDTO> SendCF(string url, RequestDTO request);
        Task<string> CheckAPI(string url);
        Task<ResponseDTO> DeleteCF(string url, int id);
        Task<List<LineInfo>> GetLineInfo(string url);
    }
}
