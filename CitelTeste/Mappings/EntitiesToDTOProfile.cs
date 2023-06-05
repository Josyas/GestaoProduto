using AutoMapper;
using CitelTeste.DTO;
using CitelTeste.Model;

namespace CitelTeste.Mappings
{
    public class EntitiesToDTOProfile : Profile
    {
        public EntitiesToDTOProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Produto, ProdutoListacadastradoDTO>().ReverseMap();
        }
    }
}
