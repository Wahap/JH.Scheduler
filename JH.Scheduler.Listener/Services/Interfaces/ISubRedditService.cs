using System.Threading.Tasks;

namespace JH.Monitor.Retriever.Services.Interfaces
{
    public interface ISubRedditService
    {
        Task GetSubRedditPosts(string subRedditName);
    }
}
