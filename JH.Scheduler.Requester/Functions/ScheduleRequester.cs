using System;
using System.Threading.Tasks;
using JH.Scheduler.Requester.Common;
using JH.Scheduler.Requester.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace JH.Scheduler.Requester
{
    public class ScheduleRequester
    {
        private readonly ISchedulerServices _scheduler;
        public ScheduleRequester(ISchedulerServices scheduler)
        {
            this._scheduler = scheduler;
        }
        [FunctionName("ScheduleRequester")]
        public void ScheduleRequesterRun([TimerTrigger("0/10 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"ScheduleRequester Timer trigger function executed at: {DateTime.Now}");
            this._scheduler.CreateRequest(AppConstants.MonitorSubRedditQueue);
            log.LogInformation($"ScheduleRequester Timer trigger function finished at: {DateTime.Now}");

        }


        [FunctionName("HttpScheduleRequester")]
        public async Task<IActionResult> HttpScheduleRequesterRun([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string subRedditName = req.Query["subRedditName"];
            log.LogInformation("HttpScheduleRequester ran for " + subRedditName);

            return new OkObjectResult(await _scheduler.CreateRequest(AppConstants.MonitorSubRedditQueue, subRedditName));
        }
    }
}
