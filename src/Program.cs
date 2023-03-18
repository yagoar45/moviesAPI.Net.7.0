using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MoviesAPi.Data;


var builder = WebApplication.CreateBuilder(args);

// criando conexão com o banco
var connectionString = builder.Configuration.GetConnectionString("MovieConnection");
builder.Services.AddDbContext<MovieContext>(opts => 
opts.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

// add automapper (passa os valores do DTO para o controlador) para toda aplicação
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());        

// possibilita o uso de JSON´s parciais
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();

// documentando api no swagger com o título e a versão, define o caminho do xml e permite comentários
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "MoviesAPI", Version = "V1"});
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
