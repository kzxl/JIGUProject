using ModelDTO;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.ServerService
{
    public interface IServerService
    {
        ResponseDTO SetCF(RequestDTO request);

        Task<List<LineInfo>> GetData();
        ResponseDTO DeleteCF(int id);
    }
}
