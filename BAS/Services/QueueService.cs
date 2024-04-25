using BAS.Contracts;

namespace BAS.Services;

public sealed class QueueService(Random random) : IQueueService
{
    private readonly object _lock = new object();
    private const string FILE_PATH = "TASK.txt"; // get from Options, bad approach here

    public DateTime EnqueueTask(string message)
    {
        var logEntry = $"{DateTime.UtcNow:o} | {DateTime.UtcNow:o} | {message}";
        DateTime result;
        lock (_lock)
        {
            // Logger from Microsoft is a good idea
            using var writer = new StreamWriter(FILE_PATH, true);
            result = DateTime.UtcNow;
            writer.WriteLine(logEntry);
        }
        Task.Delay(random.Next(50, 100)).Wait();
        
        return result;
    }
}