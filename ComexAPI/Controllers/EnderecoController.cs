using AutoMapper;
using ComexAPI.Data.Dtos.Produto;
using ComexAPI.Data;
using ComexAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ComexAPI.Data.Dtos.Endereco;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
	private ProdutoContext _context;
	private IMapper _mapper;
    public EnderecoController(ProdutoContext context, IMapper mapper)
    {
		_context = context;
		_mapper = mapper;
	}

	/// <summary>
	/// Adiciona um endereço no banco de dados
	/// </summary>
	/// <param name="enderecoDto">Objeto com os campos necessários para criação de um endereço</param>
	/// <returns>IActionResult</returns>
	/// <response code="201">Caso inserção seja feita com sucesso</response>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
	{
		Console.WriteLine("Adicionando Endereço");
		Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
		_context.Enderecos.Add(endereco);
		_context.SaveChanges();
		return CreatedAtAction(nameof(ListarEnderecoPorId), new { id = endereco.Id }, endereco);
	}

	/// <summary>
	/// Lista todos os endereços.
	/// </summary>
	/// <param name="skip">Número de endereços a serem ignorados.</param>
	/// <param name="take">Número de endereços a serem retornados.</param>
	/// <returns>Uma lista de endereçoss.</returns>
	/// <response code="200">Retorna uma lista de endereços.</response>
	[HttpGet]
	public IEnumerable<ReadEnderecoDto> ListarEnderecos([FromQuery] int skip = 0,
		[FromQuery] int take = 50)
	{
		return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take));
	}

	/// <summary>
	/// Retorna um endereço pelo seu ID.
	/// </summary>
	/// <param name="id">ID do endereço.</param>
	/// <returns>Um produto.</returns>
	/// <response code="200">Retorna um endereço.</response>
	/// <response code="404">Endereço não encontrado.</response>
	[HttpGet("{id}")]
	public IActionResult ListarEnderecoPorId(int id)
	{
		var endereco = _context.Enderecos.FirstOrDefault(produto => produto.Id == id);

		if (endereco == null) return NotFound();

		var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
		return Ok(enderecoDto);
	}

	/// <summary>
	/// Atualiza um endereço existente.
	/// </summary>
	/// <param name="id">ID do endereço.</param>
	/// <param name="enderecoDto">Objeto com os dados do endereço a serem atualizados.</param>
	/// <returns>IActionResult</returns>
	/// <response code="204">Endereço atualizado com sucesso.</response>
	/// <response code="404">Endereço não encontrado.</response>
	[HttpPut("{id}")]
	public ActionResult AtualizandoEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
	{
		var endereco = _context.Enderecos.FirstOrDefault(filme => filme.Id == id)!;
		if (endereco == null) return NotFound();
		_mapper.Map(enderecoDto, endereco);
		_context.SaveChanges();
		return NoContent();
	}

	/// <summary>
	/// Deleta um Endreço.
	/// </summary>
	/// <param name="id">ID do Endreço.</param>
	/// <returns>IActionResult</returns>
	/// <response code="204">Endereço deletado com sucesso.</response>
	/// <response code="404">Endereço não encontrado.</response>
	[HttpDelete("{id}")]
	public ActionResult DeletarEndereco(int id)
	{
		var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id)!;
		if (endereco == null) return NotFound();

		_context.Remove(endereco);
		_context.SaveChanges();
		return NoContent();
	}
}
