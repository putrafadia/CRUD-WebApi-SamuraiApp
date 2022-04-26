using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Pedang
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Berat { get; set; }
        public int Tahun { get; set; }
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
        public List<Elemen> elemens { get; set; } = new List<Elemen>();
    }
}
