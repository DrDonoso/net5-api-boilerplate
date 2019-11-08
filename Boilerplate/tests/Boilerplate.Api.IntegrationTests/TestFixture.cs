using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Net.Http;
using Xunit;

namespace Boilerplate.Api.IntegrationTests
{
    public class TestFixture : IDisposable
    {
        private static HttpClient _httpClient;

        private const string HttpClientName = "httpclient";

        public TestFixture()
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var servicesCollection = new ServiceCollection();

            servicesCollection
                .AddHttpClient(HttpClientName, client =>
                {
                    client.BaseAddress = new Uri(configuration["BaseApiUrl"]);
                })
                .AddPolicyHandler(Policy<HttpResponseMessage>.Handle<Exception>().WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(10)));

            var serviceProvider = servicesCollection.BuildServiceProvider();

            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();

            _httpClient = httpClientFactory.CreateClient(HttpClientName);
        }

        public HttpClient GetHttpClient() => _httpClient;

        public void Dispose()
        {
        }
    }

    [CollectionDefinition("Test collection")]
    public class TestCollection : ICollectionFixture<TestFixture>
    {

    }
}
