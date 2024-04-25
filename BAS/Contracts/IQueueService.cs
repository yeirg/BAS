namespace BAS.Contracts;

public interface IQueueService
{
    DateTime EnqueueTask(string message);
}
