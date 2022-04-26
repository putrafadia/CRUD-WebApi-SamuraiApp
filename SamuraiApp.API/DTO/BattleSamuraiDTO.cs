using SamuraiApp.Domain;

namespace SamuraiApp.API.DTO
{
    public class BattleSamuraiDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BattleDTO> battles { get; set; }
    }
}
