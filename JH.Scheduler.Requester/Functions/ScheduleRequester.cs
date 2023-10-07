using System;
using JH.Scheduler.Requester.Common;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace JH.Scheduler.Requester
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([TimerTrigger("0/1 * * * * *")] TimerInfo myTimer, 
            ExecutionContext context,
            ILogger logger,
            [Queue(AppConstants.MonitorSubRedditQueueName)] ICollector<SyncRefDataTask> dataSyncQueue)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            log.LogInformation($"WAEERRRRR");

        }
    }
}
