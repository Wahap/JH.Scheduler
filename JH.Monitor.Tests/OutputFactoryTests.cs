using JH.Monitor.SubRedditOperations.Common;
using JH.Monitor.SubRedditOperations.Services;
using JH.Monitor.SubRedditOperations.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JH.Monitor.Tests
{
    [TestClass]
    public class OutputFactoryTests
    {
        private IOutputFactory _outputFactory;
        private IOutputGenerator outputGenerator;
        [TestMethod]
        public void ItShouldGenerateUserOutputGeneratorInstance_WhenGeneratorTypeIsUserGenerator()
        {
            //Arrange
            _outputFactory = new OutputFactory();
            var generatorType = GeneratorType.UserGenerator;

            //Act
            outputGenerator = _outputFactory.GetOutputGenerator(generatorType);

            //Asserts
            Assert.IsInstanceOfType(outputGenerator, typeof(UserOutputGenerator));
        }

        [TestMethod]
        public void ItShouldGeneratePostGeneratorOutputGeneratorInstance_WhenGeneratorTypeIsPostGenerator()
        {
            //Arrange
            _outputFactory = new OutputFactory();
            var generatorType = GeneratorType.PostGenerator;

            //Act
            outputGenerator = _outputFactory.GetOutputGenerator(generatorType);

            //Asserts
            Assert.IsInstanceOfType(outputGenerator, typeof(PostOutputGenerator));
        }
    }
}
