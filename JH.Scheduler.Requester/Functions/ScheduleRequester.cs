using System;
using JH.Scheduler.Requester.Common;
using JH.Scheduler.Requester.Services.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace JH.Scheduler.Requester
{
    public class ScheduleRequester
    {
        private readonly ILogger _logger;
        private readonly ISchedulerServices _scheduler;
        public ScheduleRequester(ISchedulerServices scheduler)
        {
            this._scheduler = scheduler;
        }
        [FunctionName("ScheduleRequester")]
        public void Run([TimerTrigger("0/30 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"ScheduleRequester Timer trigger function executed at: {DateTime.Now}");
            this._scheduler.CreateRequest(AppConstants.MonitorSubRedditQueueName);
            log.LogInformation($"ScheduleRequester Timer trigger function finished at: {DateTime.Now}");

        }
    }
}
