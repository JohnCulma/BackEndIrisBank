using DataFileUpload.Helpers.Answers;
using IrisBanck.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataFileUpload
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.AddDbContext<AppContextIrisBank>(options => options.UseSqlServer(configuration.GetConnectionString("Pharma360")));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
            app.UseSwagger();
            app.UseSwaggerUI();
            }
        
            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode == 401)
                {
                    var response = new GeneralAnswers { title = "User", status = 401, message = "unauthorized user" };
                    await context.HttpContext.Response.WriteAsJsonAsync(response);
                }
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsApi");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
