namespace JH.Monitor.SubOperations.Models
{
    public class RedditPost
    {
        public RedditPost()
        {
        }

        public RedditPost(string title, string author, int upVoteCount)
        {
            Title = title;
            Author = author;
            UpVoteCount = upVoteCount;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public int UpVoteCount { get; set; }
    }
}
