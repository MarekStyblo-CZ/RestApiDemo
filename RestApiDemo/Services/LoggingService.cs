using Microsoft.Extensions.Logging;

namespace RestApiDemo.Services
{
    /// <summary>
    /// Helper class for logging (for deployment on prod..)
    /// </summary>
    public class LoggingService : ILoggingService
    {
        private readonly ILogger _logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message, params object[] parameters)
        {
            _logger.LogInformation(message, parameters);
        }

        public void LogDebug(string message, params object[] parameters)
        {
            _logger.LogDebug(message, parameters);
        }
    }
}
