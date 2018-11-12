using Microsoft.Extensions.Logging;
using System;

namespace Quote.Infrastructure.Logging
{


    public static class DBLoggerExtensions
    {
        public static ILoggerFactory AddContext(this ILoggerFactory factory, Func<string, LogLevel, bool> filter = null)
        {
            factory.AddProvider(new DBLoggerProvider(filter));
            return factory;
        }

        public static ILoggerFactory AddContext(this ILoggerFactory factory, LogLevel minLevel)
        {
            return AddContext(
                factory,
                (_, logLevel) => logLevel >= minLevel);
        }
    }



}
