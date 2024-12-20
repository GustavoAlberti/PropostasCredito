using DigitacaoProposta.Dominio;
using DigitacaoProposta.Dominio.GravarProposta.Aplicacao;
using DigitacaoProposta.Dominio.GravarProposta.Infra;
using DigitacaoProposta.Dominio.Regras.Validacoes.Factories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GravarPropostaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<PropostasRepositorio>();
builder.Services.AddScoped<IPropostaRuleFactory, PropostaRuleFactory>();
builder.Services.AddScoped<CriarPropostaHandler>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
