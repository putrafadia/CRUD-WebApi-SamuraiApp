using SamuraiApp.Domain;

namespace SamuraiApp.API.DTO
{
    public class PedangElemenDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Berat { get; set; }
        public int Tahun { get; set; }
        public int SamuraiId { get; set; }
        public List<ElemenDTO> elemens { get; set; }

    }
}
