using Microsoft.EntityFrameworkCore;
using Quote.Core.Logging;

namespace Quote.Infrastructure.Data
{
    public class LoggerContext : DbContext
    {
        public DbSet<EventLog> EventLogs { get; set; }
        public static string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
