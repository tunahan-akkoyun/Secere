using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class Asi
    {
        public int AsiID { get; set; } 
        public int HayvanID { get; set; } 
        public string AsiAdi { get; set; } 
        public DateTime AsiTarihi { get; set; } 
        public DateTime? SonrakiAsiTarihi { get; set; } 
        public string Notlar { get; set; } 
        public virtual Hayvan Hayvan { get; set; } 
    }

}
