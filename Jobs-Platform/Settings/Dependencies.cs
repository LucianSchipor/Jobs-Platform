﻿
using Core.Services;
using DataLayer;
using DataLayer.Repositories;
using Jobs_Platform.Services;
using System.Data.Common;

namespace Jobs_Platform.Settings
{
    public static class Dependencies
    {

       public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            try
            {

                applicationBuilder.Services.AddControllers();
                applicationBuilder.Services.AddSwaggerGen();

                applicationBuilder.Services.AddDbContext<AppDBContext>();

                AddRepositories(applicationBuilder.Services);
                AddServices(applicationBuilder.Services);
            }
            catch(DbException c)
            {
                Console.WriteLine(c.Message);
            }
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<JobsService>();
            services.AddScoped<AccountService>();
            services.AddScoped<AuthenticationService>();
            services.AddScoped<ApplicationsService>();




        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<JobsRepository>();
            services.AddScoped<AccountRepository>();
            services.AddScoped<UnitOfWork>();
            services.AddScoped<ApplicationsRepository>();

        }
    }
}
