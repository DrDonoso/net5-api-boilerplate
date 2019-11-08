using Boilerplate.Api.Controllers;
using Xunit;

namespace Boilerplate.Api.UnitTests
{
    public class IndexControllerTests
    {
        [Fact]
        public void ShouldGetResponseFromController()
        {
            var controller = new IndexController();

            var response = controller.Get();

            Assert.Equal("Ok", response);
        }
    }
}