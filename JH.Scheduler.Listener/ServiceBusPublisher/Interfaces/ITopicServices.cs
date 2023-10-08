using System.Threading.Tasks;

namespace JH.Monitor.Retriever.ServiceBusPublisher.Interfaces
{
    public interface ITopicServices
    {
        public Task<string> SendMessage(string topicName, string redditSubs);
    }
}
