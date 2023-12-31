using JH.Monitor.Retriever.Common;
using JH.Monitor.Retriever.Services.Interfaces;
using JH.Scheduler.Listener.Common;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace JH.Scheduler.Listener
{
    public class SubRedditRetriever
    {
        private readonly ISubRedditService _subRedditService;
        public SubRedditRetriever(IConfiguration configuration, ISubRedditService subRedditService)
        {
            this._subRedditService = subRedditService ?? throw new ArgumentNullException(nameof(subRedditService));
        }

        [FunctionName("SubRedditRetriever")]
        public async Task RunAsync([ServiceBusTrigger(AppConstants.MonitorSubRedditQueueName, Connection = "JackHenryServiceBusConnectionString")] string subRedditName, ILogger log)
        {
            await this._subRedditService.GetSubRedditPosts(subRedditName);

            log.LogInformation($"C# Queue trigger function processed: {subRedditName}");
        }

        [FunctionName("SubRedditRetrieverDeadLetter")]
        public async Task RunAsyncDeadLetter([ServiceBusTrigger(AppConstants.MonitorSubRedditQueueName + "/$deadletterqueue", Connection = "JackHenryServiceBusConnectionString")] string subRedditName, ILogger log)
        {
            log.LogInformation($"SubRedditRetrieverDeadLetter {subRedditName}  failed: !!!");
        }
    }
}
