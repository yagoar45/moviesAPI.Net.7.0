using Microsoft.EntityFrameworkCore;
using MoviesAPi.Data;


var builder = WebApplication.CreateBuilder(args);

// criando conexão com o banco
var connectionString = builder.Configuration.GetConnectionString("MovieConnection");
builder.Services.AddDbContext<MovieContext>(opts => 
opts.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

// add automapper (passa os valores do DTO para o controlador) para toda aplicação
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());        


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
