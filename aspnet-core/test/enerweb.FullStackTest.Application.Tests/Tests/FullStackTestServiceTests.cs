using enerweb.FullStackTest.Repository;
using Xunit;

namespace enerweb.FullStackTest.Tests
{
    public class FullStackTestServiceTests: FullStackTestApplicationTestBase
    {
        private readonly IFullStackTestService _fullStackTestService;
        public FullStackTestServiceTests(IFullStackTestService fullStackTestService)
        {
            _fullStackTestService = fullStackTestService;
        }

        [Fact]
        public void GetFiles_Should_Retrieve_A_List_Of_Files()
        {
            var test = _fullStackTestService.GetFiles();

            Assert.NotNull(test);
        }
    }
}
