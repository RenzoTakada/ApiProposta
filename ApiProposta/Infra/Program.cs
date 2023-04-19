using ApiProposta.Adapters.Rabbit;
using ApiProposta.Adapters.RestAPi;
using ApiProposta.Domain.InterfacesDominio;
using ApiProposta.Domain.UseCases;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUSCSolicitarCartao, USCSolicitarCartao>();
builder.Services.AddRabbitMqService();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.AddEndpoints();
//app.UseAuthorization();



app.Run();
