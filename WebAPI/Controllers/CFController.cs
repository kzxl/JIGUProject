using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ModelDTO;
using Shared.Services.ServerService;

namespace WebAPI.Controllers
{
    public class CFController : ControllerBase
    {
        private readonly IServerService _service;
        public CFController(IServerService service)
        { _service = service; }
        [HttpPost]
        [Route("api/sendcf")]
        public IActionResult SetCF([FromBody] RequestDTO request)
            => Ok(_service.SetCF(request));
        [HttpGet]
        [Route("api/getinfo")]
        public async Task<IActionResult> GetLineInfo()
            => Ok(await _service.GetData());
        [HttpPost]
        [Route("api/delete")]
        public IActionResult DeleteCF([FromBody] int id)
            => Ok(_service.DeleteCF(id));
    }
}
