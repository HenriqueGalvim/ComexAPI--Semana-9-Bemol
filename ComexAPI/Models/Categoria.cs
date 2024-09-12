using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Models;

public class Categoria
{
    [Required]
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; }
}
