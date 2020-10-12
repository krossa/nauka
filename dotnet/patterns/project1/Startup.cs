using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using patterns.cor;
using patterns.cor.validation;
using patterns.Cqs;
using patterns.Cqs.Requests;
using patterns.Cqs.Services;
using patterns.FluentDecorator;

namespace patterns
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddLogging();

            services.AddControllers();
            services.AddTransient<IConsoleLogger, ConsoleLogger>();

            //cqs
            services.AddTransient<IRequest<User>, GetUserQuery>();
            services.AddTransient<IRequestHandler<GetUserQuery, User>, GetUserQueryHandler>();
            services.AddSingleton<IBus>(p => new Bus(p.GetService));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //chain of responsibility
            builder.Register(c => new CarValidator(c.ResolveNamed<IVehicleValidator>("bikeValidator")))
                .Named<IVehicleValidator>("carValidator");
            builder.Register(c => new BikeValidator(c.ResolveNamed<IVehicleValidator>("boatValidator")))
                .Named<IVehicleValidator>("bikeValidator");
            builder.Register(c => new BoatValidator(c.ResolveNamed<IVehicleValidator>("noResultValidator")))
                .Named<IVehicleValidator>("boatValidator");
            builder.Register(c => new NoResultValidator())
                .Named<IVehicleValidator>("noResultValidator");

            builder.Register(c => new VehicleService(c.ResolveNamed<IVehicleValidator>("carValidator"),
            c.Resolve<ILogger<VehicleService>>()))
                .As<IVehicleService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
