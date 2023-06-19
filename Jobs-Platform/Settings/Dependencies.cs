
using DataLayer;
using DataLayer.Repositories;
using Jobs_Platform.Services;

namespace Jobs_Platform.Settings
{
        public static class Dependencies
        {

            public static void Inject(WebApplicationBuilder applicationBuilder)
            {
                applicationBuilder.Services.AddControllers();
                applicationBuilder.Services.AddSwaggerGen();

                applicationBuilder.Services.AddDbContext<AppDBContext>();

                AddRepositories(applicationBuilder.Services);
                AddServices(applicationBuilder.Services);
            }

            private static void AddServices(IServiceCollection services)
            {
                services.AddScoped<JobsService>();
            }

            private static void AddRepositories(IServiceCollection services)
            {
                services.AddScoped<JobsRepository>();
                services.AddScoped<UnitOfWork>();
            }
    }
}
