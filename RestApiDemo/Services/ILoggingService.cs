namespace RestApiDemo.Services
{
    public interface ILoggingService
    {
        void LogInformation(string message, params object[] parameters);
        void LogDebug(string message, params object[] parameters);
    }
}
