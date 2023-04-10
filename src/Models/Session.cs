using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace MoviesAPi.Models;


public class Session
{
    [Key]
    [Required]
    public int Id { get; set; }
    public virtual Movie Movie { get; set; }
    public int MovieId { get; set; }

}