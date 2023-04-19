using ApiProposta.Domain.CoreBusiness.ValuesObjects;
using ApiProposta.Domain.InterfacesDominio;

namespace ApiProposta.Adapters.RestAPi
{
    public static class Endpoint
    {
        public static WebApplication AddEndpoints(this WebApplication app)
        {
            app.MapPost("Proposta/solicitarCartao", SolicitarCartao);
           // app.MapPost("Proposta/alterarLimite", AlterarLimites);
            return app;
        }
        public async static Task<IResult> SolicitarCartao(Cliente request, IUSCSolicitarCartao uSCSolicitar)
        {
            await uSCSolicitar.SolicitarCartao(request);
            return Results.Ok("Solicitação Feita com sucesso");
        } 

    }
}
