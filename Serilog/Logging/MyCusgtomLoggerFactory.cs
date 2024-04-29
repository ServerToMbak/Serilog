namespace Serilogg.Logging
{
    public class MyCusgtomLoggerFactory : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new MyCustomLogger();
        }

        public void Dispose()
        {

        }
    }

    public class MyCustomLogger : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string logmsg = formatter(state, exception);
            logmsg = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] - {logmsg}";
            

            Console.WriteLine(logmsg);
        }
    }
}
