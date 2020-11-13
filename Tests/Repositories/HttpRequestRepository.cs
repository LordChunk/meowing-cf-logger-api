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
            await AddRequestWithId(1);
            await AddRequestWithId(2);
            await AddRequestWithId(3);
            await AddRequestWithId(4);
            await AddRequestWithId(5);

            Assert.Null(await _httpRequest.Get(r => r.Id == 6));
        }
        [Fact]
        public async void GetAllShouldReturnAllItems()
        {
            await AddRequestWithId(1);
            await AddRequestWithId(2);
            await AddRequestWithId(3);
            await AddRequestWithId(4);
            await AddRequestWithId(5);

            Assert.Equal(5, _httpRequest.GetAll().Result.Count);
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

        [Fact]
        public async void Removing1ItemShouldReduceGetAllCountBy1()
        {
            for (var i = 0; i < 8; i++) await AddRequestWithRndId();

            var id = AddRequestWithRndId().Result.Id;

            var itemCountBeforeDelete = _httpRequest.GetAll().Result.Count;
            var deleteResult = _httpRequest.Remove(r => r.Id == id).Result;
            Assert.Single(deleteResult);
            Assert.Equal(itemCountBeforeDelete, _httpRequest.GetAll().Result.Count);
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
