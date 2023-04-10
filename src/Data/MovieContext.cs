using Microsoft.EntityFrameworkCore;
using MoviesAPi.Models;

namespace MoviesAPi.Data;

// a herança "DbContext" garante que essa classe será responsável
// por persistir os dados
public class MovieContext : DbContext
{
    // criando construtor
    // o parâmetro é um tipo de objeto responsável por
    // manipular o banco de dados 
    // a palavra "base(opts)" é para que o construtor criado herde
    // as propriedades do construtor da classe "DbContext"
    // e inicialize o objeto
    public MovieContext(DbContextOptions<MovieContext> opts) : base(opts) { }

    // prop que irá retornar os filmes 
    public DbSet<Movie> Movies { get; set; }

    // prop que irá retornar os cinemas
    public DbSet<MovieTheater> MovieTheaters { get; set; }

    public DbSet<Adress> Adresses { get; set; }

    public DbSet<Session> Sessions { get; set; }
}
