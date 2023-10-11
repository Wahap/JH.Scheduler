using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using Moq;
using JH.Scheduler.Requester.Queue.Interfaces;
using System.Collections.Generic;
using JH.Scheduler.Requester.Services;
using System.Threading.Tasks;

namespace JH.Monitor.Requester.Tests
{
    [TestClass]
    public class SchedulerServicesTests
    {
        IConfiguration _config;
        Mock<IQueueServices>   _queueServices;

        [TestInitialize]
        public void setup()
        {
            //Act
            _queueServices = new Mock<IQueueServices>();

            //Arrange
            var inMemorySettings = new Dictionary<string, string> {
                    {"SubRedditName", "SubRedditName"},
            };

            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

        }

        [TestMethod]
        public async Task TestMethod1Async()
        {

            //Arrange
            _queueServices.Setup(x => x.SendMessage(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync("message published");

            //Act
            var sut = new SchedulerServices(_queueServices.Object,_config);
            var result = await sut.CreateRequest(It.IsAny<string>(), It.IsAny<string>());

            //Asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(result, "message published");
        }
    }
}