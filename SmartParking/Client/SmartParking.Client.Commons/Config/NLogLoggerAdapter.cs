using System;
using Microsoft.Extensions.Logging;
using NLog;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace SmartParking.Client.Commons.Config
{
    public class NLogLoggerAdapter<T>:ILogger<T>
    {
        private readonly Logger _logger;

        public NLogLoggerAdapter()
        {
            _logger = LogManager.GetLogger(typeof(T).FullName);
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            var message = formatter(state, exception);
            _logger.Log(ConvertLogLevel(logLevel), message);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _logger.IsEnabled(ConvertLogLevel(logLevel));
        }
        
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        private static NLog.LogLevel ConvertLogLevel(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Trace => NLog.LogLevel.Trace,
                LogLevel.Debug => NLog.LogLevel.Debug,
                LogLevel.Information => NLog.LogLevel.Info,
                LogLevel.Warning => NLog.LogLevel.Warn,
                LogLevel.Error => NLog.LogLevel.Error,
                LogLevel.Critical => NLog.LogLevel.Fatal,
                _ => NLog.LogLevel.Off
            };
        }
    }
}