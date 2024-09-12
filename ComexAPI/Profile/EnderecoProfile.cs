using ComexAPI.Data.Dtos.Endereco;
using ComexAPI.Models;

namespace ComexAPI.Profile;

public class EnderecoProfile: AutoMapper.Profile
{
    public EnderecoProfile()
    {
		CreateMap<CreateEnderecoDto, Endereco>();
		CreateMap<UpdateEnderecoDto, Endereco>();
		CreateMap<Endereco, UpdateEnderecoDto>();
		CreateMap<Endereco, ReadEnderecoDto>();
	}
}
