using AutoMapper;
using SamuraiApp.API.DTO;
using SamuraiApp.Domain;

namespace SamuraiApp.API.Profiles
{
    public class PedangProfile : Profile
    {
        public PedangProfile()
        {
            CreateMap<Pedang, PedangDTO>();
            CreateMap<PedangCreateDTO, Pedang>();
            CreateMap<PedangUpdateDTO, Pedang>();
            CreateMap<PedangSamuraiCreateDTO, Pedang>();

        }
    }
}
