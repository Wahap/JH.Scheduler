using JH.Monitor.SubRedditOperations.Common;

namespace JH.Monitor.SubRedditOperations.Services.Interfaces
{
    internal class OutputFactory : IOutputFactory
    {
        public IOutputGenerator GetOutputGenerator(GeneratorType type)
        {
            return type switch
            {
                GeneratorType.PostGenerator => new PostOutputGenerator(),
                GeneratorType.UserGenerator => new UserOutputGenerator(),
                _ => new PostOutputGenerator()
            };
        }
    }
}
