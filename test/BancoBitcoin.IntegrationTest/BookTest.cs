using BancoBitcoin.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BancoBitcoin.IntegrationTest
{
    public class BookTest
    {
        private readonly HttpClient _client;

        public BookTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Test")
                .UseStartup<Startup>());

            _client = server.CreateClient();
        }

        [Theory]
        [TestCase("GET")]
        public async Task TesteGetBooks(string method)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "api/book/GetBooks");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [TestCase("GET")]
        public async Task TesteGetBooksByInformation(string method)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "api/Book/GetBooksByInformation?id=1&price=0&order=true");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [TestCase("GET")]
        public async Task TesteGetBooksBySpecification(string method)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "api/Book/GetBooksBySpecification?originallyPublished=November&pageCount=0&order=true");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}