using AutoMapper;
using ComexAPI.Data.Dtos.Produto;
using ComexAPI.Models;

namespace ComexAPI.Profiles;

public class ProdutoProfile : AutoMapper.Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<UpdateProdutoDto, Produto>();
        CreateMap<Produto, UpdateProdutoDto>();
        CreateMap<Produto, ReadProdutoDto>();

	}
}
