using Microsoft.Extensions.Logging;

namespace Data
{
    public static class DataLogger
    {
        public static void Configure(ILoggerFactory loggerFactory) => LoggerFactory ??= loggerFactory;

        internal static ILoggerFactory LoggerFactory { get; set; }// = new LoggerFactory();
        internal static ILogger<T> CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
        internal static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);
    }
}