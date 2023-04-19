using ApiProposta.Adapters.InterfaceAdapters;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;

namespace ApiProposta.Adapters.Rabbit
{
    public class RabbitMqService : IRabbitMqService
    {
        private IModel channel;
        private string queueNAME = "SolicitarCartao";
        private string exchangeName = "SolicatorProposta";
        private string routeKEY = "SolicitaCartao-key";
        public RabbitMqService(IOptions<Settings> settings)
        {
            var factory = new ConnectionFactory { Uri = new Uri($"{settings.Value.url}") };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueNAME, durable: true, exclusive: false, autoDelete: false, arguments: null);
            channel.ExchangeDeclare(exchange: exchangeName, type:"direct",durable:true,autoDelete:false,arguments: null);
            channel.QueueBind(queue: queueNAME, exchange: exchangeName, routingKey: routeKEY, arguments: null);
        }
        public async Task<bool> publicaMensagem(string message) 
        {
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: exchangeName,
                     routingKey: routeKEY,
                     basicProperties: null,
                     body: body);
            return true;
        }
    }
}
