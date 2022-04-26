using SamuraiApp.Domain;

namespace SamuraiApp.API.DTO
{
    public class SamuraiPedangCreateDTO
    {
        public string Name { get; set; }
        public List<PedangSamuraiCreateDTO> Pedangs { get; set; }
    }
}
