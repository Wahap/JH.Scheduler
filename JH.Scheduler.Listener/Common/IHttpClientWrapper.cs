using Reddit;
namespace JH.Monitor.Retriever.Common
{
    public interface IHttpClientWrapper
    {
        RedditClient GetClient();
    }
}
