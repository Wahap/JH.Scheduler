using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JH.Monitor.SubOperations.Common;
using JH.Monitor.SubOperations.Models;
using JH.Monitor.SubRedditOperations.Common;
using JH.Monitor.SubRedditOperations.Services.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace JH.Monitor.SubOperations
{
    public class SubRedditUsersFunction
    {
        private readonly IOutputFactory _outputFactory;
        private readonly  IOutputService _outputService;

        public SubRedditUsersFunction(IOutputFactory outputFactory,IOutputService outputService)
        {
            this._outputFactory = outputFactory ?? throw new ArgumentNullException(nameof(outputFactory));
            this._outputService = outputService ?? throw new ArgumentNullException(nameof(outputService));
        }

        [FunctionName("SubUsersFunction")]
        public void Run([ServiceBusTrigger(AppConstants.RedditsubPostsTopic, AppConstants.RedditsubUsers, Connection = "JackHenryServiceBusConnectionString")]string mySbMsg, ILogger log)
        {
            var posts = JsonConvert.DeserializeObject<List<RedditPost>>(mySbMsg);
            var outpuGenerator = _outputFactory.GetOutputGenerator(GeneratorType.UserGenerator);
            string output = outpuGenerator.GetOutput(posts);

            this._outputService.SendOut(output);
        }
    }
}