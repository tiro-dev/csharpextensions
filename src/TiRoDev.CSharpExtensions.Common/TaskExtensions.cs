namespace TiRoDev.CSharpExtensions.Common;

public static class TaskExtensions
{
    public static void FireAndForget(
        this Task task, 
        TaskContinuationOptions taskContinuationOptions,
        Action<Task> taskHandler) =>
        task.ContinueWith(taskHandler, taskContinuationOptions);

    public static void FireAndForget(
        this Task task, 
        Action<Exception>? errorHandler = default) =>
        FireAndForget(task, TaskContinuationOptions.OnlyOnFaulted, taskHandler => 
            errorHandler?.Invoke(taskHandler.Exception!));

    public static async Task WithTimeout(
        this Task task, 
        TimeSpan timeout, 
        CancellationToken cancellationToken = default)
    {
        var delayTask = Task.Delay(timeout, cancellationToken);
        var completedTask = await Task.WhenAny(task, delayTask).ConfigureAwait(false);
        
        if (completedTask == delayTask)
            throw new TimeoutException();

        await task;
    }
    
    public static async Task<TResult> Fallback<TResult>(this Task<TResult> task, TResult fallbackValue)
    {
        try
        {
            return await task.ConfigureAwait(false);
        }
        catch
        {
            return fallbackValue;
        }
    }
}