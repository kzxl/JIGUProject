using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ModelDTO;

namespace WebAPI.Controllers
{
    public class CFController : ControllerBase
    {
        [HttpPost]
        [Route("api/sendcf")]
        public IActionResult SetCF([FromBody] RequestDTO request)
        {
            return Ok(new ResponseDTO { IsSuccess = true, Message = "Gửi thành công" });
        }
    }
}
