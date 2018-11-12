using System;
using Quote.Core.Entities;

namespace Quote.Core.Logging
{
    public class EventLog : BaseEntity
    {
        public string Message { get; set; }
        public int EventId { get; set; }
        public string LogLevel { get; set; }  
        public DateTime CreatedTime { get; set; }
    }
}
