using JH.Monitor.Retriever.Common;
using JH.Monitor.Retriever.ServiceBusPublisher.Interfaces;
using JH.Monitor.Retriever.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JH.Monitor.Retriever.Tests
{
    [TestClass]
    public class SubRedditServiceTests
    {
        IHttpClientWrapper _httpClientWrapper;
        IConfiguration _config;
        Mock<ITopicServices> _topicServices;
        NullLogger<SubRedditService> _logger;
        string subRedditName = "AskReddit";

        [TestInitialize]
        public void setup()
        {
           //Act
            _topicServices = new Mock<ITopicServices>();
            _logger = new NullLogger<SubRedditService>();
            
            //Arrange
            var inMemorySettings = new Dictionary<string, string> {
                    {"RedditAppId", "iiXNv-h0mUT4VTQwmp_2OA"},
                    {"RedditRefreshToken", "283463062239-z24FeZWAWKcoThjtwBfU7R0sr-qDPw"},
                    {"RedditAppSecret", "GDQh5gyNMfpX78DeohI8rjZ-HV8Z2A"},
            };

            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            _httpClientWrapper = new RedditClientWrapper(_config);
        }

        [TestMethod]
        public async Task ItShouldReturnSuccessfully_WhenParametersAreFine()
        {

            //Arrange
            _topicServices.Setup(x => x.SendMessage(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync("message published");

            //Act
            var sut = new SubRedditService(_httpClientWrapper, _topicServices.Object, _config, _logger);
            var result = await sut.GetSubRedditPosts(subRedditName);

            //Asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(result, "message published");
        }
    }
}