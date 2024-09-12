using ComexAPI.Models;

namespace ComexAPI.Data.Dtos.Cliente;

public class CreateClienteDto
{
	public string Nome { get; set; }
	public string CPF { get; set; }
	public string Email { get; set; }
	public string Profissao { get; set; }
	public string Telefone { get; set; }
	public ComexAPI.Models.Endereco Endereco { get; set; }
}
