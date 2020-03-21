using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingCart.Command;
using ShoppingCart.Events;
using ShoppingCart.Message;
using ShoppingCart.Repository;

namespace ShoppingCart
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<ICommandHandler, CommandHandler>();
            services.AddTransient<IEventStore, EventStore>();
            services.AddTransient<IBus, Bus>();
            services.AddSingleton<IRepository<Data.ShoppingCart>, Repository.Repository<Data.ShoppingCart>>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(options => options.MapControllers());
        }
    }
}
