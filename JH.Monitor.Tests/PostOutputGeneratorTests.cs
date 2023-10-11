using JH.Monitor.SubOperations.Models;
using JH.Monitor.SubRedditOperations.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace JH.Monitor.Tests
{
    [TestClass]
    public class PostOutputGeneratorTests
    {
        private  IOutputGenerator _postOutputGenerator;
        [TestMethod]
        public void ItShouldGeneratePostOutput_WhenThereIsPostData()
        {
            //Arrange
            _postOutputGenerator = new PostOutputGenerator();
            var postData = new List<RedditPost>() {
                new RedditPost("Title1","Auther1",1),
            };

            //Act
            var result = _postOutputGenerator.GetOutput(postData);

            //Asserts

            Assert.IsNotNull(result);
            Assert.AreEqual(result, "\r\nPosts with the most up votes:\r\nPost #1\r\nTitle: Title1\r\nAuthor: Auther1\r\nUpVoteCount: 1\r\n\r\n\r\n");
        }

        [TestMethod]
        public void ItShouldReturnEmptyString_WhenThereIsNoPostData()
        {
            //Arrange
            _postOutputGenerator = new PostOutputGenerator();
            var postData = new List<RedditPost>() {
            };

            //Act
            var result = _postOutputGenerator.GetOutput(postData);

            //Asserts
            Assert.AreEqual(result, "");
        }
    }
}