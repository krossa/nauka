using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace signalR.Controllers
{
    [ApiController]
    public class FooController : ControllerBase
    {
        private readonly IHubContext<InformHub, IHubClient> hubContext;

        public FooController(IHubContext<InformHub, IHubClient> hubContext)
        {
            this.hubContext = hubContext;
        }

        [HttpGet]
        [Route("api/send/{msg}")]
        public string send(string msg)
        {
            hubContext.Clients.All.InformClient(msg);
            return msg;
        }
    }
}