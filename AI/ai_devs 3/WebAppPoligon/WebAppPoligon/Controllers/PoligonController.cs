using Microsoft.AspNetCore.Mvc;
using WebAppPoligon.Services.Interfaces;

namespace WebAppPoligon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoligonController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get([FromServices] IPoligonService  service)
        {
            return await service.Process();
        }
    }
}
