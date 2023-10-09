using JH.Monitor.SubRedditOperations.Services.Interfaces;
using System;

namespace JH.Monitor.SubRedditOperations.Services
{
    public class OutputService : IOutputService
    {
        public void SendOut(string output)
        {
            Console.WriteLine(output);
        }
    }
}
