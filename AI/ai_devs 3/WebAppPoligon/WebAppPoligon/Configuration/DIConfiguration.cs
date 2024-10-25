using WebAppPoligon.Handlers;
using WebAppPoligon.Services;
using WebAppPoligon.Services.Interfaces;

namespace WebAppPoligon.Configuration
{
    public static class DIConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<HttpClientLoggingHandler>();
            services.AddHttpClient<PoligonClient>(client =>
            {
                client.BaseAddress = new Uri("https://poligon.aidevs.pl");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            }).AddHttpMessageHandler<HttpClientLoggingHandler>();
            services.AddTransient<IPoligonService, PoligonService>();

            return services;
        }
    }
}
