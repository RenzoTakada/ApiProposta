using ApiProposta.Adapters.InterfaceAdapters;

namespace ApiProposta.Adapters.Rabbit
{
    public static class RabbitConfiguration
    {
        public static IServiceCollection  AddRabbitMqService(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
       
            var connect =  services.Configure<Settings>(configuration.GetSection("RabbitMQ"));
            services.AddScoped<IRabbitMqService, RabbitMqService>();
            return services;
        }
    }
}
