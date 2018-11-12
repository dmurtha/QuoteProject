using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Quote.Core.Logging;
using Quote.Infrastructure.Data;


namespace Quote.Infrastructure.LoggingRepository
{
    public class DBLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly Func<string, LogLevel, bool> _filter;
        private LoggerContext _context;
        private bool _selfException = false;

        public DBLogger(string categoryName, Func<string, LogLevel, bool> filter)
        {
            _categoryName = categoryName;
            _filter = filter;
            _context = new LoggerContext();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
            if (_selfException)
            {
                _selfException = false;
                return;
            }
            _selfException = true;
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }
            var message = formatter(state, exception);
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            if (exception != null)
            {
                message += "\n" + exception.ToString();
            }

            try
            {
                var maxMessageLength = GetMaxMessageLength();
                message = maxMessageLength != null && message.Length > maxMessageLength ? message.Substring(0, (int)maxMessageLength) : message;
                _context.EventLogs.Add(new EventLog { Message = message, EventId = eventId.Id, LogLevel = logLevel.ToString(), CreatedTime = DateTime.UtcNow });
                _context.SaveChanges();
                _selfException = false;
            }
            catch (Exception ex)
            {
                var test = ex;
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return (_filter == null || _filter(_categoryName, logLevel));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        private int? GetMaxMessageLength()
        {

            int? maxLength = null;
            PropertyInfo[] props = typeof(EventLog).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    MaxLengthAttribute maxLengthAttr = attr as MaxLengthAttribute;
                    if (maxLengthAttr != null && prop.Name.Equals("Message"))
                    {
                        maxLength = maxLengthAttr.Length;
                    }
                }
            }

            return maxLength;
        }
    }
}
