namespace ComexAPI.Data.Dtos.Categoria;

public class ReadCategoriaDto
{
	public int Id { get; set; }
	public string Nome { get; set; }
	public virtual ICollection<Models.Produto> Produtos { get; set; }
}
