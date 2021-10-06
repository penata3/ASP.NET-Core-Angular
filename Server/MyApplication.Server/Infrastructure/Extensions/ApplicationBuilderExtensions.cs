namespace MyApplication.Server.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Data;


    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<MyApplicationDbContext>();

            dbContext.Database.Migrate();
        }


        public static IApplicationBuilder UserCors(this IApplicationBuilder app)
            =>
                app.UseCors(options => options
                  .AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod());

        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
           =>
            app.UseSwagger()
            .UseSwaggerUI(c =>
          {
              c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
              c.RoutePrefix = string.Empty;
          });


    }

}
