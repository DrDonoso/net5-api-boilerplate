using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Boilerplate.Api.IntegrationTests
{
    [Collection("Test collection")]
    public class IndexControllerTests
    {
        private TestFixture _fixture;
        private static HttpClient _httpClient;

        public IndexControllerTests(TestFixture fixture)
        {
            _httpClient = fixture.GetHttpClient();
        }

        [Fact]
        public async Task ShouldGetResponseFromApi()
        {
            await _httpClient.GetStringAsync(string.Empty);

            Assert.True(true);
        }
    }
}