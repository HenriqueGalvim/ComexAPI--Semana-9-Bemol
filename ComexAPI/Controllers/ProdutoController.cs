using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Data.Dtos;
using ComexAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private ProdutoContext _context;
    private IMapper _mapper;
    public ProdutoController(ProdutoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Adiciona um produto no banco de dados
    /// </summary>
    /// <param name="produtoDto">Objeto com os campos necessários para criação de um produto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaProduto([FromBody] CreateProdutoDto produtoDto)
    {
        Console.WriteLine("Adicionando produto");
        Produto produto = _mapper.Map<Produto>(produtoDto);
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarProdutoPorId),new { id = produto.Id },produto);
    }

    /// <summary>
    /// Lista todos os produtos.
    /// </summary>
    /// <param name="skip">Número de produtos a serem ignorados.</param>
    /// <param name="take">Número de produtos a serem retornados.</param>
    /// <returns>Uma lista de produtos.</returns>
    /// <response code="200">Retorna uma lista de produtos.</response>
    [HttpGet]
    public IEnumerable<ReadProdutoDto> ListarProdutos([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadProdutoDto>>(_context.Produtos.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retorna um produto pelo seu ID.
    /// </summary>
    /// <param name="id">ID do produto.</param>
    /// <returns>Um produto.</returns>
    /// <response code="200">Retorna um produto.</response>
    /// <response code="404">Produto não encontrado.</response>
    [HttpGet("{id}")]
    public IActionResult ListarProdutoPorId(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);

        if (produto == null) return NotFound();

        var produtoDto = _mapper.Map<ReadProdutoDto>(produto);
        return Ok(produtoDto);
    }

    /// <summary>
    /// Atualiza um produto existente.
    /// </summary>
    /// <param name="id">ID do produto.</param>
    /// <param name="produtoDto">Objeto com os dados do produto a serem atualizados.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Produto atualizado com sucesso.</response>
    /// <response code="404">Produto não encontrado.</response>
    [HttpPut("{id}")]
    public ActionResult AtualizandoProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
    {
        var produto = _context.Produtos.FirstOrDefault(filme => filme.Id == id)!;
        if (produto == null) return NotFound();
        _mapper.Map(produtoDto, produto);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Atualiza parcialmente um produto existente.
    /// </summary>
    /// <param name="id">ID do produto.</param>
    /// <param name="patch">Objeto com as alterações a serem aplicadas no produto.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Produto atualizado com sucesso.</response>
    /// <response code="400">Erro de validação.</response>
    /// <response code="404">Produto não encontrado.</response>
    [HttpPatch("{id}")]
    public ActionResult AtualizandoprodutoParcial(int id, JsonPatchDocument<UpdateProdutoDto> patch)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id)!;
        if (produto == null) return NotFound();
        var produtoParaAtualizar = _mapper.Map<UpdateProdutoDto>(produto);
        patch.ApplyTo(produtoParaAtualizar, ModelState);

        if (!TryValidateModel(produtoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(produtoParaAtualizar, produto);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um produto.
    /// </summary>
    /// <param name="id">ID do produto.</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Produto deletado com sucesso.</response>
    /// <response code="404">Produto não encontrado.</response>
    [HttpDelete("{id}")]
    public ActionResult DeletarFilme(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id)!;
        if (produto == null) return NotFound();

        _context.Remove(produto);
        _context.SaveChanges();
        return NoContent();
    }
}
