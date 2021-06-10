using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]/{action}")]
    [ApiController]
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
    }
}
