using MyClass;

namespace Identity_1.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Hayvan> Hayvanlar { get; set; }
        public IEnumerable<Tur> Turler { get; set; }
        public IEnumerable<Cins> Cinsler { get; set; }
    }
}
