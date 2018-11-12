using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quote.Core.Interfaces;
using Quote.Infrastructure.Data;

namespace Quote.Infrastructure
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration config) => Configuration = config;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string conString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ClientDBContext>(options => options.UseSqlServer(conString));
            services.AddTransient(typeof(IClient<>), typeof(EFClientRepository<>));

            //DatabaseLogger
            LoggerContext.ConnectionString = Configuration["ConnectionStrings:LoggerDatabase"];
            services.AddDbContext<LoggerContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
       

        }
    }
}
