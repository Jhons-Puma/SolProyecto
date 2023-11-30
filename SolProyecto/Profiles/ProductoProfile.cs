using AutoMapper;
using SolProyecto.DataAccess.DBEntities;
using SolProyecto.Models;

namespace SolProyecto.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<ProductoEntity, ProductoCatalogoModel>()
            .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.id))
            .ReverseMap();
        }
    }
}
