using AutoMapper;
using SamuraiApp.API.DTO;
using SamuraiApp.Domain;

namespace SamuraiApp.API.Profiles
{
    public class SamuraisProfile : Profile
    {
        public SamuraisProfile()
        {
            CreateMap<Samurai, SamuraiDTO>();
            CreateMap<Samurai, SamuraiPedangDTO>();
            CreateMap<Samurai, SamuraiPedangElemenDTO>();
            CreateMap<SamuraiCreateDTO, Samurai>();
            CreateMap<SamuraiPedangCreateDTO, Samurai>();
            CreateMap<Samurai, BattleSamuraiDTO>();
            CreateMap<Battle, BattleDTO>();

        }
    }
}
