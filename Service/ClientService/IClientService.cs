using ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.ClientService
{
    public interface IClientService
    {
        ResponseDTO SendCF(RequestDTO request);
    }
}
