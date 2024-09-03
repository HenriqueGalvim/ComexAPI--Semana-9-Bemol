using ComexAPI.Data;
using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private ProdutoContext _context;
    public ProdutoController(ProdutoContext context)
    {
        _context = context;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaProduto([FromBody] Produto produto)
    {
        Console.WriteLine("Adicionando produto");
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarProdutoPorId),new { id = produto.Id },produto);
    }

    [HttpGet]
    public IEnumerable<Produto> ListarProdutos([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _context.Produtos.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult ListarProdutoPorId(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);

        if (produto == null) return NotFound();
        return Ok(produto);
    }

/*    [HttpPut("{id}")]
    public Produto AtualizandoProduto(int id, [FromBody] Produto produtoAtualizar) {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        produto = produtoAtualizar;
        return produto;
    }

    [HttpDelete("{id}")]
    public List<Produto> DeletandoProduto(int id)
    {
        var produto = listaProdutos.FirstOrDefault(produto => produto.Id == id)!;
        listaProdutos.Remove(produto);
        return listaProdutos;
    }*/
}
