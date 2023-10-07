
using JH.Scheduler.Requester.Common;
using JH.Scheduler.Requester.Queue.Interfaces;
using JH.Scheduler.Requester.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace JH.Scheduler.Requester.Services
{
    public class SchedulerServices : ISchedulerServices
    {

        private readonly IQueueServices _queueServices;
        private readonly IConfiguration _configuration;

        public SchedulerServices(IQueueServices queueServices, IConfiguration configuration)
        {
            _queueServices = queueServices;
            _configuration = configuration;
        }
        public Task<string> CreateRequest(string queueName,string subRedditName = null)
        {
            // TO DO
            // Read subredits from db
            subRedditName ??= _configuration.GetValue<string>(ConfigurationKeys.SubRedditName);

            return _queueServices.SendMessage(queueName,subRedditName);
        }
    }
}
