namespace ComexAPI.Models;

public class Endereco
{
	public Endereco(string bairro, string cidade, string complemento, string estado, string rua, string numero)
	{
		Bairro = bairro;
		Cidade = cidade;
		Complemento = complemento;
		Estado = estado;
		Rua = rua;
		Numero = numero;
	}

	public string Bairro { get; set; }
	public string Cidade { get; set; }
	public string Complemento { get; set; }
	public string Estado { get; set; }
	public string Rua {  get; set; }
	public string Numero{ get; set; }
}
