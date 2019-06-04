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

        //[SetUp]
        //public void Setup()
        //{
        //}

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}

        [Theory]
        [TestCase("GET")]
        public async Task TesteGet(string method)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}