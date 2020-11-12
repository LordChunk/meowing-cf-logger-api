using System;
using System.Threading.Tasks;
using Data.Models;
using Data.Repositories;
using Org.BouncyCastle.Security;
using Tests.Attributes;
using Xunit;

namespace Tests.Repositories
{
    [AutoRollback]
    public class HttpRequestRepository : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _dbFixture;
        private readonly IHttpRequestRepository _httpRequest;
        private readonly Random _rnd;
        public HttpRequestRepository(DatabaseFixture dbFixture)
        {
            _dbFixture = dbFixture;
            _httpRequest = _dbFixture.RepositoryWrapper.HttpRequest;
            _rnd = new Random();
        }

        // Create
        [Fact]
        public async void CreatedShouldReturnExistingId()
        {
            var createdId = AddRequestWithRndId().Result.Id;
            await AddRequestWithRndId();
            await AddRequestWithRndId();

            var fetchedRequest = await _httpRequest.Get(r => r.Id == createdId);

            Assert.Equal(createdId, fetchedRequest.Id);
        }

        // Read
        [Fact]
        public async void GettingNonExistingItemShouldReturnNull()
        {
            Assert.Null(await _httpRequest.Get(r => r.Id == 99999));
        }

        // Update


        // Delete
        [Fact]
        public async void Removing1ItemShouldReturn1()
        {
            var id = AddRequestWithRndId().Result.Id;

            await AddRequestWithRndId();
            await AddRequestWithRndId();

            Assert.Equal(id, _httpRequest.Get(r => r.Id == id).Result.Id);
        }

        private async Task<HttpRequest> AddRequestWithId(int id = 0)
        {
            if (id < 0) throw new InvalidParameterException("IDs have to be greater than 0");

            var testRequest = new HttpRequest()
            {
                Url = @"https://example.com/example",
                Method = "POST",
                ContentLength = _rnd.Next(900000),
            };

            if (id != 0) testRequest.Id = id;

            return await _httpRequest.Add(testRequest);
        }

        private async Task<HttpRequest> AddRequestWithRndId()
        {
            return await AddRequestWithId(_rnd.Next(9000));
        }
    }
}
