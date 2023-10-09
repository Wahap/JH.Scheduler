using JH.Monitor.SubOperations.Models;
using JH.Monitor.SubRedditOperations.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JH.Monitor.SubRedditOperations.Services
{
    public class UserOutputGenerator : IOutputGenerator
    {
        public string GetOutput(List<RedditPost> posts)
        {

            var users = posts.GroupBy(p => p.Author)
               .Select(group => new
               {
                   Author = group.Key,
                   PostCount = group.Count()
               }).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine();

            sb.Append("Users with the most posts:");

            foreach (var user in users.OrderByDescending(u => u.PostCount).Take(5))
            {
                sb.AppendLine();
                string userInfo = $"Author :{user.Author}, Post Count: {user.PostCount}" ;
                sb.Append(userInfo);
            }

            sb.AppendLine();
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
