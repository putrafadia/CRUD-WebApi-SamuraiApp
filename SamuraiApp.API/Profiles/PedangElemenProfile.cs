using AutoMapper;
using SamuraiApp.API.DTO;
using SamuraiApp.Domain;

namespace SamuraiApp.API.Profiles
{
    public class PedangElemenProfile : Profile
    {
        public PedangElemenProfile()
        {
            CreateMap<Pedang, PedangElemenDTO>();
            CreateMap<Elemen, ElemenDTO>();
            CreateMap<ElemenUpdateDTO, Elemen>();
            CreateMap<ElemenCreateDTO, Elemen>();
            //CreateMap<Elemen, ElemenCreateDTO>();
            CreateMap<PedangElemenCreateDTO, Pedang>();
            CreateMap<PedangElemenUpdateDTO, Pedang>();
        }
    }
}
