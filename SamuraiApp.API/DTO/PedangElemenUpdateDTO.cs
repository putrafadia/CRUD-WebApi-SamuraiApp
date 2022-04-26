using SamuraiApp.Domain;

namespace SamuraiApp.API.DTO
{
    public class PedangElemenUpdateDTO
    {
        public string Name { get; set; }
        public int Berat { get; set; }
        public int Tahun { get; set; }
        public List<ElemenUpdateDTO> elemens { get; set; }

    }
}
