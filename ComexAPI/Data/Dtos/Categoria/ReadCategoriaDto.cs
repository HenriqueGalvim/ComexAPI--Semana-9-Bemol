namespace ComexAPI.Data.Dtos.Categoria;
using ComexAPI.Models;
public class ReadCategoriaDto
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public virtual ICollection<Produto> Produtos { get; set; }
}
