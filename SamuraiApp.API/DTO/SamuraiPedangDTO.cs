using SamuraiApp.Domain;

namespace SamuraiApp.API.DTO
{
    public class SamuraiPedangDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PedangDTO> Pedangs { get; set; }
    }
}
