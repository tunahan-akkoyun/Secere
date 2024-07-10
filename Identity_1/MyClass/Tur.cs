using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class Tur
    {
        public int TurId { get; set; }
        public string Isim { get; set; }

        public ICollection<Cins> Cinsler { get; set; }
        public ICollection<Hayvan> Hayvanlar { get; set; }
    }
}
