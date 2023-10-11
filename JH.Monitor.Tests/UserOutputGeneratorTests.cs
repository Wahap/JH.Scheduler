using JH.Monitor.SubOperations.Models;
using JH.Monitor.SubRedditOperations.Services;
using JH.Monitor.SubRedditOperations.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace JH.Monitor.Tests
{
    [TestClass]
    public class UserOutputGeneratorTests
    {
        private  IOutputGenerator _userOutputGenerator;
        [TestMethod]
        public void ItShouldGenerateUserOutput_WhenThereIsPostData()
        {
            //Arrange
            _userOutputGenerator = new UserOutputGenerator();
            var postData = new List<RedditPost>() {
                new RedditPost("Title1","Auther1",1),
            };

            //Act
            var result = _userOutputGenerator.GetOutput(postData);

            //Asserts

            Assert.IsNotNull(result);
            Assert.AreEqual(result, "\r\n\r\nUsers with the most posts:\r\nAuthor :Auther1, Post Count: 1\r\n\r\n");
        }

        [TestMethod]
        public void ItShouldReturnEmptyString_WhenThereIsNoPostData()
        {
            //Arrange
            _userOutputGenerator = new UserOutputGenerator();
            var postData = new List<RedditPost>() {
            };

            //Act
            var result = _userOutputGenerator.GetOutput(postData);

            //Asserts
            Assert.AreEqual(result, "");
        }
    }
}