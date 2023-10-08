using System.Threading.Tasks;

namespace JH.Scheduler.Requester.Queue.Interfaces
{
    public interface IQueueServices
    {
        public Task<string> SendMessage(string queueName, string message);
    }
}

