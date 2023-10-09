using JH.Monitor.SubRedditOperations.Common;


namespace JH.Monitor.SubRedditOperations.Services.Interfaces
{
    public interface IOutputFactory
    {
        IOutputGenerator GetOutputGenerator(GeneratorType type);
    }
}
