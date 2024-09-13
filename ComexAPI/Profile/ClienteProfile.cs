using AutoMapper;
using ComexAPI.Data.Dtos.Cliente;
using ComexAPI.Models;

namespace ComexAPI.Profile;

public class ClienteProfile : AutoMapper.Profile
{
	public ClienteProfile()
	{

		CreateMap<CreateClienteDto, Cliente>();
		CreateMap<UpdateClienteDto, Cliente>();
		CreateMap<Cliente, UpdateClienteDto>();
		CreateMap<Cliente, ReadClienteDto>()
			.ForMember(clienteDto => clienteDto.ReadEnderecoDto,
			opt => opt.MapFrom(cliente => cliente.Endereco));
	}
}
