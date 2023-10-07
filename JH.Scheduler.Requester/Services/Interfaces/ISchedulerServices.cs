using System.Threading.Tasks;

namespace JH.Scheduler.Requester.Services.Interfaces
{
    public interface ISchedulerServices
    {
        Task<string> CreateRequest(string queueName,string subRedditName = null);
    }
}
