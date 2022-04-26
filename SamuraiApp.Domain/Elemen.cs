using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Elemen
    {
        public int Id { get; set; }
        public string elemen { get; set; }
        public Pedang pedang { get; set; }
        public int pedangId { get; set; }

    }
}
