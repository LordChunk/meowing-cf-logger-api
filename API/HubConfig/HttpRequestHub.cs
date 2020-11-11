using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.SignalR;

namespace API.HubConfig
{
    public class HttpRequestHub : Hub, IObserver<List<int>>
    {
        private readonly RepositoryWrapper _repositoryWrapper;

        public HttpRequestHub(RepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            repositoryWrapper.HttpLogsObservable.Subscribe(this);
        }

        // Observable methods
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(List<int> updatedLogIds)
        {
            Clients.All.SendAsync("GetLogUpdates", updatedLogIds);
        }
    }
}