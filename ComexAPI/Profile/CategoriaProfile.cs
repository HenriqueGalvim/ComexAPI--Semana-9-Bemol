using AutoMapper;
using ComexAPI.Data.Dtos.Categoria;
using ComexAPI.Models;

namespace ComexAPI.Profile;

public class CategoriaProfile : AutoMapper.Profile
{
    public CategoriaProfile()
    {
		CreateMap<CreateCategoriaDto, Categoria>();
		CreateMap<UpdateCategoriaDto, Categoria>();
		CreateMap<Categoria, UpdateCategoriaDto>();
		CreateMap<Categoria, ReadCategoriaDto>();
	}
}
