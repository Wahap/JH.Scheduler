using JH.Monitor.SubOperations.Models;
using System.Collections.Generic;

namespace JH.Monitor.SubRedditOperations.Services.Interfaces
{
    public interface IOutputGenerator
    {
        string GetOutput(List<RedditPost> posts);
    }
}
