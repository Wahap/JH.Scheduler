using JH.Monitor.Retriever.Services;
using JH.Monitor.Retriever.Services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using JH.Scheduler.Retriever;
using JH.Monitor.Retriever.Common;
using JH.Monitor.Retriever.ServiceBusPublisher.Interfaces;
using JH.Monitor.Retriever.ServiceBusPublisher;

[assembly: FunctionsStartup(typeof(Startup))]

namespace JH.Scheduler.Retriever
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ISubRedditService, SubRedditService>();
            builder.Services.AddSingleton<IHttpClientWrapper, RedditClientWrapper>();
            builder.Services.AddSingleton<ITopicServices, TopicServices>();

            builder.Services.AddLogging();
        }
    }
}
