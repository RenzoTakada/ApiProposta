namespace ApiProposta.Adapters.InterfaceAdapters
{
    public interface IRabbitMqService
    {
        public Task<bool> publicaMensagem(string message);
    }
}
