using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiDemo.Services
{
    public interface ILoggingService
    {
        void LogInformation(string message, params object[] parameters);
        void LogDebug(string message, params object[] parameters);
    }
}
