using Microsoft.Extensions.Configuration;

namespace HttpRequest
{
    public class Startup : EndPointLibs.Startup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }
    }
}

