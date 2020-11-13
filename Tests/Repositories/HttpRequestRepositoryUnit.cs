using System.ComponentModel.DataAnnotations;
using Data;
using Data.Models.Common;
using Data.Repositories.Common;
using Xunit;
using Moq;


namespace Tests.Repositories
{
    public class HttpRequestRepositoryUnit
    {
        [Fact]
        public async void RemoveShouldReturnNullOnFail()
        {
            var mockContext = new Mock<ApplicationContext>();
            var testRepo = new TestRepository(mockContext.Object);


            //mockset.Setup(m => m.Remove()).ReturnsAsync()
        }
    }


    internal class TestEntity : IEntity
    {
        [Required]
        public int Id { get; set; }
    }

    internal class TestRepository : RepositoryBase<TestEntity>
    {
        public TestRepository(ApplicationContext context) : base(context) {}
    }
}