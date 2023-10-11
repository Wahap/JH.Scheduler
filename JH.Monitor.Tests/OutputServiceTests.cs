using JH.Monitor.SubOperations.Models;
using JH.Monitor.SubRedditOperations.Services;
using JH.Monitor.SubRedditOperations.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace JH.Monitor.Tests
{
    [TestClass]
    public class OutputServiceTests
    {
        private IOutputService _outputService;
        [TestMethod]
        public void ItShouldNotReturnError_WhenSendOutCalled()
        {
            //Arrange
            _outputService = new OutputService();
            string input = "test input";

            //Act
            _outputService.SendOut(input);

            //Asserts
            Assert.IsNotNull(_outputService);
            Assert.IsNotNull(true);

        }
    }
}
