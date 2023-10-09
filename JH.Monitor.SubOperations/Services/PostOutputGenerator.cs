
using JH.Monitor.SubOperations.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JH.Monitor.SubRedditOperations.Services.Interfaces
{
    internal class PostOutputGenerator : IOutputGenerator
    {
        public string GetOutput(List<RedditPost> posts)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.Append("Posts with the most up votes:");
            sb.AppendLine();


            for (int counter = 0; counter < posts.Take(5).Count(); counter++)
            {
                RedditPost post = posts[counter];
                sb.Append($"Post #{counter + 1}");
                sb.AppendLine();
                sb.Append($"Title {post.Title}");
                sb.AppendLine();
                sb.Append($"Author {post.Author}");
                sb.AppendLine();
                sb.Append($"with a up vote count of {post.UpVoteCount}");
                sb.AppendLine();
            }
            sb.AppendLine();
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
