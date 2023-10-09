using System;
using System.Collections.Generic;
using JH.Monitor.SubOperations.Common;
using JH.Monitor.SubOperations.Models;
using JH.Monitor.SubRedditOperations.Common;
using JH.Monitor.SubRedditOperations.Services.Interfaces;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace JH.Monitor.SubOperations
{
    public class SubRedditPostsFunction
    {
        private readonly IOutputFactory _outputFactory;
        private readonly IOutputService _outputService;

        public SubRedditPostsFunction(IOutputFactory outputFactory, IOutputService outputService)
        {
            this._outputFactory = outputFactory ?? throw new ArgumentNullException(nameof(outputFactory));
            this._outputService = outputService ?? throw new ArgumentNullException(nameof(outputService));
        }

        [FunctionName("SubPostsFunction")]
        public void Run([ServiceBusTrigger(AppConstants.RedditsubPostsTopic, AppConstants.Redditsubposts, Connection = "JackHenryServiceBusConnectionString")] string mySbMsg)
        {
            var posts = JsonConvert.DeserializeObject<List<RedditPost>>(mySbMsg);
            var outputGenerator = _outputFactory.GetOutputGenerator(GeneratorType.PostGenerator);
            string output = outputGenerator.GetOutput(posts);

            this._outputService.SendOut(output);
        }
    }
}
