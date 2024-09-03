using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ComexAPI.Models;

public class Produto
{
    public Produto(string nome, string descricao, float preco, int quantidade)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Quantidade = quantidade;
    }

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public float Preco {  get; set; }
    public int Quantidade { get; set; }
}
