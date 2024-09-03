using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private static List<Produto> listaProdutos = new List<Produto>();
    private static int id = 0;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public void AdicionaProduto([FromBody] Produto produto)
    {
        Console.WriteLine("Adicionando produto");
        produto.Id = id++;
        Console.WriteLine(produto.Nome);
        Console.WriteLine(produto.Descricao);
        Console.WriteLine(produto.Preco);
        Console.WriteLine(produto.Quantidade);
        listaProdutos.Add(produto);
    }

    [HttpGet]
    public IEnumerable<Produto> ListarProdutos()
    {
        Console.WriteLine("Listando produtos");
        return listaProdutos;
    }

    [HttpGet("{id}")]
    public Produto ListarProdutoPorId(int id)
    {
        return  listaProdutos.FirstOrDefault(filme => filme.Id == id)!;
    } 

    [HttpPut("{id}")]
    public Produto AtualizandoProduto(int id, [FromBody] Produto produtoAtualizar) {
        var produto = listaProdutos.FirstOrDefault(produto => produto.Id == id);
        produto = produtoAtualizar;
        return produto;
    }

    [HttpDelete("{id}")]
    public List<Produto> DeletandoProduto(int id)
    {
        var produto = listaProdutos.FirstOrDefault(produto => produto.Id == id)!;
        listaProdutos.Remove(produto);
        return listaProdutos;
    }
}
