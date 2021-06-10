using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace API.Controllers
{
    [Route("/")]
    public class RoutesController : ControllerBase
    {
        private readonly IActionDescriptorCollectionProvider _provider;

        public RoutesController(IActionDescriptorCollectionProvider provider)
        {
            _provider = provider;
        }

        [HttpGet("")]
        public IActionResult GetRoutes()
        {
            var routes = _provider.ActionDescriptors.Items.Select(x => new {
                Action = x.RouteValues["Action"],
                Controller = x.RouteValues["Controller"],
                x.AttributeRouteInfo?.Name,
                x.AttributeRouteInfo?.Template
            }).ToList();
            return Ok(routes);
        }
    }
}
