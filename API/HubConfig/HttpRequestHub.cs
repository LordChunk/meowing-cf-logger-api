using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.SignalR;

namespace API.HubConfig
{
    public class HttpRequestHub : Hub
    {
        private RepositoryWrapper _repositoryWrapper;
        public HttpRequestHub(RepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task SendRequests()
        {
            await Clients.Caller.SendAsync("GetAll", _repositoryWrapper.HttpRequest.GetAll());
        }
    }
}