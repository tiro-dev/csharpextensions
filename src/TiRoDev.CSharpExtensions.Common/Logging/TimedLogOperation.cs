using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace TiRoDev.CSharpExtensions.Common.Logging;

public class TimedLogOperation<T> : IDisposable
{
    private readonly ILoggerAdapter<T> _logger;
    private readonly LogLevel _logLevel;
    private readonly string _message;
    private readonly object?[] _args;
    private readonly Stopwatch _stopwatch;

    public TimedLogOperation(
        ILoggerAdapter<T> logger, 
        LogLevel logLevel, 
        string message, 
        object?[] args)
    {
        _logger = logger;
        _logLevel = logLevel;
        _message = message;
        _args = args;
        _stopwatch = Stopwatch.StartNew();
    }

    public void Dispose()
    {
        _stopwatch.Stop();
        _logger.Log(
            _logLevel, 
            default, 
            $"{_message} - Elapsed time: {_stopwatch.Elapsed}", 
            _args);
    }
}