﻿using JH.Scheduler.Requester;
using JH.Scheduler.Requester.Queue;
using JH.Scheduler.Requester.Queue.Interfaces;
using JH.Scheduler.Requester.Services.Interfaces;
using JH.Scheduler.Requester.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace JH.Scheduler.Requester
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IQueueServices, QueueServices>();
            builder.Services.AddSingleton<ISchedulerServices, SchedulerServices>();
            builder.Services.AddLogging();

        }
    }
}
