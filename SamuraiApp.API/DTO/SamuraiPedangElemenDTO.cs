using SamuraiApp.Domain;

namespace SamuraiApp.API.DTO
{
    public class SamuraiPedangElemenDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PedangElemenDTO> Pedangs { get; set; }
    }
}
