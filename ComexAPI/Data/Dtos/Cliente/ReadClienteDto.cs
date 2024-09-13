using ComexAPI.Data.Dtos.Endereco;

namespace ComexAPI.Data.Dtos.Cliente;

public class ReadClienteDto
{
	public string Nome { get; set; }
	public string Email { get; set; }
	public string Profissao { get; set; }
	public string Telefone { get; set; }
	public int EnderecoId { get; set; }
	public ReadEnderecoDto ReadEnderecoDto { get; set; }
}
