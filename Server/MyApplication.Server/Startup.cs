namespace MyApplication.Server
{

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Builder;
    using System.Text;
    using MyApplication.Server.Infrastructure;
    using MyApplication.Server.Features.Identity;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services
                .AddDatabase(this.Configuration)
                .AddIdentity()
                .AddJwtAuthentication(services.GetApplicationSettings(this.Configuration))
                .AddApplicationServices()
                .AddControllers();
                               
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app)
        {

                app
                .UseDeveloperExceptionPage().UseRouting()
                .UserCors()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                 {
                    endpoints.MapControllers();
                 })
                .ApplyMigrations();
        }
    }
}
