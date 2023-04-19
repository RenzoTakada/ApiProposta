using ApiProposta.Domain.CoreBusiness.ValuesObjects;

namespace ApiProposta.Domain.InterfacesDominio
{
    public interface IUSCSolicitarCartao
    {
        public Task<bool> SolicitarCartao(Cliente request);
    }
}
