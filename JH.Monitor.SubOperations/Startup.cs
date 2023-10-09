using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using JH.Monitor.SubRedditOperations.Services;
using JH.Monitor.SubRedditOperations.Services.Interfaces;
using JH.Monitor.SubRedditOperations;

[assembly: FunctionsStartup(typeof(Startup))]

namespace JH.Monitor.SubRedditOperations
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IOutputService, OutputService>();
            builder.Services.AddSingleton<IOutputFactory, OutputFactory>();

            builder.Services.AddLogging();
        }
    }
}

