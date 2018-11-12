using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Quote.Core.Interfaces;
using Quote.Core.Services;

using Quote.Infrastructure.Logging;
using Quote.Infrastructure.Data;

using Quote.Web.Interfaces;
using Quote.Web.Service;
using AutoMapper;
using AutoMapper.Configuration;


namespace Quote.Web
{
    public class Startup
    {

        public Microsoft.Extensions.Configuration.IConfiguration Configuration;

        public Startup(Microsoft.Extensions.Configuration.IConfiguration config) => Configuration = config;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            string conString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ClientDBContext>(options => options.UseSqlServer(conString));
            services.AddTransient(typeof(IClient<>), typeof(EFClientRepository<>));
            services.AddTransient(typeof(IAsyncClient<>), typeof(EFClientRepository<>));
            services.AddTransient<IClientViewModelService, ClientViewModelServices>();
            services.AddTransient<IClientService, ClientService>();
            //DatabaseLogger
            LoggerContext.ConnectionString = Configuration["ConnectionStrings:LoggerDatabase"];
            services.AddDbContext<LoggerContext>();

            var configAuto = new AutoMapper.MapperConfiguration(cfx =>
            {
                cfx.AddProfile(new AutoMapperProfile.AutoMapperProfile());
            });
            var mapper = configAuto.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddContext(LogLevel.Trace);




            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

        }
    }
}
