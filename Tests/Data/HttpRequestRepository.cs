using System;
using Data.Models;
using Tests.Attributes;
using Xunit;

namespace Tests
{
    public class HttpRequestRepository : IClassFixture<DatabaseFixture>
    {
        private DatabaseFixture dbFixture;
        public HttpRequestRepository(DatabaseFixture dbFixture)
        {
            this.dbFixture = dbFixture;
        }

        [Fact, AutoRollback]
        public async void CreatingIdTenShouldReturnIdTen()
        {
            var httpRequest = dbFixture.RepositoryWrapper.HttpRequest;

            var testRequest = new HttpRequest()
            {
                Id = 10,
                Url = @"https://example.com/example",
                Method = "POST",
                ContentLength = 34000,
            };

            await httpRequest.Add(testRequest);

            var fetchedRequest = await httpRequest.Get(r => r.Id == 10 );

            Assert.Equal(10, fetchedRequest.Id);
        }
    }
}
