using Microsoft.Extensions.Logging;

namespace TiRoDev.CSharpExtensions.Common.Logging;

public class LoggerAdapter<TType> : ILoggerAdapter<TType>
{
    private readonly ILogger<TType> _logger;

    public LoggerAdapter(ILogger<TType> logger) 
        => _logger = logger;

    public void Log(LogLevel logLevel, Exception? exception, string? message, object? args) => 
        _logger.Log(logLevel, exception, message, args);

    public void LogInformation(string? message, params object?[] args) => 
        _logger.LogInformation(message, args);

    public void LogError(Exception? exception, string? message, params object?[] args) => 
        _logger.LogError(exception, message, args);
}