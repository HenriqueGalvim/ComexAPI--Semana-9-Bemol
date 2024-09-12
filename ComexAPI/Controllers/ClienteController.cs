using AutoMapper;
using ComexAPI.Data.Dtos.Endereco;
using ComexAPI.Data;
using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc;
using ComexAPI.Data.Dtos.Cliente;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController:ControllerBase
{
	private ProdutoContext _context;
	private IMapper _mapper;
    public ClienteController(ProdutoContext context, IMapper mapper)
    {
		_context = context;
		_mapper = mapper;
	}

	/// <summary>
	/// Adiciona um Cliente no banco de dados
	/// </summary>
	/// <param name="clienteDto">Objeto com os campos necessários para criação de um cliente</param>
	/// <returns>IActionResult</returns>
	/// <response code="201">Caso inserção seja feita com sucesso</response>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public IActionResult AdicionaCLiente([FromBody] CreateClienteDto clienteDto)
	{
		Console.WriteLine("Adicionando Cliente");
		Cliente cliente = _mapper.Map<Cliente>(clienteDto);
		_context.Clientes.Add(cliente);
		_context.SaveChanges();
		return CreatedAtAction(nameof(ListarClientePorId), new { id = cliente.Id }, cliente);
	}

	/// <summary>
	/// Lista todos os Clientes.
	/// </summary>
	/// <param name="skip">Número de clientes a serem ignorados.</param>
	/// <param name="take">Número de clientes a serem retornados.</param>
	/// <returns>Uma lista de clientes.</returns>
	/// <response code="200">Retorna uma lista de clientes.</response>
	[HttpGet]
	public IEnumerable<ReadClienteDto> ListarClientes([FromQuery] int skip = 0,
		[FromQuery] int take = 50)
	{
		return _mapper.Map<List<ReadClienteDto>>(_context.Clientes.Skip(skip).Take(take));
	}

	/// <summary>
	/// Retorna um cliente pelo seu ID.
	/// </summary>
	/// <param name="id">ID do cliente.</param>
	/// <returns>Um cliente.</returns>
	/// <response code="200">Retorna um cliente.</response>
	/// <response code="404">Cliente não encontrado.</response>
	[HttpGet("{id}")]
	public IActionResult ListarClientePorId(int id)
	{
		var cliente = _context.Clientes.FirstOrDefault(produto => produto.Id == id);

		if (cliente == null) return NotFound();

		var clienteDto = _mapper.Map<ReadClienteDto>(cliente);
		return Ok(clienteDto);
	}

	/// <summary>
	/// Atualiza um cliente existente.
	/// </summary>
	/// <param name="id">ID do cliente.</param>
	/// <param name="clienteDto">Objeto com os dados do cliente a serem atualizados.</param>
	/// <returns>IActionResult</returns>
	/// <response code="204">Cliente atualizado com sucesso.</response>
	/// <response code="404">Cliente não encontrado.</response>
	[HttpPut("{id}")]
	public ActionResult AtualizandoCliente(int id, [FromBody] UpdateClienteDto clienteDto)
	{
		var cliente = _context.Clientes.FirstOrDefault(filme => filme.Id == id)!;
		if (cliente == null) return NotFound();
		_mapper.Map(clienteDto, cliente);
		_context.SaveChanges();
		return NoContent();
	}

	/// <summary>
	/// Deleta um Cliente.
	/// </summary>
	/// <param name="id">ID do Cliente.</param>
	/// <returns>IActionResult</returns>
	/// <response code="204">Cliente deletado com sucesso.</response>
	/// <response code="404">Cliente não encontrado.</response>
	[HttpDelete("{id}")]
	public ActionResult DeletarCliente(int id)
	{
		var cliente = _context.Clientes.FirstOrDefault(endereco => endereco.Id == id)!;
		if (cliente == null) return NotFound();

		_context.Remove(cliente);
		_context.SaveChanges();
		return NoContent();
	}
}
