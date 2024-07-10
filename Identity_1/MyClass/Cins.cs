using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class Cins
    {
        public int CinsId { get; set; }
        public string Isim { get; set; }

        public int TurId { get; set; }
        public Tur Tur { get; set; }
        public ICollection<Hayvan> Hayvanlar { get; set; }
    }
}
