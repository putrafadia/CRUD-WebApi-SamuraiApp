using SamuraiApp.Domain;

namespace SamuraiApp.API.DTO
{
    public class PedangElemenCreateDTO
    {
        public string Name { get; set; }
        public int Berat { get; set; }
        public int Tahun { get; set; }
        public int SamuraiId { get; set; }
        public List<ElemenCreateDTO> elemens { get; set; }

    }
}
