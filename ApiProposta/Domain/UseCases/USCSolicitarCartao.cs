using ApiProposta.Adapters.InterfaceAdapters;
using ApiProposta.Domain.CoreBusiness.ValuesObjects;
using ApiProposta.Domain.InterfacesDominio;
using System.Text.Json;

namespace ApiProposta.Domain.UseCases
{
    public class USCSolicitarCartao : IUSCSolicitarCartao
    {
        private readonly IRabbitMqService _rabbitMqService;
        public USCSolicitarCartao(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }
        public async Task<bool> SolicitarCartao(Cliente request) 
        {

            var envioRabbit = _rabbitMqService.publicaMensagem(JsonSerializer.Serialize(request));
            return true;
        }
    }
}
