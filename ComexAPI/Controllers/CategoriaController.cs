using AutoMapper;
using ComexAPI.Data.Dtos.Cliente;
using ComexAPI.Data;
using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc;
using ComexAPI.Data.Dtos.Categoria;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
	private ProdutoContext _context;
	private IMapper _mapper;
    public CategoriaController(ProdutoContext context, IMapper mapper)
    {
		_context = context;
		_mapper = mapper;
	}

    /// <summary>
    /// Adiciona uma Categoria no banco de dados
    /// </summary>
    /// <param name="categoriaDto">Objeto com os campos necessários para criação de uma categoria</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public IActionResult AdicionaCLiente([FromBody] CreateCategoriaDto categoriaDto)
	{
		Console.WriteLine("Adicionando Categoria");
		Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
		_context.Categorias.Add(categoria);
		_context.SaveChanges();
		return CreatedAtAction(nameof(ListarCategoriaPorId), new { id = categoria.Id }, categoria);
	}

	/// <summary>
	/// Lista todos as categorias.
	/// </summary>
	/// <param name="skip">Número de categorias a serem ignorados.</param>
	/// <param name="take">Número de categorias a serem retornados.</param>
	/// <returns>Uma lista de categorias.</returns>
	/// <response code="200">Retorna uma lista de categorias.</response>
	[HttpGet]
	public IEnumerable<ReadCategoriaDto> ListarCategorias([FromQuery] int skip = 0,
		[FromQuery] int take = 50)
	{
		return _mapper.Map<List<ReadCategoriaDto>>(_context.Categorias.Skip(skip).Take(take).ToList());
	}

	/// <summary>
	/// Retorna uma categoria pelo seu ID.
	/// </summary>
	/// <param name="id">ID da categoria.</param>
	/// <returns>Uma Categoria.</returns>
	/// <response code="200">Retorna uma categoria.</response>
	/// <response code="404">Categoria não encontrado.</response>
	[HttpGet("{id}")]
	public IActionResult ListarCategoriaPorId(int id)
	{
		var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

		if (categoria == null) return NotFound();

		var categoriaDto = _mapper.Map<ReadCategoriaDto>(categoria);
		return Ok(categoriaDto);
	}

	/// <summary>
	/// Atualiza uma categoria existente.
	/// </summary>
	/// <param name="id">ID da categoria.</param>
	/// <param name="categoriaDto">Objeto com os dados da categoria a serem atualizados.</param>
	/// <returns>IActionResult</returns>
	/// <response code="204">Categoria atualizado com sucesso.</response>
	/// <response code="404">Categoria não encontrado.</response>
	[HttpPut("{id}")]
	public ActionResult AtualizandoCategoria(int id, [FromBody] UpdateCategoriaDto categoriaDto)
	{
		var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id)!;
		if (categoria == null) return NotFound();
		_mapper.Map(categoriaDto, categoria);
		_context.SaveChanges();
		return NoContent();
	}

	/// <summary>
	/// Deleta uma Categoria.
	/// </summary>
	/// <param name="id">ID da Categoria.</param>
	/// <returns>IActionResult</returns>
	/// <response code="204">Categoria deletada com sucesso.</response>
	/// <response code="404">Categoria não encontrado.</response>
	[HttpDelete("{id}")]
	public ActionResult DeletarCategoria(int id)
	{
		var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id)!;
		if (categoria == null) return NotFound();

		_context.Remove(categoria);
		_context.SaveChanges();
		return NoContent();
	}
}
