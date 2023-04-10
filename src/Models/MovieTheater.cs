using System.ComponentModel.DataAnnotations;

namespace MoviesAPi.Models;

public class MovieTheater
{
    [Key]
    [Required]
    public int Id {get; set;}

    [Required(ErrorMessage ="Nome do cinema é obrigatório !")]
    public string Name {get; set;}

    // chave estrangeira => id do endereço
    // virtual = propriedade que pode ser sobrescrita por uma classe filha
    // ou seja, ela mostra uma unicidade(o dado adress é o mesmo de um outro objeto)
    public int AdressId {get; set;}
    public virtual Adress Adress {get;set;}

}