using Microsoft.Extensions.Logging;

namespace TiRoDev.CSharpExtensions.Common.Logging;

public interface ILoggerAdapter<TType>
{
    void Log(LogLevel logLevel, Exception? exception, string? message, object? args);
    
    void LogInformation(string? message, params object?[] args);
    
    void LogError(Exception? exception, string? message, params object?[] args);
}