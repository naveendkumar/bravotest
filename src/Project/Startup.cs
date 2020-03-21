using BAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Project
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllersWithViews();
            //services.AddSingleton<IRandomNumber, RandomNumber>(); //Created only for the first request. 
            //services.AddScoped<IRandomNumber, RandomNumber>(); //Created once per scope. 
            services.AddTransient<IRandomNumber, RandomNumber>(); //Created every time they are requested


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}