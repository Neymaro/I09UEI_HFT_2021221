using I09UEI_HFT_2021221.Data;
using I09UEI_HFT_2021221.Logic;
using I09UEI_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace I09UEI_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TravelAgencyDbContext>(options =>
            {
                options.UseSqlServer(TravelAgencyDbContext.ConnectionString);
                options.UseLazyLoadingProxies();
            });

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<ITravelAgencyRepository, TravelAgencyRepository>();

            services.AddScoped<ICustomerLogic, CustomerLogic>();
            services.AddScoped<IPackageLogic, PackageLogic>();
            services.AddScoped<ITravelAgencyLogic, TravelAgencyLogic>();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" }));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymentGateway v1"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
