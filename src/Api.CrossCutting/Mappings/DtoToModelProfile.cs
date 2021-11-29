using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;
using Domain.Dtos.Cep;
using Domain.Dtos.Municipio;
using Domain.Dtos.Uf;
using Domain.Models;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>()
                .ReverseMap();

            CreateMap<UserModel, UserDtoCreate>()
                .ReverseMap();

            CreateMap<UserModel, UserDtoUpdate>()
                .ReverseMap();

            CreateMap<UfDto, UfModel>().ReverseMap();

            CreateMap<MunicipioDto, MunicipioModel>().ReverseMap();

            CreateMap<MunicipioDtoCompleto, MunicipioModel>().ReverseMap();

            CreateMap<MunicipioDtoCreate, MunicipioModel>().ReverseMap();

            CreateMap<MunicipioDtoUpdate, MunicipioModel>().ReverseMap();

            CreateMap<CepDto, CepModel>().ReverseMap();

            CreateMap<CepDtoCreate, CepModel>().ReverseMap();

            CreateMap<CepDtoUpdate, CepModel>().ReverseMap();
        }
    }
}