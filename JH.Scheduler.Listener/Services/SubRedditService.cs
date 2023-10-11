using JH.Monitor.Retriever.Common;
using JH.Monitor.Retriever.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Reddit.Controllers;
using System.Linq;
using JH.Monitor.Retriever.Models;
using Microsoft.Extensions.Configuration;
using JH.Monitor.Retriever.ServiceBusPublisher.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace JH.Monitor.Retriever.Services
{
    public class SubRedditService : ISubRedditService
    {

        private readonly IHttpClientWrapper _redditClientWrapper;
        private readonly IConfiguration _config;
        private readonly ITopicServices _topicServices;
        private readonly ILogger<SubRedditService> _logger;

        // for sack of simplicity, only 30 post calculated.
        // TODO: Read TopPostResult from config
        private const int TopPostResult = 30;

        public SubRedditService(IHttpClientWrapper redditClientWrapper, ITopicServices topicServices, IConfiguration config, ILogger<SubRedditService> logger)
        {
            this._redditClientWrapper = redditClientWrapper ?? throw new ArgumentNullException(nameof(redditClientWrapper));
            this._config = config ?? throw new ArgumentNullException(nameof(config));
            this._topicServices = topicServices ?? throw new ArgumentNullException(nameof(topicServices));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<string> GetSubRedditPosts(string subRedditName)
        {
            var redditClient = this._redditClientWrapper.GetClient();
            Subreddit subReddit = redditClient.Subreddit(subRedditName).About();

            var topSubs = subReddit.Posts.Top.Take(TopPostResult).Select(post => new RedditPost(post.Title, post.Author, post.UpVotes));
            var topSubsJson = JsonConvert.SerializeObject(topSubs);
            string result = await _topicServices.SendMessage(_config.GetValue<string>(ConfigurationKeys.RedditSubsTopic), topSubsJson);
            _logger.LogInformation($"GetSubRedditPosts processed with : {topSubs.Count()} subs");

            return result;

        }

    }
}
