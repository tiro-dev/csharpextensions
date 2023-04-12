using Microsoft.Extensions.Logging;

namespace TiRoDev.CSharpExtensions.Common.Logging;

public static class LoggerExtensions
{
    public static IDisposable TimedLogOperation<T>(
        this ILoggerAdapter<T> logger, 
        LogLevel logLevel = LogLevel.Information, 
        string message = nameof(T), 
        params object?[] args) =>
        new TimedLogOperation<T>(logger, logLevel, message, args);
}