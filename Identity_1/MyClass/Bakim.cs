using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class Bakim
    {
        public int BakimID { get; set; } 
        public int HayvanID { get; set; } 
        public string BakimTipi { get; set; } 
        public DateTime BakimTarihi { get; set; } 
        public DateTime SonrakiBakimTarihi { get; set; } 
        public string Notlar { get; set; } 

        
        public virtual Hayvan Hayvan { get; set; } 
    }

}
