using Microsoft.Extensions.Configuration;
using Reddit;
using System;

namespace JH.Monitor.Retriever.Common
{
    public class RedditClientWrapper : IHttpClientWrapper
    {
        readonly IConfiguration _config;
        public RedditClientWrapper(IConfiguration configuration)
        {
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public RedditClient GetClient()
        {
            RedditClient client = new RedditClient(_config.GetValue<string>(ConfigurationKeys.RedditAppId), _config.GetValue<string>(ConfigurationKeys.RedditRefreshToken), _config.GetValue<string>(ConfigurationKeys.RedditAppSecret));
            return client;
        }
    }
}
