using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ComexAPI.Models;

public class Produto
{
    public Produto(string nome, string descricao, float preco, int quantidade, int id)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Quantidade = quantidade;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public float Preco {  get; set; }
    public int Quantidade { get; set; }
}
